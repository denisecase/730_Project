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
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Seed:";
            // 
            // lblSeed
            // 
            this.lblSeed.AutoSize = true;
            this.lblSeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSeed.Location = new System.Drawing.Point(74, 14);
            this.lblSeed.Name = "lblSeed";
            this.lblSeed.Size = new System.Drawing.Size(18, 20);
            this.lblSeed.TabIndex = 1;
            this.lblSeed.Text = "0";
            // 
            // btnRestart
            // 
            this.btnRestart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRestart.Location = new System.Drawing.Point(243, 178);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(123, 38);
            this.btnRestart.TabIndex = 4;
            this.btnRestart.Text = "Restart";
            this.btnRestart.UseVisualStyleBackColor = true;
            // 
            // btnStopStart
            // 
            this.btnStopStart.Location = new System.Drawing.Point(17, 178);
            this.btnStopStart.Name = "btnStopStart";
            this.btnStopStart.Size = new System.Drawing.Size(123, 38);
            this.btnStopStart.TabIndex = 5;
            this.btnStopStart.Text = "Stop";
            this.btnStopStart.UseVisualStyleBackColor = true;
            // 
            // listGameOutput
            // 
            this.listGameOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listGameOutput.FormattingEnabled = true;
            this.listGameOutput.Location = new System.Drawing.Point(17, 230);
            this.listGameOutput.Name = "listGameOutput";
            this.listGameOutput.ScrollAlwaysVisible = true;
            this.listGameOutput.Size = new System.Drawing.Size(349, 160);
            this.listGameOutput.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 153);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Score:";
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScore.Location = new System.Drawing.Point(74, 153);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(18, 20);
            this.lblScore.TabIndex = 8;
            this.lblScore.Text = "0";
            // 
            // txtStatus
            // 
            this.txtStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtStatus.Location = new System.Drawing.Point(17, 401);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.Size = new System.Drawing.Size(349, 20);
            this.txtStatus.TabIndex = 9;
            this.txtStatus.TabStop = false;
            // 
            // GameControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 424);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.lblScore);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listGameOutput);
            this.Controls.Add(this.btnStopStart);
            this.Controls.Add(this.btnRestart);
            this.Controls.Add(this.lblSeed);
            this.Controls.Add(this.label1);
            this.Name = "GameControl";
            this.Padding = new System.Windows.Forms.Padding(5);
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
        private System.Windows.Forms.TextBox txtStatus;
    }
}