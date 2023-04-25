using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;


namespace Displaying_shapes
{
    interface IPrint
    {
        void ShowShape(object shape);
    }
    abstract class Shape
    {
        public Shape()
        {
            FinalColor = (int)ConsoleColor.White;
            FinalSymbol = '*';
        }
        public int FinalColor { get; set; }
        public char FinalSymbol { get; set; }
        public int coordinateX { get; set; }
        public int coordinateY { get; set; }
        protected abstract char[,] PrintShapeInTHeCoordinatePosition();
        protected abstract int AdjustingTheXCoordinate(int XCoord);
        protected abstract int AdjustingTheYCoordinate(int Ycoord);
        public void positionSelection()
        {
            coordinateX = 50;  //20
            coordinateY = 10;  //10
            while (true)
            {
                ForegroundColor = ConsoleColor.White;
                Clear();
                WriteLine("LOCATION OF THE FIGURE");
                Collection_of_geometric_shapes.DysplayAllShapes();
                PrintShapeInTHeCoordinatePosition();
                ConsoleKeyInfo ckey = ReadKey();
                if (ckey.Key == ConsoleKey.DownArrow)
                    coordinateY += 1;
                if (ckey.Key == ConsoleKey.UpArrow)
                    coordinateY -= 1;
                if (ckey.Key == ConsoleKey.RightArrow)
                    coordinateX += 2;
                if (ckey.Key == ConsoleKey.LeftArrow)
                    coordinateX -= 2;
                if (ckey.Key == ConsoleKey.Enter)
                    break;
            }

        }

    }
    class Rectangle : Shape, IPrint
    {
        public Rectangle()
        {
            TheLongSide = 20;
            TheShortSide = 10;
        }
        public int TheLongSide { get; set; }
        public int TheShortSide { get; set; }
        protected override int AdjustingTheXCoordinate(int XCoord)
        {
            if (XCoord <= 0)
                return coordinateX = 0;
            return XCoord;
        }

        protected override int AdjustingTheYCoordinate(int Ycoord)
        {
            if (Ycoord <= 1)
                return coordinateY = 1;
            return Ycoord;
        }

        protected override char[,] PrintShapeInTHeCoordinatePosition()
        {
            int X = coordinateX;
            int Y = coordinateY;
            char[,] FinishedFigure = new char[TheShortSide, TheLongSide];
            AdjustingTheXCoordinate(coordinateX);
            AdjustingTheYCoordinate(coordinateY);
            SetCursorPosition(coordinateX, coordinateY);
            for (int i = 0; i < TheShortSide; i++)
            {
                for (int j = 0; j < TheLongSide; j++)
                {
                    ForegroundColor = (ConsoleColor)FinalColor;
                    Write($"{FinalSymbol,-2}");
                    FinishedFigure[i, j] = FinalSymbol;
                }
                coordinateY += 1;
                SetCursorPosition(coordinateX, coordinateY);
            }
            coordinateX = AdjustingTheXCoordinate(X);
            coordinateY = AdjustingTheYCoordinate(Y);
            return FinishedFigure;
        }
        public void ShowShape(object newrect)
        {
            Rectangle rect = (Rectangle)newrect;
            int X = rect.coordinateX;
            int Y = rect.coordinateY;
            SetCursorPosition(X, Y);
            for (int i = 0; i < rect.TheShortSide; i++)
            {
                for (int j = 0; j < rect.TheLongSide; j++)
                {
                    ForegroundColor = (ConsoleColor)rect.FinalColor;
                    Write($"{rect.FinalSymbol,-2}");
                }
                Y += 1;
                SetCursorPosition(X, Y);
            }
        }
    }
    class Rhomb : Shape, IPrint
    {
        public Rhomb()
        {
            TheDiagonal = 11;
        }
        public int TheDiagonal { get; set; }
        protected override int AdjustingTheXCoordinate(int XCoord)
        {
            if (XCoord <= TheDiagonal / 2)
            {
                coordinateX = TheDiagonal / 2 + 1;
                return coordinateX;
            }
            return XCoord;
        }

