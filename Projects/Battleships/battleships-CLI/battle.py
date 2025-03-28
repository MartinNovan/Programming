#!/usr/bin/env python3
"""
battle.py

This is the master game runner. It supports these command-line arguments:
  -v               : Verbose output; prints every move.
  -c X             : Count of battles to simulate (default=100).
  -w X             : Board width (default=10).
  -h X             : Board height (default=10).
  -l A,B,C,D,E,F,G : Comma-separated ship counts for IDs 1..7.
                    If specified, turns off the random ship generation.
                    If not specified, a random ship configuration is generated
                    (until at least 30% of the playing field is filled).

The master runner initializes both players’ boards & strategies (using their submissions)
and then runs the battle logic—using its own game state to determine hits, sunk ships, etc.—while
also informing the players’ strategy modules of the results.
"""

import argparse
import sys
import random

# Import student submissions
from player_1.board_setup.board_setup import BoardSetup as BS1
from player_1.strategy.strategy import Strategy as ST1
from player_2.board_setup.board_setup import BoardSetup as BS2
from player_2.strategy.strategy import Strategy as ST2

# --------------------------
# Helper functions
# --------------------------

def get_ship_instances(board: list[list[int]]) -> list[dict]:
    """
    Given a 2D board (list of lists of ints), identify each ship instance
    as a connected (orthogonally) component of nonzero cells.
    Returns a list of dictionaries, each with keys:
      - "ship_id": the ship type (int)
      - "coords" : a set of (x, y) coordinates belonging to this ship.
      - "hits"   : an initially empty set that will track attacked cells.
    """
    rows = len(board)
    cols = len(board[0]) if rows else 0
    visited = set()
    instances = []

    for y in range(rows):
        for x in range(cols):
            if board[y][x] != 0 and (x, y) not in visited:
                ship_id = board[y][x]
                stack = [(x, y)]
                component = set()
                while stack:
                    cx, cy = stack.pop()
                    if (cx, cy) in component:
                        continue
                    component.add((cx, cy))
                    visited.add((cx, cy))
                    for dx, dy in [(1,0), (-1,0), (0,1), (0,-1)]:
                        nx, ny = cx+dx, cy+dy
                        if 0 <= nx < cols and 0 <= ny < rows:
                            if board[ny][nx] == ship_id and (nx, ny) not in component:
                                stack.append((nx, ny))
                instances.append({"ship_id": ship_id, "coords": component, "hits": set()})
    return instances

def process_attack(x: int, y: int, ship_instances: list[dict]) -> tuple[bool, bool]:
    """
    Given an attack coordinate (x,y) and a list of ship instances (each a dict with keys
    "coords" and "hits"), determine whether the attack is a hit, and whether it sinks
    one of the ships.
    Marks the cell as hit in the corresponding ship instance if found.
    Returns a tuple (hit, sunk).
    """
    for ship in ship_instances:
        if (x, y) in ship["coords"]:
            ship["hits"].add((x, y))
            if ship["hits"] == ship["coords"]:
                return True, True
            else:
                return True, False
    return False, False

def generate_random_ships(width: int, height: int) -> list[int]:
    """
    Generate a random ship counts list (for ship IDs 1..7) such that the total number
    of ship tiles is at least 30% of the board area.
    
    Predefined tile counts:
      ID1: 2, ID2: 3, ID3: 4, ID4: 4, ID5: 4, ID6: 4, ID7: 6.
    """
    target = int(width * height * 0.3)
    tile_counts = {1: 2, 2: 3, 3: 4, 4: 4, 5: 4, 6: 4, 7: 6}
    ship_counts = {i: 0 for i in range(1,8)}
    total_tiles = 0
    while total_tiles < target:
        ship_type = random.randint(1,7)
        ship_counts[ship_type] += 1
        total_tiles += tile_counts[ship_type]
    return [ship_counts[i] for i in range(1,8)]

# --------------------------
# Battle simulation function
# --------------------------

