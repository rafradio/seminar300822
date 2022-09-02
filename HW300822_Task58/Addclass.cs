using System;

namespace MatrixMultiply
{
    class InitialSettings : Program58
    {
        public int[,] array2Dimen;
        public int[,] matrix2Dimen;
        public int[,] result2Dimen;
        public InitialSettings()
        {
            this.Initsets(0);

            this.array2Dimen = new int[this.arrayRow1, this.arrayColumn1];
            this.matrix2Dimen = new int[this.arrayRow2, this.arrayColumn2];
            this.result2Dimen = new int[this.arrayRow1, this.arrayColumn2];

            this.array2Dimen = this.InitArray(this.arrayRow1, this.arrayColumn1);
            this.matrix2Dimen = this.InitArray(this.arrayRow2, this.arrayColumn2);

            this.PrintExec(this.array2Dimen, this.arrayRow1, this.arrayColumn1, "Ваш первый массив");
            this.PrintExec(this.matrix2Dimen, this.arrayRow2, this.arrayColumn2, "Ваш второй массив");

            this.MultiplyMatrix(this.arrayRow1, this.arrayColumn2);

            this.PrintExec(this.result2Dimen, this.arrayRow1, this.arrayColumn2, "Ваш результат");
        }
        public void Initsets(int iType)
        {
            if (iType < 3)
            {
                string[] dataType = {"строки 1ой матрицы", "столбца 1ой и строки 2ой матриц", "столбца 2ой матрицы"};
                Console.Write($"Введите пожалуйста целое число для {dataType[iType]}: ");
                string enterUser = Console.ReadLine();
                if (int.TryParse(enterUser, out int number))
                {
                    switch (iType)
                    {
                        case 0:
                            this.arrayRow1 = number;
                            break;
                        case 1:
                            this.arrayColumn1 = number;
                            this.arrayRow2 = number;
                            break;
                        case 2:
                            this.arrayColumn2 = number;
                            break;
                    }
                    iType += 1;
                }
                else
                {
                    Console.WriteLine("Вы ввели не число. Повторите!");
                }
                this.Initsets(iType);
            }
            return;
        }
        public int[,] InitArray(int row, int column)
        {
            int[,] matrix = new int[row, column];
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    matrix[i, j] = new Random().Next(this.arrayFirstNum, this.arrayUpperNum);
                }
            }
            return matrix;
        }
        public void PrintExec(int[,] matrix, int row, int column, string comment) 
        {
            string s;
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"\n\n{comment}:");
            Console.BackgroundColor = ConsoleColor.Black;
            for (int i = 0; i < row; i++)
            {
                s = "";
                for (int j = 0; j < column; j++)
                {
                    s += String.Format("{0,-7}", matrix[i, j]);
                }
                Console.Write($"\n{s}");
            }
        }
        public void MultiplyMatrix(int row, int column)
        {
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    int sum = 0;
                    for (int jj = 0; jj < this.arrayColumn1; jj++)
                    {
                        sum += this.array2Dimen[i, jj] * this.matrix2Dimen[jj, j];
                    }
                    this.result2Dimen[i, j] = sum;
                }
            }

        }
    }
}