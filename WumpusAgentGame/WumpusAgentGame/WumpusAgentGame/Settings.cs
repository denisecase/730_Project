using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WumpusAgentGame
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        public int posX;
        public int posY;
        public bool allVisible = false;

        public int wumpus;
        public int gold;
        public double pitLower;
        public double pitHigher;

        public int seed;

        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (rdoSmall.Checked)
            {
                posX = 5;
                posY = 5;
            }
            else if (rdoMed.Checked)
            {
                posX = 10;
                posY = 10;
            }
            else if (rdoLarge.Checked)
            {
                posX = 15;
                posY = 15;
            }
            else
            {
                posX = Convert.ToInt32(txtXY.Text);
                posY = Convert.ToInt32(txtXY.Text);
            }

            if (txtWumpus.Text == "") wumpus = 0;
            else wumpus = Convert.ToInt32(txtWumpus.Text);
            if (txtGold.Text == "") gold = 0;
            else gold = Convert.ToInt32(txtGold.Text);
            if (txtpitLower.Text == "") pitLower = 0;
            else pitLower = Convert.ToInt32(txtpitLower.Text);
            if (txtpitHigher.Text == "") pitHigher = 0;
            else if (Convert.ToInt32(txtpitHigher.Text) <= Convert.ToInt32(txtpitLower.Text)) pitHigher = pitLower + 10;
            else pitHigher = Convert.ToInt32(txtpitHigher.Text);

            Random rand = new Random();
            if (txtSeed.Text == "") seed = rand.Next(0,1000);
            else seed = Convert.ToInt32(txtSeed.Text);


            this.Close();
        }

        private void rdoCustom_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoCustom.Checked)
            {
                txtXY.Enabled = true;
            }
        }

        private void chkVisible_CheckedChanged(object sender, EventArgs e)
        {
            if (chkVisible.Checked) allVisible = true;
            else allVisible = false;
        }
    }
}
