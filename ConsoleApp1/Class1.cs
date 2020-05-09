using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    static class CRUD
    {
        public static void Create()
        {
            try
            {
                using (var Context = new PersonContext())
                {
                    Console.Write("LastName:");
                    string LastName = Console.ReadLine();
                    Console.Write("FirstName:");
                    string FirstName = Console.ReadLine();
                    Console.Write("MiddleName:");
                    string MiddleName = Console.ReadLine();
                    Console.Write("BirthDate:");
                    DateTime BirthDate = Convert.ToDateTime(Console.ReadLine());
                    PersonTable person = new PersonTable()
                    {
                        LastName = LastName,
                        FirstName = FirstName,
                        MiddleName = MiddleName,
                        BirthDate = BirthDate
                    };
                    Context.PersonTable.Add(person);
                    if (Context.SaveChanges() > 0)
                    {
                        Console.WriteLine("Успешно добавлен!");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.ReadKey();
            }
        }
        public static void Read(string Type = null)
        {
            try
            {
                using (var context = new PersonContext())
                {
                    var PersonList = context.PersonTable.ToList();

                    PersonList.ForEach(p =>
                    {
                        Console.WriteLine($"ID:{p.Id}\tLastName:{p.LastName}\tFirstName:{p.FirstName}\tMiddleName:{p.MiddleName}\tBirthDate:{p.BirthDate}");
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (Type ==null)Console.ReadKey();
            }

        }
        public static void Update()
        {
            try
            {
                using (var Context = new PersonContext())
                {
                    Read("Update");
                    Console.WriteLine("Введите ID человека каторый вы хотели изменит его данны!!!");
                    Console.Write("ID: ");
                    int ID = Convert.ToInt32(Console.ReadLine());
                    var person = Context.PersonTable.Find(ID);
                    if (person != null)
                    {
                        Console.Write("LastName:");
                        string LastName = Console.ReadLine();
                        Console.Write("FirstName:");
                        string FirstName = Console.ReadLine();
                        Console.Write("MiddleName:");
                        string MiddleName = Console.ReadLine();
                        Console.Write("BirthDate:");
                        DateTime BirthDate = Convert.ToDateTime(Console.ReadLine());
                        person.LastName = LastName;
                        person.FirstName = FirstName;
                        person.MiddleName = MiddleName;
                        person.BirthDate = BirthDate;

                        if (Context.SaveChanges() > 0)
                        {
                            Console.WriteLine("Успешно изменено!");
                        }
                        else
                        {
                            Console.WriteLine("Не изменен!");
                        }
                    }
                    else Console.WriteLine("В нашу таблицу человек по такой ID не существует!");

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.ReadKey();
            }
        }
        public static void Delete()
        {
            try
            {
                using (var Context = new PersonContext())
                {
                    Read("Delete");
                    Console.WriteLine("Введите ID человека каторый вы хотели удалить его данны!!!");
                    Console.Write("ID: ");
                    var ID = Convert.ToInt32(Console.ReadLine());
                    var person = Context.PersonTable.Find(ID);

                    if (person != null)
                    {
                        Console.Write("Вы действительно хотели удалить? Д(да)/Н(нет):");
                        var confirm = Console.ReadLine();
                        if (confirm.ToUpper() == "Д") Context.PersonTable.Remove(person);

                        if (Context.SaveChanges() > 0)
                        {
                            Console.WriteLine("Успешно удален!");
                        }
                        else
                        {
                            Console.WriteLine("Не удален!");
                        }
                    }
                    else Console.WriteLine("В нашу таблицу человек по такой ID не существует!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.ReadKey();
            }
        }
    }
}
