using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSnake.GameObjects.Foods
{
    public class FoodDollar : Food
    {
        private const char FoodSymbol = '$';
        private const int Points = 2;
        public FoodDollar(Wall wall)
            : base(wall, FoodSymbol, Points)
        {
        }

        public override int GetFoodPoints()
        {
            return Points;
        }
    }
}
