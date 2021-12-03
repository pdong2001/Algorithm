using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhuongPhapTinh
{
    public class Matrix
    {
        protected double[,] matrix;
        protected int row;
        protected int col;
        public Matrix(double[,] data)
        {
            this.matrix = new double[data.GetLength(0), data.GetLength(1)];
            for (int i = 0; i < data.GetLength(0); i++)
            {
                for (int j = 0; j < data.GetLength(1); j++)
                {
                    matrix[i, j] = data[i, j];
                }
            }
            this.Col = data.GetLength(1);
            this.Row = data.GetLength(0);
        }
        public Matrix(Matrix data)
        {
            this.matrix = new double[data.Row, data.Col];
            for (int i = 0; i < data.Row; i++)
            {
                for (int j = 0; j < data.Col; j++)
                {
                    matrix[i, j] = data[i, j];
                }
            }
            this.Col = data.Col;
            this.Row = data.Row;
        }
        public Matrix()
        {
            row = 0;
            col = 0;
        }
        public Matrix(int Row, int Col)
        {
            matrix = new double[Row, Col];
            this.col = Col;
            this.row = Row;
        }

        public void RandomData(int Min = 0, int Max = 20)
        {
            Random rd = new Random();
            for (int i = 0; i < col; i++)
            {
                for (int j = 0; j < row; j++)
                {
                    this[i, j] = rd.Next(Min, Max);
                }
            }
        }
        public double this[int rowIndex, int colIndex]
        {
            get => matrix[rowIndex, colIndex];
            set => matrix[rowIndex, colIndex] = Math.Round(value, 5);
        }

        public int Row { get => row; set => row = value; }
        public int Col { get => col; set => col = value; }

        public void Input()
        {
            while(!int.TryParse(Input("Nhập số hàng:"), out row));
            while (!int.TryParse(Input("Nhập số cột:"), out col));
            matrix = new double[row, col];
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    matrix[i, j] = double.Parse(Input($"Nhập [{i + 1},{j + 1}]:"));
                }
            }
        }

        public static Matrix operator + (Matrix A, Matrix B)
        {
            if (A.Row != B.Row || A.Col != B.Col)
            {
                throw new Exception("Không thể cộng 2 ma trận khác kích thước");
            }
            else
            {
                Matrix rs = new Matrix(A.Row, A.Col);
                for (int i = 0; i < rs.Row; i++)
                {
                    for (int j = 0; j < rs.Col; j++)
                    {
                        rs[i, j] = A[i, j] + B[i, j];
                    }
                }
                return rs;
            }
        }

        public static Matrix operator *(Matrix A, Matrix B)
        {
            if (A.Col != B.Row)
            {
                throw new Exception("Khong the nhan hai ma tran tren !!!\nSo cot cua ma tran thu nhat phai bang so hang cua ma tran thu hai.");
            }
            else
            {
                Matrix rs = new Matrix(A.Row, B.Col);
                double sum;
                for (int i = 0; i < A.Row; i++)
                    for (int j = 0; j < B.Col; j++)
                        rs[i, j] = 0;
                for (int i = 0; i < A.Row; i++)    //hang cua ma tran thu nhat 
                {
                    for (int j = 0; j < B.Col; j++)    //cot cua ma tran thu hai 
                    {
                        sum = 0;
                        for (int k = 0; k < A.Col; k++)
                            sum = sum + A[i, k] * B[k, j];
                        rs[i, j] = Math.Round(sum, 5);
                    }
                }
                return rs;
            }
        }

        private string Input(object Text)
        {
            Console.Write(Text);
            return Console.ReadLine();
        }
    }
}
