using System;

namespace FindMinRowArray
{
    class InitialSettings : Program56
    {
        public int[,] array2Dimen;
        public InitialSettings()
        {
            this.Initsets(0);
            this.array2Dimen = new int[this.arrayRow, this.arrayColumn];
            this.InitArray();
            this.PrintExec();
            this.FindMinimum();

        }
        public void Initsets(int iType)
        {
            if (iType < 2)
            {
                string[] dataType = {"строки", "столбца"};
                Console.Write($"Введите пожалуйста целое число для {dataType[iType]}: ");
                string enterUser = Console.ReadLine();
                if (int.TryParse(enterUser, out int number))
                {
                    switch (iType)
                    {
                        case 0:
                            this.arrayRow = number;
                            break;
                        case 1:
                            this.arrayColumn = number;
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
        public void InitArray()
        {
            for (int i = 0; i < this.arrayRow; i++)
            {
                for (int j = 0; j < this.arrayColumn; j++)
                {
                    this.array2Dimen[i, j] = new Random().Next(this.arrayFirstNum, this.arrayUpperNum);
                }
            }
        }
        public void PrintExec() 
        {
            string s;
            Console.WriteLine("\nВаш массив:");
            for (int i = 0; i < this.arrayRow; i++)
            {
                s = "";
                for (int j = 0; j < this.arrayColumn; j++)
                {
                    s += String.Format("{0,-7}", this.array2Dimen[i, j]);
                }
                Console.Write($"\n{s}");
            }
        }
        public void FindMinimum()
        {
            int[] sum = new int[this.arrayRow];
            for (int i = 0; i < this.arrayRow; i++)
            {
                sum[i] = 0;
                for (int j = 0; j < this.arrayColumn; j++)
                {
                    sum[i] += this.array2Dimen[i, j];
                }


            }

            int min = sum[0];
            int minRow = 0;
            for (int i = 1; i < this.arrayRow; i++) 
            {
                if (sum[i] < min)
                {
                    min = sum[i];
                    minRow = i;
                }

            }
            Console.WriteLine($"\n\nМинимальная сумма элементов в строке {minRow + 1} и равна {min}"); 
        }
    } 
}