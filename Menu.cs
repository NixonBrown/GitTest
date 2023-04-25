using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.Threading;

namespace Displaying_shapes
{
    abstract class Menu
    {
        public abstract string Heading { get; set; }
        public abstract void MenuMethod();
        public ConsoleKeyInfo Choice(List<string> MainMenu, string annotation, ref int index)
        {
            ForegroundColor = ConsoleColor.White;
            WriteLine(annotation);
            for (int i = 0; i < MainMenu.Count; i++)
            {
                if (i == index)
                {
                    BackgroundColor = ConsoleColor.Gray;
                    ForegroundColor = ConsoleColor.Black;
                    WriteLine(MainMenu[i]);
                }
                else
                    WriteLine(MainMenu[i]);
                ResetColor();
            }
            ConsoleKeyInfo ckey = ReadKey();
            if (ckey.Key == ConsoleKey.DownArrow)
            {
                if (index == MainMenu.Count - 1)
                    index = 0;
                else
                    index++;
            }
            if (ckey.Key == ConsoleKey.UpArrow)
            {
                if (index <= 0)
                    index = MainMenu.Count - 1;
                else
                    index--;
            }
            Clear();
            return ckey;
        }
        public void ColorMenuMethod(ref int defcolor)
        {
            Heading = "CHOOSING THE SHAPE COLOR";
            int index = 0;
            List<string> Menu = new List<string>()
            {
                "Gray",
                "Blue",
                "Green",
                "Cyan",
                "Red",
                "Magenta",
                "Yellow",
                "White",
                "<- Back",
                "Exit"
            };
            while (true)
            {
                if (Choice(Menu, Heading, ref index).Key == ConsoleKey.Enter)
                {
                    if (index >= 0 && index < 8)
                    {
                        ColorReturn(index, ref defcolor);
                        break;
                    }
                    if (index == 8)
                        break;
                    if (index == 9)
                        Environment.Exit(0);
                }
                Clear();
            }
        }
        public void ColorReturn(int colornumber, ref int shcolor)
        {
            if (colornumber == 0)
                shcolor = (int)ConsoleColor.Gray;
            if (colornumber == 1)
                shcolor = (int)ConsoleColor.Blue;
            if (colornumber == 2)
                shcolor = (int)ConsoleColor.Green;
            if (colornumber == 3)
                shcolor = (int)ConsoleColor.Cyan;
            if (colornumber == 4)
                shcolor = (int)ConsoleColor.Red;
            if (colornumber == 5)
                shcolor = (int)ConsoleColor.Magenta;
            if (colornumber == 6)
                shcolor = (int)ConsoleColor.Yellow;
            if (colornumber == 7)
                shcolor = (int)ConsoleColor.White;
        }
        public void SymbolMenuMethod(ref char SHsymbol)
        {
            Heading = "SELECTING THE SYMBOL THAT THE FIGURE WILL CONSIST OF";
            int index = 0;
            List<string> Menu = new List<string>()
            {
                "!",
                "#",
                "$",
                "%",
                "&",
                "*",
                "=",
                "?",
                "@",
                "+",
                "-",
                "<- Back",
                "Exit"
            };
            while (true)
            {
                if (Choice(Menu, Heading, ref index).Key == ConsoleKey.Enter)
                {
                    if (index >= 0 && index < 11)
                    {
                        SymbolReturn(index, ref SHsymbol);
                        break;
                    }
                    if (index == 11)
                        break;
                    if (index == 12)
                        Environment.Exit(0);
                }
                Clear();
            }
        }
        public void SymbolReturn(int symbolnumber, ref char symbol)
        {
            if (symbolnumber == 0)
                symbol = '!';
            if (symbolnumber == 1)
                symbol = '#';
            if (symbolnumber == 2)
                symbol = '$';
            if (symbolnumber == 3)
                symbol = '%';
            if (symbolnumber == 4)
                symbol = '&';
            if (symbolnumber == 5)
                symbol = '*';
            if (symbolnumber == 6)
                symbol = '=';
            if (symbolnumber == 7)
                symbol = '?';
            if (symbolnumber == 8)
                symbol = '@';
            if (symbolnumber == 9)
                symbol = '+';
            if (symbolnumber == 10)
                symbol = '-';
        }
    }
    class MainMenu : Menu
    {
        public override string Heading { get; set; } = "CHOOSING A SHAPE";
        public override void MenuMethod()
        {
            int index = 0;
            List<string> Menu = new List<string>()
            {
                "Rectangle",
                "Rhomb",
                "Triangle",
                "Trapezoid",
                "All shapes",
                "Exit"
            };
            while (true)
            {
                ConsoleKey keykey = Choice(Menu, Heading, ref index).Key;
                if (keykey == ConsoleKey.Enter)
                {
                    if (index == 0)
                    {
                        RectMenu rect = new RectMenu();
                        rect.MenuMethod();
                    }
                    if (index == 1)
                    {
                        RhombMenu rhomb = new RhombMenu();
                        rhomb.MenuMethod();
                    }
                    if (index == 2)
                    {
                        TriangleMenu triangle = new TriangleMenu();
                        triangle.MenuMethod();
                    }
                    if (index == 3)
                    {
                        TrapezoidMenu trapezoid = new TrapezoidMenu();
                        trapezoid.MenuMethod();
                    }
                    if (index == 4)
                    {
                        if (Collection_of_geometric_shapes.DysplayAllShapes())
                        {
                            while (true)
                            {
                                Clear();
                                Write("ALL SHAPES");
                                Collection_of_geometric_shapes.DysplayAllShapes();
                                ConsoleKeyInfo ckey = ReadKey();
                                if (ckey.Key == ConsoleKey.Escape)
                                    break;
                                ForegroundColor = ConsoleColor.White;
                            }
                        }
                        else
                        {
                            SetCursorPosition(20, 10);
                            Write("NO SHAPES ADDED");
                            Thread.Sleep(3000);
                        }

                    }
                    if (index == 5)
                        return;
                }
                else if (keykey == ConsoleKey.Escape)
                    return;
                Clear();
            }
        }
    }
    class RectMenu : Menu
    {
        public override string Heading { get; set; } = "DEFINING RECTANGLE PARAMETERS";

