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

        public string[] player = new string[] { "", "あなた", "CPU" };

        public Boolean PrimaryTurn;

        public int gameCount, Turn, cpuTurn;

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
            cpuTurn = shiftTurn(YourTurn);
            label.Text = "あなたの手番は" + mark[Turn] + "です。";

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

        private void buttonAll_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Button cpubtn;
            int n = -1;
            Random randomcpu = new Random();

            Drow(YourTurn, btn);

            ButtonMemory();

            if (judge(Turn))
            {
                MessageBox.Show(player[Turn] + "の勝利");
                BoardEnable(false);
                return;
            }

            if (gameCount >= 9)
            {
                MessageBox.Show("引き分け");
                BoardEnable(false);
                return;
            }

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

            if (judge(cpuTurn))
            {
                MessageBox.Show(player[cpuTurn] + "の勝利");
                BoardEnable(false);
                return;
            }
            if (gameCount >= 9)
            {
                MessageBox.Show("引き分け");
                BoardEnable(false);
                return;
            }

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

        private Boolean judge(int k)
        {
            int[,] finish = new int[8, 3] {{0, 1, 2},
                                   {3, 4, 5},
                                   {6, 7, 8},
                                   {0, 3, 6},
                                   {1, 4, 7},
                                   {2, 5, 8},
                                   {0, 4, 8},
                                   {2, 4, 6}
                                  };
            int cnt;

            for (int i = 0; i < finish.GetLength(0); i++)
            {
                cnt = 0;
                for (int j = 0; j < finish.GetLength(1); j++)
                {
                    int place = finish[i, j];
                    if (gameBoard[place] == 0)
                    {
                        break;
                    }
                    else if (gameBoard[place] == k)
                    {
                        cnt++;
                    }
                    else
                    {
                        break;
                    }
                }
                if (cnt == finish.GetLength(1))
                {
                    return true;
                }
            }

            return false;
        }

        public int shiftTurn(Boolean p)
        {
            int point;
            if (p)
            {
                point = 2;
            }
            else
            {
                point = 1;
            }

            return point;
        }
    }
}
