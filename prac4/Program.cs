using System.ComponentModel.DataAnnotations;
using System.Data;
using System.IO.IsolatedStorage;
using System.Linq.Expressions;
using System.Net.Sockets;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;

namespace prac4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Z4m3tk1 zametka1 = new Z4m3tk1();
            zametka1.name = "  blazer)";
            zametka1.data = new DateTime(2007, 11, 21);
            zametka1.description = "  pit' blazer posle 4 yroka";
            Z4m3tk1 zametka2 = new Z4m3tk1();
            zametka2.name = "  стать эмо)";
            zametka2.data = new DateTime(2007, 7, 20);
            zametka2.description = "  послушать токиохотель и резать вены";
            Z4m3tk1 zametka3 = new Z4m3tk1();
            zametka3.name = "  поехать на казантип";
            zametka3.data = new DateTime(2007, 7, 25);
            zametka3.description = "  словить трип в рейве";
            Z4m3tk1 zametka4 = new Z4m3tk1();
            zametka4.name = "  школа...";
            zametka4.data = new DateTime(2007, 7, 23);
            zametka4.description = "  сходи на уроки и выучить уроки";
            Z4m3tk1 zametka5 = new Z4m3tk1();
            zametka5.name = "  получить по башке от скинов";
            zametka5.data = new DateTime(2007, 7, 23);
            zametka5.description = "  получить по башке а потом в травмпункт и к маме домой зато в школу не иду)))))";
            List<Z4m3tk1> zametki = new List<Z4m3tk1> { zametka1, zametka2, zametka3, zametka4, zametka5 };
            int pos = 1;
            DateTime date = new DateTime(2007, 7, 23);
            ConsoleKeyInfo key = new ConsoleKeyInfo((char)ConsoleKey.A, ConsoleKey.A, false, false, false);
            while (key.Key != ConsoleKey.O)
            {
                List<Z4m3tk1> sortedZam = zametki.Where(x => x.data.Date == date.Date).ToList();
                int sortedZam_count = sortedZam.Count();
                sortedZam_count = sortedZam_count + 1;
                if (key.Key == ConsoleKey.UpArrow && sortedZam_count != 0)
                {
                    pos--;
                    if (pos == 0)
                        pos = sortedZam.Count;
                }
                if (key.Key == ConsoleKey.DownArrow && sortedZam_count != 0)
                {
                    pos++;
                    if (pos == sortedZam_count + 1)
                        pos = 1;
                }
                Console.Clear();
                Console.WriteLine(date.Date.ToString("dd.MM.yyyy"));
                int op_pos = pos - 1;
                foreach (var item in sortedZam)
                {
                    Console.WriteLine(item.name);
                    for (int i = 0; i <= op_pos; i++)
                        if (key.Key == ConsoleKey.Enter)
                        {
                            Console.Clear();
                            open(sortedZam[i]);
                            break;
                        }
                }
                Console.WriteLine("  Чтобы добавить заметку, нажмите 'Tab'");
                Console.SetCursorPosition(0, pos);
                if ((key.Key != ConsoleKey.Enter) && (sortedZam_count != 0))
                    Console.WriteLine("->");
                if (pos == sortedZam_count && key.Key == ConsoleKey.Tab)
                    zametki.Add(add());
                key = Console.ReadKey();
                if (key.Key == ConsoleKey.LeftArrow)
                {
                    pos = 1;
                    date = date.AddDays(-1);
                }
                if (key.Key == ConsoleKey.RightArrow)
                {
                    pos = 1;
                    date = date.AddDays(1);
                }
            }
        }
        static void open(Z4m3tk1 a)
        {
            Console.WriteLine(a.name);
            Console.WriteLine("________________________________________________________________");
            Console.WriteLine("На " + a.data.ToString("dd.MM.yyyy") + " у вас назначена задача:");
            Console.WriteLine(a.description);
        }
        static Z4m3tk1 add()
        {
            Console.Clear();
            Z4m3tk1 new_zametki = new Z4m3tk1();
            Console.WriteLine("Введите название заметки: ");
            new_zametki.name = Console.ReadLine();
            new_zametki.name = new_zametki.name + "  ";
            Console.WriteLine("Введите дату, на которую будет назначена заметка (вводите дату в формате 'гггг.мм.дд', например 01.01.0001: ");
            string data = Console.ReadLine();
            string[] num_split = data.Split(".");
            for (int i = 0; i < num_split.Length; i++)
                Console.WriteLine(num_split[i]);
            if (data.Length != 10)
            {
                Console.WriteLine("Вы ввели дату в неверном формате");
                return null;
            }
            if (num_split[0].Length != 2)
            {
                Console.WriteLine("Вы ввели дату в неверном формате");
                return null;
            }
            if (num_split[1].Length != 2)
            {
                Console.WriteLine("Вы ввели дату в неверном формате");
                return null;
            }
            if (num_split[2].Length != 4)
            {
                Console.WriteLine("Вы ввели дату в неверном формате");
                return null;
            }
            new_zametki.data = new DateTime(Convert.ToInt32(num_split[2]), Convert.ToInt32(num_split[1]), Convert.ToInt32(num_split[0]));
            Console.WriteLine("Введите описание заметки: ");
            new_zametki.description = Console.ReadLine();
            new_zametki.description = new_zametki.description + "  ";
            return new_zametki;
            Console.WriteLine("Вы добавили заметку. Чтобы вернуться в меню заметок, нажмите стрелку влево или вправо");

        }
    }
}