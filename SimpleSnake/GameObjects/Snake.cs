using SimpleSnake.GameObjects.Foods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSnake.GameObjects
{
    public class Snake
    {
        private const char SnakeSymbol = '\u25CF';

        private readonly Queue<Point> snakeElements;
        private readonly Food[] food;
        private readonly Wall wall;
        
        private int foodIndex;

        private int nextLeftX;
        private int nextTopY;

        private int snakePoints;
        private int level;
        public Snake(Wall wall)
        {
            snakeElements = new Queue<Point>();
            snakePoints = 0;
            level = 0;
            
            this.wall = wall;
            food = new Food[3];
           
            foodIndex = RandomFoodNumber;
            
            GetFoods();
            CreateSnake();

            food[foodIndex].SetRandomPosition(snakeElements);
        }
        private int RandomFoodNumber => new Random().Next(0, food.Length); 
        private int TopY { get; set; }
        private int LeftX { get; set; }
        public int SnakePoints => snakePoints;
        public int Level => level;
        private void CreateSnake()
        {
            for(int topY = 1; topY <= 6; topY++)
            {
                snakeElements.Enqueue(new Point(2, topY));
            }
        }        
        private void GetFoods()
        {
            food[0] = new FoodHash(wall);
            food[1] = new FoodDollar(wall);
            food[2] = new FoodAsterisk(wall);
        }
        private void GetNextPoint(Point direction, Point snakeHead)
        {
            nextLeftX = snakeHead.LeftX + direction.LeftX;
            nextTopY = snakeHead.TopY + direction.TopY;
        }
        public bool IsPointOfWall(Point snake)
        {
            return snake.TopY == 0 || snake.LeftX == 0 ||
                snake.LeftX == LeftX - 1 || snake.TopY == TopY;
        }

        public bool IsMoving(Point direction)
        {
            Point currentSnakeHead = snakeElements.Last();

            GetNextPoint(direction, currentSnakeHead);

            bool isPointOfSnake = snakeElements
                .Any(x => x.LeftX == nextLeftX && x.TopY == nextTopY);

            if(isPointOfSnake)
            {
                return false;
            }

            Point snakeNewHead = new Point(nextLeftX, nextTopY);

            bool isWall = wall.IsPointOfWall(snakeNewHead);

            if (isWall)
            {
                return false;
            }

            snakeElements.Enqueue(snakeNewHead);
            snakeNewHead.Draw(SnakeSymbol);

            if (food[foodIndex].IsFoodPoint(snakeNewHead))
            {
                Eat(direction, currentSnakeHead);
            }

            Point snakeTail = snakeElements.Dequeue();
            snakeTail.Draw(' ');

            return true;
        }
        private void Eat(Point direction, Point currentSnakeHead)
        {
            int length = food[foodIndex].FoodPoints;

            for(int i = 0; i < length; i++)
            {
                snakeElements.Enqueue(new Point(nextLeftX, nextTopY));
                GetNextPoint(direction, currentSnakeHead);
            }

            IncreaseEatenFoodPoints();
            IncreaseLevel();

            foodIndex = RandomFoodNumber;
            food[foodIndex].SetRandomPosition(snakeElements);
        }
        private void IncreaseEatenFoodPoints()
        {
            if (food[foodIndex].GetType() == typeof(FoodAsterisk))
            {
                snakePoints += food[foodIndex].GetFoodPoints();
            }
            else if (food[foodIndex].GetType() == typeof(FoodHash))
            {
                snakePoints += food[foodIndex].GetFoodPoints();
            }
            else if (food[foodIndex].GetType() == typeof(FoodDollar))
            {
                snakePoints += food[foodIndex].GetFoodPoints();
            }
        }
        private void IncreaseLevel()
        {
            if (snakePoints >= (level + 1) * 5)
            {
                level++;
            }
        }
    }
}