        public override void MenuMethod()
        {
            Rectangle rectangle = new Rectangle();
            Clear();
            int index = 0;
            List<string> Menu = new List<string>()
            {
                "The first side",
                "The second side",
                "Shape color",
                "The symbols that the figure will consist of",
                "Location of the figure",
                "<- Back",
                "Exit"
            };
            while (true)
            {
                ConsoleKey keykey = Choice(Menu, Heading, ref index).Key;
                if (keykey == ConsoleKey.Enter)
                {
                    if (index == 0)
                    {
                        Clear();
                        WriteLine("THE FIRST SIDE");
                        Write("Enter value: ");
                        rectangle.TheLongSide = int.Parse(ReadLine());
                    }
                    if (index == 1)
                    {
                        Clear();
                        WriteLine("THE SECOND SIDE");
                        Write("Enter value: ");
                        rectangle.TheShortSide = int.Parse(ReadLine());
                    }
                    if (index == 2)
                    {
                        int RecColor = 0;
                        Clear();
                        ColorMenuMethod(ref RecColor);
                        rectangle.FinalColor = RecColor;
                    }
                    if (index == 3)
                    {
                        char RecSymbol = ' ';
                        Clear();
                        SymbolMenuMethod(ref RecSymbol);
                        rectangle.FinalSymbol = RecSymbol;
                    }
                    if (index == 4)
                    {
                        rectangle.positionSelection();
                        Clear();
                        SetCursorPosition(20, 10);
                        ForegroundColor = ConsoleColor.White;
                        Write("--SAVED--");
                        Collection_of_geometric_shapes.AddShape(rectangle);
                        Thread.Sleep(3000);
                        break;
                    }
                    if (index == 5)
                        break;
                    if (index == 6)
                        Environment.Exit(0);
                }
                else if (keykey == ConsoleKey.Escape)
                    break;
                Clear();
            }
        }
    }
    class RhombMenu : Menu
    {
        public override string Heading { get; set; } = "DEFINING RHOMB PARAMETERS";

        public override void MenuMethod()
        {
            Rhomb rhomb = new Rhomb();
            Clear();
            int index = 0;
            List<string> Menu = new List<string>(6)
            {
                "Diamond size",
                "Shape color",
                "The symbols that the figure will consist of",
                "Location of the figure",
                "<- Back",
                "Exit"
            };
            while (true)
            {
                ConsoleKey keykey = Choice(Menu, Heading, ref index).Key;
                if (keykey == ConsoleKey.Enter)
                {
                    if (index == 0)
                    {
                        while (true)
                        {
                            Clear();
                            WriteLine("DIAMOND SIZE");
                            WriteLine("The value must be odd and equal to at least five \nfor the correct display of the figure");
                            Write("Enter value: ");
                            rhomb.TheDiagonal = int.Parse(ReadLine());
                            if (rhomb.TheDiagonal < 5 || rhomb.TheDiagonal % 2 == 0)
                            {
                                Clear();
                                SetCursorPosition(10, 2);
                                WriteLine("Incorrect data");
                                Thread.Sleep(3000);
                            }
                            else
                                break;
                        }
                    }
                    if (index == 1)
                    {
                        int RhomColor = 0;
                        Clear();
                        ColorMenuMethod(ref RhomColor);
                        rhomb.FinalColor = RhomColor;
                    }
                    if (index == 2)
                    {
                        char RhomSymb = ' ';
                        Clear();
                        SymbolMenuMethod(ref RhomSymb);
                        rhomb.FinalSymbol = RhomSymb;
                    }
                    if (index == 3)
                    {
                        rhomb.positionSelection();
                        Clear();
                        SetCursorPosition(20, 10);
                        ForegroundColor = ConsoleColor.White;
                        Write("--SAVED--");
                        Collection_of_geometric_shapes.AddShape(rhomb);
                        Thread.Sleep(3000);
                        break;
                    }
                    if (index == 4)
                        break;
                    if (index == 5)
                        Environment.Exit(0);
                }
                else if (keykey == ConsoleKey.Escape)
                    break;
                Clear();
            }
        }
    }
    class TriangleMenu : Menu
    {
        public override string Heading { get; set; } = "DEFINING TRIANGLE PARAMETERS";

