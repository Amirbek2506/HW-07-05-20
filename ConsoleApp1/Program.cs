using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.Write("1.Create\n2.Read\n3.Update\n4.Delete\nВаш выбор: ");
                switch (Console.ReadLine())
                {
                    case "1": CRUD.Create(); break;
                    case "2": CRUD.Read(); break;
                    case "3": CRUD.Update(); break;
                    case "4": CRUD.Delete(); break;
                    default:
                        break;
                }
            }
        }
    }
}
