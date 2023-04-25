using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Displaying_shapes
{
    class Collection_of_geometric_shapes
    {

        static List<object> AllShapes = new List<object>();

        static public void AddShape(object SomeKindOfShape)
        {
            AllShapes.Add(SomeKindOfShape);
        }

        static void Distributor(IPrint ConsolePrint)
        {
            ConsolePrint.ShowShape(ConsolePrint);
        }

        static public bool DysplayAllShapes()
        {
            if (AllShapes.FirstOrDefault() != null)
            {
                foreach (var item in AllShapes)
                    Distributor((IPrint)item);
                return true;
            }
            return false;
        }
    }
        class Program
        {
            static void Main(string[] args)
            {
                MainMenu menu = new MainMenu();
                menu.MenuMethod();
            }
        }
}