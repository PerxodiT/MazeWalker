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

        public const int mWidth = 200;
        public const int mHeight = 150;
        public const int sHalfHeight = sHeight / 2;
        public const int WallHeight = sWidth / 8;

        public const int TextureScale = 200;

        public const int RAY_COUNT = 800;
        public const double FOV = Math.PI / 3;
        public const double Half_FOV = FOV / 2;
        public const double deltaFOV = FOV / RAY_COUNT;

        public const double PlayerSpeed = 2;
        public const float Scale = sWidth / RAY_COUNT;
        public static float Camera_Dist = (float)(sWidth / (2 * Math.Tan(FOV / 2)));
    }
}
