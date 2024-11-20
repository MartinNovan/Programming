# Understanding Hash Maps

## Overview

A hash map (or hash table) is a data structure that implements an associative array, a structure that can map keys to values. Hash maps are designed to provide fast insertion, deletion, and lookup operations. They achieve this efficiency by using a hash function to compute an index into an array of buckets or slots, from which the desired value can be found.

## How Hash Maps Work

1. **Hash Function**: A hash function takes an input (or 'key') and returns an integer, which is used as an index in the hash table. The goal of the hash function is to distribute the keys uniformly across the hash table.

2. **Collision Handling**: When two keys hash to the same index, a collision occurs. There are several strategies to handle collisions:
   - **Chaining**: Each slot in the hash table contains a linked list of entries that hash to the same index.
   - **Open Addressing**: When a collision occurs, the algorithm searches for the next available slot in the array.

## Implementations

### 1. Array Implementation

#### `01_array.py`
This implementation uses a simple list to store elements. It measures the time taken to add and find elements in batches.

- **Performance**: This method is straightforward but can be slow for large datasets, especially for lookups, as it requires linear time complexity in the worst case.

### 2. Chaining Hash Map

#### `02_hashmap_chaining.py`
This implementation uses chaining to handle collisions. Each index in the hash table points to a list of entries.

- **Performance**: Chaining allows for efficient handling of collisions, but performance can degrade if many keys hash to the same index.

### 3. Open Addressing Hash Map

#### `03_hashmap_open_addressing.py`
This implementation uses open addressing to resolve collisions. When a collision occurs, it searches for the next available slot.

- **Performance**: Open addressing can be more space-efficient than chaining but may lead to clustering, which can degrade performance.

### 4. Built-in Hash Map

#### `04_built_in_hashmap.py`
This implementation uses Python's built-in dictionary, which is optimized for performance.

- **Performance**: The built-in hash map is highly efficient and handles collisions internally, making it the preferred choice for most applications.

## Performance Comparison

Each implementation has different performance characteristics based on how they handle collisions and the underlying data structure used. The built-in hash map is generally the fastest due to its optimizations, while the array implementation is the simplest but least efficient for large datasets.

## Conclusion

Hash maps are a powerful data structure that provides efficient key-value storage and retrieval. Understanding how they work and their performance characteristics is essential for effective programming and algorithm design. By comparing different implementations, we can appreciate the trade-offs involved in choosing the right data structure for a given problem.