        public override void MenuMethod()
        {
            Triangle triangle = new Triangle();
            Clear();
            int index = 0;
            List<string> Menu = new List<string>(6)
            {
                "Triangle size",
                "Shape color",
                "The symbols that the figure will consist of",
                "Location of the figure",
                "<- Back",
                "Exit"
            };
            while (true)
            {
                ConsoleKey keykey = Choice(Menu, Heading, ref index).Key;
                if (keykey == ConsoleKey.Enter)
                {
                    if (index == 0)
                    {
                        Clear();
                        WriteLine("TRIANGLE SIZE");
                        Write("Enter value: ");
                        triangle.height = int.Parse(ReadLine());
                        triangle.LenghthBase = triangle.height + triangle.height - 1;
                    }
                    if (index == 1)
                    {
                        int TriColor = 0;
                        Clear();
                        ColorMenuMethod(ref TriColor);
                        triangle.FinalColor = TriColor;
                    }
                    if (index == 2)
                    {
                        char TriSymbol = ' ';
                        Clear();
                        SymbolMenuMethod(ref TriSymbol);
                        triangle.FinalSymbol = TriSymbol;
                    }
                    if (index == 3)
                    {
                        triangle.positionSelection();
                        Clear();
                        SetCursorPosition(20, 10);
                        ForegroundColor = ConsoleColor.White;
                        Write("--SAVED--");
                        Collection_of_geometric_shapes.AddShape(triangle);
                        Thread.Sleep(3000);
                        break;
                    }
                    if (index == 4)
                        break;
                    if (index == 5)
                        Environment.Exit(0);
                }
                else if (keykey == ConsoleKey.Escape)
                    break;
                Clear();
            }
        }
    }
    class TrapezoidMenu : Menu
    {
        public override string Heading { get; set; } = "DEFINING TRAPEZOID PARAMETERS";

        public override void MenuMethod()
        {
            Trapezoid trapezoid = new Trapezoid();
            Clear();
            int index = 0;
            List<string> Menu = new List<string>(6)
            {
                "Trapezoid size",
                "Shape color",
                "The symbols that the figure will consist of",
                "Location of the figure",
                "<- Back",
                "Exit"
            };
            while (true)
            {
                ConsoleKey keykey = Choice(Menu, Heading, ref index).Key;
                if (keykey == ConsoleKey.Enter)
                {
                    if (index == 0)
                    {
                        Clear();
                        WriteLine("TRAPEZOID SIZE");
                        Write("Enter value: ");
                        trapezoid.height = int.Parse(ReadLine());
                        trapezoid.LowerBase = trapezoid.height * 2 + trapezoid.height - 2;
                    }
                    if (index == 1)
                    {
                        int TrapColor = 0;
                        Clear();
                        ColorMenuMethod(ref TrapColor);
                        trapezoid.FinalColor = TrapColor;
                    }
                    if (index == 2)
                    {
                        char TrapSymbol = ' ';
                        Clear();
                        SymbolMenuMethod(ref TrapSymbol);
                        trapezoid.FinalSymbol = TrapSymbol;
                    }
                    if (index == 3)
                    {
                        trapezoid.positionSelection();
                        Clear();
                        SetCursorPosition(20, 10);
                        ForegroundColor = ConsoleColor.White;
                        Write("--SAVED--");
                        Collection_of_geometric_shapes.AddShape(trapezoid);
                        Thread.Sleep(3000);
                        break;
                    }
                    if (index == 4)
                        break;
                    if (index == 5)
                        Environment.Exit(0);
                }
                else if (keykey == ConsoleKey.Escape)
                    break;
                Clear();
            }
        }
    }
}