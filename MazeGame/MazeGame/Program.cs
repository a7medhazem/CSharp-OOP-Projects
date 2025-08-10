namespace MazeGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\t Hello to Maze Game! ");
            Console.WriteLine("****************************************");
            Console.WriteLine("Use keyboard arrows to move the player. ");
            Console.WriteLine("****************************************");
            Console.Write("Press Any Key to start:");
            Console.ReadKey();

            Maze maze = new Maze(9, 30);


            while (true)
            {
                maze.DrawMaze();
                maze.MovePlayer();

            }

        }
    }
}
