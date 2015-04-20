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
    public delegate double Function(double[] x);

    public partial class Form1 : Form
    {
        private DrawCurve currentData = null;
 
        private string[] kappa;
        private int[] range;

        private int rangeV = 0;

        public Form1()
        {
            InitializeComponent();
            range = new int[7];
            kappa = new string[7];
            setup();

            chr_2Dcurve.Series[0].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Single;

            
        }

        public void setup()
        {
            lb_curvature.Items.Add("Function 1");
            lb_curvature.Items.Add("Function 2");
            lb_curvature.Items.Add("Function 3");
            lb_curvature.Items.Add("Function 4");
            lb_curvature.Items.Add("Function 5");
            lb_curvature.Items.Add("Function 6");
            lb_curvature.Items.Add("Function 7");

            
            kappa[0] = "1/3+Sin[t]";
            kappa[1] = "1/10+Sin[t]";
            kappa[2] = "1/5+2*Sin[t]+3*Cos[t/3]";
            kappa[3] = "1/5+Sin[t/2]-Cos[t/3]";
            kappa[4] = "1/5+Sin[t/3]+2*Cos[t/2]";
            kappa[5] = "1+(3/(5+4*Cos[t]))*3";
            kappa[6] = "1+(3/(5+4*Cos[t]))*4";

            range[0] = 6;
            range[1] = 20;
            range[2] = 30;
            range[3] = 60;
            range[4] = 60;
            range[5] = 2;
            range[6] = 2;

            lb_curvature.SetSelected(0, true);
            rangeV = 6;
            txt_range.Text = rangeV.ToString();
        }

        private void bt_InputFn_Click(object sender, EventArgs e)
        {
            dlgFnInput fnIn = new dlgFnInput();
            fnIn.ShowDialog();
        }

        //Hookup
        public void HookUp(DrawCurve data)
        {
            currentData = data;
            chr_2Dcurve.DataSource = currentData.Bsdata;
            chr_2Dcurve.Series[0].XValueMember = "X";
            chr_2Dcurve.Series[0].YValueMembers = "Y";

            currentData.Bsdata.ListChanged += new ListChangedEventHandler(Bsdata_ListChanged);
        }
        void Bsdata_ListChanged(object sender, ListChangedEventArgs e)
        {
            chr_2Dcurve.DataBind();
        }


        private void calculate(double lower, double upper)
        {
            if (rb_Math.Checked == true)
            {
                DrawCurve math1 = new DrawCurve();
                MathematicaLink math2 = new MathematicaLink();
                this.Cursor = Cursors.WaitCursor;
                HookUp(math1);
                int choice = lb_curvature.SelectedIndex;
                rangeV = range[choice];
                txt_range.Text = rangeV.ToString();
                math1.SolveAcurate(math2,kappa[choice],rangeV.ToString());

                this.Cursor = Cursors.Arrow;

            }
            else if (rb_Euler.Checked == true)
            {
                DrawCurve rk4 = new DrawCurve();
                this.Cursor = Cursors.WaitCursor;
                HookUp(rk4);
                int choice = lb_curvature.SelectedIndex + 1;
                rk4.SolveFast(rk4, choice, lower, upper);
                this.Cursor = Cursors.Arrow;
            }
        }

        private void txt_range_TextChanged(object sender, EventArgs e)
        {
            int value;
            bool test;

            test = int.TryParse(txt_range.Text, out value);
            if (test)
            {
                rangeV = value;
                calculate(0, value * Math.PI);
            }
        }

        private void btPlus_Click(object sender, EventArgs e)
        {
            rangeV++;
            txt_range.Text = rangeV.ToString();
        }

        private void btMinus_Click(object sender, EventArgs e)
        {
            rangeV--;
            txt_range.Text = rangeV.ToString();
        }

        private void bt_Calc_Click(object sender, EventArgs e)
        {
            calculate(0, rangeV * Math.PI);
        }

        

    }

    
}
