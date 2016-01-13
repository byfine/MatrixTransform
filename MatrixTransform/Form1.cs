using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MatrixTransform
{
    public partial class Form1 : Form
    {
        Triangle2D triangle2D;
        Triangle3D triangle3D;

        private Matrix4x4 mScale; // 缩放矩阵
        private Matrix4x4 mRotation;// 旋转矩阵
        
        private float camDistance = 250f; // 摄像机距离
        private Matrix4x4 mView; // 视图（摄像机）矩阵

        private Matrix4x4 mProjection; //投影矩阵

        public Form1()
        {
            InitializeComponent();

            mScale = new Matrix4x4();
            mRotation = new Matrix4x4();
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
        }


        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            // 平移坐标系
            e.Graphics.TranslateTransform(300, 300);
            // 绘制三角形
            triangle3D.Draw(e.Graphics);
        }

        private int angle;
        private void timer1_Tick(object sender, EventArgs e)
        {
            // 角度变化
            angle += 2;
            double rAngle = angle / 360f * Math.PI;

            // 更新旋转矩阵
            mRotation[1, 1] = Math.Cos(rAngle);
            mRotation[1, 3] = Math.Sin(rAngle);
            mRotation[2, 2] = 1;
            mRotation[3, 1] = -Math.Sin(rAngle);
            mRotation[3, 3] = Math.Cos(rAngle);
            mRotation[4, 4] = 1;

            // 组合模型矩阵
            Matrix4x4 m = mScale.Mul(mRotation);

            // 应用视图矩阵
            Matrix4x4 mv = m.Mul(mView);

            // 应用投影矩阵
            Matrix4x4 mvp = mv.Mul(mProjection);
            
            // 对三角形应用变换矩阵
            triangle3D.Transform(mvp);

            this.Invalidate();
        }


        /// <summary>
        /// 创建3D三角形
        /// </summary>
        private Triangle3D CreateTriangle3D()
        {
            // 在局部空间定义顶点
            Vector4 a = new Vector4(0, -0.5f, 0, 1);
            Vector4 b = new Vector4(0.5f, 0.5f, 0, 1);
            Vector4 c = new Vector4(-0.5f, 0.5f, 0, 1);

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
    }
}
