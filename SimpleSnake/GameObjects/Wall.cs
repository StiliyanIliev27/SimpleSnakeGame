using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSnake.GameObjects
{
    public class Wall : Point
    {
        private const char WallSymbol = '\u25A0';
        public Wall(int leftX, int topY) : base(leftX, topY)
        {
            InitializeWallBorders();
        }

        public bool IsPointOfWall(Point snakeHead)
        {
            return snakeHead.LeftX == 0
                || snakeHead.TopY == 0
                || snakeHead.LeftX == this.LeftX
                || snakeHead.TopY == this.TopY;
        }
        private void SetHorizontalLine(int topY)
        {
            for (int leftX = 0; leftX < LeftX; leftX++)
            {
                Draw(leftX, topY, WallSymbol);
            }
        }
        private void SetVerticalLine(int leftX)
        {
            for (int topY = 0; topY < TopY; topY++)
            {
                Draw(leftX, topY, WallSymbol);
            }
        }
        private void InitializeWallBorders()
        {
            SetHorizontalLine(0);

            SetVerticalLine(0);
            SetVerticalLine(LeftX - 1);

            SetHorizontalLine(TopY);
        }
    }
}
