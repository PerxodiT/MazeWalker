﻿namespace MazeWalker
{
    partial class Game
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Clock = new System.Windows.Forms.Timer(this.components);
            this.FPS_Text = new System.Windows.Forms.Label();
            this.Screen = new System.Windows.Forms.PictureBox();
            this.FpsCounter = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.Screen)).BeginInit();
            this.SuspendLayout();
            // 
            // Clock
            // 
            this.Clock.Interval = 1;
            this.Clock.Tick += new System.EventHandler(this.Clock_Tick);
            // 
            // FPS_Text
            // 
            this.FPS_Text.AutoSize = true;
            this.FPS_Text.BackColor = System.Drawing.Color.Transparent;
            this.FPS_Text.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.FPS_Text.Font = new System.Drawing.Font("Lucida Console", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FPS_Text.ForeColor = System.Drawing.Color.Red;
            this.FPS_Text.Location = new System.Drawing.Point(727, 9);
            this.FPS_Text.Name = "FPS_Text";
            this.FPS_Text.Size = new System.Drawing.Size(61, 37);
            this.FPS_Text.TabIndex = 0;
            this.FPS_Text.Text = "60";
            // 
            // Screen
            // 
            this.Screen.Location = new System.Drawing.Point(0, 0);
            this.Screen.Name = "Screen";
            this.Screen.Size = new System.Drawing.Size(800, 600);
            this.Screen.TabIndex = 1;
            this.Screen.TabStop = false;
            this.Screen.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Screen_MouseMove);
            // 
            // FpsCounter
            // 
            this.FpsCounter.Enabled = true;
            this.FpsCounter.Interval = 1000;
            this.FpsCounter.Tick += new System.EventHandler(this.FpsCounter_Tick);
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.FPS_Text);
            this.Controls.Add(this.Screen);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Game";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game";
            this.Load += new System.EventHandler(this.Game_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Game_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Game_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.Screen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer Clock;
        private System.Windows.Forms.Label FPS_Text;
        private System.Windows.Forms.PictureBox Screen;
        private System.Windows.Forms.Timer FpsCounter;
    }
}

