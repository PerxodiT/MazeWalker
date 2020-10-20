using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Schema;

namespace MazeWalker
{
    struct Coord {
        public Coord(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public int x { get; set; }
        public int y { get; set; }
    }
    class Map
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public int Tile { get; set; }
        public double DiagLen { get; set; }


        public Hashtable Walls;
        //public Dictionary

        public Map()
        {
            Maze maze = new Maze(12, 12);
            maze.Generate(0, 0);
            Dictionary<Coord, Color> walls = new Dictionary<Coord, Color> { };
            Bitmap map_image = (Bitmap)MazeDrawer.Draw(maze).Clone();
            Width = map_image.Width;
            Height = map_image.Height;
            DiagLen = Math.Sqrt(Width * Width + Height * Height);

            Tile = Settings.mHeight / Height;

            for (int y = 0; y < Height; y++)
                for (int x = 0; x < Width; x++)
                {
                    var pixel = map_image.GetPixel(x, y);
                    if (pixel != Color.FromArgb(255,255,255,255))
                        walls.Add(Coord(x, y), pixel);
                }
            Walls = new Hashtable(walls);
            Console.WriteLine("Map init complete!");
        }

        public void Draw(Graphics g)
        {
            foreach (DictionaryEntry wall in Walls)
            {
                g.FillRectangle(new SolidBrush((Color)wall.Value), ((Coord)wall.Key).x
                    * Tile, ((Coord)wall.Key).y * Tile, Tile, Tile);
            }
        }

        static public Coord Coord(int x, int y)
        {
           return new Coord(x,y);
        }
    }
}
