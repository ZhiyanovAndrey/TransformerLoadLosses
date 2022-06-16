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
        public int Unom;
        public int S;
        public int Pxx;
        public double R;
       
           //Параметризированный конструктор для классса Trans.
        public Trans (int Unom, int S, int Pxx, double R)
        {
            this.Unom = Unom;
            this.S = S;
            this.Pxx = Pxx;
            this.R = R;
        }
            



    }
    class LoadLosses
    {
        static void Main(string[] args)
        {
            //Присваиваем значение полям в объеках PRIME & SECOND
            Trans PRIME = new Trans(55, 16000, 14805, 0.215f);
            Trans SECOND = new Trans(55, 16000, 9750, 0.328f);

         


            double P1, P2, S1, S2, I, I2;

      //формула для пересечения графиков SAME TRANS
            S1 = PRIME.Unom * Math.Sqrt(2 * PRIME.Pxx / PRIME.R);  
            I = S1 / PRIME.Unom;

       //формула для пересечения графиков DIFFERENT TRANS, в приоритете AOMNG
            S2 = Math.Sqrt((PRIME.S* PRIME.S) * (SECOND.R/(PRIME.R+SECOND.R)) + ((PRIME.Unom * PRIME.Unom) *  SECOND.Pxx / PRIME.R));
            I2 = S2 / PRIME.Unom;

            Console.Write("Необходимо отключать параллельный трансформатор при нагрузке меньше: " + Math.Round(S2) + " кВт");
            Console.WriteLine("  и токе меньше: " + Math.Round(I2) + " А");


            Console.WriteLine("Нагрузка\t Один\t Параллель");

            for (int i = 0; i <= PRIME.S * 2; i += 800)
            {
                //формула для графика нагрузочных потерь одного трансформатора
                P1 = ((i * i) / (PRIME.Unom * PRIME.Unom)) * PRIME.R + PRIME.Pxx;

                //формула для графика нагрузочных потерь 2х трансформаторов            
                P2 = ((i * i) / (SECOND.Unom * SECOND.Unom)) * SECOND.R / 2 + 2 * SECOND.Pxx;
                Console.WriteLine("{0}\t      {1}\t     {2}\t ", i, Math.Round(P1), Math.Round(P2));

            }

            Console.ReadKey();
        }
    }
}
