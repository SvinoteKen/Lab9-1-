﻿using Lab9__1_.List;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9__1_
{
    public enum Type
    {
        Р,
        К,
        РБП
    }
    struct Log
    {
        public DateTime Time;
        public string Act;
        public string Str;
        public void DisplayLog()
        {
            Console.WriteLine("{0,-20} - {1,-15} {2,-30}", Time, Act, Str);
        }
    }
    struct Restaraunts
    {
        public string name;
        public Type type;
        public string address;
        public int rating;
        
    }
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\MSI\source\repos\Lab9 (1.Net)\Lab9 (1.Net)\lab.txt";
            DoublyLinkedList<Restaraunts> restaraunt = new DoublyLinkedList<Restaraunts>();
            bool First = true;
            using (StreamReader sr = new StreamReader(path))
            {
                while (sr.Peek() > -1)
                {
                    
                    string name = sr.ReadLine();
                    string typeText = sr.ReadLine();
                    Type type = new Type();
                    if (typeText == "Р")
                    {
                        type = Type.Р;
                    }
                    if (typeText == "К")
                    {
                        type = Type.К;
                    }
                    if (typeText == "РБП")
                    {
                        type = Type.РБП;
                    }
                    string adr = sr.ReadLine();
                    int rat = Convert.ToInt32(sr.ReadLine());
                    Restaraunts restaraunts1;
                    restaraunts1.name = name;
                    restaraunts1.type = type;
                    restaraunts1.address = adr;
                    restaraunts1.rating = rat;
                    if (First)
                    {
                        restaraunt.AddFirst(restaraunts1);
                        First = false;
                    }
                    else
                    {
                        restaraunt.Add(restaraunts1);
                    }
                }


            }
            List<Log> log = new List<Log>();
            DateTime time1 = DateTime.Now;
            DateTime time2 = DateTime.Now;
            TimeSpan interval = time2 - time1;
            String prompt = "1 – Просмотр таблицы\n2 – Добавить запись\n3 – Удалить запись\n4 – Обновить запись\n5 – Поиск записей\n6 – Просмотреть лог\n7 - Сортировка по рейтингу\n8 - Выход";
            Console.WriteLine(prompt);
            int x = int.Parse(Console.ReadLine());
            for (int y = x; y != 8;)
            {
                if (y == 1)
                {
                    Console.WriteLine("____________________________________________________________________________________________________");
                    Console.WriteLine("|{0,-98}|", "Рестраны и Кафе");
                    Console.WriteLine("____________________________________________________________________________________________________");
                    Console.WriteLine("|{0,-33}|{1,-10}|{2,-42}|{3,-10}|", "Название", "Тип", "Адресс", "Рейтинг");
                    Console.WriteLine("____________________________________________________________________________________________________");
                    foreach (Restaraunts info in restaraunt)
                    {
                        Console.WriteLine("|{0,-33}|{1,-10}|{2,-42}|{3,-10}|", info.name, info.type, info.address, info.rating);
                    }
                    Console.WriteLine("____________________________________________________________________________________________________");

                }
                if (y == 2)
                {
                    Console.WriteLine("Введите название:");
                    string name = Console.ReadLine();
                    Type type = new Type();
                    Console.WriteLine("Выбирите вид:1-Ресторан, 2-Кафе, 3-РБП");
                    int h = int.Parse(Console.ReadLine()) - 1;
                    type = (Type)h;
                    Console.WriteLine("Введите адрес:");
                    string address = Console.ReadLine();
                    Console.WriteLine("Введите рейтинг:");
                    int rating = Convert.ToInt32(Console.ReadLine());
                    Restaraunts res;
                    res.name = name;
                    res.type = type;
                    res.address = address;
                    res.rating = rating;
                    restaraunt.Add(res);
                    Log ADD;
                    ADD.Time = DateTime.Now;
                    ADD.Act = "Добавлена запись";
                    ADD.Str = name;
                    log.Add(ADD);
                    time1 = DateTime.Now;
                    TimeSpan inteval2 = time1 - time2;
                    if (interval < inteval2)
                    {
                        interval = inteval2;
                    }
                    time2 = ADD.Time;
                }
                if (y == 3)
                {
                    Console.WriteLine("Какую запись вы хотите удалить:");
                    int index = int.Parse(Console.ReadLine()) - 1;
                    if (index > restaraunt.Count || index < 0) { continue; }
                    Log DELETE;
                    DELETE.Time = DateTime.Now;
                    DELETE.Act = "Запись удалена";
                    int cnt1 = 0;
                    string DeleteName = "";
                    foreach (Restaraunts info in restaraunt)
                    {
                        if (cnt1 == index)
                        {
                            DeleteName = info.name;
                            restaraunt.Remove(info);
                        }
                        cnt1++;
                    }
                    DELETE.Str = DeleteName;
                    log.Add(DELETE);
                    time1 = DateTime.Now;
                    TimeSpan inteval2 = time1 - time2;
                    if (interval < inteval2)
                    {
                        interval = inteval2;
                    }
                    time2 = DELETE.Time;
                }
                if (y == 4)
                {
                    Console.WriteLine("Какую запись вы хотите обновить:");
                    int index = int.Parse(Console.ReadLine()) - 1;
                    if (index > restaraunt.Count || index < 0) { continue; }
                    string oldName = "";
                    int count = 0;
                    foreach (Restaraunts info in restaraunt)
                    {
                        if (count == index)
                        {
                            oldName = info.name;
                            restaraunt.Remove(info);
                        }
                        count++;
                    }
                    Console.WriteLine("Введите название:");
                    string name = Console.ReadLine();
                    Console.WriteLine("Выбирите вид:1-Ресторан, 2-Кафе, 3-РБП");
                    int h = int.Parse(Console.ReadLine());
                    Type type = (Type)h;
                    Console.WriteLine("Введите адрес:");
                    string address = Console.ReadLine();
                    Console.WriteLine("Введите рейтинг:");
                    int r = Convert.ToInt32(Console.ReadLine());
                    Restaraunts res;
                    res.name = name;
                    res.type = type;
                    res.address = address;
                    res.rating = r;

                    Log UPDATE;
                    UPDATE.Time = DateTime.Now;
                    UPDATE.Act = "Запись обнавлена";
                    UPDATE.Str = oldName;
                    log.Add(UPDATE);
                    time1 = UPDATE.Time;
                    TimeSpan inteval2 = time1 - time2;
                    if (interval < inteval2)
                    {
                        interval = inteval2;
                    }
                    time2 = UPDATE.Time;
                    restaraunt.AddToPosition(res, index);
                }
                if (y == 5)
                {
                    Console.WriteLine("Выберите вид заведения:\n1 - Ресторан\n2 - Кафе\n3 - Ресторан быстрого питания");
                    int u = int.Parse(Console.ReadLine()) - 1;
                    foreach(Restaraunts info in restaraunt)
                    { 
                        if (u == 0)
                        {   
                            if (info.type == (Type)u)
                            {
                                string e = info.name;
                                Console.WriteLine("По вышему поиску:{0}", e);
                                Console.WriteLine();
                            }
                        }
                        if (u == 1)
                        {
                            if (info.type == (Type)u)
                            {
                                string e = info.name;
                                Console.WriteLine("По вышему поиску:{0}", e);
                                Console.WriteLine();
                            }
                        }
                        if (u == 2)
                        {
                            if (info.type == (Type)u)
                            {
                                string e = info.name;
                                Console.WriteLine("По вышему поиску:{0}", e);
                                Console.WriteLine();
                            }
                        }
                    }
                }
                if (y == 6)
                {
                    for (int i = 0; i < log.Count; i++)
                    {
                        log[i].DisplayLog();
                    }
                    Console.WriteLine();
                    Console.WriteLine(interval + " - Самый долгий период бездействия пользователя");
                    break;
                }
                if (y == 7)
                {
                    List<Restaraunts> sorted = new List<Restaraunts>();
                    
                    Restaraunts res;
                    foreach (Restaraunts user in restaraunt)
                    {
                        res.name = user.name;
                        res.type = user.type;
                        res.address = user.address;
                        res.rating = user.rating;
                        sorted.Add(res);
                    }
                    Console.WriteLine("Выберите тип сортировки:\n1.По убыванию\n2.По возравстанию");
                    int u = Convert.ToInt32(Console.ReadLine());
                    if (u == 1)
                    {
                        InsertSortDes(sorted, 0, sorted.Count - 1);
                    }
                    if (u == 2)
                    {
                        InsertSortAsc(sorted, 0, sorted.Count - 1);
                    }
                    restaraunt.Clear();
                    bool F = true;
                    for (int i = 0; i < sorted.Count; i++)
                    {
                        res.name = sorted[i].name;
                        res.type = sorted[i].type;
                        res.address = sorted[i].address;
                        res.rating = sorted[i].rating;
                        if (F)
                        {
                            restaraunt.AddFirst(res);
                            F = false;
                        }
                        else
                        {
                            restaraunt.Add(res);
                        }
                    }
                }
                Console.WriteLine(prompt);
                y = int.Parse(Console.ReadLine());

            }
            using (StreamWriter sw = new StreamWriter(path, false))
            {
                foreach (Restaraunts info in restaraunt)
                {
                    sw.WriteLine(info.name + "\n" + info.type + "\n" + info.address + "\n" + info.rating);
                }
                sw.Close();
            }
        }

        static void InsertSortAsc(List<Restaraunts> arr, int l, int r)
        {
            for (int i = l + 1; i <= r; i++)
            {
                for (int j = r; j > l; j--)
                {
                    if (arr[j - 1].rating > arr[j].rating)
                    {
                        int x = j - 1;
                        int y = j;
                        Swap(ref arr, ref x, ref y);
                    }
                }
            }

        }
        static void InsertSortDes(List<Restaraunts> arr, int l, int r)
        {
            for (int i = l + 1; i <= r; i++)
            {
                for (int j = r; j > l; j--)
                {
                    if (arr[j - 1].rating < arr[j].rating)
                    {
                        int x = j - 1;
                        int y = j;
                        Swap(ref arr, ref x, ref y);
                    }
                }
            }

        }
        static void Swap(ref List<Restaraunts> a, ref int x, ref int y)
        {
            Restaraunts[] temp = new Restaraunts[a.Count - 1];
            temp[x] = a[x];
            a[x] = a[y];
            a[y] = temp[x];

        }

    }
}