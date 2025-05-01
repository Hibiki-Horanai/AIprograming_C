using System;
using System.Drawing;
using System.Windows.Forms;

namespace CurveApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Width = Height = 600;
        }

        //描画処理
        private void Form1_Paint(object sender,PaintEventArgs e)
        {
            var c = new Curve();
            c.Move(0, 300);
            c.Draw(600, 0);
        }
    }

    //曲線描画の基礎クラス
    public class Curve
    {
        public double lastX = 0;
        public double lastY = 0;
        Pen pen = new Pen(Color.FromArgb(255, 0, 0, 0));

        public void Move(double x , double y)
        {
            lastX = x;
            lastY = y;
        }

        //長さと角度で現在位置から線を描画
        public void Forward(double len , double angle)
        {
            var x = lastX + len * Math.Cos(angle);
            var y = lastY + len * Math.Sin(angle);
            DrawLine(lastX, lastY, x, y);
            Move(x, y);
        }

        public void Draw(int len , double angle)
        {
            Forward(len, angle);
        }

        public void DrawLine(double x1, double y1,double x2, double y2)
        {
            var g = Form.ActiveForm.CreateGraphics();
            g.DrawLine(pen, (float)x1, (float)y1, (float)x2, (float)y2);
            g.Dispose();
        }
    }
}
