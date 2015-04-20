using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Wolfram.NETLink;

namespace Thesis_Forms
{
    public partial class dlgFnInput : Form
    {
        private int brackets;
        private List<string> functionIn;
        private List<string> MathematicaIn;
        private int tmp;

        public dlgFnInput()
        {
            InitializeComponent();
            functionIn = new List<string>();
            MathematicaIn = new List<string>();
            brackets = 0;
        }

        private void bt1_Click(object sender, EventArgs e)
        {
            functionIn.Add("1");
            MathematicaIn.Add("1");
            refreshTxt();
        }

        private void bt2_Click(object sender, EventArgs e)
        {
            functionIn.Add("2");
            MathematicaIn.Add("2");
            refreshTxt();
        }

        private void bt3_Click(object sender, EventArgs e)
        {
            functionIn.Add("3");
            MathematicaIn.Add("3");
            refreshTxt();
        }

        private void bt4_Click(object sender, EventArgs e)
        {
            functionIn.Add("4");
            MathematicaIn.Add("4");
            refreshTxt();
        }

        private void bt5_Click(object sender, EventArgs e)
        {
            functionIn.Add("5");
            MathematicaIn.Add("5");
            refreshTxt();
        }

        private void bt6_Click(object sender, EventArgs e)
        {
            functionIn.Add("6");
            MathematicaIn.Add("6");
            refreshTxt();
        }

        private void bt7_Click(object sender, EventArgs e)
        {
            functionIn.Add("7");
            MathematicaIn.Add("7");
            refreshTxt();
        }

        private void bt8_Click(object sender, EventArgs e)
        {
            functionIn.Add("8");
            MathematicaIn.Add("8");
            refreshTxt();
        }

        private void bt9_Click(object sender, EventArgs e)
        {
            functionIn.Add("9");
            MathematicaIn.Add("9");
            refreshTxt();
        }

        private void bt0_Click(object sender, EventArgs e)
        {
            functionIn.Add("0");
            MathematicaIn.Add("0");
            refreshTxt();
        }

        private void btPlus_Click(object sender, EventArgs e)
        {
            if (int.TryParse(functionIn[functionIn.Count - 1], out tmp) || functionIn[functionIn.Count - 1] == ")")
            {
                functionIn.Add("+");
                MathematicaIn.Add("+");
                refreshTxt();
            }
            else
            {
                MessageBox.Show("Operator must follow number or bracket", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btMinus_Click(object sender, EventArgs e)
        {
            if (int.TryParse(functionIn[functionIn.Count - 1], out tmp) || functionIn[functionIn.Count - 1] == ")")
            {
                functionIn.Add("-");
                MathematicaIn.Add("-");
                refreshTxt();
            }
            else
            {
                MessageBox.Show("Operator must follow number or bracket", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btStar_Click(object sender, EventArgs e)
        {
            if (int.TryParse(functionIn[functionIn.Count - 1], out tmp) || functionIn[functionIn.Count - 1] == ")")
            {
                functionIn.Add("*");
                MathematicaIn.Add("*");
                refreshTxt();
            }
            else
            {
                MessageBox.Show("Operator must follow number or bracket", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btDiv_Click(object sender, EventArgs e)
        {
            if (int.TryParse(functionIn[functionIn.Count - 1], out tmp) || functionIn[functionIn.Count - 1] == ")")
            {
                functionIn.Add("/");
                MathematicaIn.Add("/");
                refreshTxt();
            }
            else
            {
                MessageBox.Show("Operator must follow number or bracket", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btLBrack_Click(object sender, EventArgs e)
        {

            if (functionIn[functionIn.Count - 1] == "+" || functionIn[functionIn.Count - 1] == "/" ||
                functionIn[functionIn.Count - 1] == "-" || functionIn[functionIn.Count - 1] == "*" ||
                functionIn[functionIn.Count - 1] == "^" || functionIn.Count == 0)
            {
                brackets++;
                functionIn.Add("(");
                MathematicaIn.Add("(");
                refreshTxt();
            }
            else
            {
                MessageBox.Show("Bracket must follow an operator", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btRBrack_Click(object sender, EventArgs e)
        {

            if (functionIn[functionIn.Count - 1] == "+" || functionIn[functionIn.Count - 1] == "/" ||
                functionIn[functionIn.Count - 1] == "-" || functionIn[functionIn.Count - 1] == "*" ||
                functionIn[functionIn.Count - 1] == "^" || functionIn[functionIn.Count - 1] == "(")
            {
                MessageBox.Show("Right bracket must follow an number or right bracket", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                brackets--;
                functionIn.Add(")");
                MathematicaIn.Add(")");
                refreshTxt();
            }

        }

        private void btPow_Click(object sender, EventArgs e)
        {
            brackets++;
            functionIn.Add("^(");
            MathematicaIn.Add("^(");
            refreshTxt();
        }

        private void btSin_Click(object sender, EventArgs e)
        {
            if (functionIn[functionIn.Count - 1] == "+" || functionIn[functionIn.Count - 1] == "/" ||
                functionIn[functionIn.Count - 1] == "-" || functionIn[functionIn.Count - 1] == "*" ||
                functionIn[functionIn.Count - 1] == "^" || functionIn.Count == 0)
            {
                brackets++;
                functionIn.Add("Sin(");
                MathematicaIn.Add("Sin[");
                refreshTxt();
            }
            else
            {
                MessageBox.Show("Function must follow an operator", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btCos_Click(object sender, EventArgs e)
        {
            if (functionIn[functionIn.Count - 1] == "+" || functionIn[functionIn.Count - 1] == "/" ||
                functionIn[functionIn.Count - 1] == "-" || functionIn[functionIn.Count - 1] == "*" ||
                functionIn[functionIn.Count - 1] == "^" || functionIn.Count == 0)
            {
                brackets++;
                functionIn.Add("Cos(");
                MathematicaIn.Add("Cos[");
                refreshTxt();
            }
            else
            {
                MessageBox.Show("Function must follow an operator", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bExp_Click(object sender, EventArgs e)
        {
            if (functionIn[functionIn.Count - 1] == "+" || functionIn[functionIn.Count - 1] == "/" ||
                functionIn[functionIn.Count - 1] == "-" || functionIn[functionIn.Count - 1] == "*" ||
                functionIn[functionIn.Count - 1] == "^" || functionIn.Count == 0)
            {
                brackets++;
                functionIn.Add("Exp(");
                MathematicaIn.Add("Exp[");
                refreshTxt();
            }
            else
            {
                MessageBox.Show("Function must follow an operator", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btMRBrack_Click(object sender, EventArgs e)
        {
            brackets--;
            MathematicaIn.Add("]");
            refreshTxt();

        }

        private void bt_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btBack_Click(object sender, EventArgs e)
        {
            MathematicaIn.RemoveAt(MathematicaIn.Count - 1);
            refreshTxt();
        }
        public void refreshTxt()
        {
            string output = "";
            foreach (string s in MathematicaIn)
            {
                output += s;
            }
            txt_Output.Text = output;
        }
    }
}
