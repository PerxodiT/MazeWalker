using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MazeWalker
{
    class Player
    {
        float x { get; set; }
        float y { get; set; }
        double a { get; set; }
        float sin_a, cos_a;
        private Map Map;
        RayCast RayCast;

        private const float HalfPI = (float)(Math.PI / 2);
        private const float PI = (float)(Math.PI);

        private Bitmap[] WallTexture;

        public Player(float x, float y, Map map)
        {
            this.x = x;
            this.y = y;
            this.a = 0;
            this.Map = map;
            sin_a = (float)Math.Sin(a);
            cos_a = (float)Math.Cos(a);
            RayCast = new RayCast(Map);
            WallTexture = new Bitmap[Properties.Resources.Wall.Width];
            var texture = new Bitmap(Properties.Resources.Wall);
            for (int i = 0; i < WallTexture.Length; i++)
            {
                var tempBMP = new Bitmap(1, Properties.Resources.Wall.Width);
                for (int picY = 0; picY < tempBMP.Width; picY++)
                    tempBMP.SetPixel(0, picY, texture.GetPixel(i, picY));
                WallTexture[i] = (Bitmap)tempBMP.Clone();
            }
        }

        public void Turn(double rot)
        {
            a += rot;
            a = a % (Math.PI * 2);
            sin_a = (float)Math.Sin(a);
            cos_a = (float)Math.Cos(a);
        }

        public void Walk(char Dir, double frame_time)
        {
            float d = (float)(Settings.PlayerSpeed * frame_time);
            switch (Dir)
            {
                case 'w':
                    if (d > RayCast.Ray(x, y, a)) break;
                    x = x + d * cos_a;
                    y = y + d * sin_a;
                    break;
                case 's':
                    if (d > RayCast.Ray(x, y, a + PI)) break;
                    x = x - d * cos_a;
                    y = y - d * sin_a;
                    break;
                case 'a':
                    if (d > RayCast.Ray(x, y, a - HalfPI)) break;
                    x = x + d * sin_a;
                    y = y - d * cos_a;
                    break;
                case 'd':
                    if (d > RayCast.Ray(x, y, a + HalfPI)) break;
                    x = x - d * sin_a;
                    y = y + d * cos_a;
                    break;
                case 'q':
                    Turn(-1 * frame_time);
                    break;
                case 'e':
                    Turn(1 * frame_time);
                    break;
            }
        }

        public void Draw(Graphics g)
        {
            int c = Map.Tile;
            
            float Screen_x = 0;
            for (double angle = a - Settings.Half_FOV, i = 0;
                angle < a + Settings.Half_FOV;
                angle += Settings.deltaFOV, i++)
            {
                Color wall;
                //float offset;
                float dist = (float)(RayCast.Ray((float)x, (float)y, angle, out wall) * Math.Cos(a-angle));
                int wall_height = (int)((Settings.Camera_Dist * Settings.WallHeight / dist * .01F));
                int sky = (Settings.WallHeight - wall_height) / 2;



                float color = 1 / dist > 1 ? 1 : 1/dist;
                Brush brush = new SolidBrush(Color.FromArgb(255, (int)(wall.R * color), (int)(wall.G * color), (int)(wall.B * color)));
                Brush floorBrush = new SolidBrush(Color.FromArgb(255, 180, 180, 180));
                //var line = new Bitmap(WallTexture[(int)(offset*200)], 1, wall_height);
                //g.DrawImage(line, Screen_x, Settings.WallHeight + sky + wall_height);
                g.FillRectangle(brush, Screen_x, Settings.WallHeight + sky, Settings.Scale, wall_height);
                g.FillRectangle(floorBrush, Screen_x, Settings.WallHeight + sky + wall_height, Settings.Scale, Settings.sHeight - Settings.WallHeight + sky + wall_height);
                Screen_x += Settings.Scale;
            }
        }

        public void DrawOnMap(Graphics g)
        {
            int c = Map.Tile;
            g.FillEllipse(new SolidBrush(Color.Red),
                x * c - 2, y * c - 2,
                4, 4);

            g.DrawLine(new Pen(Color.Red, 1),
                (float)(x * c), (float)(y * c),
                (float)((x + Math.Cos(a)) * c), (float)((y + Math.Sin(a)) * c));
        }
    }
}
