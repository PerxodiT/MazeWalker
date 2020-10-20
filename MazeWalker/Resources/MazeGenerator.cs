using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeWalker.Resources
{
     struct cell
    {
        public cell(short _x, short _y)
        {
            x = _x;
            y = _y;
        }

        public cell(int _x, int _y)
        {
            x = (short)_x;
            y = (short)_y;
        }

        public short x { get; set; }
        public short y { get; set; }
    };

    struct cellString
    {
        public cellString(int len)
        {
            cells = new cell[len];
            this.size = 0;
        }
        public cell[] cells { get; set; }
        public int size { get; set; }
    };


    class MazeGenerator
    {
        private int[,] maze;
        int height;
        int width;
        public MazeGenerator(int _height, int _width)
        {
            maze = new int[_height,_width];
            height = _height;
            width = _width;
        }

        
    }
}
