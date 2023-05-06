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
            Random random = new Random();
            Turn = random.Next(2) + 1;
            YourTurn = (Turn == 1);
            label.Text = "あなたの手番は" + mark[Turn] + "です。" ;

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
                btn.Text = mark[0];
            }
        }

        private void buttonALl_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Button cpubtn;
            int n = -1;
            Random randomcpu = new Random();

            Drow(YourTurn, btn);

            ButtonMemory();

            while (n == -1)
            {
                int randomIndex = randomcpu.Next(9);
                if (gameBoard[randomIndex] == 0)
                {
                    n = randomIndex;
                }
            }

            Control[] d;
            d = this.Controls.Find("button" + n.ToString(), true);
            cpubtn = (Button)d[0];

            Drow(!YourTurn, cpubtn);

            ButtonMemory();
        }

        public void ButtonMemory()
        {
            Control[] f;
            Button btn;
            for (int i = 0; i < gameBoard.Length; i++)
            {
                f = this.Controls.Find("button" + i.ToString(), true);
                btn = (Button)f[0];

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

        public void Drow(Boolean g, Button h) 
        {
            if (g)
            {
                h.Text = mark[1];
            }
            else
            {
                h.Text = mark[2];
            }

            gameCount++;

        }
    }
}
