namespace TaskExample2;

public class Program
{
    private static string result;

    public static async Task Main(string[] args)
    {
        var a = await SaySomething();
        Console.WriteLine(result );
        Console.WriteLine("End");
    }

    private static async Task<string> SaySomething()
    {
        await Task.Delay(2000);
        result = "Hello, world";
        return "Something";
    }
}