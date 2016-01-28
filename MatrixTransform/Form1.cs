using System;
using System.Drawing;
using System.Windows.Forms;

namespace MatrixTransform
{
    public partial class Form1 : Form
    {

        private bool drawCube = true;

        private Triangle3D triangle3D;
        private Cube cube;

        private Matrix4x4 mScale; // 缩放矩阵

        private Matrix4x4 mRotationX;// X旋转矩阵
        private Matrix4x4 mRotationY;// Y旋转矩阵
        private Matrix4x4 mRotationZ;// Z旋转矩阵
        
        private float camDistance = 250f; // 摄像机距离
        private Matrix4x4 mView; // 视图（摄像机）矩阵

        private Matrix4x4 mProjection; //投影矩阵

        public Form1()
        {
            InitializeComponent();

            mScale = new Matrix4x4();
            mRotationX = new Matrix4x4();
            mRotationY = new Matrix4x4();
            mRotationZ = new Matrix4x4();
            mView = new Matrix4x4();
            mProjection = new Matrix4x4();

            //初始化缩放矩阵
            mScale[1, 1] = 250;
            mScale[2, 2] = 250;
            mScale[3, 3] = 250;
            mScale[4, 4] = 1;

            //初始化视图矩阵
            mView[1, 1] = 1;
            mView[2, 2] = 1;
            mView[3, 3] = 1;
            mView[4, 3] = camDistance; //相机距离
            mView[4, 4] = 1;

            //初始化投影矩阵
            mProjection[1, 1] = 1;
            mProjection[2, 2] = 1;
            mProjection[3, 3] = 1;
            mProjection[3, 4] = 1f / camDistance;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            triangle3D = CreateTriangle3D();
            cube = new Cube();
        }


        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            // 平移坐标系
            e.Graphics.TranslateTransform(300, 300);

            if (drawCube){
                // 绘制矩形
                cube.Draw(e.Graphics, checkBox_isLine.Checked);
            }
            else{
                // 绘制三角形
                triangle3D.Draw(e.Graphics, checkBox_isLine.Checked);
            }
        }

        private int angle;
        private void timer1_Tick(object sender, EventArgs e)
        {
            // 角度变化
            angle += 3;
            double rAngle = angle / 360f * Math.PI;

            // 更新绕x旋转矩阵
            mRotationX[1, 1] = 1;
            mRotationX[2, 2] = Math.Cos(rAngle);
            mRotationX[2, 3] = Math.Sin(rAngle);
            mRotationX[3, 2] = -Math.Sin(rAngle);
            mRotationX[3, 3] = Math.Cos(rAngle);
            mRotationX[4, 4] = 1;

            // 更新绕y旋转矩阵
            mRotationY[1, 1] = Math.Cos(rAngle);
            mRotationY[1, 3] = Math.Sin(rAngle);
            mRotationY[2, 2] = 1;
            mRotationY[3, 1] = -Math.Sin(rAngle);
            mRotationY[3, 3] = Math.Cos(rAngle);
            mRotationY[4, 4] = 1;

            //// 更新绕z旋转矩阵
            mRotationZ[1, 1] = Math.Cos(rAngle);
            mRotationZ[1, 2] = Math.Sin(rAngle);
            mRotationZ[2, 1] = -Math.Sin(rAngle);
            mRotationZ[2, 2] = Math.Cos(rAngle);
            mRotationZ[3, 3] = 1;
            mRotationZ[4, 4] = 1;



            //撤销X轴旋转效果
            if (checkBox_x.Checked)
            {
                //乘以转置矩阵等效于乘以逆矩阵
                Matrix4x4 tx = mRotationX.Transpose();
                mRotationX = mRotationX.Mul(tx);
            }
            //撤销Y轴旋转效果
            if (checkBox_y.Checked)
            {
                //乘以转置矩阵等效于乘以逆矩阵
                Matrix4x4 ty = mRotationY.Transpose();
                mRotationY = mRotationY.Mul(ty);
            }
            //撤销Z轴旋转效果
            if (checkBox_z.Checked)
            {
                //乘以转置矩阵等效于乘以逆矩阵
                Matrix4x4 tz = mRotationZ.Transpose();
                mRotationZ = mRotationZ.Mul(tz);
            }
            Matrix4x4 mall = mRotationX.Mul(mRotationY.Mul(mRotationZ));

            // 组合模型矩阵
            Matrix4x4 m = mScale.Mul(mall);


            if (drawCube){
                cube.CalculateLighting(m, new Vector4(-1, 1, -1, 0));
            }
            else{
                triangle3D.CalculateLighting(m, new Vector4(-1, 1, -1, 0));
            }
            

            // 应用视图矩阵
            Matrix4x4 mv = m.Mul(mView);

            // 应用投影矩阵
            Matrix4x4 mvp = mv.Mul(mProjection);

            // 应用变换矩阵
            if (drawCube){
                cube.Transform(mvp);
            }
            else{
                triangle3D.Transform(mvp);
            }

            this.Invalidate();
        }


        /// <summary>
        /// 创建3D三角形
        /// </summary>
        private Triangle3D CreateTriangle3D()
        {
            // 在局部空间定义顶点
            Vector4 a = new Vector4(0, 0.5f, 0, 1);
            Vector4 b = new Vector4(0.5f, -0.5f, 0, 1);
            Vector4 c = new Vector4(-0.5f, -0.5f, 0, 1);

            return new Triangle3D(a, b, c);
        }

        /// <summary>
        /// 创建2D三角形
        /// </summary>
        private Triangle2D CreateTriangle2D()
        {
            PointF A = new PointF(0, -200);
            PointF B = new PointF(200, 200);
            PointF C = new PointF(-200, 200);
            return new Triangle2D(A, B, C);
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            camDistance = (sender as ScrollBar).Value;
            mView[4, 3] = camDistance;
        }

        private void checkBox_drawCube_CheckedChanged(object sender, EventArgs e)
        {
            drawCube = checkBox_drawCube.Checked;
        }
    }
}
