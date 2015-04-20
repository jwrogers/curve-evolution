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
    public class DrawCurve
    {
        
    

        //private static Function kappa1 = x => (1.0 / 3.0) + Math.Sin(x[0]);
        //private static Function kappa2 = x => (1.0 / 5.0) + 2 * Math.Sin(x[0]) + 3 * Math.Cos(x[0] / 3.0);
        //private static Function kappa3 = x => (1.0 / 5.0) + Math.Sin(x[0] / 2.0) - Math.Cos(x[0] / 3.0);
        //private static Function kappa4 = x => (1.0 / 5.0) + Math.Sin(x[0] / 3.0) + 2 * Math.Cos(x[0] / 2.0);
        //private static Function kappa5 = x => (1.0 / 10.0) + Math.Sin(x[0]);
        //private static Function kappa6 = x => 1 + (3.0 / (5 + 4 * Math.Cos(x[0]))) * (3);
        //private static Function kappa7 = x => 1 + (3.0 / (5 + 4 * Math.Cos(x[0]))) * (4);

        //private static Function u3dashk1 = x => (deriv / ((1.0 / 3.0) + Math.Sin(x[0]))) * x[3] - (((1.0 / 3.0) + Math.Sin(x[1])) * ((1.0 / 3.0) + Math.Sin(x[0])) * x[2]);
        //private static Function u3dashk2 = x => (deriv / ((1.0 / 5.0) + 2 * Math.Sin(x[0]) + 3 * Math.Cos(x[0] / 3.0))) * x[3] - (((1.0 / 5.0) + 2 * Math.Sin(x[0]) + 3 * Math.Cos(x[0] / 3.0)) * ((1.0 / 5.0) + 2 * Math.Sin(x[0]) + 3 * Math.Cos(x[0] / 3.0)) * x[2]);
        //private static Function u3dashk3 = x => (deriv / ((1.0 / 5.0) + Math.Sin(x[0] / 2.0) - Math.Cos(x[0] / 3.0))) * x[3] - (((1.0 / 5.0) + Math.Sin(x[0] / 2.0) - Math.Cos(x[0] / 3.0)) * ((1.0 / 5.0) + Math.Sin(x[0] / 2.0) - Math.Cos(x[0] / 3.0)) * x[2]);
        //private static Function u3dashk4 = x => (deriv / ((1.0 / 5.0) + Math.Sin(x[0] / 3.0) + 2 * Math.Cos(x[0] / 2.0))) * x[3] - (((1.0 / 5.0) + Math.Sin(x[0] / 3.0) + 2 * Math.Cos(x[0] / 2.0)) * ((1.0 / 5.0) + Math.Sin(x[0] / 3.0) + 2 * Math.Cos(x[0] / 2.0)) * x[2]);
        //private static Function u3dashk5 = x => (deriv / ((1.0 / 10.0) + Math.Sin(x[0]))) * x[3] - (((1.0 / 10.0) + Math.Sin(x[0])) * ((1.0 / 10.0) + Math.Sin(x[0])) * x[2]);
        //private static Function u3dashk6 = x => (deriv / (1 + (3.0 / (5 + 4 * Math.Cos(x[0]))) * (3))) * x[3] - ((1 + (3.0 / (5 + 4 * Math.Cos(x[0]))) * (3)) * (1 + (3.0 / (5 + 4 * Math.Cos(x[0]))) * (3)) * x[2]);
        //private static Function u3dashk7 = x => (deriv / (1 + (3.0 / (5 + 4 * Math.Cos(x[0]))) * (4))) * x[3] - ((1 + (3.0 / (5 + 4 * Math.Cos(x[0]))) * (4)) * (1 + (3.0 / (5 + 4 * Math.Cos(x[0]))) * (4)) * x[2]);

        //data binding source
        private BindingSource bsdata = new BindingSource();
        public BindingSource Bsdata
        {
            get { return bsdata; }
            set { bsdata = value; }
        }
        //List of solution data points
        private BindingList<Vector> solution = new BindingList<Vector>();
        internal BindingList<Vector> Solution
        {
            get { return solution; }
            set { solution = value; }
        }

        /// <summary>
        /// The method for calculating a step of the third order RKF solver
        /// </summary>
        /// <param name="f1">The first function to be solved</param>
        /// <param name="f2">The second function to be solved</param>
        /// <param name="f3">The third function to be solved</param>
        /// <param name="t">The time/current iteration step</param>
        /// <param name="h">The step size</param>
        /// <param name="y">The previous points</param>
        /// <returns>The new points</returns>
        private List<double[]> RKFStep(Function f1, Function f2, Function f3, double t, double h, double[] y)
        {
            double K11, K21, K31, K41, K12, K22, K32, K42, K13, K23, K33, K43, K51, K52, K53, K61, K62, K63;
            double[] yNew = new double[3];
            double[] yNewhat = new double[3];
            double[] R = new double[3];
            double C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22, C23, C24, C25, C26;
            C1 = 3.0 / 8.0; C2 = 3.0 / 32.0; C3 = 9.0 / 32.0;

            C4 = 12.0 / 13.0; C5 = 1932.0 / 2197.0; C6 = 7200.0 / 2197.0; C7 = 7296.0 / 2197.0;

            C8 = 439.0 / 216.0; C9 = 3680.0 / 513.0; C10 = 845.0 / 4104.0;

            C12 = 8.0 / 27.0; C13 = 3544.0 / 2565.0; C14 = 1859.0 / 4104.0; C15 = 11.0 / 40.0;

            C16 = 25.0 / 216.0; C17 = 1408.0 / 2565.0; C18 = 2197.0 / 4104.0;

            C19 = 16.0 / 135.0; C20 = 6656.0 / 12825.0; C21 = 28561.0 / 56430.0; C22 = 9.0 / 50.0; C23 = 2.0 / 55.0;

            C24 = 128.0 / 4275.0; C25 = 2197.0 / 75240.0;

            C26 = 2.0 / 55.0;

            K11 = h * f1(new double[] { t, y[0], y[1], y[2] });
            K12 = h * f2(new double[] { t, y[0], y[1], y[2] });
            K13 = h * f3(new double[] { t, y[0], y[1], y[2] });

            K21 = h * f1(new double[] { t + 0.25 * h, y[0] + 0.25 * K11, y[1] + 0.25 * K12, y[2] + 0.25 * K13 });
            K22 = h * f2(new double[] { t + 0.25 * h, y[0] + 0.25 * K11, y[1] + 0.25 * K12, y[2] + 0.25 * K13 });
            K23 = h * f3(new double[] { t + 0.25 * h, y[0] + 0.25 * K11, y[1] + 0.25 * K12, y[2] + 0.25 * K13 });

            K31 = h * f1(new double[] { t + C1 * h, y[0] + C2 * K11 + C3 * K21, y[1] + C2 * K12 + C3 * K22, y[2] + C2 * K13 + C3 * K23 });
            K32 = h * f2(new double[] { t + C1 * h, y[0] + C2 * K11 + C3 * K21, y[1] + C2 * K12 + C3 * K22, y[2] + C2 * K13 + C3 * K23 });
            K33 = h * f3(new double[] { t + C1 * h, y[0] + C2 * K11 + C3 * K21, y[1] + C2 * K12 + C3 * K22, y[2] + C2 * K13 + C3 * K23 });

            K41 = h * f1(new double[] { t + C4 * h, y[0] + C5 * K11 - C6 * K21 + C7 * K31, y[1] + C5 * K12 - C6 * K21 + C7 * K32, y[2] + C5 * K13 - C6 * K23 + C7 * K33 });
            K42 = h * f2(new double[] { t + C4 * h, y[0] + C5 * K11 - C6 * K21 + C7 * K31, y[1] + C5 * K12 - C6 * K21 + C7 * K32, y[2] + C5 * K13 - C6 * K23 + C7 * K33 });
            K43 = h * f3(new double[] { t + C4 * h, y[0] + C5 * K11 - C6 * K21 + C7 * K31, y[1] + C5 * K12 - C6 * K21 + C7 * K32, y[2] + C5 * K13 - C6 * K23 + C7 * K33 });

            K51 = h * f1(new double[] { t + h, y[0] + C8 * K11 - 8.0 * K21 + C9 * K31 - C10 * K41, y[1] + C8 * K12 - 8.0 * K22 + C9 * K32 - C10 * K42, y[2] + C8 * K13 - 8.0 * K23 + C9 * K33 - C10 * K43 });
            K52 = h * f2(new double[] { t + h, y[0] + C8 * K11 - 8.0 * K21 + C9 * K31 - C10 * K41, y[1] + C8 * K12 - 8.0 * K22 + C9 * K32 - C10 * K42, y[2] + C8 * K13 - 8.0 * K23 + C9 * K33 - C10 * K43 });
            K53 = h * f3(new double[] { t + h, y[0] + C8 * K11 - 8.0 * K21 + C9 * K31 - C10 * K41, y[1] + C8 * K12 - 8.0 * K22 + C9 * K32 - C10 * K42, y[2] + C8 * K13 - 8.0 * K23 + C9 * K33 - C10 * K43 });

            K61 = h * f1(new double[] { t + 0.5 * h, y[0] - C12 * K11 + 2.0 * K21 - C13 * K31 + C14 * K41 - C15 * K51, y[1] - C12 * K12 + 2.0 * K22 - C13 * K32 + C14 * K42 - C15 * K52, y[2] - C12 * K13 + 2.0 * K23 - C13 * K33 + C14 * K43 - C15 * K53 });
            K62 = h * f2(new double[] { t + 0.5 * h, y[0] - C12 * K11 + 2.0 * K21 - C13 * K31 + C14 * K41 - C15 * K51, y[1] - C12 * K12 + 2.0 * K22 - C13 * K32 + C14 * K42 - C15 * K52, y[2] - C12 * K13 + 2.0 * K23 - C13 * K33 + C14 * K43 - C15 * K53 });
            K63 = h * f3(new double[] { t + 0.5 * h, y[0] - C12 * K11 + 2.0 * K21 - C13 * K31 + C14 * K41 - C15 * K51, y[1] - C12 * K12 + 2.0 * K22 - C13 * K32 + C14 * K42 - C15 * K52, y[2] - C12 * K13 + 2.0 * K23 - C13 * K33 + C14 * K43 - C15 * K53 });

            yNew[0] = y[0] + C16 * K11 + C17 * K31 + C18 * K41 - K51 / 5.0;
            yNew[1] = y[1] + C16 * K12 + C17 * K32 + C18 * K42 - K52 / 5.0;
            yNew[2] = y[2] + C16 * K13 + C17 * K33 + C18 * K43 - K53 / 5.0;

            //yNewhat[0] = y[0] + C19 * K11 + C20 * K31 + C21 * K41 - C22 * K51 + C23 * K61;
            //yNewhat[1] = y[1] + C19 * K12 + C20 * K32 + C21 * K42 - C22 * K52 + C23 * K62;
            //yNewhat[2] = y[2] + C19 * K13 + C20 * K33 + C21 * K43 - C22 * K53 + C23 * K63;

            R[0] = (1.0 / h) * Math.Abs((K11 / 360.0) - C24 * K31 - C25 * K41 + (K51 / 50.0) + C26 * K61);
            R[1] = (1.0 / h) * Math.Abs((K12 / 360.0) - C24 * K32 - C25 * K42 + (K52 / 50.0) + C26 * K62);
            R[2] = (1.0 / h) * Math.Abs((K13 / 360.0) - C24 * K33 - C25 * K43 + (K53 / 50.0) + C26 * K63);

            return new List<double[]> { yNew, yNewhat, R };
        }
        /// <summary>
        /// A method for computing a solution to a third order IVP ODE using RKF
        /// </summary>
        /// <param name="f1">The first function to be solved</param>
        /// <param name="f2">The second function to be solved</param>
        /// <param name="f3">The third function to be solved</param>
        /// <param name="y0">The initial values for the system</param>
        /// <param name="a">The lower bound to the range</param>
        /// <param name="b">The upper bound to the range</param>
        /// <param name="NumSteps">The number of steps to take in the range</param>
        /// <returns>A list of points calculated by the function</returns>
        public List<Vector>[] RKF(double[] y0, double a, double b, int NumSteps, int choice)
        {
            List<Vector> odesol1 = new List<Vector>();
            double h = (Math.Max(a, b) - Math.Min(a, b)) / (NumSteps - 1.0);
            double xt = a, x0 = 0;
            double[] yNew = y0, yOld = new double[yNew.Length];
            int i = 0;
            double deriv = 0;
            List<double[]> resultStep = new List<double[]>();
            //double tolerance = 1E-9;
            double err = 0, tol = 1E-4, /*maxErr = 0, delta = 0,*/ s = 0;

            double hmin = 1E-9;
            double hmax = 5;

            Function udash = x => x[2];
            Function u2dash = x => x[3];
            Function u3dash = x => x[0];
            Function kappa1 = x => (1.0 / 3.0) + Math.Sin(x[0]);
            Function kappa2 = x => (1.0 / 5.0) + 2 * Math.Sin(x[0]) + 3 * Math.Cos(x[0] / 3.0);
            Function kappa3 = x => (1.0 / 5.0) + Math.Sin(x[0] / 2.0) - Math.Cos(x[0] / 3.0);
            Function kappa4 = x => (1.0 / 5.0) + Math.Sin(x[0] / 3.0) + 2 * Math.Cos(x[0] / 2.0);
            Function kappa5 = x => (1.0 / 10.0) + Math.Sin(x[0]);
            Function kappa6 = x => 1 + (3.0 / (5 + 4 * Math.Cos(x[0]))) * (3);
            Function kappa7 = x => 1 + (3.0 / (5 + 4 * Math.Cos(x[0]))) * (4);

            while (i<NumSteps)
            {
                /*if (i >= NumSteps)
                {
                    break;
                }*/
                
                switch (choice)
                {
                    case (1):
                        deriv = DrawCurve.RichardsonWithError(kappa1, xt, 1E-6, 10000, 1E-9);
                        u3dash = x => (deriv / ((1.0 / 3.0) + Math.Sin(x[0]))) * x[3] - (((1.0 / 3.0) + Math.Sin(x[0])) * ((1.0 / 3.0) + Math.Sin(x[0])) * x[2]);
                        break;
                    case (2):
                        deriv = DrawCurve.RichardsonWithError(kappa2, xt, 1E-6, 10000, 1E-9);
                        u3dash = x => (deriv / ((1.0 / 5.0) + 2 * Math.Sin(x[0]) + 3 * Math.Cos(x[0] / 3.0))) * x[3] - (((1.0 / 5.0) + 2 * Math.Sin(x[0]) + 3 * Math.Cos(x[0] / 3.0)) * ((1.0 / 5.0) + 2 * Math.Sin(x[0]) + 3 * Math.Cos(x[0] / 3.0)) * x[2]); ;
                        break;
                    case (3):
                        deriv = DrawCurve.RichardsonWithError(kappa3, xt, 1E-6, 10000, 1E-9);
                        u3dash = x => (deriv / ((1.0 / 5.0) + Math.Sin(x[0] / 2.0) - Math.Cos(x[0] / 3.0))) * x[3] - (((1.0 / 5.0) + Math.Sin(x[0] / 2.0) - Math.Cos(x[0] / 3.0)) * ((1.0 / 5.0) + Math.Sin(x[0] / 2.0) - Math.Cos(x[0] / 3.0)) * x[2]);
                        break;
                    case (4):
                        deriv = DrawCurve.RichardsonWithError(kappa4, xt, 1E-6, 10000, 1E-9);
                        u3dash = x => (deriv / ((1.0 / 5.0) + Math.Sin(x[0] / 3.0) + 2 * Math.Cos(x[0] / 2.0))) * x[3] - (((1.0 / 5.0) + Math.Sin(x[0] / 3.0) + 2 * Math.Cos(x[0] / 2.0)) * ((1.0 / 5.0) + Math.Sin(x[0] / 3.0) + 2 * Math.Cos(x[0] / 2.0)) * x[2]);
                        break;
                    case (5):
                        deriv = DrawCurve.RichardsonWithError(kappa5, xt, 1E-6, 10000, 1E-9);
                        u3dash = x => (deriv / ((1.0 / 10.0) + Math.Sin(x[0]))) * x[3] - (((1.0 / 10.0) + Math.Sin(x[0])) * ((1.0 / 10.0) + Math.Sin(x[0])) * x[2]);
                        break;
                    case (6):
                        deriv = DrawCurve.RichardsonWithError(kappa6, xt, 1E-6, 10000, 1E-9);
                        u3dash = x => (deriv / (1 + (3.0 / (5 + 4 * Math.Cos(x[0]))) * (3))) * x[3] - ((1 + (3.0 / (5 + 4 * Math.Cos(x[0]))) * (3)) * (1 + (3.0 / (5 + 4 * Math.Cos(x[0]))) * (3)) * x[2]);
                        break;
                    case (7):
                        deriv = DrawCurve.RichardsonWithError(kappa7, xt, 1E-6, 10000, 1E-9);
                        u3dash = x => (deriv / (1 + (3.0 / (5 + 4 * Math.Cos(x[0]))) * (4))) * x[3] - ((1 + (3.0 / (5 + 4 * Math.Cos(x[0]))) * (4)) * (1 + (3.0 / (5 + 4 * Math.Cos(x[0]))) * (4)) * x[2]);
                        break;
                    default:
                        deriv = DrawCurve.RichardsonWithError(kappa5, xt, 1E-6, 10000, 1E-9);
                        u3dash = x => (deriv / ((1.0 / 10.0) + Math.Sin(x[0]))) * x[3] - (((1.0 / 10.0) + Math.Sin(x[0])) * ((1.0 / 10.0) + Math.Sin(x[0])) * x[2]);
                        break;
                }
                odesol1.Add(new Vector(xt, yNew[0],0));
                for (int j = 0; j < yNew.Length; j++)
                {
                    yOld[j] = yNew[j];
                }
                resultStep = RKFStep(udash, u2dash, u3dash, xt, h, yOld);

                /*for (int j = 0; j < 3; j++)
                {
                    err = Math.Max(err, resultStep[2][j]);
                }*/
                err = resultStep[2][0];
                s = Math.Pow(0.5 * tol / err, 0.25);

                if (err < tol)
                {
                    yNew = resultStep[0];
                    xt = x0 + h;
                    x0 = xt;
                }
                if (s < 0.1)
                {
                    s = 0.1;
                }
                else if (s > 4.0)
                {
                    s = 4.0;
                }
                h *= s;
                if (h > b - x0)
                {
                    h = b - x0;
                }
                if (h > hmax)
                {
                    h = hmax;
                }
                else if (h < hmin)
                {
                    h = hmin;
                }
                i++;
                err = 0;
            }
            deriv = 0;
            return new List<Vector>[] { odesol1 };
        }



        /// <summary>
        /// The method for calculating a step of the third order RK4 solver
        /// </summary>
        /// <param name="f1">The first function to be solved</param>
        /// <param name="f2">The second function to be solved</param>
        /// <param name="f3">The third function to be solved</param>
        /// <param name="t">The time/current iteration step</param>
        /// <param name="h">The step size</param>
        /// <param name="y">The previous points</param>
        /// <returns>The new points</returns>
        private double[] RK4Step(Function f1, Function f2, Function f3, double x, double h, double[] y)
        {
            double F11, F21, F31, F41, F12, F22, F32, F42, F13, F23, F33, F43;
            double[] yNew = new double[3];

            F11 = h * f1(new double[] { x, y[0], y[1], y[2] });
            F12 = h * f2(new double[] { x, y[0], y[1], y[2] });
            F13 = h * f3(new double[] { x, y[0], y[1], y[2] });

            F21 = h * f1(new double[] { x + 0.5 * h, y[0] + 0.5 * F11, y[1] + 0.5 * F12, y[2] + 0.5 * F13 });
            F22 = h * f2(new double[] { x + 0.5 * h, y[0] + 0.5 * F11, y[1] + 0.5 * F12, y[2] + 0.5 * F13 });
            F23 = h * f3(new double[] { x + 0.5 * h, y[0] + 0.5 * F11, y[1] + 0.5 * F12, y[2] + 0.5 * F13 });

            F31 = h * f1(new double[] { x + 0.5 * h, y[0] + 0.5 * F21, y[1] + 0.5 * F22, y[2] + 0.5 * F23 });
            F32 = h * f2(new double[] { x + 0.5 * h, y[0] + 0.5 * F21, y[1] + 0.5 * F22, y[2] + 0.5 * F23 });
            F33 = h * f3(new double[] { x + 0.5 * h, y[0] + 0.5 * F21, y[1] + 0.5 * F22, y[2] + 0.5 * F23 });

            F41 = h * f1(new double[] { x + h, y[0] + F31, y[1] + F32, y[2] + F33 });
            F42 = h * f2(new double[] { x + h, y[0] + F31, y[1] + F32, y[2] + F33 });
            F43 = h * f3(new double[] { x + h, y[0] + F31, y[1] + F32, y[2] + F33 });

            yNew[0] = y[0] + (1 / 6.0) * (F11 + 2 * F21 + 2 * F31 + F41);
            yNew[1] = y[1] + (1 / 6.0) * (F12 + 2 * F22 + 2 * F32 + F42);
            yNew[2] = y[2] + (1 / 6.0) * (F13 + 2 * F23 + 2 * F33 + F43);

            return yNew;
        }
        /// <summary>
        /// A method for computing a solution to a third order IVP ODE using RK4
        /// </summary>
        /// <param name="f1">The first function to be solved</param>
        /// <param name="f2">The second function to be solved</param>
        /// <param name="f3">The third function to be solved</param>
        /// <param name="y0">The initial values for the system</param>
        /// <param name="a">The lower bound to the range</param>
        /// <param name="b">The upper bound to the range</param>
        /// <param name="NumSteps">The number of steps to take in the range</param>
        /// <returns>A list of points calculated by the function</returns>
        public List<Vector>[] RK4(double[] y0, double a, double b, int NumSteps, int choice)
        {
            List<Vector> odesol1 = new List<Vector>();

            double h = (Math.Max(a, b) - Math.Min(a, b)) / (NumSteps - 1.0);
            double xt = a;
            double[] yNew = y0, yOld = new double[yNew.Length];
            int i = 0;
            double deriv = 0;


            Function udash = x => x[2];
            Function u2dash = x => x[3];
            Function u3dash = x => x[0];
            Function kappa1 = x => (1.0 / 3.0) + Math.Sin(x[0]);
            Function kappa2 = x => (1.0 / 5.0) + 2 * Math.Sin(x[0]) + 3 * Math.Cos(x[0] / 3.0);
            Function kappa3 = x => (1.0 / 5.0) + Math.Sin(x[0] / 2.0) - Math.Cos(x[0] / 3.0);
            Function kappa4 = x => (1.0 / 5.0) + Math.Sin(x[0] / 3.0) + 2 * Math.Cos(x[0] / 2.0);
            Function kappa5 = x => (1.0 / 10.0) + Math.Sin(x[0]);
            Function kappa6 = x => 1 + (3.0 / (5 + 4 * Math.Cos(x[0]))) * (3);
            Function kappa7 = x => 1 + (3.0 / (5 + 4 * Math.Cos(x[0]))) * (4);

            while (i < NumSteps)
            {
                switch (choice)
                {
                    case (1):
                        deriv = DrawCurve.RichardsonWithError(kappa1, xt, 1E-6, 10000, 1E-9);
                        u3dash = x => (deriv / ((1.0 / 3.0) + Math.Sin(x[0]))) * x[3] - (((1.0 / 3.0) + Math.Sin(x[0])) * ((1.0 / 3.0) + Math.Sin(x[0])) * x[2]);
                        break;
                    case (2):
                        deriv = DrawCurve.RichardsonWithError(kappa2, xt, 1E-6, 10000, 1E-9);
                        u3dash = x => (deriv / ((1.0 / 5.0) + 2 * Math.Sin(x[0]) + 3 * Math.Cos(x[0] / 3.0))) * x[3] - (((1.0 / 5.0) + 2 * Math.Sin(x[0]) + 3 * Math.Cos(x[0] / 3.0)) * ((1.0 / 5.0) + 2 * Math.Sin(x[0]) + 3 * Math.Cos(x[0] / 3.0)) * x[2]); ;
                        break;
                    case (3):
                        deriv = DrawCurve.RichardsonWithError(kappa3, xt, 1E-6, 10000, 1E-9);
                        u3dash = x => (deriv / ((1.0 / 5.0) + Math.Sin(x[0] / 2.0) - Math.Cos(x[0] / 3.0))) * x[3] - (((1.0 / 5.0) + Math.Sin(x[0] / 2.0) - Math.Cos(x[0] / 3.0)) * ((1.0 / 5.0) + Math.Sin(x[0] / 2.0) - Math.Cos(x[0] / 3.0)) * x[2]);
                        break;
                    case (4):
                        deriv = DrawCurve.RichardsonWithError(kappa4, xt, 1E-6, 10000, 1E-9);
                        u3dash = x => (deriv / ((1.0 / 5.0) + Math.Sin(x[0] / 3.0) + 2 * Math.Cos(x[0] / 2.0))) * x[3] - (((1.0 / 5.0) + Math.Sin(x[0] / 3.0) + 2 * Math.Cos(x[0] / 2.0)) * ((1.0 / 5.0) + Math.Sin(x[0] / 3.0) + 2 * Math.Cos(x[0] / 2.0)) * x[2]);
                        break;
                    case (5):
                        deriv = DrawCurve.RichardsonWithError(kappa5, xt, 1E-6, 10000, 1E-9);
                        u3dash = x => (deriv / ((1.0 / 10.0) + Math.Sin(x[0]))) * x[3] - (((1.0 / 10.0) + Math.Sin(x[0])) * ((1.0 / 10.0) + Math.Sin(x[0])) * x[2]);
                        break;
                    case (6):
                        deriv = DrawCurve.RichardsonWithError(kappa6, xt, 1E-6, 10000, 1E-9);
                        u3dash = x => (deriv / (1 + (3.0 / (5 + 4 * Math.Cos(x[0]))) * (3))) * x[3] - ((1 + (3.0 / (5 + 4 * Math.Cos(x[0]))) * (3)) * (1 + (3.0 / (5 + 4 * Math.Cos(x[0]))) * (3)) * x[2]);
                        break;
                    case (7):
                        deriv = DrawCurve.RichardsonWithError(kappa7, xt, 1E-6, 10000, 1E-9);
                        u3dash = x => (deriv / (1 + (3.0 / (5 + 4 * Math.Cos(x[0]))) * (4))) * x[3] - ((1 + (3.0 / (5 + 4 * Math.Cos(x[0]))) * (4)) * (1 + (3.0 / (5 + 4 * Math.Cos(x[0]))) * (4)) * x[2]);
                        break;
                    default:
                        deriv = DrawCurve.RichardsonWithError(kappa1, xt, 1E-6, 10000, 1E-9);
                        u3dash = x => (deriv / ((1.0 / 3.0) + Math.Sin(x[0]))) * x[3] - (((1.0 / 3.0) + Math.Sin(x[0])) * ((1.0 / 3.0) + Math.Sin(x[0])) * x[2]);
                        break;
                }
                odesol1.Add(new Vector(xt, yNew[0],0));
                for (int j = 0; j < yNew.Length; j++)
                {
                    yOld[j] = yNew[j];
                }
                yNew = RK4Step(udash, u2dash, u3dash, xt, h, yOld);
                xt = xt + h;
                i++;
            }
            return new List<Vector>[] { odesol1 };
        }



        /// <summary>
        /// A method to preform the Richardson Extrapolation algorithm on the function f.
        /// </summary>
        /// <param name="f">The function to be used</param>
        /// <param name="x">The value to approximate the derivative at</param>
        /// <param name="h">The step to take</param>
        /// <param name="iter">The iteration from RichardsonWithError to approximate the derivative at</param>
        /// <returns></returns>
        private static double Richardson(Function f, double x, double h, int iter)
        {
            //error checking
            if (h < 0)
                throw new ArgumentOutOfRangeException("ERROR Richardson:\nThe value of h cannot be negative");

            double dval1, dval2;
            if (iter == 1)
                return ((1.0 / (2.0 * h)) * (f(new double[] { x + h }) - f(new double[] { x - h })));

            //recursivly call Richardson until iter == 1
            else if (iter >= 2)
            {
                dval1 = Richardson(f, x, h / 2.0, iter - 1);
                dval2 = Richardson(f, x, h, iter - 1);
                return (dval1 + (1.0 / (Math.Pow(4, (iter - 1)) - 1)) * (dval1 - dval2));
            }
            else
            {
                throw new ArgumentException("ERROR Richardson:\nInvalid value of iter. The iteration must be positive.");
            }

        }
        /// <summary>
        /// A method to preform the Richardson Extrapolation algorithm with Error control.
        /// The method will continue until the error is within a the tolerance given.
        /// </summary>
        /// <param name="f">The function to be used</param>
        /// <param name="x">The value to approximate the derivative at</param>
        /// <param name="h">The step to take in the Richarson step.</param>
        /// <param name="maxIter">The maximum number of iterations the program should keep looking for a solution</param>
        /// <param name="tolerance">How close the convergence needs to be before the program stops</param>
        /// <returns></returns>
        public static double RichardsonWithError(Function f, double x, double h, int maxIter, double tolerance)
        {
            double deriv = 0.0, derivold = 0.0, err = 0.0, errold = double.MaxValue;
            int i = 1;

            //error checking
            if (maxIter < 1)
                throw new ArgumentOutOfRangeException("ERROR Richardson:\nmaxiter is  invalid. Needs to be 1 or greater.");
            if (tolerance < 0)
                throw new ArgumentOutOfRangeException("ERROR Richardson:\nTolerance is  invalid. Needs to be greater than zero.");


            while (i < maxIter)
            {
                deriv = Richardson(f, x, h, i);
                err = Math.Abs(deriv - derivold);
                if (err < tolerance)
                    break;

                if (err > errold)
                {
                    deriv = derivold;
                    err = errold;
                    break;
                }
                else
                {
                    derivold = deriv;
                    errold = err;
                    deriv = 0;
                    err = 0;
                }

                i++;
            }

            return deriv;
        }


        public void SolveFast(DrawCurve instance, int choice, double lower, double upper)
        {
            List<Vector>[] out1;
            List<Vector> out2 = new List<Vector>();
            solution.Clear();
            bsdata.DataSource = null;
            List<Vector>[] test = this.RK4(new double[] { 0, 1, 0 }, lower, upper, 10000, choice);
            List<Vector>[] test2 = this.RK4(new double[] { 0, 0, 0.1 }, lower, upper, 10000, choice);
            //List<Vector>[] test = this.RKF(new double[] { 0, 1, 0 }, lower, upper, 10000, choice);
            //List<Vector>[] test2 = this.RKF(new double[] { 0, 0, 0.1 }, lower, upper, 10000, choice);
            for (int i = 0; i < test[0].Count; i++)
            {
                out2.Add(new Vector(test[0][i].Y, test2[0][i].Y,0));
                solution.Add(new Vector(Math.Round(test[0][i].Y, 5), Math.Round(test2[0][i].Y, 5),0));
            }
            out1 = new List<Vector>[] { out2 };
            OutputToFile(out1, "testOut", new double[] { 0, 6 }, 10);
            bsdata.DataSource = solution;
        }
        public void SolveAcurate(MathematicaLink instance, string kappa, string range)
        {
            solution.Clear();
            bsdata.DataSource = null;
            List<Vector> curve = new List<Vector>();
            curve = instance.MathDraw(kappa, range);
            for (int i = 0; i < curve.Count; i++)
            {
                solution.Add(curve[i]);
            }
            bsdata.DataSource = solution;

        }

        public void OutputToFile(List<Vector>[] output, string Filename, double[] range, int NumSteps)
        {
            try
            {
                string directory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
                Directory.CreateDirectory(directory + "\\ODEsolOutput\\");

                StreamWriter sw = new StreamWriter(directory + "\\ODEsolOutput\\" + Filename + ".csv", false);
                if (sw == null)
                {
                    throw new DirectoryNotFoundException("ERROR OTF: Unable to find directory for QueueTime.csv");
                }
                else
                {
                    sw.WriteLine("Number Outputs ,{0},Range,{1},{2},NumSteps,{3}", output.Length, range[0], range[1], NumSteps);
                    foreach (List<Vector> Victor in output)
                    {
                        sw.WriteLine("Data Length, {0}", Victor.Count);
                        for (int i = 0; i < Victor.Count; i++)
                            sw.WriteLine("{0},{1}", Victor[i].X, Victor[i].Y);
                        Console.WriteLine("POP");
                    }
                }
                sw.Close();


            }
            catch
            {
                Console.WriteLine("Unable to write CSV file.");
            }
        }

        public double SecondDeriv(Vector B, Vector S, Vector A)
        {
            double D1,D2,deriv;


                D1 = (S.Y-B.Y)/(S.X-B.X);
                D2 = (A.Y-S.Y)/(A.X-S.X);

                deriv = (D2 - D1) / ((A.X - B.X) / 2);

            return deriv;
        }

    }

    public class MathematicaLink
    {
        private string[] mlArgs = { "-linkmode", "launch", "-linkname", 
                "C:\\Program Files\\Wolfram Research\\Mathematica\\9.0\\MathKernel.exe" };
        public List<Vector> MathDraw(string kappa, string range)
        {
            IKernelLink ml = null;
            List<Vector> outputCurve = new List<Vector>();
            try
            {
                ml = MathLinkFactory.CreateKernelLink(mlArgs);
                ml.WaitAndDiscardAnswer();
                ml.Evaluate("k[t_]=" + kappa);
                ml.WaitAndDiscardAnswer();
                ml.Evaluate("range = " + range);
                ml.WaitAndDiscardAnswer();
                ml.Evaluate("Needs[\"DrawCurve`\"]");
                ml.WaitAndDiscardAnswer();
                ml.Evaluate("DrawCurve[k,range]");
                ml.WaitForAnswer();
                double[,] CurveArray = (double[,])ml.GetArray(typeof(double), 2);
                int rows = CurveArray.GetLength(0);
                int cols = CurveArray.GetLength(1);
                for (int i = 0; i < rows; i++)
                {
                    outputCurve.Add(new Vector(CurveArray[i, 0], CurveArray[i, 1], 0));
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("Error: " + ee.Message);
            }
            finally
            {
                //tidy everything up
                ml.Close();
            }
            return outputCurve;

        }

    }
    
}
