using Utilities.Math;
using System;
using System.Diagnostics;
namespace Integration
{
    class Program
    { 
        static void Main(string[] arguments)
        {
            var g = new Grid(5, 5);
            PrintGrid(g);
            g = new Grid(2, 4);
            PrintGrid(g);
            g = new Grid(4, 2);
            PrintGrid(g);

        }

        static void PrintGrid(Grid g)
        {
            Debug.WriteLine(g.ToString());            
            Debug.WriteLine(g.GridInfo);
            Debug.WriteLine("===============");
            
        }
    }
}
