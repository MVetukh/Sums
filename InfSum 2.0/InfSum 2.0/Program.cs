using System;
using System.Text;//пространство имен для стринг билдера
using System.Diagnostics;//пространство имен, в котором использутеся стопвоч
using System.IO;//для текстврайтера


namespace InfSum_2
{
    internal class Program
    {
        public static int problem, m;
        public static double a, k;
        const int limittime = 10;
        static void Main(string[] args)
        {
            StringBuilder report = new StringBuilder();
            string text;//вспомогательная строка; с помощью нового класса  в эту строку добавляется новое значение
            do
            {
                Console.Write(text = "Введите номер задачи:");
                problem = int.Parse(Console.ReadLine());
                report.AppendLine(text + problem);
                double error;
                Console.Write(text = "Введите погрешность от 0 до 0.1:");
                while (!double.TryParse(Console.ReadLine(), out error) || error < 0 || error > 0.1)
                {
                    Console.Write("Некорректно введена погрешность.");
                }
                report.AppendLine(text + error);//append оставляет введеные значение в одной строке, appendline - в следующей
                double sum = problem < 5 ? 1.0 : 0;
                double curcterm = 1;//начальный множитель
                if (problem == 20)
                {
                    Console.Write(text = "Введите натуральный параметр m:");
                    m = int.Parse(Console.ReadLine());
                    report.AppendLine(text + m);
                }
                if (problem == 21)
                {
                    Console.Write(text = "Введите положительный параметр а, не превыщающий 1:");
                    while (!double.TryParse(Console.ReadLine(), out a) || a > 1 || a < 0)
                    {
                        Console.WriteLine("некорректное значение параметра а, введите заново:");
                    }
                    report.AppendLine(text + a);
                }

                Stopwatch timer = new Stopwatch();// ввод нового класса
                bool machineT(double k)//метод машинной точности, используем буль для проверки правильности значения
                {
                    curcterm = problem < 7 ? curcterm * Factory(k) : CurTerm(k);
                    bool time = timer.Elapsed.TotalSeconds < limittime;// пока время не достигнет лимита, цикл будет работать
                    return error < 1e-16 ? sum + curcterm != sum : Math.Abs(curcterm / sum) > error&&time;//если погрешность меньше 10^-16, то
                    //вычисления проводятся с машинной точностью(сумма не меняется)

                }
               // double k;
                timer.Start();
                for (k = problem == 21 ? 0 : 1; machineT(k); k++)
                {
                    sum += curcterm;
                }
                timer.Stop();

                double err = Math.Abs(sum - ControlValue());

                Console.WriteLine($"Время выполнения = {timer.Elapsed.Seconds} c");
                Console.WriteLine(text = $"Сумма равна {sum:g7}; Контрольное значение = {ControlValue()}");
                report.AppendLine(text);
                Console.WriteLine(text = $"Текущее значение k={k}");
                report.AppendLine(text);
                Console.WriteLine(text = $"Разница между суммой и контрольным значением в итоге составляет {err:g9}");
                report.AppendLine(text);
                Console.WriteLine("press escape to continue");



                //эта штука спрашивает номер задачи: если 21, то k=0
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
            using (TextWriter wr = File.CreateText("InfSum.txt"))
                wr.Write(report);//с помощью класса TwxtWriter создаем новый текстовый файл, где выводятся все накопленные значения
        }
        public static double Factory(double k)
        {
            switch (problem)
            {
                case 1:
                    return 1.0 / k;
                case 2:
                    return -1.0 / k;
                case 3:
                    return 1.0 / (2 * k * (2 * k - 1));
                case 4:
                    return -1.0 / (2 * k * (2 * k - 1));
                case 5:
                    return 1.0 / (2 * k - 1) / k;
                case 6:
                    return Math.Pow(-1, k - 1) / (2 * k - 1) / k;

                default: return Double.NaN;
            }
        }
        public static double CurTerm(double k)
        {
            switch (problem)
            {
                case 7:
                    return 1.0 / k / k;
                case 8:
                    return 1.0 / (2 * k - 1) / (2 * k - 1);
                case 9:
                    return Math.Pow(-1, k + 1) / (k * k);
                case 10:
                    return 1 / Math.Pow(k, 4);
                case 11:
                    return 1 / Math.Pow(k, 6);
                case 12:
                    return 1 / Math.Pow(k, 8);
                case 13:
                    return Math.Pow(-1, k - 1) / k;
                case 14:
                    return Math.Pow(-1, k - 1) / (2 * k - 1);
                case 15:
                    return Math.Pow(-1, k - 1) / Math.Pow(2 * k - 1, 3);
                case 16:
                    return 1.0 / k / (k + 1);
                case 17:
                    return 1.0 / (2 * k - 1) / (2 * k + 1);
                case 18:
                    return 1.0 / (k - 1) / (k + 1);
                case 19:
                    return 1.0 / k / (k + 1) / (k + 2);
                case 20:
                    // Здесь я хочу ввести локальные множители
                    double m = 1;
                    int FactM;
                    for (FactM = 1; FactM <= m; FactM++)
                    {
                        m *= (k + FactM);
                    }
                    return 1 / m;
                case 21:
                    return Math.Pow(a, k);

                default: return double.NaN;
            }
        }
        public static double ControlValue()
        {
            switch (problem)
            {
                case 1:
                    return Math.E;
                case 2:
                    return 1 / Math.E;
                case 3:
                    return Math.Cosh(1);
                case 4:
                    return Math.Cos(1);
                case 5:
                    return Math.Sinh(1);
                case 6:
                    return Math.Sin(1);
                case 7:
                    return Math.Pow(Math.PI, 2) / 6;
                case 8:
                    return Math.Pow(Math.PI, 2) / 8;
                case 9:
                    return Math.Pow(Math.PI, 2) / 12;
                case 10:
                    return Math.Pow(Math.PI, 4) / 90;
                case 11:
                    return Math.Pow(Math.PI, 6) / 945;
                case 12:
                    return Math.Pow(Math.PI, 8) / 9450;
                case 13:
                    return Math.Log(2);
                case 14:
                    return Math.PI / 4;
                case 15:
                    return Math.Pow(Math.PI, 3) / 32;
                case 16:
                    return 1;
                case 17:
                    return 1 / 2.0;
                case 18:
                    return 3 / 4.0;
                case 19:
                    return 1 / 4.0;
                case 20:
                    double Factm = 1;
                    double n;
                    for (n = 1; n <= Factm; n++)
                    {
                        Factm *= n;
                    }
                    return 1.0 / (m * Factm);
                case 21:
                    return 1 / (1 - a);
                default:
                    return double.NaN;
            }
        }
    }
}
