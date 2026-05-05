




internal class Program
{
    private static void Main(string[] args)
    {
        Queue<PrintingJop> printingJops = new Queue<PrintingJop>();
        printingJops.Enqueue(new PrintingJop("documentation.docx", 2));  //Enqueue() enter to queue
        printingJops.Enqueue(new PrintingJop("user-stories.pdf", 6));
        printingJops.Enqueue(new PrintingJop("report.xlsx", 6));
        printingJops.Enqueue(new PrintingJop("payroll.report", 5));
        printingJops.Enqueue(new PrintingJop("budget.xlsx", 4));
        printingJops.Enqueue(new PrintingJop("algorithm.ppt", 1));

        Console.WriteLine($"Current  Before while Queue Count: {printingJops.Count}");

        Random rnd = new Random();
        while (printingJops.Count > 0)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            var job = printingJops.Dequeue(); // Dequeue() delete F-O queue
            Console.WriteLine($"printing ... [{job}]");
            System.Threading.Thread.Sleep(rnd.Next(1, 5) * 1000);
        }
        Console.WriteLine($"Current after while Queue Count: {printingJops.Count}");
    }

class PrintingJop
{
    private readonly string _file;
    private readonly int _copies;

    public PrintingJop(string file, int copies)
    {
        _file = file;
        _copies = copies;
    }

    public override string ToString()
    {
        return $"{_file} x #{_copies} copies";
    }
}