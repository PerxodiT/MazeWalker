using MazeWalker.Properties;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace MazeWalker
{
    public partial class Game : Form
    {
        Graphics g;
        DateTime time = DateTime.Now;
        Map Map = new Map();
        Bitmap buf = new Bitmap(Settings.sWidth, Settings.sHeight);
        double frame_time = 1;
        Player Player;

        public Game()
        {
            InitializeComponent();
        }
        //===================================================
        private void Game_Load(object sender, EventArgs e)
        {
            g = Graphics.FromImage(buf);
            Clock.Enabled = true;
            Player = new Player(5, 5, Map);

        }
        private void Game_KeyPress(object sender, KeyPressEventArgs e)
        {
            Player.Walk(e.KeyChar, frame_time);
        }
        private void Game_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) this.Close();
        }
        //===================================================
        private void Draw()
        {
            g.Clear(Color.FromArgb(255, 0, 150, 255));
            foreach (DictionaryEntry wall in Map.Walls)
            {
                g.FillRectangle(new SolidBrush((Color)wall.Value), ((Coord)wall.Key).x
                    * Map.Tile, ((Coord)wall.Key).y * Map.Tile, Map.Tile, Map.Tile);
            }
            
            Player.Draw(g);
        }

        const double min_frametime = 1 / 60;
        private void Clock_Tick(object sender, EventArgs e)
        {
            time = DateTime.Now;
            Draw();

            Screen.Image = buf;
            Screen.Update();
            frame_time = (DateTime.Now - time).TotalSeconds;
            FPS_Text.Text = ((int)(1/frame_time)).ToString();
        }
        //===================================================
    }
}
