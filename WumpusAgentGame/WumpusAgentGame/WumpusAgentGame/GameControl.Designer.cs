namespace WumpusAgentGame
{
    partial class GameControl
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
            this.label1 = new System.Windows.Forms.Label();
            this.lblSeed = new System.Windows.Forms.Label();
            this.btnRestart = new System.Windows.Forms.Button();
            this.btnStopStart = new System.Windows.Forms.Button();
            this.listGameOutput = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblScore = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Seed:";
            // 
            // lblSeed
            // 
            this.lblSeed.AutoSize = true;
            this.lblSeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSeed.Location = new System.Drawing.Point(69, 9);
            this.lblSeed.Name = "lblSeed";
            this.lblSeed.Size = new System.Drawing.Size(18, 20);
            this.lblSeed.TabIndex = 1;
            this.lblSeed.Text = "0";
            // 
            // btnRestart
            // 
            this.btnRestart.Location = new System.Drawing.Point(223, 194);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(123, 38);
            this.btnRestart.TabIndex = 4;
            this.btnRestart.Text = "Restart";
            this.btnRestart.UseVisualStyleBackColor = true;
            // 
            // btnStopStart
            // 
            this.btnStopStart.Location = new System.Drawing.Point(12, 194);
            this.btnStopStart.Name = "btnStopStart";
            this.btnStopStart.Size = new System.Drawing.Size(123, 38);
            this.btnStopStart.TabIndex = 5;
            this.btnStopStart.Text = "Stop";
            this.btnStopStart.UseVisualStyleBackColor = true;
            // 
            // listGameOutput
            // 
            this.listGameOutput.FormattingEnabled = true;
            this.listGameOutput.Location = new System.Drawing.Point(12, 238);
            this.listGameOutput.Name = "listGameOutput";
            this.listGameOutput.ScrollAlwaysVisible = true;
            this.listGameOutput.Size = new System.Drawing.Size(334, 186);
            this.listGameOutput.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 171);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Score:";
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScore.Location = new System.Drawing.Point(69, 171);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(18, 20);
            this.lblScore.TabIndex = 8;
            this.lblScore.Text = "0";
            // 
            // GameControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(358, 435);
            this.Controls.Add(this.lblScore);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listGameOutput);
            this.Controls.Add(this.btnStopStart);
            this.Controls.Add(this.btnRestart);
            this.Controls.Add(this.lblSeed);
            this.Controls.Add(this.label1);
            this.Name = "GameControl";
            this.Text = "GameControl";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblSeed;
        private System.Windows.Forms.Button btnRestart;
        private System.Windows.Forms.Button btnStopStart;
        private System.Windows.Forms.ListBox listGameOutput;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblScore;
    }
}