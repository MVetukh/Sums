using System;



namespace ExSum

{

    public class FinitSumClass
    {
        public const int problemAmount = 51; 
        private static int problem;
        public static void Main()
        {
            do
            {
                Console.WriteLine("Ведите номер задачи");
                //problem = int.Parse(Console.ReadLine());
                while(!int.TryParse(Console.ReadLine(),out problem)||problem<0|| problem>problemAmount)
                {
                    Console.WriteLine("Неверный номер задачи");
                }
                Console.WriteLine("Введите количество суммируемых членов суммы");
                int k = int.Parse(Console.ReadLine());
                double controlValue = ControlValue(k);
                double sum = 0;
                int blProblem = (problem) / 11;
                int step = 1 + (blProblem & 1);
                int p = 1;
                int mult = 1 - (blProblem / 2) * 2;//problem <= 21 ? 1 : -1;  

                for (int n = (problem >= 44) & (problem <= 47) ? 0 : 1; n <= step * k; n += step)
                {
                    sum += problem >= 44 ? CurTerm(n) : CurTerm(n) * p;
                    p *= mult;
                }
                Console.WriteLine("sum = {0:n0}; control value = {1:n0}", sum, controlValue);
                Console.WriteLine("Нажмите ESC для завершение прогаммы");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
        private static double CurTerm(int n)
        {
            if (problem < 44)
            {
                int temp1 = (problem % 11);
                return Math.Pow(n, temp1);
            }
            else
            {
                switch (problem)

                {
                    case 44:
                        return (1 + 2 * n);
                    case 45:
                        return (1 + 3 * n + 3 * n * n);
                    case 46:
                        return (1 + 4 * n + 6 * n * n + 4 * n * n * n);
                    case 47:
                        return (1 + 5 * n + 10 * n * n + 10 * n * n * n + 5 * n * n * n * n);
                    case 48:
                        return (2 * n - 1);
                    case 49:
                        return (3 * n * 3 - 3 * n + 1);
                    case 50:
                        return (4 * n * n * n - 6 * n * n + 4 * n - 1);
                    case 51:
                        return (5 * n * n * n * n - 10 * n * n * n + 10 * n * n - 5 * n + 1);
                    default: return Double.NaN;
                }
            }
        }
        private static double ControlValue(int k)
        {
            int mult1 = (k & 1) * 2 - 1;
            int mult2 = (k & 1);
            switch (problem)
            {
                // первый блок суммы вида n^p 
                case 0:
                    return
                        k;
                case 1:
                    return
                        Math.Pow(k, 2) / 2 + k / 2.0;
                case 2:
                    return
                        Math.Pow(k, 3) / 3 + Math.Pow(k, 2) / 2 + k / 6.0;
                case 3:
                    return
                        Math.Pow(k, 4) / 4 + Math.Pow(k, 3) / 2 + Math.Pow(k, 2) / 4;
                case 4:
                    return
                        Math.Pow(k, 5) / 5 + Math.Pow(k, 4) / 2 + Math.Pow(k, 3) / 3 - k / 42.0;
                case 5:
                    return
                        Math.Pow(k, 6) / 6 + Math.Pow(k, 5) / 2 + Math.Pow(k, 4) / 12 - Math.Pow(k, 2) / 12;
                case 6:
                    return
                        Math.Pow(k, 7) / 7 + Math.Pow(k, 6) / 2 + Math.Pow(k, 5) / 2 - Math.Pow(k, 3) / 6 + k / 42.0;
                case 7:
                    return
                        Math.Pow(k, 8) / 8 + Math.Pow(k, 7) / 2 + 7 * Math.Pow(k, 6) / 12 - 7 * Math.Pow(k, 4) / 24 + Math.Pow(k, 2) / 12;



                case 8:



                    return



                        Math.Pow(k, 9) / 9 + Math.Pow(k, 8) / 2 + 2 * Math.Pow(k, 7) / 3 - 7 * Math.Pow(k, 5) / 15 + 2 * Math.Pow(k, 3) / 9 - k / 30.0;



                case 9:



                    return



                        Math.Pow(k, 10) / 10 + Math.Pow(k, 9) / 2 + 3 * Math.Pow(k, 8) / 4 - 7 * Math.Pow(k, 6) / 10 + Math.Pow(k, 4) / 2 - 3 * k * k / 20.0;



                case 10:



                    return



                        Math.Pow(k, 11) / 11 + Math.Pow(k, 10) / 2 + 5 * Math.Pow(k, 9) / 6 - Math.Pow(k, 7) + Math.Pow(k, 5) - Math.Pow(k, 3) / 2 + 5 * k / 66.0;



                //второй блок суммы ввида (2n-1)^p, есть ошибка  



                case 11:



                    return



                        k;



                case 12:



                    return



                        2 * Math.Pow(k, 2) / 2;



                case 13:



                    return



                        Math.Pow(2, 2) * Math.Pow(k, 3) / 3 - k / 3.0;



                case 14:



                    return



                        Math.Pow(2, 3) * Math.Pow(k, 4) / 4 - k * k;



                case 15:



                    return



                        Math.Pow(2, 4) * Math.Pow(k, 5) / 5 - 8 * Math.Pow(k, 3) / 3 + 7 * k / 15.0;



                case 16:



                    return



                        Math.Pow(2, 5) * Math.Pow(k, 6) / 6 - 20 * Math.Pow(k, 4) / 3 + 7 * k * k / 3.0;



                case 17:



                    return



                        Math.Pow(2, 6) * Math.Pow(k, 7) / 7 - 16 * Math.Pow(k, 5) + 28 * k * k * k / 3 - 31 * k / 21.0;



                case 18:



                    return



                        Math.Pow(2, 7) * Math.Pow(k, 8) / 8 - 112 * Math.Pow(k, 6) / 3 + 98 * Math.Pow(k, 4) / 3 - 31 * Math.Pow(k, 2) / 3;



                case 19:



                    return



                        Math.Pow(2, 8) * Math.Pow(k, 9) / 9 - 256 * Math.Pow(k, 7) / 3 + 1568 * Math.Pow(k, 5) / 15 - 496 * k * k * k / 9.0 + 127 * k / 15;



                case 20:



                    return



                        Math.Pow(2, 9) * Math.Pow(k, 10) / 10 - 192 * Math.Pow(k, 8) + 1568 * Math.Pow(k, 6) / 5 - 248 * Math.Pow(k, 4) + 381 * k * k / 5.0;



                case 21:



                    return



                        Math.Pow(2, 10) * Math.Pow(k, 11) / 11 - 1280 * Math.Pow(k, 9) / 3 + 896 * Math.Pow(k, 7) - 992 * Math.Pow(k, 5) + 508 * Math.Pow(k, 3) - 2555 * k / 33.0;



                //третий блок суммы ввида (-1)^n-1*n^p   



                case 22:



                    return



                         mult1 * Math.Pow(k, 0) * mult2;



                case 23:



                    return



                         mult1 * k / 2.0 + mult2 * 1 / 2.0;



                case 24:



                    return



                         mult1 * (k * k / 2.0 + k / 2.0);



                case 25:



                    return



                        mult1 * (k * k * k / 2.0 + 3 * k * k / 4.0) - mult2 * 1 / 4.0;



                case 26:



                    return



                        mult1 * (Math.Pow(k, 4) / 2 + k * k * k - k / 2.0);



                case 27:

                    return

                        mult1 * (Math.Pow(k, 5) / 2 + 5 * Math.Pow(k, 4) / 4 - 5 * k * k / 4.0) + mult2 * 1 / 2.0;

                case 28:

                    return

                        mult1 * (Math.Pow(k, 6) / 2 + 3 * Math.Pow(k, 5) / 2 - 5 * Math.Pow(k, 3) / 2 + 3 * k / 2.0);

                case 29:

                    return

                        mult1 * (Math.Pow(k, 7) / 2 + 7 * Math.Pow(k, 6) / 4 - 35 * Math.Pow(k, 4) / 8 + 21 * k * k / 4.0) - mult2 * 17 / 8.0;

                case 30:

                    return

                        mult1 * (Math.Pow(k, 8) / 2 + 2 * Math.Pow(k, 7) - 7 * Math.Pow(k, 5) + 14 * k * k * k) - mult2 * 17 / 2.0;

                case 31:

                    return

                        mult1 * (Math.Pow(k, 9) / 2 + 9 * Math.Pow(k, 8) / 4 - 21 * Math.Pow(k, 6) / 2 + 63 * Math.Pow(k, 4) / 2 - 153 * k * k / 4.0) + mult2 * 34 / 2 / 0;

                case 32:

                    return

                        mult1 * (Math.Pow(k, 10) / 2 + 5 * Math.Pow(k, 9) / 2 - 15 * Math.Pow(k, 7) + 63 * Math.Pow(k, 5) - 255 * k * k * k / 2.0 + 155 * k / 2);

                // 4 блок суммы вида (-1)^(n-1)*(2n-1)^p  

                case 33:

                    return

                        mult1 * 1;

                case 34:

                    return

                        mult1 * k;

                case 35:

                    return

                        mult1 * 2 * k * k - mult2 * 1;

                case 36:

                    return

                        mult1 * (2 * 2 * k * k * k - 3 * k);

                case 37:

                    return

                        mult1 * (2 * 2 * 2 * Math.Pow(k, 4) - 12 * k * k) + mult2 * 5;

                case 38:

                    return

                        mult1 * (Math.Pow(2, 4) * Math.Pow(k, 5) - 40 * k * k * k + 25 * k);

                case 39:

                    return
                        mult1 * (Math.Pow(2, 5) * Math.Pow(k, 6) - 120 * Math.Pow(k, 4) + 150 * k * k) - mult2 * 61;
                case 40:
                    return
                        mult1 * (Math.Pow(2, 6) * Math.Pow(k, 7) - 336 * Math.Pow(k, 5) + 700 * k * k * k - 427 * k);
                case 41:
                    return
                        mult1 * (Math.Pow(2, 7) * Math.Pow(k, 8) - 896 * Math.Pow(k, 6) + 2800 * Math.Pow(k, 4) - 3416 * k * k) + mult2 * 1385;
                case 42:
                    return
                        mult1 * (Math.Pow(2, 8) * Math.Pow(k, 9) - 2304 * Math.Pow(k, 7) + 10080 * Math.Pow(k, 5) - 20496 * k * k * k + 12465 * k);
                case 43:
                    return
                        mult1 * (Math.Pow(2, 9) * Math.Pow(k, 10) - 5760 * Math.Pow(k, 8) + 33600 * Math.Pow(k, 6) - 102480 * Math.Pow(k, 4) + 124650 * k * k) - mult2 * 50521;
                case 44:
                    return k * k;
                case 45:
                    return k * k * k;
                case 46:
                    return k * k * k * k;
                case 47:
                    return k * k * k * k * k;
                case 48:
                    return k * k;
                case 49:
                    return k * k * k;
                case 50:
                    return k * k * k * k;
                case 51:
                    return k * k * k * k * k;
                default: return double.NaN;
            }
        }
    }
}