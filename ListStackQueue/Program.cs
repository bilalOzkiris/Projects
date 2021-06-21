using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Black;

            // 1.Soru b bölümü.
            string[] provinceNames = { "Edirne", "İstanbul", "Kırklareli", "Kocaeli", "Denizli", "İzmir", "Manisa", "Muğla", "Adana", "Antalya", "Mersin", "Ankara", "Bolu", "Trabzon", "Erzurum" };
            int[] airTemperatures = { 21, 22, 21, 25, 24, 21, 22, 18, 27, 23, 26, 18, 17, 20, 8 };
            ArrayList aList = new ArrayList();
            List<Province> gList;
            Province province;
            int counter1 = 0;
            int counter2 = 1;
            while (counter1 < provinceNames.Length)
            {
                gList = new List<Province>();
                int gListLength = 2 * counter2 - 1;
                for (int i = 0; i < gListLength; i++)
                {
                    province = new Province(provinceNames[counter1], airTemperatures[counter1]);
                    gList.Add(province);
                    counter1++;
                    if (counter1 == provinceNames.Length)
                    {
                        break;
                    }
                }
                aList.Add(gList);
                counter2++;
            }
            foreach (List<Province> provinces in aList)
            {
                foreach (Province province1 in provinces)
                {
                    Console.WriteLine("{0}, {1}", province1.getProvinceName(), province1.getAirTemperature());
                }
                Console.WriteLine();
            }

            // 2.Soru a bölümü.
            StackX theStack = new StackX(airTemperatures.Length);
            for (int i = 0; i < airTemperatures.Length; i++)
            {
                theStack.push(airTemperatures[i]);
            }
            while (!theStack.isEmpty())
            {
                int value = theStack.pop();
                Console.Write(value + "  ");
            }
            Console.WriteLine();
            Console.WriteLine();

            // 2.Soru b bölümü.
            QueueX theQueue = new QueueX(airTemperatures.Length);
            for (int i = 0; i < airTemperatures.Length; i++)
            {
                theQueue.insert(airTemperatures[i]);
            }
            while (!theQueue.isEmpty())
            {
                int value = theQueue.remove();
                Console.Write(value + "  ");
            }
            Console.WriteLine();
            Console.WriteLine();


            // 3.Soru
            PQueProvince thePQProvince = new PQueProvince(provinceNames.Length);
            Province province2;
            for (int i = 0; i < provinceNames.Length; i++)
            {
                province2 = new Province(provinceNames[i], airTemperatures[i]);
                thePQProvince.insert(province2);
            }
            while (!thePQProvince.isEmpty())
            {
                Province value = thePQProvince.remove();
                Console.WriteLine("{0}, {1}", value.getProvinceName(), value.getAirTemperature());
            }
            Console.WriteLine();

            // 4.Soru b bölümü.
            Random random = new Random();
            double[] processingTimes = new double[25];
            for (int i = 0; i < processingTimes.Length; i++)
            {
                double time = random.Next(15, 125);
                processingTimes[i] = time;

            }
            QueueXDouble queueXDouble = new QueueXDouble(25);
            PQueDouble pQueDouble = new PQueDouble(25);
            for (int j = 0; j < processingTimes.Length; j++)
            {
                queueXDouble.insert(processingTimes[j]);
                pQueDouble.insert(processingTimes[j]);
            }
            Console.WriteLine("KUYRUK");
            int customerNum = 1;
            double total = 0;
            while (!queueXDouble.isEmpty())
            {
                double temp = queueXDouble.remove();
                total += temp;
                Console.WriteLine(customerNum + ". müşterinin işlem süresi: " + total);
                customerNum++;
            }
            double mean1 = total / 25;
            Console.WriteLine("Ortalama işlem süresi: " + mean1);
            Console.WriteLine();
            Console.WriteLine("ÖNCELİKLİ KUYRUK");
            customerNum = 1;
            total = 0;
            while (!pQueDouble.isEmpty())
            {
                double temp = pQueDouble.remove();
                total += temp;
                Console.WriteLine(customerNum + ". müşterinin işlem süresi: " + total);
                customerNum++;
            }
            double mean2 = total / 25;
            Console.WriteLine("Ortalama işlem süresi: " + mean2);


            Console.ReadKey();
        }
    }
}