        protected override int AdjustingTheYCoordinate(int Ycoord)
        {
            if (Ycoord <= 1)
            {
                coordinateY = 1;
                return coordinateY;
            }
            return Ycoord;
        }

        protected override char[,] PrintShapeInTHeCoordinatePosition()
        {
            int X = coordinateX;
            int Y = coordinateY;
            char[,] FinishRhomb = new char[TheDiagonal, TheDiagonal];
            AdjustingTheXCoordinate(coordinateX);
            AdjustingTheYCoordinate(coordinateY);
            SetCursorPosition(coordinateX, coordinateY);
            int HalfDiagonal = TheDiagonal / 2 + 1;
            int TheSecondHalf = TheDiagonal - HalfDiagonal;
            TheDiagonal -= TheDiagonal;
            TheDiagonal++;
            for (int i = 0; i < HalfDiagonal; i++)
            {
                for (int j = 0; j < TheDiagonal; j++)
                {
                    ForegroundColor = (ConsoleColor)FinalColor;
                    Write($"{FinalSymbol,-2}");
                    FinishRhomb[i, j] = FinalSymbol;
                }
                WriteLine();
                SetCursorPosition(coordinateX -= 2, coordinateY += 1);
                TheDiagonal += 2;
            }
            TheDiagonal -= 4;
            SetCursorPosition(coordinateX += 4, coordinateY);
            for (int i = 0; i < TheSecondHalf; i++)
            {
                for (int j = 0; j < TheDiagonal; j++)
                {
                    ForegroundColor = (ConsoleColor)FinalColor;
                    Write($"{FinalSymbol,-2}");
                    FinishRhomb[i, j] = FinalSymbol;
                }
                WriteLine();
                SetCursorPosition(coordinateX += 2, coordinateY += 1);
                TheDiagonal -= 2;
            }
            TheDiagonal = HalfDiagonal + TheSecondHalf;
            coordinateX = AdjustingTheXCoordinate(X);
            coordinateY = AdjustingTheYCoordinate(Y);
            return FinishRhomb;
        }
        public void ShowShape(object newrhom)
        {
            Rhomb rhom = (Rhomb)newrhom;
            int X = rhom.coordinateX;
            int Y = rhom.coordinateY;
            int Diagonal = rhom.TheDiagonal;
            int HalfDiagonal = Diagonal / 2 + 1;
            int TheSecondHalf = Diagonal - HalfDiagonal;
            Diagonal -= Diagonal;
            Diagonal++;
            SetCursorPosition(X, Y);
            for (int i = 0; i < HalfDiagonal; i++)
            {
                for (int j = 0; j < Diagonal; j++)
                {
                    ForegroundColor = (ConsoleColor)rhom.FinalColor;
                    Write($"{rhom.FinalSymbol,-2}");
                }
                WriteLine();
                SetCursorPosition(X -= 2, Y += 1);
                Diagonal += 2;
            }
            Diagonal -= 4;
            SetCursorPosition(X += 4, Y);
            for (int i = 0; i < TheSecondHalf; i++)
            {
                for (int j = 0; j < Diagonal; j++)
                {
                    ForegroundColor = (ConsoleColor)rhom.FinalColor;
                    Write($"{rhom.FinalSymbol,-2}");
                }
                WriteLine();
                SetCursorPosition(X += 2, Y += 1);
                Diagonal -= 2;
            }
        }
    }
    class Triangle : Shape, IPrint
    {
        public Triangle()
        {
            height = 10;
            LenghthBase = height + height - 1;
        }
        public int height { get; set; }
        public int LenghthBase { get; set; }
        protected override int AdjustingTheXCoordinate(int XCoord)
        {
            if (XCoord <= LenghthBase / 2)
                return coordinateX = LenghthBase / 2 + 1;
            return XCoord;
        }

