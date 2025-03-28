"""
strategy.py

This module contains the Strategy class responsible for:
 - Tracking the known state of the enemy board.
 - Deciding which (x, y) cell to attack next.
 - Registering the result of each attack (hit/miss, sunk).
 - Keeping track of remaining enemy ships in a ships_dict.
"""

import random

class GameOver(Exception):
    """Custom exception for game over"""
    pass

class Strategy:
    def __init__(self, rows: int, cols: int, ships_dict: dict[int, int]):
        """
        Initializes the game strategy with enemy board dimensions and ship configuration.
        
        Parameters:
        rows (int): Number of rows in enemy board
        cols (int): Number of columns in enemy board
        ships_dict (dict): Dictionary mapping ship IDs to their quantities
        """
        # Store board dimensions
        self.rows = rows
        self.cols = cols
        
        # Initialize tracking variables
        self.ships_dict = ships_dict.copy()
        self.attacked = set()
        self.enemy_board = [['?' for _ in range(cols)] for _ in range(rows)]
        self.probability_map = [[1.0 for _ in range(cols)] for _ in range(rows)]
        
        # Define ship metadata including size and shape
        self.ship_metadata = {
            1: 2, 2: 3, 3: 4, 4: 4, 5: 4, 6: 4, 7: 6  # ID: size
        }
        
        # Copy of remaining ships for tracking purposes
        self.ships_remaining = ships_dict.copy()

        self.ship_shapes = {
            1: {"type": "I", "size": 2},   # I (2)
            2: {"type": "I", "size": 3},   # I (3)
            3: {"type": "I", "size": 4},   # I (4)
            4: {"type": "T", "size": 4},   # T (3+1)
            5: {"type": "L", "size": 3},   # L (3x2)
            6: {"type": "Z", "size": 4},   # Z (2x3)
            7: {"type": "TT", "size": 6}   # TT (4+2)
        }

        self.current_target = None  # Current ship being targeted

        self.remaining_ships = sorted(ships_dict.keys(), key=lambda x: self.ship_metadata[x], reverse=True)

        self.ship_hits = {}  # Dictionary to store hits for each ship
        self.current_ship_hits = set()  # Set to store hits for the current ship
        self.prediction_mode = False
    
        # Define all T shape rotations
        self.t_shapes = [
            {(1,0), (0,1), (1,1), (2,1)},  
            {(1,0), (1,1), (1,2), (0,1)},  
            {(1,0), (0,1), (1,1), (2,1)},  
            {(1,0), (1,1), (1,2), (2,1)},
            {(1,0), (1,1), (2,0), (0,0)},
            {(0,1), (0,2), (0,0), (1,1)}   
        ]

        # Define all Z shape rotations
        self.z_shapes = [
            {(1, 0), (1, 1), (2, 1), (0, 0)},
            {(0, 1), (1, 0), (1, 1), (0, 2)},
            {(0, 1), (1, 0), (1, 1), (2, 0)},
            {(0, 1), (1, 1), (1, 2), (0, 0)},
        ]

        # Define all L shape rotations
        self.l_shapes = [
            {(1, 0), (1, 1), (1, 2), (0, 0)},
            {(1, 0), (2, 0), (0, 0), (0, 1)},
            {(0, 1), (1, 1), (2, 0), (2, 1)},
            {(1, 0), (2, 0), (2, 1), (0, 0)},
            {(0, 1), (0, 2), (1, 2), (0, 0)},
            {(0, 1), (1, 1), (2, 1), (0, 0)},
            {(0, 1), (1, 0), (0, 2), (0, 0)},
            {(1, 0), (0, 2), (1, 2), (1, 1)}
        ]

        self.move = 1  # Initialize move counter (starting with 1, odd numbers only)

    def get_next_attack(self) -> tuple[int, int]:
        """Selects the best attack position based on the probability map"""
        if not self.current_target:
            candidates = [(x, y) for y in range(self.rows)
                         for x in range(self.cols)
                         if self.probability_map[y][x] != 'X' and
                         self.probability_map[y][x] > 0 and
                         (x, y) not in self.attacked and
                         (x + y) % 2 == 0]
        else:
            candidates = [(x, y) for y in range(self.rows)
                         for x in range(self.cols)
                         if self.probability_map[y][x] != 'X' and
                         self.probability_map[y][x] > 0 and
                         (x, y) not in self.attacked]
        
        # Find the maximum probability among candidates
        max_prob = max(self.probability_map[y][x] for x, y in candidates)
        
        # Filter candidates with the maximum probability
        candidates = [(x, y) for x, y in candidates if self.probability_map[y][x] == max_prob]
        
        # Return a random candidate if there are multiple
        return random.choice(candidates)
        print(candidates)
        input_str = input("Enter coordinates in the format 'x y': ")
        x, y = map(int, input_str.strip().split())
                
        # Check if the coordinates are valid and not already attacked
        if 0 <= x < self.cols and 0 <= y < self.rows:
            if (x, y) not in self.attacked:
                return (x, y)
            else:
                print("This position has already been attacked. Try again.")
        else:
            print("Invalid coordinates. Try again.")



    def register_attack(self, x: int, y: int, is_hit: bool, is_sunk: bool):
        """Updates strategy state based on attack result"""
        self.attacked.add((x, y))
        self.enemy_board[y][x] = 'H' if is_hit else 'M'
        
        # Mark the attacked position as 'X' in the probability map
        self.probability_map[y][x] = 'X'  # Set to 'X' regardless of hit or miss
        
        if is_hit:
            self.current_ship_hits.add((x, y))            
            self._update_probabilities_after_hit(x, y)
            self.prediction_mode = True
            
            if not self.current_target:
                self.current_target = (x, y)  # Set current target on first hit
            
            if is_sunk:
                self._update_ship_count()
                self._mark_invalid_positions_around_sunk_ship(x, y)
                self.current_target = None  # Clear target after sinking
                self.current_ship_hits = set()  # Reset hits for the current ship
                self.prediction_mode = False
        else:
            self.probability_map[y][x] = 'X'

        if self.prediction_mode:
            self._update_probabilities(x, y)
        self._mark_invalid_positions();
        # Log the probability map after every attack
        self._log_probability_map()

    def _mark_invalid_positions(self):
        """Marks positions as invalid if all their neighbors are misses or 0.0"""
        for y in range(self.rows):
            for x in range(self.cols):
                if self.probability_map[y][x] == 'X' or self.probability_map[y][x] == 0.0:
                    continue
                
                invalid_neighbors = 0
                for dx, dy in [(-1, 0), (1, 0), (0, -1), (0, 1)]:
                    nx, ny = x + dx, y + dy
                    if 0 <= nx < self.cols and 0 <= ny < self.rows:
                        if (self.probability_map[ny][nx] == 'X' and self.enemy_board[ny][nx] == 'M') or self.probability_map[ny][nx] == 0.0:
                            invalid_neighbors += 1
                    else:
                        invalid_neighbors += 1
                
                if invalid_neighbors == 4:
                    self.probability_map[y][x] = 0.0

    def _identify_ship(self):
        """Identifies the ship shape based on hits"""
        if not self.current_ship_hits:
            return
        
        # Use the current ship hits for identification
        hits = self.current_ship_hits
        
        # Find the minimal bounding box
        min_x = min(h[0] for h in hits)
        max_x = max(h[0] for h in hits)
        min_y = min(h[1] for h in hits)
        max_y = max(h[1] for h in hits)
        
        # Calculate width, height, and size
        width = max_x - min_x + 1
        height = max_y - min_y + 1
        size = len(hits)
       
        # Identify ship based on width, height, and size
        if size == 2 and (width == 2 or height == 2):
            self.current_ship_id = 1  # I (2)
            ship_shape = "I"
        elif size == 3 and (width == 3 or height == 3):
            self.current_ship_id = 2  # I (3)
            ship_shape = "I"
        elif size == 4 and (width == 4 or height == 4):
            self.current_ship_id = 3  # I (4)
            ship_shape = "I"
        elif size == 4 and (width == 3 and height == 2) or (width == 2 and height == 3):
            # Normalize hits to start from (0, 0)
            normalized_hits = {(h[0] - min_x, h[1] - min_y) for h in hits}

            # Check for T shape
            if normalized_hits in self.t_shapes:
                self.current_ship_id = 4  # T (3+1)
                ship_shape = "T"
            # Check for Z shape
            elif normalized_hits in self.z_shapes: 
                self.current_ship_id = 6  # Z (2x3)
                ship_shape = "Z"
            elif normalized_hits in self.l_shapes:
                self.current_ship_id = 5  # L (3x2)
                ship_shape = "L"
            else:
                return
        elif size == 6 and (width >= 4 or height >= 4):
            self.current_ship_id = 7  # TT (4+2)
            ship_shape = "TT"
        else:
            # Fallback logic for unknown shapes
            print("No matching ship found.")  # Debugging
            return
        return self.current_ship_id

    def _update_probabilities_after_hit(self, x: int, y: int):
        """Updates probabilities based on possible ship placements after hit"""
        # Increase probabilities of neighboring cells by +10, but not the hit cell itself
        for dx, dy in [(-1, 0), (1, 0), (0, -1), (0, 1)]:
            nx, ny = x + dx, y + dy
            if 0 <= nx < self.cols and 0 <= ny < self.rows:
                # Check if the cell is not marked as 'X' and is a number
                if isinstance(self.probability_map[ny][nx], (int, float)):
                    if self.probability_map[ny][nx] != 0.0 and self.probability_map[ny][nx] < 10.0:
                        self.probability_map[ny][nx] = min(100, self.probability_map[ny][nx] + 10)


    def _update_ship_count(self):
        """Detects ship size and updates counts"""
        ship_id = self._identify_ship()
        if self.ships_remaining.get(ship_id, 0) > 0:
                self.ships_remaining[ship_id] -= 1

    def get_enemy_board(self) -> list[list[str]]:
        """Required by tests - returns a copy of the game board"""
        return [row.copy() for row in self.enemy_board]

    def get_remaining_ships(self) -> dict[int, int]:
        """Required by tests - returns remaining ships"""
        return self.ships_remaining.copy()

    def all_ships_sunk(self) -> bool:
        """Required by tests - checks ship status"""
        return sum(self.ships_remaining.values()) == 0

    def _find_ship_cells(self, x: int, y: int) -> list:
        """Finds all cells of a sunk ship using BFS"""
        visited = set()
        queue = [(x, y)]
        ship_cells = []
        
        while queue:
            cx, cy = queue.pop(0)
            if (cx, cy) in visited:
                continue
            visited.add((cx, cy))
            
            if self.enemy_board[cy][cx] == 'H':
                ship_cells.append((cx, cy))
                # Check all four directions
                for dx, dy in [(-1,0), (1,0), (0,-1), (0,1)]:
                    nx, ny = cx + dx, cy + dy
                    if 0 <= nx < self.cols and 0 <= ny < self.rows:
                        queue.append((nx, ny))
        return ship_cells

    def _mark_invalid_positions_around_sunk_ship(self, x: int, y: int):
        """Marks positions around a sunk ship as invalid"""
        # Find all cells of the sunk ship
        ship_cells = self._find_ship_cells(x, y)
        
        # Mark surrounding area (horizontal and vertical neighbors) as invalid
        for cx, cy in ship_cells:
            for dx, dy in [(-1,0), (1,0), (0,-1), (0,1)]:
                nx, ny = cx + dx, cy + dy
                if 0 <= nx < self.cols and 0 <= ny < self.rows:
                    if self.probability_map[ny][nx] != 'X':  # Ignore already attacked positions
                        self.probability_map[ny][nx] = 0  # Mark as invalid

    def _log_probability_map(self):
        """Logs the probability map to a file"""
        # Open the file in 'w' mode to clear it on the first write
        mode = 'w' if not hasattr(self, '_log_initialized') else 'a'
        with open("probability_map.log", mode) as f:
            f.write(f"Move: {self.move}\n")  # Log the current move
            f.write(f"Current Target: {self.current_target}\n")  # Log current target
            f.write(f"Attacked Positions: {self.attacked}\n")  # Log attacked positions
            f.write("Probability Map:\n")
            for y in range(self.rows):
                row = []
                for x in range(self.cols):
                    if self.probability_map[y][x] == 'X':
                        row.append(" X  ")  # Mark attacked positions
                    else:
                        row.append(f"{self.probability_map[y][x]:.1f}")  # Show probabilities
                f.write(" ".join(row) + "\n")  # Write row to file
            f.write("\n")  # Add a newline for separation
        # Mark that the log has been initialized
        self._log_initialized = True
        self.move += 2  # Increment move counter by 2 (odd numbers only)

    def _update_probabilities(self, x: int, y: int):
        """Updates probabilities based on possible ship placements"""
        ship_cells = self.current_ship_hits
        
        # Check if ship_cells is empty
        if not ship_cells:
            return []
        
        remaining_ships = self.ships_remaining
        
        # Find the minimal bounding box
        min_x = min(h[0] for h in ship_cells)
        max_x = max(h[0] for h in ship_cells)
        min_y = min(h[1] for h in ship_cells)
        max_y = max(h[1] for h in ship_cells)
        
        # Calculate width, height, and size
        width = max_x - min_x + 1
        height = max_y - min_y + 1
        size = len(ship_cells)

        normalized_hits = {(h[0] - min_x, h[1] - min_y) for h in ship_cells}

        # Find possible ships that could fit the current hits
        possible_ships = []
        for ship_id, count in remaining_ships.items():
            if count > 0 and self.ship_metadata[ship_id] > size:
                if self.ship_shapes[ship_id]["type"] == "I":
                    if width == 1 or height == 1:
                        possible_ships.append(ship_id)
                else:
                    possible_ships.append(ship_id)
        
        if 3 >= size >= 2:
            # Determine the direction of the ship (horizontal or vertical)
            is_vertical = width == 1  # All x coordinates are the same
            is_horizontal = height == 1    # All y coordinates are the same

            for cx, cy in ship_cells:
                if is_horizontal:
                    # Check left neighbor (horizontal)
                    nx, ny = cx - 1, cy
                    if 0 <= nx < self.cols and 0 <= ny < self.rows:
                        if isinstance(self.probability_map[ny][nx], (int, float)) and self.probability_map[ny][nx] != 0.0 and self.probability_map[ny][nx] != 21.0:
                            self.probability_map[ny][nx] = min(100, self.probability_map[ny][nx] + 10)
                    # Check right neighbor (horizontal)
                    nx, ny = cx + 1, cy
                    if 0 <= nx < self.cols and 0 <= ny < self.rows:
                        if isinstance(self.probability_map[ny][nx], (int, float)) and self.probability_map[ny][nx] != 0.0 and self.probability_map[ny][nx] != 21.0:
                            self.probability_map[ny][nx] = min(100, self.probability_map[ny][nx] + 10)
                elif is_vertical:
                    # Check top neighbor (vertical)
                    nx, ny = cx, cy - 1
                    if 0 <= nx < self.cols and 0 <= ny < self.rows:
                        if isinstance(self.probability_map[ny][nx], (int, float)) and self.probability_map[ny][nx] != 0.0 and self.probability_map[ny][nx] != 21.0:
                            self.probability_map[ny][nx] = min(100, self.probability_map[ny][nx] + 10)
                    # Check bottom neighbor (vertical)
                    nx, ny = cx, cy + 1
                    if 0 <= nx < self.cols and 0 <= ny < self.rows:
                        if isinstance(self.probability_map[ny][nx], (int, float)) and self.probability_map[ny][nx] != 0.0 and self.probability_map[ny][nx] != 21.0:
                            self.probability_map[ny][nx] = min(100, self.probability_map[ny][nx] + 10)
            if size == 3:
                is_z_shape_already = False  # Definujte proměnnou zde, před podmínkou
                if width == 2 and height == 2:
                    if self.ships_remaining.get(6, 0) > 0 or self.ships_remaining.get(7, 0) > 0:
                        # Z shape detection and targeting logic
                        pos1 = (min_x, min_y)
                        pos2 = (min_x, max_y)
                        pos3 = (max_x, max_y)
                        pos4 = (max_x, min_y)
                        
                        # Rotace 1:
                        # *
                        # **
                        if pos1 in self.current_ship_hits and pos2 in self.current_ship_hits and pos3 in self.current_ship_hits:
                            target_x1 = min_x - 1
                            target_y1 = min_y
                            target_x2 = max_x
                            target_y2 = max_y + 1
                            if 0 <= target_x1 < self.cols and 0 <= target_y1 < self.rows:
                                if isinstance(self.probability_map[target_y1][target_x1], (int, float)):
                                    self.probability_map[target_y1][target_x1] = min(100, self.probability_map[target_y1][target_x1] + 30)
                            elif 0 <= target_x2 < self.cols and 0 <= target_y2 < self.rows:
                                if isinstance(self.probability_map[target_y2][target_x2], (int, float)):
                                    self.probability_map[target_y2][target_x2] = min(100, self.probability_map[target_y2][target_x2] + 30)
                        
                        # Rotace 2:
                        # **
                        #  *
                        elif pos1 in self.current_ship_hits and pos3 in self.current_ship_hits and pos4 in self.current_ship_hits:
                            target_x1 = min_x
                            target_y1 = min_y - 1
                            target_x2 = max_x + 1
                            target_y2 = max_y
                            if 0 <= target_x1 < self.cols and 0 <= target_y1 < self.rows:
                                if isinstance(self.probability_map[target_y1][target_x1], (int, float)):
                                    self.probability_map[target_y1][target_x1] = min(100, self.probability_map[target_y1][target_x1] + 30)
                            elif 0 <= target_x2 < self.cols and 0 <= target_y2 < self.rows:
                                if isinstance(self.probability_map[target_y2][target_x2], (int, float)):
                                    self.probability_map[target_y2][target_x2] = min(100, self.probability_map[target_y2][target_x2] + 30)
                        
                        # Rotace 3:
                        #  *
                        # **
                        elif pos2 in self.current_ship_hits and pos3 in self.current_ship_hits and pos4 in self.current_ship_hits:
                            target_x1 = max_x + 1
                            target_y1 = min_y
                            target_x2 = min_x
                            target_y2 = max_y + 1
                            if 0 <= target_x1 < self.cols and 0 <= target_y1 < self.rows:
                                if isinstance(self.probability_map[target_y1][target_x1], (int, float)):
                                    self.probability_map[target_y1][target_x1] = min(100, self.probability_map[target_y1][target_x1] + 30)
                            elif 0 <= target_x2 < self.cols and 0 <= target_y2 < self.rows:
                                if isinstance(self.probability_map[target_y2][target_x2], (int, float)):
                                    self.probability_map[target_y2][target_x2] = min(100, self.probability_map[target_y2][target_x2] + 30)
                        
                        # Rotace 4:
                        # **
                        # *
                        elif pos1 in self.current_ship_hits and pos2 in self.current_ship_hits and pos4 in self.current_ship_hits:
                            target_x1 = max_x
                            target_y1 = min_y - 1
                            target_x2 = min_x - 1
                            target_y2 = max_y
                            if 0 <= target_x1 < self.cols and 0 <= target_y1 < self.rows:
                                if isinstance(self.probability_map[target_y1][target_x1], (int, float)):
                                    self.probability_map[target_y1][target_x1] = min(100, self.probability_map[target_y1][target_x1] + 30)
                            elif 0 <= target_x2 < self.cols and 0 <= target_y2 < self.rows:
                                if isinstance(self.probability_map[target_y2][target_x2], (int, float)):
                                    self.probability_map[target_y2][target_x2] = min(100, self.probability_map[target_y2][target_x2] + 30)

                if self.ships_remaining.get(6, 0) > 0 or self.ships_remaining.get(7, 0) > 0 and is_z_shape_already:
                    ''' 
                    jelikož máme:
                    *
                    ** 
                    nebo jednu z těchto rotací a do Z to nelze dosadit tak zkontrolujeme zbývající lodě, pokud bude z L nebo T lodě zbývat jen jedna loď a druhá zbývat nebude tak se bude dosazovat podle té co zbývá jinak se to bude porovnávat podle toho jaké okolní pole byly sestřelené a pokud i tak bude možné dosadit obě lodě tak se to bere podle počtu lodí
                    ''' 
                elif (height == 1 or width == 1):
                    #zkontroluj lodě co zbývají pro rozhodnutí dosazení L a T
                    l_ships_count = self.ships_remaining.get(5, 0)
                    t_ships_count = self.ships_remaining.get(4, 0)

                    if width == 1 and \
                        (min_y - 1 < 0 or self.probability_map[min_y - 1][min_x] in (0.0, 'X')) and \
                        (max_y + 1 >= self.rows or self.probability_map[max_y + 1][min_x] in (0.0, 'X')):
                        #check inpossible positions on sides
                        '''
                        *
                        *
                        *
                        check x marked down:
                        X*X
                        X*X
                        X*X
                        after if there isnt possibility for L or T shape and other bcs ends of the line is blocked
                        '''
                        middle_y = max_y - 1
                        if t_ships_count > 0 and \
                            (0 <= min_x + 1 < self.cols and self.probability_map[middle_y][min_x + 1] in (0.0, 'X')) or \
                            (0 <= min_x - 1 < self.cols and self.probability_map[middle_y][min_x - 1] in (0.0, 'X')):
                            if 0 <= min_x + 1 < self.cols and self.probability_map[middle_y][min_x + 1] in (0.0, 'X'):
                                # Zvýšení pravděpodobnosti pro pravou buňku
                                if 0 <= min_x + 1 < self.cols and 0 <= middle_y < self.rows:
                                    if isinstance(self.probability_map[middle_y][min_x + 1], (int, float)):
                                        self.probability_map[middle_y][min_x + 1] = min(100, self.probability_map[middle_y][min_x + 1] + 10)
                            elif 0 <= min_x - 1 < self.cols and self.probability_map[middle_y][min_x - 1] in (0.0, 'X'):
                                # Zvýšení pravděpodobnosti pro levou buňku
                                if 0 <= min_x - 1 < self.cols and 0 <= middle_y < self.rows:
                                    if isinstance(self.probability_map[middle_y][min_x - 1], (int, float)):
                                        self.probability_map[middle_y][min_x - 1] = min(100, self.probability_map[middle_y][min_x - 1] + 10)
                        elif l_ships_count > 0 and \
                            (0 <= min_x + 1 < self.cols and self.probability_map[min_y][min_x + 1] in (0.0, 'X')) or \
                            (0 <= min_x - 1 < self.cols and self.probability_map[min_y][min_x - 1] in (0.0, 'X')) or \
                            (0 <= min_x + 1 < self.cols and self.probability_map[max_y][min_x + 1] in (0.0, 'X')) or \
                            (0 <= min_x - 1 < self.cols and self.probability_map[max_y][min_x - 1] in (0.0, 'X')):
                            if 0 <= min_x + 1 < self.cols and self.probability_map[min_y][min_x + 1] in (0.0, 'X'):
                                # Zvýšení pravděpodobnosti pro pravou buňku (min_y)
                                if 0 <= min_x + 1 < self.cols and 0 <= min_y < self.rows:
                                    if isinstance(self.probability_map[min_y][min_x + 1], (int, float)):
                                        self.probability_map[min_y][min_x + 1] = min(100, self.probability_map[min_y][min_x + 1] + 10)
                            elif 0 <= min_x - 1 < self.cols and self.probability_map[min_y][min_x - 1] in (0.0, 'X'):
                                # Zvýšení pravděpodobnosti pro levou buňku (min_y)
                                if 0 <= min_x - 1 < self.cols and 0 <= min_y < self.rows:
                                    if isinstance(self.probability_map[min_y][min_x - 1], (int, float)):
                                        self.probability_map[min_y][min_x - 1] = min(100, self.probability_map[min_y][min_x - 1] + 10)
                            elif 0 <= min_x + 1 < self.cols and self.probability_map[max_y][min_x + 1] in (0.0, 'X'):
                                # Zvýšení pravděpodobnosti pro pravou buňku (max_y)
                                if 0 <= min_x + 1 < self.cols and 0 <= max_y < self.rows:
                                    if isinstance(self.probability_map[max_y][min_x + 1], (int, float)):
                                        self.probability_map[max_y][min_x + 1] = min(100, self.probability_map[max_y][min_x + 1] + 10)
                            elif 0 <= min_x - 1 < self.cols and self.probability_map[max_y][min_x - 1] in (0.0, 'X'):
                                # Zvýšení pravděpodobnosti pro levou buňku (max_y)
                                if 0 <= min_x - 1 < self.cols and 0 <= max_y < self.rows:
                                    if isinstance(self.probability_map[max_y][min_x - 1], (int, float)):
                                        self.probability_map[max_y][min_x - 1] = min(100, self.probability_map[max_y][min_x - 1] + 10)
                    elif height == 1 and \
                        (min_x - 1 < 0 or self.probability_map[min_y][min_x - 1] in (0.0, 'X')) and \
                        (max_x + 1 >= self.cols or self.probability_map[min_y][max_x + 1] in (0.0, 'X')):
                        # same as above but in horizontal direction
                        middle_x = (min_x + max_x) // 2
                        if t_ships_count > 0 and \
                            (0 <= min_y + 1 < self.rows and self.probability_map[min_y][min_x] in (0.0, 'X')) or \
                            (0 <= min_y - 1 < self.rows and self.probability_map[min_y][max_x] in (0.0, 'X')):
                            if 0 <= min_y + 1 < self.rows and self.probability_map[min_y][min_x] in (0.0, 'X'):
                                # Zvýšení pravděpodobnosti pro pravou buňku
                                if 0 <= min_x < self.cols and 0 <= min_y < self.rows:
                                    if isinstance(self.probability_map[min_y][min_x], (int, float)):
                                        self.probability_map[min_y][min_x] = min(100, self.probability_map[min_y][min_x] + 10)
                            elif 0 <= min_y - 1 < self.rows and self.probability_map[min_y][max_x] in (0.0, 'X'):
                                # Zvýšení pravděpodobnosti pro levou buňku
                                if 0 <= min_x < self.cols and 0 <= min_y < self.rows:
                                    if isinstance(self.probability_map[min_y][max_x], (int, float)):
                                        self.probability_map[min_y][max_x] = min(100, self.probability_map[min_y][max_x] + 10)
                        elif l_ships_count > 0 and \
                            (0 <= min_y + 1 < self.rows and self.probability_map[min_y][min_x] in (0.0, 'X')) or \
                            (0 <= min_y - 1 < self.rows and self.probability_map[min_y][max_x] in (0.0, 'X')) or \
                            (0 <= min_y + 1 < self.rows and self.probability_map[min_y][max_x] in (0.0, 'X')) or \
                            (0 <= min_y - 1 < self.rows and self.probability_map[min_y][max_x] in (0.0, 'X')):
                            if 0 <= min_y + 1 < self.rows and self.probability_map[min_y][min_x] in (0.0, 'X'):
                                # Zvýšení pravděpodobnosti pro pravou buňku (min_y)
                                if 0 <= min_x < self.cols and 0 <= min_y < self.rows:
                                    if isinstance(self.probability_map[min_y][min_x], (int, float)):
                                        self.probability_map[min_y][min_x] = min(100, self.probability_map[min_y][min_x] + 10)
                            elif 0 <= min_y - 1 < self.rows and self.probability_map[min_y][max_x] in (0.0, 'X'):
                                # Zvýšení pravděpodobnosti pro levou buňku (min_y)
                                if 0 <= min_x < self.cols and 0 <= min_y < self.rows:
                                    if isinstance(self.probability_map[min_y][max_x], (int, float)):
                                        self.probability_map[min_y][max_x] = min(100, self.probability_map[min_y][max_x] + 10)
                            if 0 <= middle_x + 1 < self.cols and 0 <= min_y < self.rows:
                                if isinstance(self.probability_map[min_y][middle_x + 1], (int, float)):
                                    self.probability_map[min_y][middle_x + 1] = min(100, self.probability_map[min_y][middle_x + 1] + 10)
                            elif 0 <= middle_x - 1 < self.cols and 0 <= min_y < self.rows and self.probability_map[min_y][middle_x - 1] in (0.0, 'X'):
                                # Zvýšení pravděpodobnosti pro levou buňku
                                if isinstance(self.probability_map[min_y][middle_x - 1], (int, float)):
                                    self.probability_map[min_y][middle_x - 1] = min(100, self.probability_map[min_y][middle_x - 1] + 10)
                        elif l_ships_count > 0 and \
                            (0 <= min_y < self.rows and 0 <= min_x + 1 < self.cols and self.probability_map[min_y][min_x + 1] in (0.0, 'X')) or \
                            (0 <= min_y < self.rows and 0 <= min_x - 1 < self.cols and self.probability_map[min_y][min_x - 1] in (0.0, 'X')) or \
                            (0 <= min_y < self.rows and 0 <= max_x + 1 < self.cols and self.probability_map[min_y][max_x + 1] in (0.0, 'X')) or \
                            (0 <= min_y < self.rows and 0 <= max_x + 1 < self.cols and self.probability_map[min_y][max_x + 1] in (0.0, 'X')) or \
                            (0 <= min_y < self.rows and 0 <= max_x - 1 < self.cols and self.probability_map[min_y][max_x - 1] in (0.0, 'X')):
                            if 0 <= min_y < self.rows and 0 <= min_x + 1 < self.cols and self.probability_map[min_y][min_x + 1] in (0.0, 'X'):
                                # Zvýšení pravděpodobnosti pro pravou buňku (min_x)
                                if isinstance(self.probability_map[min_y][min_x + 1], (int, float)):
                                    self.probability_map[min_y][min_x + 1] = min(100, self.probability_map[min_y][min_x + 1] + 10)
                            elif 0 <= min_y < self.rows and 0 <= min_x - 1 < self.cols and self.probability_map[min_y][min_x - 1] in (0.0, 'X'):
                                # Zvýšení pravděpodobnosti pro levou buňku (min_x)
                                if isinstance(self.probability_map[min_y][min_x - 1], (int, float)):
                                    self.probability_map[min_y][min_x - 1] = min(100, self.probability_map[min_y][min_x - 1] + 10)
                            elif 0 <= min_y < self.rows and 0 <= max_x + 1 < self.cols and self.probability_map[min_y][max_x + 1] in (0.0, 'X'):
                                # Zvýšení pravděpodobnosti pro pravou buňku (max_x)
                                if isinstance(self.probability_map[min_y][max_x + 1], (int, float)):
                                    self.probability_map[min_y][max_x + 1] = min(100, self.probability_map[min_y][max_x + 1] + 10)
                            elif 0 <= min_y < self.rows and 0 <= max_x - 1 < self.cols and self.probability_map[min_y][max_x - 1] in (0.0, 'X'):
                                # Zvýšení pravděpodobnosti pro levou buňku (max_x)
                                if isinstance(self.probability_map[min_y][max_x - 1], (int, float)):
                                    self.probability_map[min_y][max_x - 1] = min(100, self.probability_map[min_y][max_x - 1] + 10)
        elif size >= 4:
            is_vertical = width == 1  # All x coordinates are the same (for size 4)
            is_horizontal = height == 1 # All y coordinates are the same (for size 4)
            if is_horizontal:
                # Find the middle cell of the horizontal ship
                middle_x = (min_x + max_x) // 2
                middle_y = min_y
                # Check if the bottom cell is a miss or out of bounds
                bottom_x, bottom_y = middle_x, middle_y + 1
                is_bottom_miss = (bottom_x < 0 or bottom_x >= self.cols or bottom_y < 0 or bottom_y >= self.rows or 
                                 self.enemy_board[bottom_y][bottom_x] == 'M')
                if is_bottom_miss:
                    # If bottom is a miss or out of bounds, target the top two cells
                    top_x1, top_y1 = middle_x, middle_y - 1
                    top_x2, top_y2 = middle_x + 1, middle_y - 1
                    if 0 <= top_x1 < self.cols and 0 <= top_y1 < self.rows:
                        if isinstance(self.probability_map[top_y1][top_x1], (int, float)) and self.probability_map[top_y1][top_x1] != 0.0:
                            self.probability_map[top_y1][top_x1] = min(100, self.probability_map[top_y1][top_x1] + 20)

                    if 0 <= top_x2 < self.cols and 0 <= top_y2 < self.rows:
                        if isinstance(self.probability_map[top_y2][top_x2], (int, float)) and self.probability_map[top_y2][top_x2] != 0.0:
                            self.probability_map[top_y2][top_x2] = min(100, self.probability_map[top_y2][top_x2] + 20)
                else:
                    # If bottom is not a miss, target the bottom cell
                    if isinstance(self.probability_map[bottom_y][bottom_x], (int, float)) and self.probability_map[bottom_y][bottom_x] != 0.0:
                        self.probability_map[bottom_y][bottom_x] = min(100, self.probability_map[bottom_y][bottom_x] + 20)
            elif is_vertical:
                # Find the middle cell of the vertical ship
                middle_x = min_x
                middle_y = (min_y + max_y) // 2
                # Check if the right cell is a miss or out of bounds
                right_x, right_y = middle_x + 1, middle_y
                is_right_miss = (right_x < 0 or right_x >= self.cols or right_y < 0 or right_y >= self.rows or 
                                self.enemy_board[right_y][right_x] == 'M')
                
                if is_right_miss:
                    # If right is a miss or out of bounds, target the left two cells
                    left_x1, left_y1 = middle_x - 1, middle_y
                    left_x2, left_y2 = middle_x - 1, middle_y + 1
                    if 0 <= left_x1 < self.cols and 0 <= left_y1 < self.rows:
                        if isinstance(self.probability_map[left_y1][left_x1], (int, float)) and self.probability_map[left_y1][left_x1] != 0.0:
                            self.probability_map[left_y1][left_x1] = min(100, self.probability_map[left_y1][left_x1] + 20)

                    if 0 <= left_x2 < self.cols and 0 <= left_y2 < self.rows:
                        if isinstance(self.probability_map[left_y2][left_x2], (int, float)) and self.probability_map[left_y2][left_x2] != 0.0:
                            self.probability_map[left_y2][left_x2] = min(100, self.probability_map[left_y2][left_x2] + 20)
                else:
                    # If right is not a miss, target the right cell
                    if isinstance(self.probability_map[right_y][right_x], (int, float)) and self.probability_map[right_y][right_x] != 0.0:
                        self.probability_map[right_y][right_x] = min(100, self.probability_map[right_y][right_x] + 20)
            elif size == 4:
                if width == 3 and height == 2 and self._identify_ship() == 6:
                    # Horizontální loď Z
                    # Najdeme spodní dvě pole (y_min + 1)
                    bottom_left = (min_x - 1, min_y + 1)
                    bottom_right = (min_x, min_y + 1)
                    
                    # Zkontrolujeme, zda jsou obě spodní pole platná
                    is_bottom_left_valid = (0 <= bottom_left[0] < self.cols and 0 <= bottom_left[1] < self.rows and 
                                           self.probability_map[bottom_left[1]][bottom_left[0]] != 'X' and 
                                           self.probability_map[bottom_left[1]][bottom_left[0]] != 0.0)
                    is_bottom_right_valid = (0 <= bottom_right[0] < self.cols and 0 <= bottom_right[1] < self.rows and 
                                             self.probability_map[bottom_right[1]][bottom_right[0]] != 'X' and 
                                             self.probability_map[bottom_right[1]][bottom_right[0]] != 0.0)
                    is_bottom_right_hit = (0 <= bottom_right[0] < self.cols and 0 <= bottom_right[1] < self.rows and 
                                             self.enemy_board[bottom_right[1]][bottom_right[0]] == 'H')
                    
                    if is_bottom_right_hit: #zrcadlené Z
                        bottom_left = (max_x, min_y + 1)
                        bottom_right = (max_x + 1, min_y + 1)
                        is_bottom_left_valid = (0 <= bottom_left[0] < self.cols and 0 <= bottom_left[1] < self.rows and 
                                               self.probability_map[bottom_left[1]][bottom_left[0]] != 'X' and 
                                               self.probability_map[bottom_left[1]][bottom_left[0]] != 0.0)
                        is_bottom_right_valid = (0 <= bottom_right[0] < self.cols and 0 <= bottom_right[1] < self.rows and 
                                                self.probability_map[bottom_right[1]][bottom_right[0]] != 'X' and 
                                                self.probability_map[bottom_right[1]][bottom_right[0]] != 0.0)
                        if is_bottom_left_valid and is_bottom_right_valid:
                            # Pokud jsou obě spodní pole platná, zvýšíme pravděpodobnost pro první sousední spodní pole
                            self.probability_map[bottom_left[1]][bottom_left[0]] = min(100, self.probability_map[bottom_left[1]][bottom_left[0]] + 20)
                        else:
                            # Pokud jen jedno z polí není platné, zvýšíme pravděpodobnost pro vrchní dvě pole
                            top_left = (min_x, min_y)
                            top_right = (min_x - 1, min_y)
                        
                            if 0 <= top_left[0] < self.cols and 0 <= top_left[1] < self.rows:
                                if isinstance(self.probability_map[top_left[1]][top_left[0]], (int, float)) and self.probability_map[top_left[1]][top_left[0]] != 0.0:
                                    self.probability_map[top_left[1]][top_left[0]] = min(100, self.probability_map[top_left[1]][top_left[0]] + 20)
                        
                            if 0 <= top_right[0] < self.cols and 0 <= top_right[1] < self.rows:
                                if isinstance(self.probability_map[top_right[1]][top_right[0]], (int, float)) and self.probability_map[top_right[1]][top_right[0]] != 0.0:
                                    self.probability_map[top_right[1]][top_right[0]] = min(100, self.probability_map[top_right[1]][top_right[0]] + 20)
                    elif is_bottom_left_valid and is_bottom_right_valid:
                        # Pokud jsou obě spodní pole platná, zvýšíme pravděpodobnost pro první sousední spodní pole
                        self.probability_map[bottom_right[1]][bottom_right[0]] = min(100, self.probability_map[bottom_right[1]][bottom_right[0]] + 20)
                    else:
                        # Pokud jen jedno z polí není platné, zvýšíme pravděpodobnost pro vrchní dvě pole
                        top_left = (max_x, min_y)
                        top_right = (max_x + 1, min_y)
                        
                        if 0 <= top_left[0] < self.cols and 0 <= top_left[1] < self.rows:
                            if isinstance(self.probability_map[top_left[1]][top_left[0]], (int, float)) and self.probability_map[top_left[1]][top_left[0]] != 0.0:
                                self.probability_map[top_left[1]][top_left[0]] = min(100, self.probability_map[top_left[1]][top_left[0]] + 20)
                        
                        if 0 <= top_right[0] < self.cols and 0 <= top_right[1] < self.rows:
                            if isinstance(self.probability_map[top_right[1]][top_right[0]], (int, float)) and self.probability_map[top_right[1]][top_right[0]] != 0.0:
                                self.probability_map[top_right[1]][top_right[0]] = min(100, self.probability_map[top_right[1]][top_right[0]] + 20)
                elif width == 2 and height == 3 and self._identify_ship() == 6:
                    # Vertikální loď Z
                    # Najdeme pravé dvě pole (x_min + 1)
                    right_top = (max_x, min_y - 1)
                    right_bottom = (max_x, min_y)
                    
                    # Zkontrolujeme, zda jsou obě pravé pole platná
                    is_right_top_valid = (0 <= right_top[0] < self.cols and 0 <= right_top[1] < self.rows and 
                                         self.probability_map[right_top[1]][right_top[0]] != 'X' and 
                                         self.probability_map[right_top[1]][right_top[0]] != 0.0)
                    is_right_bottom_valid = (0 <= right_bottom[0] < self.cols and 0 <= right_bottom[1] < self.rows and 
                                             self.probability_map[right_bottom[1]][right_bottom[0]] != 'X' and 
                                             self.probability_map[right_bottom[1]][right_bottom[0]] != 0.0)
                    is_right_bottom_hit = (0 <= right_bottom[0] < self.cols and 0 <= right_bottom[1] < self.rows and 
                                           self.enemy_board[right_bottom[1]][right_bottom[0]] == 'H')
                    
                    if is_right_bottom_hit:  # Zrcadlené Z
                        right_top = (min_x + 1, max_y)
                        right_bottom = (min_x + 1, max_y + 1)
                        is_right_top_valid = (0 <= right_top[0] < self.cols and 0 <= right_top[1] < self.rows and 
                                             self.probability_map[right_top[1]][right_top[0]] != 'X' and 
                                             self.probability_map[right_top[1]][right_top[0]] != 0.0)
                        is_right_bottom_valid = (0 <= right_bottom[0] < self.cols and 0 <= right_bottom[1] < self.rows and 
                                                 self.probability_map[right_bottom[1]][right_bottom[0]] != 'X' and 
                                                 self.probability_map[right_bottom[1]][right_bottom[0]] != 0.0)
                        if is_right_top_valid and is_right_bottom_valid:
                            # Pokud jsou obě pravé pole platná, zvýšíme pravděpodobnost pro první sousední pravé pole
                            self.probability_map[right_top[1]][right_top[0]] = min(100, self.probability_map[right_top[1]][right_top[0]] + 20)
                        else:
                            # Pokud jen jedno z polí není platné, zvýšíme pravděpodobnost pro levé dvě pole
                            left_top = (min_x - 1, min_y)
                            left_bottom = (min_x - 1, min_y + 1)
                            
                            if 0 <= left_top[0] < self.cols and 0 <= left_top[1] < self.rows:
                                if isinstance(self.probability_map[left_top[1]][left_top[0]], (int, float)) and self.probability_map[left_top[1]][left_top[0]] != 0.0:
                                    self.probability_map[left_top[1]][left_top[0]] = min(100, self.probability_map[left_top[1]][left_top[0]] + 20)
                            
                            if 0 <= left_bottom[0] < self.cols and 0 <= left_bottom[1] < self.rows:
                                if isinstance(self.probability_map[left_bottom[1]][left_bottom[0]], (int, float)) and self.probability_map[left_bottom[1]][left_bottom[0]] != 0.0:
                                    self.probability_map[left_bottom[1]][left_bottom[0]] = min(100, self.probability_map[left_bottom[1]][left_bottom[0]] + 20)
                    elif is_right_top_valid and is_right_bottom_valid:
                        # Pokud jsou obě pravé pole platná, zvýšíme pravděpodobnost pro první sousední pravé pole
                        self.probability_map[right_bottom[1]][right_bottom[0]] = min(100, self.probability_map[right_bottom[1]][right_bottom[0]] + 20)
                    else:
                        # Pokud jen jedno z polí není platné, zvýšíme pravděpodobnost pro levé dvě pole
                        left_top = (min_x, min_y)
                        left_bottom = (min_x, min_y - 1)
                        
                        if 0 <= left_top[0] < self.cols and 0 <= left_top[1] < self.rows:
                            if isinstance(self.probability_map[left_top[1]][left_top[0]], (int, float)) and self.probability_map[left_top[1]][left_top[0]] != 0.0:
                                self.probability_map[left_top[1]][left_top[0]] = min(100, self.probability_map[left_top[1]][left_top[0]] + 20)
                        
                        if 0 <= left_bottom[0] < self.cols and 0 <= left_bottom[1] < self.rows:
                            if isinstance(self.probability_map[left_bottom[1]][left_bottom[0]], (int, float)) and self.probability_map[left_bottom[1]][left_bottom[0]] != 0.0:
                                self.probability_map[left_bottom[1]][left_bottom[0]] = min(100, self.probability_map[left_bottom[1]][left_bottom[0]] + 20)
                elif width == 2 and height == 2:
                    #logika pro střelený čtverec
                    return
            elif size == 5:
                is_horizontal = width > height    # Loď je vertikální pokud je šířka větší než výška
                is_vertical = height > width  # Loď je horizontální pokud je výška větší než šířka
                if width == 4 or height == 4:
                    if is_horizontal:
                        # Počítáme hity pro každou y souřadnici
                        y_counts = {}
                        for cell in ship_cells:
                            y_counts[cell[1]] = y_counts.get(cell[1], 0) + 1

                        # Najdeme y souřadnici s nejvíce hity - to je základna lodi
                        base_y = max(y_counts, key=y_counts.get)
                        target_y = base_y + 1 if base_y == min_y else base_y - 1
                        target_x = ((min_x + max_x) // 2) + 1

                        # Přidáno: kontrola hranic před přístupem
                        if 0 <= target_x < self.cols and 0 <= target_y < self.rows:
                            if isinstance(self.probability_map[target_y][target_x], (int, float)) and self.probability_map[target_y][target_x] != 0.0:
                                self.probability_map[target_y][target_x] = min(100, self.probability_map[target_y][target_x] + 20)

                    elif is_vertical:
                        x_counts = {}
                        for cell in ship_cells:
                            x_counts[cell[0]] = x_counts.get(cell[0], 0) + 1

                        base_x = max(x_counts, key=x_counts.get)
                        target_x = base_x + 1 if base_x == min_x else base_x - 1
                        target_y = ((min_y + max_y) // 2) + 1

                        # Přidáno: kontrola hranic před přístupem
                        if 0 <= target_x < self.cols and 0 <= target_y < self.rows:
                            if isinstance(self.probability_map[target_y][target_x], (int, float)) and self.probability_map[target_y][target_x] != 0.0:
                                self.probability_map[target_y][target_x] = min(100, self.probability_map[target_y][target_x] + 20)
                else:
                    if is_horizontal:
                        y_counts = {}
                        for cell in ship_cells:
                            y_counts[cell[1]] = y_counts.get(cell[1], 0) + 1

                        target_y = max(y_counts, key=y_counts.get)
                        if y_counts[target_y] == 3:
                            y_row = min(y_counts, key=y_counts.get)
                            for cell in ship_cells:
                                if cell[1] == y_row and (cell[0] == min_x or cell[0] == max_x):
                                    target_x = cell[0] - 1 if cell[0] == min_x else cell[0] + 1

                                    # Přidáno: kontrola hranic před přístupem
                                    if 0 <= target_x < self.cols and 0 <= target_y < self.rows:
                                        if isinstance(self.probability_map[target_y][target_x], (int, float)) and self.probability_map[target_y][target_x] != 0.0:
                                            self.probability_map[target_y][target_x] = min(100, self.probability_map[target_y][target_x] + 20)

                    if is_vertical:
                        x_counts = {}
                        for cell in ship_cells:
                            x_counts[cell[0]] = x_counts.get(cell[0], 0) + 1

                        target_x = max(x_counts, key=x_counts.get)
                        if x_counts[target_x] == 3:
                            x_row = min(x_counts, key=x_counts.get)
                            for cell in ship_cells:
                                if cell[0] == x_row and (cell[1] == min_y or cell[1] == max_y):
                                    target_y = cell[1] - 1 if cell[1] == min_y else cell[1] + 1

                                    # Přidáno: kontrola hranic před přístupem
                                    if 0 <= target_x < self.cols and 0 <= target_y < self.rows:
                                        if isinstance(self.probability_map[target_y][target_x], (int, float)) and self.probability_map[target_y][target_x] != 0.0:
                                            self.probability_map[target_y][target_x] = min(100, self.probability_map[target_y][target_x] + 20)
