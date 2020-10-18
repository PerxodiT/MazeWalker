using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeWalker
{
    static class Settings
    {
        public const int sWidth = 800;
        public const int sHeight = 600;
        public const int sHalfHeight = sHeight / 2;



        public const double RAY_COUNT = 1200;
        public const double FOV = Math.PI / 3;
        public const double Half_FOV = FOV / 2;
        public const double deltaFOV = FOV / RAY_COUNT;

        public const double PlayerSpeed = 5;
    }
}
