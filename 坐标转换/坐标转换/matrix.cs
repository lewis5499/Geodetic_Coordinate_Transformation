﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elevation_adjust
{
    class matrix
    {
        //矩阵的显示
        public static string matToStr(double[,] iMatrix)
        {
            int row = iMatrix.GetLength(0);
            int column = iMatrix.GetLength(1);
            string str1 = "";
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    str1 += iMatrix[i, j].ToString();
                    str1 += ' ';
                }
                str1.TrimEnd();
                str1 += "\r\n";
            }
            return str1;
        }

        //矩阵的转置 
        public static double[,] matTran(double[,] iMatrix)
        {
            int row = iMatrix.GetLength(0);
            int column = iMatrix.GetLength(1);
            //double[,] iMatrix = new double[column, row];
            double[,] TempMatrix = new double[row, column];
            double[,] iMatrixT = new double[column, row];
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    TempMatrix[i, j] = iMatrix[i, j];
                }
            }
            for (int i = 0; i < column; i++)
            {
                for (int j = 0; j < row; j++)
                {
                    iMatrixT[i, j] = TempMatrix[j, i];
                }
            }
            return iMatrixT;
        }

        //矩阵的逆矩阵
        public static double[,] matInv(double[,] iMatrix)
        {
            int i = 0;
            int row = iMatrix.GetLength(0);
            double[,] MatrixZwei = new double[row, row * 2];
            double[,] iMatrixInv = new double[row, row];
            for (i = 0; i < row; i++)
            {
                for (int j = 0; j < row; j++)
                {
                    MatrixZwei[i, j] = iMatrix[i, j];
                }
            }
            for (i = 0; i < row; i++)
            {
                for (int j = row; j < row * 2; j++)
                {
                    MatrixZwei[i, j] = 0;
                    if (i + row == j)
                        MatrixZwei[i, j] = 1;
                }
            }
            for (i = 0; i < row; i++)
            {
                if (MatrixZwei[i, i] != 0)
                {
                    double intTemp = MatrixZwei[i, i];
                    for (int j = 0; j < row * 2; j++)
                    {
                        MatrixZwei[i, j] = MatrixZwei[i, j] / intTemp;
                    }
                }
                for (int j = 0; j < row; j++)
                {
                    if (j == i)
                        continue;
                    double intTemp = MatrixZwei[j, i];
                    for (int k = 0; k < row * 2; k++)
                    {
                        MatrixZwei[j, k] = MatrixZwei[j, k] - MatrixZwei[i, k] * intTemp;
                    }
                }
            }
            for (i = 0; i < row; i++)
            {
                for (int j = 0; j < row; j++)
                {
                    iMatrixInv[i, j] = MatrixZwei[i, j + row];
                }
            }
            return iMatrixInv;
        }

        //矩阵加法
        public static double[,] matAdd(double[,] MatrixEin, double[,] MatrixZwei)
        {
            double[,] MatrixResult = new double[MatrixEin.GetLength(0), MatrixZwei.GetLength(1)];
            for (int i = 0; i < MatrixEin.GetLength(0); i++)
                for (int j = 0; j < MatrixZwei.GetLength(1); j++)
                    MatrixResult[i, j] = MatrixEin[i, j] + MatrixZwei[i, j];
            return MatrixResult;
        }

        //矩阵减法
        public static double[,] matSub(double[,] MatrixEin, double[,] MatrixZwei)
        {
            double[,] MatrixResult = new double[MatrixEin.GetLength(0), MatrixZwei.GetLength(1)];
            for (int i = 0; i < MatrixEin.GetLength(0); i++)
                for (int j = 0; j < MatrixZwei.GetLength(1); j++)
                    MatrixResult[i, j] = MatrixEin[i, j] - MatrixZwei[i, j];
            return MatrixResult;
        }

        //矩阵乘法
        public static double[,] matMul(double[,] MatrixEin, double[,] MatrixZwei)
        {
            double[,] MatrixResult = new double[MatrixEin.GetLength(0), MatrixZwei.GetLength(1)];
            for (int i = 0; i < MatrixEin.GetLength(0); i++)
            {
                for (int j = 0; j < MatrixZwei.GetLength(1); j++)
                {
                    for (int k = 0; k < MatrixEin.GetLength(1); k++)
                    {
                        MatrixResult[i, j] += MatrixEin[i, k] * MatrixZwei[k, j];
                    }
                }
            }
            return MatrixResult;
        }

        //矩阵求行列式
        public static double mat_nn(double[,] MatrixEin)
        {
            return MatrixEin[0, 0] * MatrixEin[1, 1] * MatrixEin[2, 2] + MatrixEin[0, 1] * MatrixEin[1, 2] * MatrixEin[2, 0] + MatrixEin[0, 2] * MatrixEin[1, 0] * MatrixEin[2, 1]
            - MatrixEin[0, 2] * MatrixEin[1, 1] * MatrixEin[2, 0] - MatrixEin[0, 1] * MatrixEin[1, 0] * MatrixEin[2, 2] - MatrixEin[0, 0] * MatrixEin[1, 2] * MatrixEin[2, 1];
        }
    }
}