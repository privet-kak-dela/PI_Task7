using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Great_Post
{
    class Program
    {
        static void Main(string[] args)
        {
            hello nikolay
            Console.WriteLine("Введите количество переменных");
            int m = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите eval");
            string s = Console.ReadLine();
            Debug.Assert(m <= 10 && m > 0,"Количество переменных меньше 10 и больше 0 должно быть");
            Debug.Assert(Math.Pow(2, m) == s.Length,"Давайте по новой");
            foreach (var e in s)
                Debug.Assert(e == '0' || e == '1',"ЭЭ..в строке должны быть только нолики и единички");

           
            Great_Post(s);

            
        }
        /// <summary>
        /// Функция, которая проверяет: является ли число степенью двойки
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        static bool sqrtTwo(int n)
        {
            for (int i = 0; i <= 1024; i++)
            {
                if (n == Math.Pow(2, i))
                    return true;

            }
            return false;
        }
       /// <summary>
       /// Функция, которая переводит число из десятичной в двоичную систему счисления
       /// </summary>
       /// <param name="n"></param>
       /// <returns></returns>
        static string Bin(int n)
        {
            var res = "";
            while (n > 0)
            {
                res += Convert.ToString(n % 2);
                n /= 2;
            }
            string ans = "";
            for (int i = res.Length-1; i >= 0; i--)
            {
                ans+= res[i];
            }
            return ans;
        }
        
        /// <summary>
        /// Функция, возвращающая true,если функция сохраняет ноль, и false в противном случае
        /// </summary>
        /// <param name="eval"></param>
        /// <returns></returns>
        static bool Is_P0(string eval) => eval[0] == '0';
        /// <summary>
        /// Функция, возвращающая true,если функция сохраняет единицу, и false в противном случае
        /// </summary>
        /// <param name="eval"></param>
        /// <returns></returns>
        static bool Is_P1(string eval) => eval[eval.Length - 1] == '1';
        /// <summary>
        /// Функция, возвращающая true,если функция самодвойственная, и false в противном случае
        /// </summary>
        /// <param name="eval"></param>
        /// <returns></returns>
        static bool Is_SelfDual(string eval)
        {
            string eval_selfdual = "";
            for (int i = eval.Length - 1; i >= 0; i--)
            {
                if (eval[i] == '0')
                    eval_selfdual += "1";
                else
                    eval_selfdual += "0";
            }
            return eval == eval_selfdual;
        }
        /// <summary>
        /// Функция, возвращающая true,если функция линейная, и false в противном случае
        /// </summary>
        /// <param name="eval"></param>
        /// <returns></returns>
        static bool Is_Linear(string s)
        {
            string cofficents = "" + s[0];

            for (int i = s.Length - 1; i >= 1; i--)
            {
                if (sqrtTwo(i))
                {
                    int v1 = s[0] == '0' ? 0 : 1;
                    int v2 = s[i] == '0' ? 0 : 1;
                    cofficents += v1 ^ v2;
                } 
            }
            string ev = "";
            for (int i = 0; i < s.Length; i++)
            {
                int new_eval = s[0] == '0' ? 0 : 1;
                var ti = "" + Bin(i);

                while (ti.Length != Convert.ToInt32(Math.Log(s.Length,2)))
                    ti = "0" + ti;

                for (int j = 0; j < ti.Length; j++)
                {
                    if (ti[j] == cofficents[j + 1] && ti[j] == '0')
                        new_eval ^= 0;
                    if (ti[j] == cofficents[j + 1] && ti[j] == '1')
                        new_eval ^= 1;
                    if (ti[j] != cofficents[j + 1])
                        new_eval ^= 0;
                }
                ev += new_eval;

            }
            return ev == s;
        }
        /// <summary>
        /// Функция,  возвращающая true,если функция монотонная, и false в противном случае
        /// </summary>
        /// <param name="eval"></param>
        static bool Is_Mono(string s)
        {
            string[] Truth_Table = new string[s.Length];
            for (int i = 0; i < s.Length; i++)
            {
                var ti = "" + Bin(i);

                while (ti.Length != Convert.ToInt32(Math.Log(s.Length, 2)))
                    ti = "0" + ti;
                Truth_Table[i] = ti;
            }
            for (int i = 0; i < s.Length; i++)
            {
                for (int j = i + 1; j < s.Length; j++)
                {
                    for (int k = 0; k < Truth_Table[i].Length; k++)
                    {
                        if (Truth_Table[i][k] == Truth_Table[j][k] || (Truth_Table[i][k] == '0' && Truth_Table[j][k] == '1'))
                            if (s[i] == '1' && s[j] == '0')
                                return false;
                    }
                }
            }
            return true;

        }
        static void Great_Post(string eval)
        {
            if (Is_P0(eval))
                Console.WriteLine("Функция сохраняет ноль");
            else
                Console.WriteLine("Функция не сохраняет ноль");
            if (Is_P1(eval))
                Console.WriteLine("Функция сохраняет единицу");
            else
                Console.WriteLine("Функция не сохраняет единицу");
            if (Is_SelfDual(eval))
                Console.WriteLine("Функция является самодвойственной");
            else
                Console.WriteLine("Функция не является самодвойственной");
            if (Is_Linear(eval))
                Console.WriteLine("Функция является линейной");
            else
                Console.WriteLine("Функция не является линейной");
            if (Is_Mono(eval))
                Console.WriteLine("Функция является монотонной");
            else
                Console.WriteLine("Функция не является монотонной");


        }
       
    }
}
