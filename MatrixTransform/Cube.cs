
using System.Drawing;

namespace MatrixTransform
{
    class Cube
    {

        Vector4 a = new Vector4(-0.5, 0.5, 0.5, 1);
        Vector4 b = new Vector4(0.5, 0.5, 0.5, 1);
        Vector4 c = new Vector4(0.5, 0.5, -0.5, 1);
        Vector4 d = new Vector4(-0.5, 0.5, -0.5, 1);

        Vector4 e = new Vector4(-0.5, -0.5, 0.5, 1);
        Vector4 f = new Vector4(0.5, -0.5, 0.5, 1);
        Vector4 g = new Vector4(0.5, -0.5, -0.5, 1);
        Vector4 h = new Vector4(-0.5, -0.5, -0.5, 1);

        // 6个矩形面，共12个三角面
        private Triangle3D[] triangles = new Triangle3D[12];

        public Cube()
        {
            // up
            triangles[0] = new Triangle3D(a, b, c);
            triangles[1] = new Triangle3D(a, c, d);

            // bottom
            triangles[2] = new Triangle3D(e, h, f);
            triangles[3] = new Triangle3D(f, h, g);

            // front
            triangles[4] = new Triangle3D(d, c, g);
            triangles[5] = new Triangle3D(d, g, h);

            // back
            triangles[6] = new Triangle3D(a, e, b);
            triangles[7] = new Triangle3D(b, e, f);

            // right
            triangles[8] = new Triangle3D(b, f, c);
            triangles[9] = new Triangle3D(c, f, g);

            // left
            triangles[10] = new Triangle3D(a, d, h);
            triangles[11] = new Triangle3D(a, h, e);
        }

        /// <summary>
        /// 矩阵变换
        /// </summary>
        public void Transform(Matrix4x4 m)
        {
            foreach (Triangle3D t in triangles){
                t.Transform(m);
            }
        }


        /// <summary>
        /// 计算光照
        /// </summary>
        /// <param name="obj2World">模型矩阵</param>
        /// <param name="light">光方向</param>
        public void CalculateLighting(Matrix4x4 obj2World, Vector4 light)
        {
            foreach (Triangle3D t in triangles)
            {
                t.CalculateLighting(obj2World, light);
            }
        }

        /// <summary>
        /// 绘制矩形
        /// </summary>
        public void Draw(Graphics g, bool isLines)
        {
            foreach (Triangle3D t in triangles)
            {
                t.Draw(g, isLines);
            }
        }
    }
}
