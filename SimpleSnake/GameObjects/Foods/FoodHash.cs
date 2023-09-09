using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSnake.GameObjects.Foods
{
    public class FoodHash : Food
    {
        private const char FoodSymbol = '#';
        private const int Points = 3;
        public FoodHash(Wall wall)
            : base(wall, FoodSymbol, Points)
        {
        }
        public override int GetFoodPoints()
        {
            return Points;
        }
    }
}
