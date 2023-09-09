using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSnake.GameObjects.Foods
{
    public abstract class Food : Point
    {
        private char foodSymbol;
        private Random random;
        private Wall wall;
        protected Food(Wall wall, char foodSymbol, int points) : base(wall.LeftX, wall.TopY)
        {
            this.wall = wall;
            FoodPoints = points;
            this.foodSymbol = foodSymbol;
           
            random = new Random();
        }

        public int FoodPoints { get; private set; }
        public void SetRandomPosition(Queue<Point> snake)
        {
            int maxX = wall.LeftX - 2;
            int maxY = wall.TopY - 2;
            LeftX = random.Next(2, maxX);
            TopY = random.Next(2, maxY);

            bool isPointOfSnake = snake.Any(x => x.TopY == TopY && x.LeftX == LeftX);

            while (isPointOfSnake)
            {
                LeftX = random.Next(2, maxX);
                TopY = random.Next(2, maxY);

                isPointOfSnake = snake.Any(x => x.TopY == TopY && x.LeftX == LeftX);
            }

            Console.BackgroundColor = ConsoleColor.Red;
            Draw(foodSymbol);
            Console.BackgroundColor= ConsoleColor.White;
        }
        public bool IsFoodPoint(Point snake)
        {
            return snake.TopY == TopY && snake.LeftX == LeftX;
        }
        public abstract int GetFoodPoints();
    }
}
