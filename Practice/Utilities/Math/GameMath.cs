using System;
using System.Collections.Generic;

namespace Utilities.Math
{
    public class Die
    {
        private Die()
        {
            generate = new Random();
        }

        public Die(int s)
        {
            sides = s;
        }

        public int Roll()
        {
            return generate.Next(1, sides + 1);
        }

        private int sides;
        private Random generate;
    }
    public class Cell
    {
        public Cell(int x, int y, int id)
        {
            X = x;
            Y = y;
            ID = id;
        }
        public int X { get; }
        public int Y { get; }
        public int ID { get; }
        public override string ToString()
        {
            string output = (ID < 10) ? ID.ToString() + "  " : ID.ToString() + " ";
            return output;
        }
    }
    public class Grid
    {
        public Grid(int rows, int cols)
        {
            Rows = rows;
            Cols = cols;
            NumCells = Rows * Cols;
            Cells = new List<Cell>();

            for(int id = 0, y = 0; y < Rows; y++)
            {
                for(int x = 0; x < Cols; x++)
                {
                    var c = new Cell(y, x, id);
                    Cells.Add(c);
                    GridInfo += c.ToString();         
                    id++;
                }

                GridInfo += "\n";
            }
        }
        public string GridInfo { get; set; }


        public override string ToString()
        {
            return string.Format("TopLeft {0} \nTopRight {1} \nBottomLeft {2} \nBottomRight {3} \n", TopLeft, TopRight, BottomLeft, BottomRight);
        }

        public int TopRight { get { return Cols - 1; } }
        public int BottomRight { get { return Rows * Cols - 1; } }
        public int TopLeft { get { return 0; } }
        public int BottomLeft { get { return Rows * Cols - Cols; } }

        public int NumCells { get; set; }
        public int Rows { get; set; }
        public int Cols { get; set; }
        public List<Cell> Cells { get; set; }


    }

}
