using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixTransform
{
    class Triangle3D
    {
        //初始顶点
        public Vector4 A, B, C;
        //变换后的顶点
        private Vector4 a, b, c;


        public Triangle3D() { }

        public Triangle3D(Vector4 a, Vector4 b, Vector4 c)
        {
            this.A = this.a = new Vector4(a);
            this.B = this.b =  new Vector4(b);
            this.C = this.c = new Vector4(c);
        }

        /// <summary>
        /// 三角形利用矩阵的乘法进行变换
        /// </summary>
        /// <param name="m">变换矩阵的组合</param>
        public void Transform(Matrix4x4 m)
        {
            a = m.Mul(A);
            b = m.Mul(B);
            c = m.Mul(C);
        }

        /// <summary>
        /// 绘制三角形到2D
        /// </summary>
        public void Draw(Graphics g)
        {
            g.DrawLines(new Pen(Color.Red, 2), Get2DPointFArr());
        }


        private PointF[] Get2DPointFArr()
        {
            PointF[] arr = new PointF[4];
            arr[0] = Get2DPointF(this.a);
            arr[1] = Get2DPointF(this.b);
            arr[2] = Get2DPointF(this.c);
            arr[3] = arr[0];

            return arr;
        }

        /// <summary>
        /// 利用透视除法返回二维点
        /// </summary>
        private PointF Get2DPointF(Vector4 v)
        {
            PointF p = new PointF();
            p.X = (float) (v.x / v.w);
            p.Y = (float) (v.y / v.w);

            return p;
        }

    }
}
