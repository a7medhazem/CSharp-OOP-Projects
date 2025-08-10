using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGame
{
    public class Maze
    {
        private int Width; // shape width of the game
        private int Height; // shape height of the game
        private Player _player;
        private IMazeObject[,] shape;// Contains the full layout of the game
        public Maze(int width, int height)
        {
            Width = width;
            Height = height;
            shape = new IMazeObject[Width, Height];
            _player = new Player()
            {
                // Set the starting position of the player '@'       
                X = 1,
                Y = 1
            };

        }
        
        public void DrawMaze()
        {
            Console.Clear();// To display a single layout of the output screen
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    if (i == _player.X && j == _player.Y)
                    {
                        //draw plyer
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(_player.Icon);
                        Console.ResetColor();

                    }
                    else
                    {
                        if (i == Width - 2 && j == Height - 1)
                        {
                            //draw exit position
                            Console.BackgroundColor = ConsoleColor.White;
                            shape[Width - 2, Height - 1] = new EmptySpace();
                            Console.Write(shape[Width - 2, Height - 1].Icon);
                            Console.ResetColor();
                        }
                        else if (i == 0 || j == 0 || i == Width - 1 || j == Height - 1 ||
                                 (i == Width - 4 && j >= 5) ||
                                 (i == Width - 6 && j <= Height - 4) ||
                                 (i == Width - 2 && j == Height - 4))
                        {
                            //draw walls
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.ForegroundColor = ConsoleColor.Black;

                            shape[i, j] = new Wall();
                            Console.Write(shape[i, j].Icon);

                            Console.ResetColor();
                        }

                        else
                        {
                            //draw empty spaces
                            shape[i, j] = new EmptySpace();
                            Console.Write(shape[i, j].Icon);
                        }
                    }

                }
                Console.WriteLine("");

            }
        }


        public void MovePlayer()
        {
            ConsoleKeyInfo Key = Console.ReadKey(); // Read information about the input key
            ConsoleKey UserInput = Key.Key;//store key info
            switch (UserInput)
            {
                case ConsoleKey.UpArrow:
                    UpdatePlayer(-1, 0);
                    break;
                case ConsoleKey.DownArrow:
                    UpdatePlayer(1, 0);
                    break;
                case ConsoleKey.RightArrow:
                    UpdatePlayer(0, 1);
                    break;
                case ConsoleKey.LeftArrow:
                    UpdatePlayer(0, -1);
                    break;
                default:
                    break;
            }
        }
        
        // Update the player's position after an arrow key is pressed
        private void UpdatePlayer(int dx, int dy)
        {
            int newX = _player.X + dx;
            int newY = _player.Y + dy;

            if (newX < Width && newX > 0 &&
                newY < Height && newY > 0
                && shape[newX, newY].IsSolid == false)
            {
                _player.X = newX;
                _player.Y = newY;
            }
            if (newX == Width - 2 && newY == Height - 1)
            {
                Console.WriteLine("You Win!");
                Environment.Exit(0);
            }
        }
    }
}
