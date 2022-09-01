using System;

namespace SortRowArray
{
    class InitialSettings : Program54
    {
        public int[,] array2Dimen;
        public InitialSettings()
        {
            this.Initsets(0);
            this.array2Dimen = new int[this.arrayRow, this.arrayColumn];
            this.InitArray();
            this.PrintExec();
            this.SortArrayRow();
            this.PrintExec();
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
        public void SortArrayRow()
        {
            for (int i = 0; i < this.arrayRow; i++)
            {
                bool doesItNotChanged = true;
                for (int j = 0; j < this.arrayColumn; j++)
                {
                    for (int jj = 0; jj < this.arrayColumn - j - 1; jj++)
                    {
                        int inter = this.array2Dimen[i, jj];
                        if (this.array2Dimen[i, jj] < this.array2Dimen[i, jj + 1])
                        {
                            this.array2Dimen[i, jj] = this.array2Dimen[i, jj + 1];
                            this.array2Dimen[i, jj + 1] = inter;
                            doesItNotChanged = false;
                        }
                    }
                    if (doesItNotChanged) break;

                }

            }

        }
    }
}