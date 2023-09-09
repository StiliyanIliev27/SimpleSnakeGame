using SimpleSnake.Enums;
using SimpleSnake.GameObjects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSnake.Core
{
    public class Engine
    {
        private readonly GameObjects.Point[] pointsOfDirection;
        private Direction direction;
       
        private readonly Snake snake;
        private readonly Wall wall;

        private double sleepTime;

        public Engine(Wall wall, Snake snake)
        {
            this.wall = wall;
            this.snake = snake;
            
            sleepTime = 100;
           
            pointsOfDirection = new GameObjects.Point[4];

            pointsOfDirection[0] = new GameObjects.Point(1, 0);
            pointsOfDirection[1] = new GameObjects.Point(-1, 0);
           
            pointsOfDirection[2] = new GameObjects.Point(0, 1);
            pointsOfDirection[3] = new GameObjects.Point(0, -1);
        }
        public void Run()
        {
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    GetNextDirection();
                }

                bool isMoving = snake
                    .IsMoving(pointsOfDirection[(int)direction]);

                DrawPointsOnBoard();
                DrawLevelOnBoard();

                if(!isMoving)
                {
                    AskUserForRestart();
                }

                sleepTime -= 0.01;

                Thread.Sleep((int)sleepTime);
            }
        }
        private void GetNextDirection()
        {
            ConsoleKeyInfo userInput = Console.ReadKey();

            if(userInput.Key == ConsoleKey.LeftArrow)
            {
                if(direction != Direction.Right)
                {
                    direction = Direction.Left;
                }
            }
            else if(userInput.Key == ConsoleKey.RightArrow)
            {
                if(direction != Direction.Left)
                {
                    direction = Direction.Right;
                }
            }
            else if(userInput.Key == ConsoleKey.UpArrow)
            {
                if(direction != Direction.Down)
                {
                    direction = Direction.Up;
                }
            }
            else if (userInput.Key == ConsoleKey.DownArrow)
            {
                if (direction != Direction.Up)
                {
                    direction = Direction.Down;
                }
            }

            Console.CursorVisible = false;
           
            bool isMoving = snake
                .IsMoving(pointsOfDirection[(int)direction]);

            if (!isMoving)
            {
                AskUserForRestart();
            }
        }
        private void AskUserForRestart()
        {
            Console.SetCursorPosition(63, 2);
            Console.Write("Would you like to continue? y/n");

            string input = Console.ReadLine();

            if(input == "y")
            {
                Console.Clear();
                StartUp.Main();
            }
            else
            {
                StopGame();
            }
        }
        private void StopGame()
        {
            Console.SetCursorPosition(20, 10); 
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("Game over!");
            Environment.Exit(0);
        }
        private void DrawPointsOnBoard()
        {
            Console.SetCursorPosition(63, 6);
            Console.Write($"Total Experience: {snake.SnakePoints}");            
        }
        private void DrawLevelOnBoard()
        {
            Console.SetCursorPosition(63, 5);
            Console.Write($"Total level: {snake.Level}");
        }
    }
}
