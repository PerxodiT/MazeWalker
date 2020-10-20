using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeWalker
{
    static class MazeDrawer
    {
        public static Bitmap Draw(Maze maze)
        {
            //25x25
            int MapWidth = maze.Width * 2 + 1; 
            int MapHeight = maze.Height * 2 + 1;

            //var red = new Pen(Color.Red);
            Bitmap map = new Bitmap(MapWidth, MapHeight);
            Graphics g = Graphics.FromImage(map);

            g.Clear(Color.FromArgb(255, 200, 0, 0));

            for (int x = 0; x < maze.Width; x++)
                for (int y = 0; y < maze.Height; y++)
                    DrawCell(maze.Board, map, x, y);
            g.DrawRectangle(new Pen(Color.FromArgb(255, 200, 0, 0)), 0, 0, MapWidth -1, MapHeight-1);
            return map;
        }
        
        static private void DrawCell(Cell[,] cells, Bitmap map, int x, int y)
        {
            var cell = cells[x, y];
            var white = Color.FromArgb(255, 255, 255, 255);

            map.SetPixel(c(x), c(y), white);
            
            if (!cell.NorthWall)
                map.SetPixel(c(x), c(y)-1, white);
            if (!cell.SouthWall)
                map.SetPixel(c(x), c(y)+1, white);
            if (!cell.EastWall)
                map.SetPixel(c(x)+1, c(y), white);
            if (!cell.WestWall)
                map.SetPixel(c(x)-1, c(y), white);
        }

        static private int c(int coord)
        {
            return 2 * coord + 1;
        }
    }
}
