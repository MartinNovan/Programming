using System.Diagnostics;

namespace async_methods_visualised;

internal static class AsyncDemo
{
    private static async Task Main()
    {
        Console.WriteLine("[Starting Asynchronous Methods]");
        await RunAsyncMethods();

        Console.WriteLine("\n[Starting Synchronous Methods]");
        RunSyncMethods();
    }

    private static async Task RunAsyncMethods()
    {
        Stopwatch stopwatch = Stopwatch.StartNew();

        Console.WriteLine("[Async Main Start]");

        // Start two asynchronous methods in parallel
        var task1 = Method1Async(stopwatch);
        var task2 = Method2Async(stopwatch);

        // Wait for both tasks to complete
        await Task.WhenAll(task1, task2);

        Console.WriteLine("[Async Main End] Time Elapsed: {0} ms", stopwatch.ElapsedMilliseconds);
    }

    private static void RunSyncMethods()
    {
        Stopwatch stopwatch = Stopwatch.StartNew();

        Console.WriteLine("[Sync Main Start]");

        // Execute two synchronous methods sequentially
        Method1Sync(stopwatch);
        Method2Sync(stopwatch);

        Console.WriteLine("[Sync Main End] Time Elapsed: {0} ms", stopwatch.ElapsedMilliseconds);
    }

    private static async Task Method1Async(Stopwatch stopwatch)
    {
        Log("[Async Method1 Start]", stopwatch);
        await Task.Delay(3000); // Simulate asynchronous delay
        Log("[Async Method1 End]", stopwatch);
    }

    private static async Task Method2Async(Stopwatch stopwatch)
    {
        Log("[Async Method2 Start]", stopwatch);
        await Task.Delay(1000); // Simulate shorter asynchronous delay
        Log("[Async Method2 End]", stopwatch);
    }

    private static void Method1Sync(Stopwatch stopwatch)
    {
        Log("[Sync Method1 Start]", stopwatch);
        Thread.Sleep(3000); // Simulate synchronous delay
        Log("[Sync Method1 End]", stopwatch);
    }

    private static void Method2Sync(Stopwatch stopwatch)
    {
        Log("[Sync Method2 Start]", stopwatch);
        Thread.Sleep(1000); // Simulate shorter synchronous delay
        Log("[Sync Method2 End]", stopwatch);
    }

    private static void Log(string message, Stopwatch stopwatch)
    {
        Console.WriteLine($"[{DateTime.Now:HH:mm:ss.fff}] {message} Time Elapsed: {stopwatch.ElapsedMilliseconds} ms");
    }
}