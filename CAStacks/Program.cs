
using System.Diagnostics.Contracts;



internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("STACKS");

        Stack<Command> undo = new Stack<Command>();
        Stack<Command> redo = new Stack<Command>();

        string line;

        while (true)
        {
            Console.Write("URL (EXIT TO 'QUIT') : ");
            line = Console.ReadLine().ToLower();

            if (line == "exit")
                break;
            else if (line == "back")
                if (undo.Count > 0)
                {
                    var item = undo.Pop();
                    redo.Push(item);
                }
                else
                {
                    continue;
                }
            else if (line == "forward")
                if (redo.Count > 0)
                {
                    var item = redo.Pop();
                    undo.Push(item);
                }
                else
                {
                    continue;
                }
            else
            {
                // add url line
                undo.Push(new Command (line));
            }
            Console.Clear();
            Print("back", undo);
            Print("forward", redo);

        }//end of while


        Stack<int> numbers = new Stack<int>(new List<int> { 1, 2, 3 });

        while (numbers.Count > 0)
        {
            var n = numbers.Peek();  // peek() only pointer to the top of a stack without delete otherwise pop() is deleting the top of a stack

            Console.WriteLine(n);
        }



    } // END OF MAIN
    public static void Print(string name,Stack<Command> commands)
    {   
        Console.WriteLine($"{name} History");
        Console.BackgroundColor = name.ToLower() == "back" ? ConsoleColor.DarkGreen : ConsoleColor.Magenta;
        foreach (var u in commands)
        {
            Console.WriteLine($"\t{u}");
        }
        Console.BackgroundColor = ConsoleColor.Black;



    } // end of method
} // END OF PROGRAM

class Command
{
    private readonly DateTime _createat;
    private readonly string _url;

    public Command(string _url)
    {
        _createat = DateTime.Now;
        this._url = _url;
    }
    public override string ToString()
    {
        return $"[{this._createat.ToString("yyyy-MM-dd hh:mm")}] {this._url}";
    }
}