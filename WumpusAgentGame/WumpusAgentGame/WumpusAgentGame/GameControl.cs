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
    public partial class GameControl : Form
    {
        public GameControl()
        {
            InitializeComponent();
            GameOutput = new List<string>();
        }

        private List<string> GameOutput;

        public void setSeed(int sd)
        {
            lblSeed.Text = Convert.ToString(sd);
        }

        public void SetOutputList(List<string> ls)
        {
            GameOutput = ls;
        }

        public void UpdateList()
        {
            listGameOutput.Items.Clear();
            for (int i = GameOutput.Count-1; i >= 0; i--)
            {
                listGameOutput.Items.Add(GameOutput.ElementAt(i));
            }
        }
        public void UpdateScore(int i)
        {
            lblScore.Text = Convert.ToString(i);
        }

        public void SetStatus(string s)
        {
            txtStatus.Text = s;
        }

       
    }
}
