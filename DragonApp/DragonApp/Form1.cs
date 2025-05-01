using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CurveApp;


namespace DragonApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Width = Height = 600;
        }

        private void Form1_Paint(object sender , PaintEventArgs eventArgs)
        {
            var c = new Dragon();
            c.Move(150, 300);
            c.Draw(15, 300, 0, 1);
        }
    }

    class Dragon : Curve
    {
        public void Draw(int n,double len,double angle,int sw)
        {
            if (n == 1)
            {
                Forward(len, angle);
            }
            else
            {
                var l = len / (2 / Math.Sqrt(2));
                var a = Math.PI * 0.25 * sw;
                Draw(n - 1, l, angle - a, 1);
                Draw(n - 1, l, angle + a, -1);
            }
        }
    }
}
