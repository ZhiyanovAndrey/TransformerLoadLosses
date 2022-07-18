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

            //Параметры для ВЛ-110 Сергач
            OverHeadPowerLine line1 = new OverHeadPowerLine(0.249, 0.427, 4.3);

            TransformatorSplitWinding t1 = new TransformatorSplitWinding(115, 25000, 9.81, 135000, 26000);
            Transformator t2 = new Transformator(55, 16000, 2.012, 18175, 14805);

            List<ElectricalObjects> electricalObjects = new List<ElectricalObjects>();
            electricalObjects.Add(t1);
            electricalObjects.Add(t2);
            electricalObjects.Add(line1);

            foreach (var item in electricalObjects)
            {
                if (item is OverHeadPowerLine)
                {
                    Console.WriteLine($"Сопротивления ВЛ {nameof(item)} = ");
                }

                if (item is Transformator)
                {
                    Console.WriteLine($"Сопротивления трансформатора {item} = ");
                }
                Console.WriteLine($"Активное = {item.Resistance()}");
                Console.WriteLine($"Реактивное = {item.Reactance()}");
                Console.WriteLine($"Полное = {item.Impedance()}");

            }



            //Console.WriteLine($"Resistance {overHeadPowerLine.Resistance()}");
            //Console.WriteLine($"Reactance {overHeadPowerLine.Reactance()}");
            //Console.WriteLine($"Impedance {overHeadPowerLine.Impedance()}");




            Console.ReadKey();
        }
    }
}
