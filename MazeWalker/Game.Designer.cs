namespace MazeWalker
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
            this.SuspendLayout();
            // 
            // Clock
            // 
            this.Clock.Interval = 15;
            this.Clock.Tick += new System.EventHandler(this.Clock_Tick);
            // 
            // FPS_Text
            // 
            this.FPS_Text.AutoSize = true;
            this.FPS_Text.BackColor = System.Drawing.Color.Transparent;
            this.FPS_Text.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.FPS_Text.Font = new System.Drawing.Font("Lucida Console", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FPS_Text.ForeColor = System.Drawing.Color.Red;
            this.FPS_Text.Location = new System.Drawing.Point(12, 9);
            this.FPS_Text.Name = "FPS_Text";
            this.FPS_Text.Size = new System.Drawing.Size(61, 37);
            this.FPS_Text.TabIndex = 0;
            this.FPS_Text.Text = "60";
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.FPS_Text);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Game";
            this.Text = "Game";
            this.Load += new System.EventHandler(this.Game_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Game_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Game_KeyPress);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer Clock;
        private System.Windows.Forms.Label FPS_Text;
    }
}

