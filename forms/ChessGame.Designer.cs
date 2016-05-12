namespace ChessGame
{
    partial class ChessGame
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChessGame));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.gameMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newGameMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pbNum = new System.Windows.Forms.PictureBox();
            this.pbAbc = new System.Windows.Forms.PictureBox();
            this.labWhoMove = new System.Windows.Forms.Label();
            this.pbWhoMove = new System.Windows.Forms.PictureBox();
            this.tbGameLog = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_Save = new System.Windows.Forms.Button();
            this.btn_Load = new System.Windows.Forms.Button();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAbc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbWhoMove)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gameMenuItem,
            this.setingsToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(838, 24);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip1";
            // 
            // gameMenuItem
            // 
            this.gameMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGameMenuItem});
            this.gameMenuItem.Name = "gameMenuItem";
            this.gameMenuItem.Size = new System.Drawing.Size(50, 20);
            this.gameMenuItem.Text = "Game";
            // 
            // newGameMenuItem
            // 
            this.newGameMenuItem.Name = "newGameMenuItem";
            this.newGameMenuItem.Size = new System.Drawing.Size(152, 22);
            this.newGameMenuItem.Text = "New Game";
            this.newGameMenuItem.Click += new System.EventHandler(this.newGameMenuItem_Click);
            // 
            // setingsToolStripMenuItem
            // 
            this.setingsToolStripMenuItem.Name = "setingsToolStripMenuItem";
            this.setingsToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.setingsToolStripMenuItem.Text = "Setings";
            this.setingsToolStripMenuItem.Click += new System.EventHandler(this.setingsToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // pbNum
            // 
            this.pbNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbNum.Location = new System.Drawing.Point(5, 27);
            this.pbNum.Name = "pbNum";
            this.pbNum.Size = new System.Drawing.Size(30, 600);
            this.pbNum.TabIndex = 2;
            this.pbNum.TabStop = false;
            this.pbNum.Paint += new System.Windows.Forms.PaintEventHandler(this.pbNum_Paint);
            // 
            // pbAbc
            // 
            this.pbAbc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbAbc.Location = new System.Drawing.Point(41, 633);
            this.pbAbc.Name = "pbAbc";
            this.pbAbc.Size = new System.Drawing.Size(600, 30);
            this.pbAbc.TabIndex = 3;
            this.pbAbc.TabStop = false;
            this.pbAbc.Paint += new System.Windows.Forms.PaintEventHandler(this.pbAbc_Paint);
            // 
            // labWhoMove
            // 
            this.labWhoMove.AutoSize = true;
            this.labWhoMove.Location = new System.Drawing.Point(647, 30);
            this.labWhoMove.Name = "labWhoMove";
            this.labWhoMove.Size = new System.Drawing.Size(112, 16);
            this.labWhoMove.TabIndex = 4;
            this.labWhoMove.Text = "Now move: White";
            // 
            // pbWhoMove
            // 
            this.pbWhoMove.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbWhoMove.Location = new System.Drawing.Point(5, 633);
            this.pbWhoMove.Name = "pbWhoMove";
            this.pbWhoMove.Size = new System.Drawing.Size(30, 30);
            this.pbWhoMove.TabIndex = 5;
            this.pbWhoMove.TabStop = false;
            this.pbWhoMove.Paint += new System.Windows.Forms.PaintEventHandler(this.pbWhoMove_Paint);
            // 
            // tbGameLog
            // 
            this.tbGameLog.Location = new System.Drawing.Point(647, 49);
            this.tbGameLog.Multiline = true;
            this.tbGameLog.Name = "tbGameLog";
            this.tbGameLog.ReadOnly = true;
            this.tbGameLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbGameLog.Size = new System.Drawing.Size(187, 578);
            this.tbGameLog.TabIndex = 666;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(41, 27);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(600, 600);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // btn_Save
            // 
            this.btn_Save.Location = new System.Drawing.Point(647, 633);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(89, 30);
            this.btn_Save.TabIndex = 8;
            this.btn_Save.Text = "Save";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // btn_Load
            // 
            this.btn_Load.Location = new System.Drawing.Point(745, 633);
            this.btn_Load.Name = "btn_Load";
            this.btn_Load.Size = new System.Drawing.Size(89, 30);
            this.btn_Load.TabIndex = 9;
            this.btn_Load.Text = "Load";
            this.btn_Load.UseVisualStyleBackColor = true;
            this.btn_Load.Click += new System.EventHandler(this.btn_Load_Click);
            // 
            // ChessGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(838, 668);
            this.Controls.Add(this.btn_Load);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.tbGameLog);
            this.Controls.Add(this.pbWhoMove);
            this.Controls.Add(this.labWhoMove);
            this.Controls.Add(this.pbAbc);
            this.Controls.Add(this.pbNum);
            this.Controls.Add(this.menuStrip);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ChessGame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Chess";
            this.Load += new System.EventHandler(this.ChessGame_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAbc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbWhoMove)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem gameMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newGameMenuItem;
        private System.Windows.Forms.PictureBox pbNum;
        private System.Windows.Forms.PictureBox pbAbc;
        private System.Windows.Forms.Label labWhoMove;
        private System.Windows.Forms.PictureBox pbWhoMove;
        private System.Windows.Forms.TextBox tbGameLog;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem setingsToolStripMenuItem;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Button btn_Load;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    }
}

