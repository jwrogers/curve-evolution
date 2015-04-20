namespace Thesis_Forms
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.bt_InputFn = new System.Windows.Forms.Button();
            this.txt_FnOut = new System.Windows.Forms.TextBox();
            this.chr_2Dcurve = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lb_curvature = new System.Windows.Forms.ListBox();
            this.tt_main = new System.Windows.Forms.ToolTip(this.components);
            this.txt_range = new System.Windows.Forms.TextBox();
            this.lbl_range = new System.Windows.Forms.Label();
            this.btPlus = new System.Windows.Forms.Button();
            this.btMinus = new System.Windows.Forms.Button();
            this.txt_lower = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rb_Euler = new System.Windows.Forms.RadioButton();
            this.rb_Math = new System.Windows.Forms.RadioButton();
            this.bt_Calc = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chr_2Dcurve)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bt_InputFn
            // 
            this.bt_InputFn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bt_InputFn.Location = new System.Drawing.Point(688, 56);
            this.bt_InputFn.Name = "bt_InputFn";
            this.bt_InputFn.Size = new System.Drawing.Size(192, 48);
            this.bt_InputFn.TabIndex = 0;
            this.bt_InputFn.Text = "Input Function";
            this.bt_InputFn.UseVisualStyleBackColor = true;
            this.bt_InputFn.Click += new System.EventHandler(this.bt_InputFn_Click);
            // 
            // txt_FnOut
            // 
            this.txt_FnOut.Location = new System.Drawing.Point(688, 16);
            this.txt_FnOut.Name = "txt_FnOut";
            this.txt_FnOut.ReadOnly = true;
            this.txt_FnOut.Size = new System.Drawing.Size(192, 20);
            this.txt_FnOut.TabIndex = 1;
            // 
            // chr_2Dcurve
            // 
            chartArea1.Name = "ChartArea1";
            this.chr_2Dcurve.ChartAreas.Add(chartArea1);
            legend1.Enabled = false;
            legend1.Name = "Legend1";
            this.chr_2Dcurve.Legends.Add(legend1);
            this.chr_2Dcurve.Location = new System.Drawing.Point(8, 8);
            this.chr_2Dcurve.Name = "chr_2Dcurve";
            this.chr_2Dcurve.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright;
            series1.BorderWidth = 5;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Color = System.Drawing.Color.DodgerBlue;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            this.chr_2Dcurve.Series.Add(series1);
            this.chr_2Dcurve.Size = new System.Drawing.Size(600, 600);
            this.chr_2Dcurve.TabIndex = 2;
            // 
            // lb_curvature
            // 
            this.lb_curvature.FormattingEnabled = true;
            this.lb_curvature.Location = new System.Drawing.Point(696, 128);
            this.lb_curvature.Name = "lb_curvature";
            this.lb_curvature.Size = new System.Drawing.Size(184, 160);
            this.lb_curvature.TabIndex = 3;
            // 
            // tt_main
            // 
            this.tt_main.AutomaticDelay = 200;
            // 
            // txt_range
            // 
            this.txt_range.Location = new System.Drawing.Point(760, 304);
            this.txt_range.Name = "txt_range";
            this.txt_range.Size = new System.Drawing.Size(32, 20);
            this.txt_range.TabIndex = 5;
            this.txt_range.TextChanged += new System.EventHandler(this.txt_range_TextChanged);
            // 
            // lbl_range
            // 
            this.lbl_range.AutoSize = true;
            this.lbl_range.Location = new System.Drawing.Point(688, 304);
            this.lbl_range.Name = "lbl_range";
            this.lbl_range.Size = new System.Drawing.Size(39, 13);
            this.lbl_range.TabIndex = 6;
            this.lbl_range.Text = "Range";
            // 
            // btPlus
            // 
            this.btPlus.Location = new System.Drawing.Point(728, 328);
            this.btPlus.Name = "btPlus";
            this.btPlus.Size = new System.Drawing.Size(32, 32);
            this.btPlus.TabIndex = 7;
            this.btPlus.Text = "+";
            this.btPlus.UseVisualStyleBackColor = true;
            this.btPlus.Click += new System.EventHandler(this.btPlus_Click);
            // 
            // btMinus
            // 
            this.btMinus.Location = new System.Drawing.Point(760, 328);
            this.btMinus.Name = "btMinus";
            this.btMinus.Size = new System.Drawing.Size(32, 32);
            this.btMinus.TabIndex = 8;
            this.btMinus.Text = "-";
            this.btMinus.UseVisualStyleBackColor = true;
            this.btMinus.Click += new System.EventHandler(this.btMinus_Click);
            // 
            // txt_lower
            // 
            this.txt_lower.Location = new System.Drawing.Point(728, 304);
            this.txt_lower.Name = "txt_lower";
            this.txt_lower.Size = new System.Drawing.Size(32, 20);
            this.txt_lower.TabIndex = 9;
            this.txt_lower.Text = "0  to ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rb_Euler);
            this.groupBox1.Controls.Add(this.rb_Math);
            this.groupBox1.Location = new System.Drawing.Point(728, 368);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(120, 64);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            // 
            // rb_Euler
            // 
            this.rb_Euler.AutoSize = true;
            this.rb_Euler.Location = new System.Drawing.Point(8, 40);
            this.rb_Euler.Name = "rb_Euler";
            this.rb_Euler.Size = new System.Drawing.Size(86, 17);
            this.rb_Euler.TabIndex = 1;
            this.rb_Euler.Text = "Fast Solution";
            this.rb_Euler.UseVisualStyleBackColor = true;
            // 
            // rb_Math
            // 
            this.rb_Math.AutoSize = true;
            this.rb_Math.Checked = true;
            this.rb_Math.Location = new System.Drawing.Point(8, 16);
            this.rb_Math.Name = "rb_Math";
            this.rb_Math.Size = new System.Drawing.Size(109, 17);
            this.rb_Math.TabIndex = 0;
            this.rb_Math.TabStop = true;
            this.rb_Math.Text = "Accurate Solution";
            this.rb_Math.UseVisualStyleBackColor = true;
            // 
            // bt_Calc
            // 
            this.bt_Calc.Location = new System.Drawing.Point(696, 456);
            this.bt_Calc.Name = "bt_Calc";
            this.bt_Calc.Size = new System.Drawing.Size(192, 48);
            this.bt_Calc.TabIndex = 11;
            this.bt_Calc.Text = "Calculate";
            this.bt_Calc.UseVisualStyleBackColor = true;
            this.bt_Calc.Click += new System.EventHandler(this.bt_Calc_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(907, 602);
            this.Controls.Add(this.bt_Calc);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txt_lower);
            this.Controls.Add(this.btMinus);
            this.Controls.Add(this.btPlus);
            this.Controls.Add(this.lbl_range);
            this.Controls.Add(this.txt_range);
            this.Controls.Add(this.lb_curvature);
            this.Controls.Add(this.chr_2Dcurve);
            this.Controls.Add(this.txt_FnOut);
            this.Controls.Add(this.bt_InputFn);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.chr_2Dcurve)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bt_InputFn;
        private System.Windows.Forms.TextBox txt_FnOut;
        private System.Windows.Forms.DataVisualization.Charting.Chart chr_2Dcurve;
        private System.Windows.Forms.ListBox lb_curvature;
        private System.Windows.Forms.ToolTip tt_main;
        private System.Windows.Forms.TextBox txt_range;
        private System.Windows.Forms.Label lbl_range;
        private System.Windows.Forms.Button btPlus;
        private System.Windows.Forms.Button btMinus;
        private System.Windows.Forms.TextBox txt_lower;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rb_Euler;
        private System.Windows.Forms.RadioButton rb_Math;
        private System.Windows.Forms.Button bt_Calc;
    }
}

