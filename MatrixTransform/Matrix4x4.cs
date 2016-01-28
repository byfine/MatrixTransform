
namespace MatrixTransform
{
    class Matrix4x4
    {
        private double[,] pts;

        public Matrix4x4()
        {
            pts = new double[4,4];
        }

        /// <summary>
        /// 索引器
        /// </summary>
        public double this[int i, int j]
        {
            get { return pts[i - 1, j - 1]; }
            set { pts[i - 1, j - 1] = value; }
        }

        /// <summary>
        /// 矩阵乘法
        /// </summary>
        public Matrix4x4 Mul(Matrix4x4 m)
        {
            Matrix4x4 newM = new Matrix4x4();
            for (int w = 1; w <= 4; w++){
                for (int h = 1; h <= 4; h++){
                    for (int n = 1; n <= 4; n++){
                        newM[w, h] += this[w, n] * m[n, h];
                    }
                }
            }
            return newM;
        }

        /// <summary>
        /// 矩阵乘法
        /// </summary>
        public Vector4 Mul(Vector4 v)
        {
            Vector4 newV = new Vector4();
            newV.x = v.x * this[1, 1] + v.y * this[2, 1] + v.z * this[3, 1] + v.w * this[4, 1];
            newV.y = v.x * this[1, 2] + v.y * this[2, 2] + v.z * this[3, 2] + v.w * this[4, 2];
            newV.z = v.x * this[1, 3] + v.y * this[2, 3] + v.z * this[3, 3] + v.w * this[4, 3];
            newV.w = v.x * this[1, 4] + v.y * this[2, 4] + v.z * this[3, 4] + v.w * this[4, 4];

            return newV;
        }

        /// <summary>
        /// 求转置矩阵
        /// </summary>
        public Matrix4x4 Transpose()
        {
            Matrix4x4 t =new Matrix4x4();
            for (int i = 1; i <= 4; i++){
                for (int j = 1; j <= 4; j++){
                    t[i, j] = this[j, i];
                }
            }
            return t;
        }
    }
}
