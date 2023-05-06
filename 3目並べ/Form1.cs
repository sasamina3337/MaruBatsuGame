using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3目並べ
{
    public partial class Form1 : Form
    {
        public string[] mark = new string[] { "", "○", "×" };

        public Boolean PrimaryTurn;

        public int gameCount, Turn;

        public int[] gameBoard = new int[9];

        public Boolean YourTurn;

        public Form1()
        {
            InitializeComponent();
        }

        private void start_Click(object sender, EventArgs e)
        {
            BoardEnable(true);
            gameCount = 0;
            ButtonMemory();
            Random random = new Random();
            YourTurn = (random.Next(2) == 0);

        }
        public void BoardEnable(Boolean l)
        {
            Control[] c;
            Button btn;
            for (int i = 0; i < gameBoard.Length; i++)
            {
                c = this.Controls.Find("button" + i.ToString(), true);
                btn = (Button)c[0];
                btn.Enabled = l;
            }
        }

        private void buttonALl_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            ButtonMemory();
            gameCount++;
            if (YourTurn)
            {
                btn.Text = mark[1];
            }
            else
            {
                btn.Text = mark[2];
            }
        }

        public void ButtonMemory()
        {
            Control[] d;
            Button btn;
            for (int i = 0; i < gameBoard.Length && i < 9; i++)
            {
                d = this.Controls.Find("button" + i.ToString(), true);
                btn = (Button)d[0];

                if (btn.Text == mark[0])
                {
                    gameBoard[i] = 0;
                }
                else if (btn.Text == mark[1])
                {
                    gameBoard[i] = 1;
                    btn.Enabled = false;
                }
                else
                {
                    gameBoard[i] = 2;
                    btn.Enabled = false;
                }
            }
        }
    }
}
