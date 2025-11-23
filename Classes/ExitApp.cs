class ExitApp
{
    static public async void CloseApp()
    {
        Console.WriteLine("The app will close in:\n");
        Console.WriteLine("5\n");
        await
        TimeDelay.OneSec();
        Console.WriteLine("4\n");
        await
        TimeDelay.OneSec();
        Console.WriteLine("3\n");
        await
        TimeDelay.OneSec();
        Console.WriteLine("2\n");
        await
        TimeDelay.OneSec();
        Console.WriteLine("1\n");
        await
        TimeDelay.OneSec();
        Environment.Exit(0);
    }
}

class TimeDelay
{
    // Delay function to delay 1 second before continuing code execution
    static public async Task OneSec()
    {
        await Task.Delay(1000);
    }
}