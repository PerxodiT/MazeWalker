using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeWalker
{
    struct RayCast
    {
        Map Map;
        public RayCast(Map map)
        {
            Map = map;
        }
        public double Ray(double _x, double _y, double angle)
        {
            double c = 0.02, x = 0, y = 0;
            double sin_ang = Math.Sin(angle);
            double cos_ang = Math.Cos(angle);
            sin_ang = sin_ang == 0 ? 0.0000001 : sin_ang;
            cos_ang = cos_ang == 0 ? 0.0000001 : cos_ang;
            
            
            for (; c < 20; c += .02)
            {
                x = _x + c * cos_ang;
                y = _y + c * sin_ang;
                if ( Map.Walls.ContainsKey(Map.Coord((int)x, (int)y)) ) break;
            }
            return c;
        }
        
        public float Ray(float px, float py, double angle)
        {
            int x, y;
            float sin_ang = (float)Math.Sin(angle);
            float cos_ang = (float)Math.Cos(angle);
            sin_ang = sin_ang == 0 ? 0.0000001F : sin_ang;
            cos_ang = cos_ang == 0 ? 0.0000001F : cos_ang;

            int dirX;
            int dirY;
            

            // Dist fo x's
            // Selecting direction
            dirX = cos_ang >= 0 ? 1 : -1;
            dirY = sin_ang >= 0 ? 1 : -1;
            int mx = dirX == 1 ? (int)px + 1 : (int)px; 
            int my = dirY == 1 ? (int)py + 1 : (int)py; 

            float sideDistX = (mx - px) / cos_ang;
            float deltaDistX = 1 / cos_ang;
            float distX;
            x = (int)((px + sideDistX * cos_ang) + (dirX * 0.001F));
            y = (int)((py + sideDistX * sin_ang) + (dirY * 0.001F));

            if (Map.Walls.ContainsKey(Map.Coord(x, y)))
                distX = sideDistX;
            else if (deltaDistX > Map.DiagLen)
                distX = (float)Map.DiagLen; //When intersects outside the map dist = MaxDist
            else
            {
                distX = sideDistX;
                for (int x2 = x; x2 > 0 && x2 < Map.Width; x2 += dirX)
                {
                    distX += deltaDistX;
                    x = (int)((px + distX * cos_ang) + (dirX * 0.01F));
                    y = (int)((py + distX * sin_ang) + (dirY * 0.01F));
                    if (Map.Walls.ContainsKey(Map.Coord(x, y))) break;
                }
            }


            // Dist fo y's
            float sideDistY = (my - py) / sin_ang;
            float deltaDistY = 1 / sin_ang;
            float distY;
            x = (int)((px + sideDistY * cos_ang) + (dirX * 0.01F));
            y = (int)((py + sideDistY * sin_ang) + (dirY * 0.01F));

            if (Map.Walls.ContainsKey(Map.Coord(x, y)))
                distY = sideDistY;
            else if (deltaDistX > Map.DiagLen)
                distY = (float)Map.DiagLen; //When intersects outside the map dist = MaxDist
            else
            {
                distY = sideDistY;
                for (int y2 = y; y2 > 0 && y2 < Map.Height; y2 += dirY)
                {
                    distY += deltaDistY;
                    x = (int)((px + distY * cos_ang) + (dirX * 0.01F));
                    y = (int)((py + distY * sin_ang) + (dirY * 0.01F));
                    if (Map.Walls.ContainsKey(Map.Coord(x, y))) break;
                }
            }
            return distX < distY ? distX : distY;
        }
    }
}
