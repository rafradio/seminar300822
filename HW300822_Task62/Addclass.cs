using System;

namespace MakeSpiralArray
{
    class InitialSettings : Program62
    {
        public int[,] array2Dimen;
        public int arrayMaxNumber;
        public int arrayStartNumber;
        public int arrayRow1;
        public int arrayColumn1;
        public int startArrayRow;
        public int startArrayColumn;
        public string directionFill;
        public InitialSettings()
        {
            
            this.Initsets(0);

            this.array2Dimen = new int[this.arrayRow, this.arrayColumn];
            this.arrayStartNumber = 1;
            this.arrayMaxNumber = this.arrayRow * this.arrayColumn;
            this.arrayRow1 = this.arrayRow;
            this.arrayColumn1 = this.arrayColumn;
            
            this.directionFill = "left";
            this.startArrayRow = 0;
            this.startArrayColumn = 0;
            this.FillArray(0, 0);
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
        public void PrintExec() 
        {
            string s;
            Console.WriteLine("\nВаш массив: ");
            for (int i = 0; i < this.arrayRow1; i++)
            {
                s = "";
                for (int j = 0; j < this.arrayColumn1; j++)
                {
                    s += String.Format("{0,-7}", this.array2Dimen[i, j]);
                }
                Console.Write($"\n{s}");
            }
            
        }
        public void FillArray(int row, int column)
        {
            void FindDirection()
            {
                void OptionDirect()
                {
                    if (column == (this.arrayColumn -1) && (row < (this.arrayRow - 1))) this.directionFill = "down";
                    if (row == (this.arrayRow -1) && (column > this.startArrayColumn)) this.directionFill = "right";
                    if (column == (this.startArrayColumn) && (row > this.startArrayRow)) this.directionFill = "up";
                    if (row == this.startArrayRow && (column < (this.arrayColumn -1))) this.directionFill = "left";
                }
                OptionDirect();
                Console.WriteLine(this.directionFill);
                if (this.directionFill == "left") column += 1;

                if (this.directionFill == "down") row += 1;

                if (this.directionFill == "right") column -= 1;

                if (this.directionFill == "up") row -= 1;

                return;

            }


            if (this.array2Dimen[row, column] == 0)
            {
                this.array2Dimen[row, column] = this.arrayStartNumber;
                this.arrayStartNumber += 1;
            }
            else
            {
                row += 1;
                column += 1;
                this.arrayColumn -= 1;
                this.arrayRow -= 1;
                this.startArrayRow += 1;
                this.startArrayColumn += 1;
                this.array2Dimen[row, column] = this.arrayStartNumber;
                this.arrayStartNumber += 1;

            }

            if (this.arrayStartNumber <= this.arrayMaxNumber)
            {
                FindDirection();
                Console.WriteLine($"\nНовые значения {row}  {column}  {this.arrayRow}  {this.arrayColumn}  {this.startArrayRow}  {this.startArrayColumn}");
                this.FillArray(row, column);
            }

            return;


        }
    }
}