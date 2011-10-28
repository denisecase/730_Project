namespace WumpusAgentGame
{
    partial class Settings
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
            this.btnPlay = new System.Windows.Forms.Button();
            this.txtXY = new System.Windows.Forms.TextBox();
            this.picTitle = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdoCustom = new System.Windows.Forms.RadioButton();
            this.rdoLarge = new System.Windows.Forms.RadioButton();
            this.rdoMed = new System.Windows.Forms.RadioButton();
            this.rdoSmall = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkVisible = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtWumpus = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtGold = new System.Windows.Forms.TextBox();
            this.txtpitLower = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtpitHigher = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSeed = new System.Windows.Forms.TextBox();
            this.SEED = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picTitle)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPlay
            // 
            this.btnPlay.Location = new System.Drawing.Point(698, 430);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(75, 23);
            this.btnPlay.TabIndex = 0;
            this.btnPlay.Text = "Play";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // txtXY
            // 
            this.txtXY.Enabled = false;
            this.txtXY.Location = new System.Drawing.Point(66, 87);
            this.txtXY.Name = "txtXY";
            this.txtXY.Size = new System.Drawing.Size(40, 20);
            this.txtXY.TabIndex = 1;
            this.txtXY.Text = "20";
            this.txtXY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // picTitle
            // 
            this.picTitle.Location = new System.Drawing.Point(12, 12);
            this.picTitle.Name = "picTitle";
            this.picTitle.Size = new System.Drawing.Size(761, 146);
            this.picTitle.TabIndex = 3;
            this.picTitle.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtXY);
            this.groupBox1.Controls.Add(this.rdoCustom);
            this.groupBox1.Controls.Add(this.rdoLarge);
            this.groupBox1.Controls.Add(this.rdoMed);
            this.groupBox1.Controls.Add(this.rdoSmall);
            this.groupBox1.Location = new System.Drawing.Point(12, 164);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(761, 121);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Game Settings";
            // 
            // rdoCustom
            // 
            this.rdoCustom.AutoSize = true;
            this.rdoCustom.Location = new System.Drawing.Point(6, 88);
            this.rdoCustom.Name = "rdoCustom";
            this.rdoCustom.Size = new System.Drawing.Size(60, 17);
            this.rdoCustom.TabIndex = 5;
            this.rdoCustom.Text = "Custom";
            this.rdoCustom.UseVisualStyleBackColor = true;
            this.rdoCustom.CheckedChanged += new System.EventHandler(this.rdoCustom_CheckedChanged);
            // 
            // rdoLarge
            // 
            this.rdoLarge.AutoSize = true;
            this.rdoLarge.Location = new System.Drawing.Point(6, 65);
            this.rdoLarge.Name = "rdoLarge";
            this.rdoLarge.Size = new System.Drawing.Size(90, 17);
            this.rdoLarge.TabIndex = 4;
            this.rdoLarge.Text = "Large (15x15)";
            this.rdoLarge.UseVisualStyleBackColor = true;
            // 
            // rdoMed
            // 
            this.rdoMed.AutoSize = true;
            this.rdoMed.Location = new System.Drawing.Point(6, 42);
            this.rdoMed.Name = "rdoMed";
            this.rdoMed.Size = new System.Drawing.Size(100, 17);
            this.rdoMed.TabIndex = 3;
            this.rdoMed.Text = "Medium (10x10)";
            this.rdoMed.UseVisualStyleBackColor = true;
            // 
            // rdoSmall
            // 
            this.rdoSmall.AutoSize = true;
            this.rdoSmall.Checked = true;
            this.rdoSmall.Location = new System.Drawing.Point(6, 19);
            this.rdoSmall.Name = "rdoSmall";
            this.rdoSmall.Size = new System.Drawing.Size(76, 17);
            this.rdoSmall.TabIndex = 2;
            this.rdoSmall.TabStop = true;
            this.rdoSmall.Text = "Small (5x5)";
            this.rdoSmall.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtpitHigher);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtpitLower);
            this.groupBox2.Controls.Add(this.txtGold);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtWumpus);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.chkVisible);
            this.groupBox2.Location = new System.Drawing.Point(12, 291);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(761, 121);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Advanced Options";
            // 
            // chkVisible
            // 
            this.chkVisible.AutoSize = true;
            this.chkVisible.Location = new System.Drawing.Point(6, 19);
            this.chkVisible.Name = "chkVisible";
            this.chkVisible.Size = new System.Drawing.Size(70, 17);
            this.chkVisible.TabIndex = 6;
            this.chkVisible.Text = "All Visible";
            this.chkVisible.UseVisualStyleBackColor = true;
            this.chkVisible.CheckedChanged += new System.EventHandler(this.chkVisible_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Wumpus\'";
            // 
            // txtWumpus
            // 
            this.txtWumpus.Location = new System.Drawing.Point(6, 42);
            this.txtWumpus.Name = "txtWumpus";
            this.txtWumpus.Size = new System.Drawing.Size(40, 20);
            this.txtWumpus.TabIndex = 6;
            this.txtWumpus.Text = "1";
            this.txtWumpus.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(52, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Gold";
            // 
            // txtGold
            // 
            this.txtGold.Location = new System.Drawing.Point(6, 68);
            this.txtGold.Name = "txtGold";
            this.txtGold.Size = new System.Drawing.Size(40, 20);
            this.txtGold.TabIndex = 8;
            this.txtGold.Text = "1";
            this.txtGold.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtpitLower
            // 
            this.txtpitLower.Location = new System.Drawing.Point(6, 94);
            this.txtpitLower.Name = "txtpitLower";
            this.txtpitLower.Size = new System.Drawing.Size(40, 20);
            this.txtpitLower.TabIndex = 9;
            this.txtpitLower.Text = "12";
            this.txtpitLower.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(52, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "% to";
            // 
            // txtpitHigher
            // 
            this.txtpitHigher.Location = new System.Drawing.Point(85, 94);
            this.txtpitHigher.Name = "txtpitHigher";
            this.txtpitHigher.Size = new System.Drawing.Size(40, 20);
            this.txtpitHigher.TabIndex = 11;
            this.txtpitHigher.Text = "25";
            this.txtpitHigher.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(131, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "% Pits";
            // 
            // txtSeed
            // 
            this.txtSeed.Location = new System.Drawing.Point(652, 433);
            this.txtSeed.Name = "txtSeed";
            this.txtSeed.Size = new System.Drawing.Size(40, 20);
            this.txtSeed.TabIndex = 13;
            this.txtSeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // SEED
            // 
            this.SEED.AutoSize = true;
            this.SEED.Location = new System.Drawing.Point(610, 436);
            this.SEED.Name = "SEED";
            this.SEED.Size = new System.Drawing.Size(36, 13);
            this.SEED.TabIndex = 13;
            this.SEED.Text = "SEED";
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(785, 465);
            this.Controls.Add(this.SEED);
            this.Controls.Add(this.txtSeed);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.picTitle);
            this.Controls.Add(this.btnPlay);
            this.Name = "Settings";
            this.Text = "Settings";
            ((System.ComponentModel.ISupportInitialize)(this.picTitle)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.TextBox txtXY;
        private System.Windows.Forms.PictureBox picTitle;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdoCustom;
        private System.Windows.Forms.RadioButton rdoLarge;
        private System.Windows.Forms.RadioButton rdoMed;
        private System.Windows.Forms.RadioButton rdoSmall;
        private System.Windows.Forms.CheckBox chkVisible;
        private System.Windows.Forms.TextBox txtpitHigher;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtpitLower;
        private System.Windows.Forms.TextBox txtGold;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtWumpus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSeed;
        private System.Windows.Forms.Label SEED;
    }
}