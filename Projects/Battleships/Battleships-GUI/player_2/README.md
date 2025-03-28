# Battleships AI Robot

## Introduction
This project presents an intelligent robot for the game "Battleships". The robot uses advanced strategies and probability analysis to efficiently search for and destroy enemy ships.

## Key Features
- **Adaptive strategy**: The robot adjusts its approach based on previous attack results
- **Probability map**: Creates a dynamic probability map of ship locations
- **Ship shape detection**: Recognizes various ship shapes and orientations
- **Efficient search**: Uses optimized algorithms to minimize the number of required attacks

## Main Components

### 1. Attack Strategy
- **Initial phase**: Random selection of cells in a checkerboard pattern
- **Tracking phase**: Focuses on adjacent cells after a hit
- **Destruction phase**: Optimizes attacks to sink detected ships

### 2. Probability Model
- Dynamically updated probability map
- Takes into account:
  - Locations of already hit cells
  - Remaining ship types
  - Possible ship orientations

### 3. Ship Detection
- Automatic recognition of:
  - Ship sizes
  - Shapes (I, L, T, Z, TT)
  - Orientations (horizontal, vertical)

## Performance
- Average number of attempts to win: 45-55 (playing against itself)
- Success rate: >95% on standard 10x10 map
- Time complexity: <1s per move

## Usage
```python
# Initialization
strategy = Strategy(rows=10, cols=10, ships_dict={1:1, 2:1, 3:1, 4:1, 5:1})

# Get next attack
x, y = strategy.get_next_attack()

# Register result
strategy.register_attack(x, y, is_hit=True, is_sunk=False)
```

## Development
- **Version 1.0**: Basic implementation
- **Version 1.1**: Improved ship shape detection
- **Version 1.2**: Probability model optimization