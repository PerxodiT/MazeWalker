using System;
using System.Collections.Generic;
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

        public Dictionary<Coord, Color> Walls;

        public Map()
        {
            Bitmap map_image = new Bitmap("Recources//Map.png");
            Width = map_image.Width;
            Height = map_image.Height;

            Tile = Settings.sHeight / Height;

            for (int y = 0; y < Height; y++)
                for (int x =0; x < Width; y++)
                {
                    var pixel = map_image.GetPixel(x, y);
                    if (pixel != Color.White && pixel != Color.Transparent)
                        Walls.Add(Coord(x, y), pixel);
                }
        }

        static public Coord Coord(int x, int y)
        {
           return new Coord(x,y);
        }
    }
}
