using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixTransform
{
    /// <summary>
    /// 2D三角形类
    /// </summary>
    class Triangle2D
    {
        private PointF A, B, C;

        public Triangle2D(PointF A, PointF B, PointF C)
        {
            this.A = A;
            this.B = B;
            this.C = C;
        }

        public void Draw(Graphics g)
        {
            Pen pen = new Pen(Color.Red, 2);
            g.DrawLine(pen, A, B);
            g.DrawLine(pen, B, C);
            g.DrawLine(pen, C, A);
        }


        public void Rotate(int degree)
        {
            float angle = (float)(degree / 360f * Math.PI);

            ApplyRotateMatrix(ref A, angle);
            ApplyRotateMatrix(ref B, angle);
            ApplyRotateMatrix(ref C, angle);
        }

        /// <summary>
        /// 应用2d旋转矩阵
        /// </summary>
        /// <param name="p">顶点</param>
        /// <param name="angle">角度</param>
        void ApplyRotateMatrix(ref PointF p, float angle)
        {
            float newX = (float)(p.X * Math.Cos(angle) - p.Y * Math.Sin(angle));
            float newY = (float)(p.X * Math.Sin(angle) + p.Y * Math.Cos(angle));
            p.X = newX;
            p.Y = newY;
        }
    }
}
