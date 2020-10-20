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
        int MouseX = Settings.sWidth / 2;

        public Game()
        {
            InitializeComponent();
        }
        //===================================================
        private void Game_Load(object sender, EventArgs e)
        {
            g = Graphics.FromImage(buf);
            Clock.Enabled = true;
            Player = new Player(1.5F, 1.5F, Map);
            Cursor.Hide();
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
            Player.Draw(g);
            g.FillRectangle(Brushes.White, 0, 0, Map.Width * Map.Tile, Map.Height * Map.Tile);
            Map.Draw(g);
            Player.DrawOnMap(g);
        }

        string FPS = "0";
        private void Clock_Tick(object sender, EventArgs e)
        {
            time = DateTime.Now;
            Draw();
            Screen.Image = buf;
            Screen.Update();
            frame_time = (DateTime.Now - time).TotalSeconds;
            FPS = ((int)(1/frame_time)).ToString();
            int rotate = Cursor.Position.X - (Settings.sWidth / 2 + this.Location.X);
            Player.Turn(rotate * 0.001F);
            Cursor.Position = new Point(Settings.sWidth / 2 + this.Location.X, Settings.sHeight / 2 + this.Location.Y);
        }

        private void FpsCounter_Tick(object sender, EventArgs e)
        {
            FPS_Text.Text = FPS;
        }

        private void Screen_MouseMove(object sender, MouseEventArgs e)
        {
            
        }
        //===================================================
    }
}
