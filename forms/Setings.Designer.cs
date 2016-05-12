namespace ChessGame
{
    partial class Setings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Setings));
            this.ch_varOfMove = new System.Windows.Forms.CheckBox();
            this.ch_UnderAttack = new System.Windows.Forms.CheckBox();
            this.btn_Save = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_PreviousTile = new System.Windows.Forms.Button();
            this.btn_NextTile = new System.Windows.Forms.Button();
            this.pb_tileImages = new System.Windows.Forms.PictureBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btn_PreviousFig = new System.Windows.Forms.Button();
            this.btn_NextFig = new System.Windows.Forms.Button();
            this.pb_figImages = new System.Windows.Forms.PictureBox();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_tileImages)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_figImages)).BeginInit();
            this.SuspendLayout();
            // 
            // ch_varOfMove
            // 
            this.ch_varOfMove.AutoSize = true;
            this.ch_varOfMove.Location = new System.Drawing.Point(6, 22);
            this.ch_varOfMove.Name = "ch_varOfMove";
            this.ch_varOfMove.Size = new System.Drawing.Size(130, 19);
            this.ch_varOfMove.TabIndex = 1;
            this.ch_varOfMove.Text = "Show possible ways";
            this.ch_varOfMove.UseVisualStyleBackColor = true;
            // 
            // ch_UnderAttack
            // 
            this.ch_UnderAttack.AutoSize = true;
            this.ch_UnderAttack.Location = new System.Drawing.Point(6, 47);
            this.ch_UnderAttack.Name = "ch_UnderAttack";
            this.ch_UnderAttack.Size = new System.Drawing.Size(163, 19);
            this.ch_UnderAttack.TabIndex = 3;
            this.ch_UnderAttack.Text = "Show figures under attack";
            this.ch_UnderAttack.UseVisualStyleBackColor = true;
            // 
            // btn_Save
            // 
            this.btn_Save.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
            this.btn_Save.Location = new System.Drawing.Point(120, 319);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(92, 36);
            this.btn_Save.TabIndex = 4;
            this.btn_Save.Text = "Applay";
            this.btn_Save.UseVisualStyleBackColor = false;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ch_varOfMove);
            this.groupBox1.Controls.Add(this.ch_UnderAttack);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 75);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Advice";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_PreviousTile);
            this.groupBox2.Controls.Add(this.btn_NextTile);
            this.groupBox2.Controls.Add(this.pb_tileImages);
            this.groupBox2.Location = new System.Drawing.Point(12, 93);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 107);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Board tile";
            // 
            // btn_PreviousTile
            // 
            this.btn_PreviousTile.Font = new System.Drawing.Font("Showcard Gothic", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_PreviousTile.Location = new System.Drawing.Point(14, 22);
            this.btn_PreviousTile.Name = "btn_PreviousTile";
            this.btn_PreviousTile.Size = new System.Drawing.Size(45, 75);
            this.btn_PreviousTile.TabIndex = 2;
            this.btn_PreviousTile.Text = "<";
            this.btn_PreviousTile.UseVisualStyleBackColor = true;
            this.btn_PreviousTile.Click += new System.EventHandler(this.btn_PreviousTile_Click);
            // 
            // btn_NextTile
            // 
            this.btn_NextTile.Font = new System.Drawing.Font("Showcard Gothic", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_NextTile.Location = new System.Drawing.Point(146, 22);
            this.btn_NextTile.Name = "btn_NextTile";
            this.btn_NextTile.Size = new System.Drawing.Size(45, 75);
            this.btn_NextTile.TabIndex = 1;
            this.btn_NextTile.Text = ">";
            this.btn_NextTile.UseVisualStyleBackColor = true;
            this.btn_NextTile.Click += new System.EventHandler(this.btn_NextTile_Click);
            // 
            // pb_tileImages
            // 
            this.pb_tileImages.Location = new System.Drawing.Point(65, 22);
            this.pb_tileImages.Name = "pb_tileImages";
            this.pb_tileImages.Size = new System.Drawing.Size(75, 75);
            this.pb_tileImages.TabIndex = 0;
            this.pb_tileImages.TabStop = false;
            this.pb_tileImages.Paint += new System.Windows.Forms.PaintEventHandler(this.pb_tileImages_Paint);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btn_PreviousFig);
            this.groupBox3.Controls.Add(this.btn_NextFig);
            this.groupBox3.Controls.Add(this.pb_figImages);
            this.groupBox3.Location = new System.Drawing.Point(12, 206);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 107);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Figures";
            // 
            // btn_PreviousFig
            // 
            this.btn_PreviousFig.Font = new System.Drawing.Font("Showcard Gothic", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_PreviousFig.Location = new System.Drawing.Point(14, 22);
            this.btn_PreviousFig.Name = "btn_PreviousFig";
            this.btn_PreviousFig.Size = new System.Drawing.Size(45, 75);
            this.btn_PreviousFig.TabIndex = 2;
            this.btn_PreviousFig.Text = "<";
            this.btn_PreviousFig.UseVisualStyleBackColor = true;
            this.btn_PreviousFig.Click += new System.EventHandler(this.btn_PreviousFig_Click);
            // 
            // btn_NextFig
            // 
            this.btn_NextFig.Font = new System.Drawing.Font("Showcard Gothic", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_NextFig.Location = new System.Drawing.Point(146, 22);
            this.btn_NextFig.Name = "btn_NextFig";
            this.btn_NextFig.Size = new System.Drawing.Size(45, 75);
            this.btn_NextFig.TabIndex = 1;
            this.btn_NextFig.Text = ">";
            this.btn_NextFig.UseVisualStyleBackColor = true;
            this.btn_NextFig.Click += new System.EventHandler(this.btn_NextFig_Click);
            // 
            // pb_figImages
            // 
            this.pb_figImages.Location = new System.Drawing.Point(65, 22);
            this.pb_figImages.Name = "pb_figImages";
            this.pb_figImages.Size = new System.Drawing.Size(75, 75);
            this.pb_figImages.TabIndex = 0;
            this.pb_figImages.TabStop = false;
            this.pb_figImages.Paint += new System.Windows.Forms.PaintEventHandler(this.pb_figImages_Paint);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(0)))), ((int)(((byte)(34)))));
            this.btn_Cancel.Location = new System.Drawing.Point(12, 319);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(92, 36);
            this.btn_Cancel.TabIndex = 8;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = false;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // Setings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(226, 368);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_Save);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Setings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Setings";
            this.Load += new System.EventHandler(this.Setings_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pb_tileImages)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pb_figImages)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.CheckBox ch_varOfMove;
        private System.Windows.Forms.CheckBox ch_UnderAttack;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_NextTile;
        private System.Windows.Forms.PictureBox pb_tileImages;
        private System.Windows.Forms.Button btn_PreviousTile;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btn_PreviousFig;
        private System.Windows.Forms.Button btn_NextFig;
        private System.Windows.Forms.PictureBox pb_figImages;
        private System.Windows.Forms.Button btn_Cancel;
    }
}