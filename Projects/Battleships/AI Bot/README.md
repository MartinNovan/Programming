# Battleships AI Robot

## Introduction
This project presents an intelligent robot for the game "Battleships". The robot uses advanced strategies and probability analysis to efficiently search for and destroy enemy ships. Version 1.3.2 introduces significant improvements in attack efficiency and ship detection accuracy.

## Key Features
- **Adaptive strategy**: The robot adjusts its approach based on previous attack results
- **Probability map**: Creates a dynamic probability map of ship locations with improved accuracy
- **Ship shape detection**: Enhanced recognition of various ship shapes and orientations
- **Efficient search**: Optimized algorithms to minimize the number of required attacks
- **Performance tracking**: Built-in performance monitoring and analysis

## Main Components

### 1. Attack Strategy
- **Initial phase**: Optimized checkerboard pattern with improved probability distribution
- **Tracking phase**: Enhanced adjacent cell analysis after a hit
- **Destruction phase**: Advanced algorithms for faster ship sinking

### 2. Probability Model
- Improved dynamic probability map
- Enhanced calculations considering:
  - Locations of already hit cells
  - Remaining ship types
  - Possible ship orientations
  - Edge and corner probabilities

### 3. Ship Detection
- Advanced recognition of:
  - Ship sizes
  - Shapes (I, L, T, Z, TT)
  - Orientations (horizontal, vertical)
  - Partial ship patterns

## Performance
- Average number of attempts to win: 40-50 (playing against itself)
- Success rate: >99% on standard 10x10 map
- Time complexity: <0.5s per move
- Win rate against previous versions:
  - 1.3.2 vs v1.3.1 -> 93.83% 
  - 1.3.1 vs v1.2 -> 84.00%

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
- See more in [Updates](Updates.md) and [Generational Difference](GenerationalBattleResults.md).