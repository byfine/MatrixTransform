using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace MatrixTransform
{
    class Triangle3D
    {
        //初始顶点
        public Vector4 A, B, C;
        //变换后的顶点
        private Vector4 a, b, c;

        //法向量
        private Vector4 normal;
        //用于计算光照
        private float dot;
        //是否背面剔除
        private bool cullBack;

        public Triangle3D() { }

        public Triangle3D(Vector4 a, Vector4 b, Vector4 c)
        {
            this.A = this.a = new Vector4(a);
            this.B = this.b =  new Vector4(b);
            this.C = this.c = new Vector4(c);
        }

        /// <summary>
        /// 计算光照
        /// </summary>
        /// <param name="obj2World">模型矩阵</param>
        /// <param name="light">光方向</param>
        public void CalculateLighting(Matrix4x4 obj2World, Vector4 light)
        {
            // 应用模型矩阵，转换到世界坐标
            Transform(obj2World);

            //求两个边
            Vector4 u = b - a;
            Vector4 v = c - a;

            //叉乘得法向量
            normal = u.Cross(v);

            //标准化法向量和灯光向量
            Vector4 normalNor = normal.Normalized;
            Vector4 lightNor = light.Normalized;

            //计算灯光和法向量的点积
            dot = normalNor.Dot(lightNor);
            //限制在0-1范围
            dot = Math.Max(0, dot);

            //视线向量，z的反方向
            Vector4 sight = new Vector4(0, 0, -1, 0);
            //计算是否背面剔除
            cullBack = normalNor.Dot(sight) < 0;
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
        public void Draw(Graphics g, bool isLines)
        {

            PointF[] points = Get2DPointFArr();
            if (isLines){
                //绘制边
                g.DrawLines(new Pen(Color.Black, 2), points);
            }
            else if (!cullBack)
            {
                //应用光照计算后的颜色
                int c = (int)(200 * dot) + 55;
                Color color = Color.FromArgb(c, c, c);
                Brush brush = new SolidBrush(color);

                //填充颜色
                GraphicsPath path = new GraphicsPath();
                path.AddLines(points);
                g.FillPath(brush, path);
            }
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
            p.Y = -(float) (v.y / v.w);

            return p;
        }

    }
}
