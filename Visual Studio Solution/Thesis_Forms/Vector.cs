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
    public class Vector
    {
        private double x;

        public double X
        {
            get { return x; }
        }
        private double y;

        public double Y
        {
            get { return y; }
        }

        private double z;

        public double Z
        {
            get { return z; }
        }


        public Vector() { }
        public Vector(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public static Vector Cross(Vector v1, Vector v2)
        {
            Vector result = new Vector();
            result.x = v1.y * v2.z - v1.z * v2.y;
            result.y = v1.z * v2.x - v1.x * v2.z;
            result.z = v1.x * v2.y - v1.y * v2.x;

            return result;
        }
    }
}