        protected override int AdjustingTheYCoordinate(int Ycoord)
        {
            if (Ycoord <= 1)
                return coordinateY = 1;
            return Ycoord;
        }

        protected override char[,] PrintShapeInTHeCoordinatePosition()
        {
            int X = coordinateX;
            int Y = coordinateY;
            char[,] FinishTriangle = new char[height, LenghthBase];
            coordinateX = AdjustingTheXCoordinate(coordinateX);
            coordinateY = AdjustingTheYCoordinate(coordinateY);
            SetCursorPosition(coordinateX, coordinateY);
            LenghthBase -= LenghthBase;
            LenghthBase++;
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < LenghthBase; j++)
                {
                    ForegroundColor = (ConsoleColor)FinalColor;
                    Write($"{FinalSymbol,-2}");
                    FinishTriangle[i, j] = FinalSymbol;
                }
                SetCursorPosition(coordinateX -= 2, coordinateY += 1);
                LenghthBase += 2;
            }
            coordinateX = AdjustingTheXCoordinate(X);
            coordinateY = AdjustingTheYCoordinate(Y);
            return FinishTriangle;
        }
        public void ShowShape(object newtrian)
        {
            Triangle trian = (Triangle)newtrian;
            int X = trian.coordinateX;
            int Y = trian.coordinateY;
            SetCursorPosition(X, Y);
            trian.LenghthBase -= trian.LenghthBase;
            trian.LenghthBase++;
            for (int i = 0; i < trian.height; i++)
            {
                for (int j = 0; j < trian.LenghthBase; j++)
                {
                    ForegroundColor = (ConsoleColor)trian.FinalColor;
                    Write($"{trian.FinalSymbol,-2}");
                }
                SetCursorPosition(X -= 2, Y += 1);
                trian.LenghthBase += 2;
            }
        }
    }
    class Trapezoid : Shape, IPrint
    {
        public Trapezoid()
        {
            height = 10;
            LowerBase = height * 2 + height - 2;
        }
        public int height { get; set; }
        public int LowerBase { get; set; }
        public int UpperBase { get; set; }
        protected override int AdjustingTheXCoordinate(int XCoord)
        {
            if (XCoord <= LowerBase / 2)
                return coordinateX = LowerBase / 2 + 1;
            return XCoord;
        }

        protected override int AdjustingTheYCoordinate(int Ycoord)
        {
            if (Ycoord <= 1)
                return coordinateY = 1;
            return Ycoord;
        }

        protected override char[,] PrintShapeInTHeCoordinatePosition()
        {
            int X = coordinateX;
            int Y = coordinateY;
            char[,] FinishedFigure = new char[height, LowerBase];
            AdjustingTheXCoordinate(coordinateX);
            AdjustingTheYCoordinate(coordinateY);
            SetCursorPosition(coordinateX, coordinateY);
            LowerBase = height;
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < LowerBase; j++)
                {
                    ForegroundColor = (ConsoleColor)FinalColor;
                    Write($"{FinalSymbol,-2}");
                    FinishedFigure[i, j] = FinalSymbol;
                }
                SetCursorPosition(coordinateX -= 2, coordinateY += 1);
                LowerBase += 2;
            }
            coordinateX = AdjustingTheXCoordinate(X);
            coordinateY = AdjustingTheYCoordinate(Y);
            return FinishedFigure;
        }
        public void ShowShape(object newtrap)
        {
            Trapezoid trap = (Trapezoid)newtrap;
            int X = trap.coordinateX;
            int Y = trap.coordinateY;
            SetCursorPosition(X, Y);
            trap.LowerBase = trap.height;
            for (int i = 0; i < trap.height; i++)
            {
                for (int j = 0; j < trap.LowerBase; j++)
                {
                    ForegroundColor = (ConsoleColor)trap.FinalColor;
                    Write($"{trap.FinalSymbol,-2}");
                }
                SetCursorPosition(X -= 2, Y += 1);
                trap.LowerBase += 2;
            }
        }
    }
}
