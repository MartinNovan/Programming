# Battleships Game Mechanics

## Basic Rules
1. The game is played on a square grid (usually 10x10)
2. Each player has their own map with placed ships
3. The goal is to find and destroy all enemy ships

## Ship Types
| ID | Name | Size | Shape |
|----|------|------|-------|
| 1  | Destroyer | 2 | I |
| 2  | Cruiser | 3 | I |
| 3  | Battleship | 4 | I |
| 4  | Aircraft Carrier | 4 | T |
| 5  | Submarine | 4 | L |
| 6  | Cruiser II | 4 | Z |
| 7  | Super Ship | 6 | TT |

## Game Mechanics

### 1. Game Setup
- Each player places their ships on the map
- Ships must:
  - Be completely within the playing area
  - Not overlap
  - Have at least one cell space between them

### 2. Gameplay
- Players take turns attacking
- Attack is performed by entering coordinates (x,y)
- Attack result:
  - **Miss**: Cell is empty
  - **Hit**: Cell contains part of a ship
  - **Sunk**: Entire ship has been destroyed

### 3. End of Game
- The game ends when one player destroys all enemy ships

## Map Representation
- **0**: Empty water
- **1-7**: Ship ID
- **'M'**: Missed attack
- **'H'**: Hit

## Ship Placement Rules
1. Ships can be oriented horizontally or vertically
2. Special ships (T, L, Z, TT) have fixed shapes
3. Minimum distance between ships is 1 cell

## Sinking Detection
- A ship is considered sunk when all its cells are hit
- After sinking, adjacent cells are marked as empty

## Strategic Elements
- Efficient space searching
- Probability analysis of ship locations
- Shape and orientation detection
- Optimization of required number of attacks