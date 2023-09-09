using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSnake.GameObjects.Foods
{
    public class FoodAsterisk : Food
    {
        private const char FoodSymbol = '*';
        private const int Points = 1;
        public FoodAsterisk(Wall wall)
            : base(wall, FoodSymbol, Points)
        {
        }
        public override int GetFoodPoints()
        {
            return Points;
        }
    }
}
