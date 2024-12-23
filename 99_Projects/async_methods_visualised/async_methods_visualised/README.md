# Async Methods Visualised

This project demonstrates the difference between **asynchronous** and **synchronous** methods in C#. It compares their execution behavior and the time taken for completion using a simple console application.

## Key Concepts

### Asynchronous Methods in C#
- **Asynchronous programming** allows multiple tasks to run concurrently, without blocking the execution of other tasks.
- In C#, the `async` and `await` keywords are used to define and work with asynchronous methods.
- **Advantages**:
    - Improves responsiveness in applications (e.g., UI applications).
    - Utilizes system resources more efficiently.
- **Disadvantages**:
    - Requires careful handling to avoid bugs like deadlocks or unhandled exceptions.

### Synchronous Methods in C#
- **Synchronous programming** executes tasks sequentially. Each task must finish before the next one starts.
- **Advantages**:
    - Simpler to write and debug.
- **Disadvantages**:
    - Can block the main thread, leading to reduced performance and unresponsiveness.

---

## How It Works

The program runs two scenarios:
1. **Asynchronous execution** of `Method1Async` and `Method2Async`.
2. **Synchronous execution** of `Method1Sync` and `Method2Sync`.

Each method simulates work using delays:
- `Method1`: 3000ms (3 seconds)
- `Method2`: 1000ms (1 second)

### Code Overview
#### Asynchronous Execution
- Methods `Method1Async` and `Method2Async` run concurrently using `Task.WhenAll`.
- Non-blocking delays are introduced using `Task.Delay`.

#### Synchronous Execution
- Methods `Method1Sync` and `Method2Sync` execute sequentially.
- Blocking delays are introduced using `Thread.Sleep`.

#### Output Logging
- Timestamps and elapsed times are logged using a `Stopwatch` to highlight performance differences.

---

## Execution Example

### Output

#### Asynchronous Methods
```[Starting Asynchronous Methods]
[Async Main Start]
[19:12:49.970] [Async Method1 Start] Time Elapsed: 28 ms
[19:12:49.999] [Async Method2 Start] Time Elapsed: 31 ms
[19:12:51.002] [Async Method2 End] Time Elapsed: 1033 ms
[19:12:53.007] [Async Method1 End] Time Elapsed: 3039 ms
[Async Main End] Time Elapsed: 3039 ms
```
#### Synchronous Methods
```
[Starting Synchronous Methods]
[Sync Main Start]
[19:12:53.009] [Sync Method1 Start] Time Elapsed: 1 ms
[19:12:56.014] [Sync Method1 End] Time Elapsed: 3006 ms
[19:12:56.015] [Sync Method2 Start] Time Elapsed: 3006 ms
[19:12:57.023] [Sync Method2 End] Time Elapsed: 4014 ms
[Sync Main End] Time Elapsed: 4015 ms
```

---

## Observations
- **Asynchronous Execution**:
    - Both methods start almost simultaneously.
    - Total execution time: ~3 seconds (time of the longest task).

- **Synchronous Execution**:
    - Methods execute one after another.
    - Total execution time: ~4 seconds (sum of both tasks).

### Visual Comparison
| **Scenario**           | **Start Time (ms)** | **End Time (ms)** | **Total Time (ms)** |
|-------------------------|---------------------|-------------------|---------------------|
| **Asynchronous Methods**| ~28                 | ~3039             | ~3039              |
| **Synchronous Methods** | ~1                  | ~4014             | ~4015              |
* Note: The actual start and end times may vary slightly due to system performance.
* Note: The first method takes longer because of .NET runtime initialization, JIT compilation, and dependency loading when the application starts, regardless of whether it is asynchronous or synchronous. This effect is natural and subsequent method calls are no longer affected.
---

## Usage

### Prerequisites
- .NET 6.0 or higher installed.

### Run the Application
1. Clone the repository:
   ```bash
   git clone https://github.com/MartinNovan/Programming
2. Navigate to the project directory and run:
   ```bash
   dotnet run

## Conclusion
This example highlights the efficiency of asynchronous programming for non-blocking operations. While synchronous methods are simpler, asynchronous methods are preferred for improving application responsiveness and performance in tasks that involve I/O operations or long-running processes.