namespace ThreadLockExplore;

internal class Program
{
    private const string FilePath = @"C:\\Users\\vladx\\RiderProjects\\CSharpExplore\\ThreadLockExplore\\file.txt";
    private static readonly object LockObject = new();

    private readonly SemaphoreSlim Semaphore = new(1);

    public static void Main(string[] args)
    {
        var range = Enumerable.Range(0, 100);
        range.AsParallel().ForAll(a => ReadFromFile());

        void ReadFromFile()
        {
            int fileData = Convert.ToInt32(File.ReadAllText(FilePath));
            Console.WriteLine("File value: " + fileData);
            using var writer = new StreamWriter(FilePath);
            fileData++;
            writer.WriteLine(fileData);
        }
    }
}