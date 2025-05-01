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

namespace KochApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Width = Height = 600;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            var c = new Koch();
            c.Move(50, 300);
            c.Draw(10, 500, 0);
        }
    }

    //コッホ曲線クラス
    class Koch : Curve
    {
        public void Draw(int n,double len,double angle)
        {
            if(n == 1)
            {
                Forward(len, angle);
            }
            else
            {
                var l = len /(2 / Math.Sqrt(2) + 2);
                var a = Math.PI * 0.25;
                Draw(n - 1, l, angle);
                Draw(n - 1, l, angle - a);
                Draw(n - 1, l, angle + a);
                Draw(n - 1, l, angle);

            }
        }    
    }
}
