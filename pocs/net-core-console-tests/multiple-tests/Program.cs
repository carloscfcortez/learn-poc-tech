using System.Threading.Tasks;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");


        #region Testing tasks
        Task mytaskTest = new Task(() =>
        {
            Console.WriteLine("My task console test");
        });
        mytaskTest.Start();
        mytaskTest.Wait();
        Console.WriteLine("After start");

        #endregion
    }
}
