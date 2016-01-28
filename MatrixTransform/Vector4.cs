

using System;

namespace MatrixTransform
{
    class Vector4
    {
        public double x, y, z, w;
        public Vector4() { }

        public Vector4(double x, double y, double z, double w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }

        public Vector4(Vector4 v)
        {
            this.x = v.x;
            this.y = v.y;
            this.z = v.z;
            this.w = v.w;
        }

        /// <summary>
        /// 重载减法运算符
        /// </summary>
        public static Vector4 operator -(Vector4 a, Vector4 b)
        {
            return new Vector4(a.x - b.x, a.y - b.y, a.z - b.z, a.w - b.w);
        }

        /// <summary>
        /// 重载加法运算符
        /// </summary>
        public static Vector4 operator +(Vector4 a, Vector4 b)
        {
            return new Vector4(a.x + b.x, a.y + b.y, a.z + b.z, a.w + b.w);
        }

        /// <summary>
        /// 叉乘
        /// </summary>
        public Vector4 Cross(Vector4 v)
        {
            return new Vector4(
                y * v.z - z * v.y, 
                z * v.x - x * v.z, 
                x * v.y - y * v.x,
                0);
        }

        /// <summary>
        /// 点乘
        /// </summary>
        public float Dot(Vector4 v)
        {
            return (float)(x * v.x + y * v.y + z * v.z);
        }

        /// <summary>
        /// 模长
        /// </summary>
        public double Length
        {
            get { return Math.Sqrt(x * x + y * y + z * z + w * w); }
        }

        /// <summary>
        /// 标准化
        /// </summary>
        public Vector4 Normalized
        {
            get { return new Vector4(x / Length, y / Length, z / Length, w / Length); }
        }
    }
}