def simulate_battle(verbose: bool, width: int, height: int, ship_counts: list[int], starting_player: int) -> tuple[int, int]:
    """
    Simulate one battle between two players.
    
    Parameters:
      verbose       : If True, print detailed moves.
      width, height : Board dimensions.
      ship_counts   : List of 7 integers for ship counts for IDs 1..7.
      starting_player: 1 or 2; which player starts the battle.
    
    Returns:
      (winner, moves) where:
        - winner is 1, 2, or 0 for a draw.
        - moves is the number of moves played.
    
    If moves exceed width*height*100, the battle is considered a draw.
    """
    max_moves = width * height * 100
    
    # Build ships_dict from ship_counts list: keys 1..7.
    ships_dict = {i+1: ship_counts[i] for i in range(7)}
    
    # Initialize Player 1:
    p1_bs = BS1(height, width, ships_dict)
    p1_bs.place_ships()
    p1_board = p1_bs.get_board()
    p1_strat = ST1(height, width, ships_dict)
    p1_instances = get_ship_instances(p1_board)
    
    # Initialize Player 2:
    p2_bs = BS2(height, width, ships_dict)
    p2_bs.place_ships()
    p2_board = p2_bs.get_board()
    p2_strat = ST2(height, width, ships_dict)
    p2_instances = get_ship_instances(p2_board)
    
    moves = 0
    current_player = starting_player
    while moves < max_moves:
        moves += 1
        if current_player == 1:
            x, y = p1_strat.get_next_attack()
            hit, sunk = process_attack(x, y, p2_instances)
            p1_strat.register_attack(x, y, is_hit=hit, is_sunk=sunk)
            if verbose:
                print(f"Move {moves}: Player 1 attacks ({x},{y}) -> {'Hit' if hit else 'Miss'}{' and Sunk' if sunk else ''}")
            if all(ship["hits"] == ship["coords"] for ship in p2_instances):
                if verbose:
                    print(f"Player 1 wins after {moves} moves!")
                return 1, moves
            current_player = 2
        else:
            x, y = p2_strat.get_next_attack()
            hit, sunk = process_attack(x, y, p1_instances)
            p2_strat.register_attack(x, y, is_hit=hit, is_sunk=sunk)
            if verbose:
                print(f"Move {moves}: Player 2 attacks ({x},{y}) -> {'Hit' if hit else 'Miss'}{' and Sunk' if sunk else ''}")
            if all(ship["hits"] == ship["coords"] for ship in p1_instances):
                if verbose:
                    print(f"Player 2 wins after {moves} moves!")
                return 2, moves
            current_player = 1

    # If we exceeded max_moves, consider it a draw.
    if verbose:
        print(f"Battle ended in a draw after {moves} moves.")
    return 0, moves

# --------------------------
# Main function
# --------------------------

def main():
    parser = argparse.ArgumentParser(description="Battle simulation between two players.")
    parser.add_argument("-v", "--verbose", action="store_true", help="Verbose output")
    parser.add_argument("-c", "--count", type=int, default=100, help="Number of battles (default=100)")
    parser.add_argument("-W", "--width", type=int, default=10, help="Board width (default=10)")
    parser.add_argument("-H", "--height", type=int, default=10, help="Board height (default=10)")
    parser.add_argument("-l", "--list", type=str, default=None,
                        help="Comma-separated ship counts for IDs 1..7 (if specified, turns off random ship generation)")
    args = parser.parse_args()

    verbose = args.verbose
    battle_count = args.count
    width = args.width
    height = args.height

    if args.list is None:
        ship_counts = generate_random_ships(width, height)
        if verbose:
            print(f"Random ship counts generated: {ship_counts}")
    else:
        try:
            ship_counts = list(map(int, args.list.split(',')))
            if len(ship_counts) != 7:
                raise ValueError
        except ValueError:
            print("Invalid ship counts list. Must be 7 comma-separated integers.")
            sys.exit(1)

    wins = {1: 0, 2: 0, 0: 0}  # 0 indicates a draw.
    total_moves = 0

    for battle_num in range(1, battle_count+1):
        # Alternate starting player: if battle number is odd, Player 1 starts; if even, Player 2 starts.
        starting_player = 1 if (battle_num % 2 == 1) else 2
        if verbose:
            print(f"\n=== Battle {battle_num} (Player {starting_player} starts) ===")
        winner, moves = simulate_battle(verbose, width, height, ship_counts, starting_player)
        wins[winner] += 1
        total_moves += moves
        if verbose:
            outcome = "Draw" if winner == 0 else f"Winner: Player {winner}"
            print(f"Battle {battle_num} finished: {outcome} in {moves} moves.")

    avg_moves = total_moves / battle_count if battle_count else 0
    print("\n=== Overall Battle Results ===")
    print(f"Total battles: {battle_count}")
    print(f"Player 1 wins: {wins[1]}")
    print(f"Player 2 wins: {wins[2]}")
    print(f"Draws: {wins[0]}")
    print(f"Average game length: {avg_moves:.2f} moves")

if __name__ == "__main__":
    main()
