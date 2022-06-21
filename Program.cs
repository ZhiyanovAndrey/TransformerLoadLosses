using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransformerLoadLosses
{
    //Check of condition for the parallel operation of the power transformer
    class Trans
    {
        //Присваиваем значение полям в члену классса Trans
        public double Unom;
        public double Snom;
        public double Pxx;
        public double Pкз;


        //Параметризированный конструктор для классса Trans.
        public Trans(int U, int S, int Pxx, int Pкз)
        {
            Unom = U;
            Snom = S;
            this.Pxx = Pxx;
            this.Pкз = Pкз;

        }

        //Метод для определения нагрузки при которой следует подключать параллельный трансформатор


        //Метод для построения графиков нагрузки с двумя одинаковыми трансформаторами при которой следует подключать параллельный трансформатор




    }
    class Program
    {
        static void Main(string[] args)
        {
            int step = 800;
            //Присваиваем значение полям в объеках PRIME & SECOND
            Trans PRIME = new Trans(55, 16000, 14805, 18175);
            Trans SECOND = new Trans(55, 16000, 14805, 18175);






            //формула для пересечения графиков SAME TRANS
            double S1 = PRIME.Snom * Math.Sqrt(2 * PRIME.Pxx / PRIME.Pкз);
            double I1 = S1 / PRIME.Unom;

            ////метод для пересечения графиков DIFFERENT TRANS, в приоритете PRIME
            //     S2 = Math.Sqrt((PRIME.S* PRIME.S) * (SECOND.R/(PRIME.R+SECOND.R)) + ((PRIME.Unom * PRIME.Unom) *  SECOND.Pxx / PRIME.R));
            //     I2 = S2 / PRIME.Unom;

            Console.Write("Необходимо отключать параллельный трансформатор при нагрузке меньше: " + Math.Round(S1) + " кВт");
            Console.WriteLine("  и токе меньше: " + Math.Round(I1) + " А");


            Console.WriteLine("Нагрузка\t Один\t Параллель");

            for (int i = 0; i <= PRIME.Snom * 2; i += step)
            {
                //формула для графика нагрузочных потерь одного трансформатора
                double P1 = Math.Pow((i / PRIME.Snom), 2) * PRIME.Pкз + PRIME.Pxx;

                //формула для графика нагрузочных потерь 2х трансформаторов            
                double R1 = PRIME.Pкз * Math.Pow(PRIME.Unom / PRIME.Snom, 2);
                double R2 = SECOND.Pкз * Math.Pow(SECOND.Unom / SECOND.Snom, 2);

                double P2 = Math.Pow((i / PRIME.Snom), 2) * (PRIME.Pкз * SECOND.Pкз / (PRIME.Pкз + SECOND.Pкз)) + (PRIME.Pxx + SECOND.Pxx);
                Console.WriteLine("{0}\t      {1}\t     {2}\t ", i, Math.Round(P1), Math.Round(P2));

            }

            Console.ReadKey();
        }
    }
}
