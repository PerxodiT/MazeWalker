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

            Dictionary<Coord, Color> walls = new Dictionary<Coord, Color> { };
            Bitmap map_image = new Bitmap(Properties.Resources.Map);
            Width = map_image.Width;
            Height = map_image.Height;
            DiagLen = Math.Sqrt(Width * Width + Height * Height);

            Tile = Settings.sHeight / Height;

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

        static public Coord Coord(int x, int y)
        {
           return new Coord(x,y);
        }
    }
}
