using System;

namespace Print3DArrow
{
    class InitialSettings : Program60
    {
        public int[,,] array3Dimen;

        public InitialSettings()
        {
            this.Initsets(0);
            this.array3Dimen = new int[this.arrayRow, this.arrayColumn, this.arrayZ];
            this.InitArray();
            this.PrintExec();

        }
        public void Initsets(int iType)
        {
            if (iType < 3)
            {
                string[] dataType = {"строки", "столбца", "3-его измерения"};
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
                        case 2:
                            this.arrayZ = number;
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
                    for (int z = 0; z < this.arrayZ; z++)
                    {
                        this.array3Dimen[i, j, z] = this.CheckContain();
                    }
                }
            }
        }
        public int CheckContain()
        {
            bool isItContain = false;
            int inter = new Random().Next(this.arrayFirstNum, this.arrayUpperNum);
            for (int i = 0; i < this.arrayRow; i++)
            {
                for (int j = 0; j < this.arrayColumn; j++)
                {
                    for (int z = 0; z < this.arrayZ; z++)
                    {
                        if (inter == this.array3Dimen[i, j, z]) isItContain = true;
                    }
                }
            }
            if (isItContain) 
            {
                inter = this.CheckContain();
            }
            return inter;
        }
        public void PrintExec()
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nВаш 3D массив:");
            Console.BackgroundColor = ConsoleColor.Black;
            for (int i = 0; i < this.arrayRow; i++)
            {
                for (int j = 0; j < this.arrayColumn; j++)
                {
                    for (int z = 0; z < this.arrayZ; z++)
                    {
                        Console.Write($"{this.array3Dimen[i, j, z]}({i}, {j}, {z}) ");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}