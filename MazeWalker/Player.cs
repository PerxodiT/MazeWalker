using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MazeWalker
{
    class Player
    {
        double x { get; set; }
        double y { get; set; }
        double a { get; set; }
        double sin_a, cos_a;
        private Map Map;
        RayCast RayCast;

        public Player(double x, double y, Map map)
        {
            this.x = x;
            this.y = y;
            this.a = 0;
            this.Map = map;
            sin_a = Math.Sin(a);
            cos_a = Math.Cos(a);
            RayCast = new RayCast(Map);
        }

        public void Turn(double rot)
        {
            a += rot;
            a = a % (Math.PI * 2);
            sin_a = Math.Sin(a);
            cos_a = Math.Cos(a);
        }

        public void Walk(char Dir, double frame_time)
        {
            double d = Settings.PlayerSpeed * frame_time;
            switch (Dir)
            {
                case 'w':
                    x = x + d * cos_a;
                    y = y + d * sin_a;
                    break;
                case 's':
                    x = x - d * cos_a;
                    y = y - d * sin_a;
                    break;
                case 'a':
                    x = x + d * sin_a;
                    y = y - d * cos_a;
                    break;
                case 'd':
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
            g.FillEllipse(new SolidBrush(Color.BlueViolet),
                (int)((x - .1F) * c), (int)((y - .1F) * c),
                (int)(.2F * c), (int)(.2F * c));

            g.DrawLine(Pens.BlueViolet,
                (float)(x * c), (float)(y * c),
                (float)((x + Math.Cos(a)) * c), (float)((y + Math.Sin(a)) * c));

            
            for (double angle = a - Settings.Half_FOV, i = 0;
                angle < a + Settings.Half_FOV;
                angle += Settings.deltaFOV, i++)
            {
                float dist = RayCast.Ray((float)x, (float)y, angle);
                float rx = (float)(x + dist * Math.Cos(angle));
                float ry = (float)(y + dist * Math.Sin(angle));

                if (i % 3 == 0)
                g.DrawLine(Pens.Red, (float)(x * c), (float)(y * c), rx * c, ry * c);
            }
        }
    }
}
