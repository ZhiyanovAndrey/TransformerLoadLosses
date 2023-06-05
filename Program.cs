using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryElectricalObjects;

namespace TransformerLoadLosses
{
    //программа вычисляет сопротивления электрических объектов, преобразуя электрическую схему в схему замещения
    class Program
    {
        static void Main(string[] args)
        {


            List<ElectricalObjects> electricalObjects = new List<ElectricalObjects>();
            electricalObjects.Add(new OverHeadPowerLine(0.249, 0.427, 4.3));//  ВЛ-110 АС120\19
            electricalObjects.Add(new TransformatorSplitWinding(115, 25000, 9.81, 135000, 26000)); // ОРДТНЖ-25000\110
            electricalObjects.Add(new Transformator(27.5, 400, 6.5, 5500, 950)); // ТМЖ-400\27.5
            electricalObjects.Add(new OverHeadPowerLine(0.258, 0.6, 0.04)); // КЛ-0.4 ААГ3х120+1х50

            foreach (var item in electricalObjects)
            {
                if (item is OverHeadPowerLine)
                {
                    Console.WriteLine($"Сопротивления ВЛ  = ");
                }

                if (item is TransformatorSplitWinding)
                {
                    Console.WriteLine($"Сопротивления трансформатора с расщепленной обмоткой  = ");
                }

                if (item is Transformator)
                {
                    Console.WriteLine($"Сопротивления трансформатора  = ");
                }

                Console.WriteLine($"Активное = {item.Resistance()}");
                Console.WriteLine($"Реактивное = {item.Reactance()}");
                Console.WriteLine($"Полное = {item.Impedance()}");
                Console.WriteLine();

            }

         var obj = new Transformator(27.5, 400, 6.5, 5500, 950);
            string x = "Сопротивления трансформатора";

            Console.WriteLine($"{obj.GetType().Name} {x.GetHashCode()} = {obj.Reactance()}");
            Console.WriteLine(obj.GetType().Name);
            Console.WriteLine(typeof(Transformator).Name);
            

            //Console.WriteLine($"Resistance {new Transformator(27.5, 400, 6.5, 5500, 950)}");
            //Console.WriteLine($"Reactance {overHeadPowerLine.Reactance()}");
            //Console.WriteLine($"Impedance {overHeadPowerLine.Impedance()}");




            Console.ReadKey();
        }
    }
}
