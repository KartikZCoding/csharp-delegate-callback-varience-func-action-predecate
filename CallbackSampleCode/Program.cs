namespace CallbackSampleCode
{
    public delegate void PrintHelpDel(int amount);
    public delegate void MessageDel(string message);
    public class Program
    {
        static void Main(string[] args)
        {
            Program p =new Program();
            p.PrintNumber(100, p.Print); // pass delegate as parameter
            p.PrintNumber(200, p.Cost);
            p.Demo()("Hello from Demo"); // return delegate from method
        }

        public void Print(int price)
        {
            Console.WriteLine($"Price: {price}");
        }

        public void Cost(int cost)
        {
            Console.WriteLine($"Cost: {cost}");
        }

        public void PrintNumber(int amount, PrintHelpDel printHelpDel)
        {
            printHelpDel(amount);
        }

        public static void Message(string message)
        {
            Console.WriteLine($"Message: {message}");
        }
        public MessageDel Demo()
        {
            return Message;
        }
        

    }
}
