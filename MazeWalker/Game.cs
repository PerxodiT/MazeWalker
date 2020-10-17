using MazeWalker.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MazeWalker
{
    public partial class Game : Form
    {
        Graphics g;
        DateTime time = DateTime.Now;
        Map Map = new Map();

        public Game()
        {
            InitializeComponent();
        }
        //===================================================
        private void Game_Load(object sender, EventArgs e)
        {
            g = this.CreateGraphics();
            Clock.Enabled = true;
        }
        private void Game_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
        private void Game_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) this.Close();
        }
        //===================================================

        private void Draw()
        {
            g.Clear(Color.FromArgb(255, 0, 150, 255));
            foreach (KeyValuePair<Coord, Color> wall in Map.Walls)
            {
                g.FillRectangle(new SolidBrush(wall.Value), wall.Key.x, wall.Key.y, Map.Tile, Map.Tile);
            }
        }

        private void Clock_Tick(object sender, EventArgs e)
        {
            time = DateTime.Now;
            Draw();

            this.Update();
            double frame_time = (DateTime.Now - time).TotalSeconds;
            FPS_Text.Text = ((int)(1/frame_time)).ToString();
        }
        //===================================================


    }
}
