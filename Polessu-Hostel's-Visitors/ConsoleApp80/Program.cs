﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace ConsoleApplication65
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите путь для создания файла :Журнал:");
            string put = Console.ReadLine();//вводится путь сохранения файла (журнал)
            Console.WriteLine("Введите путь для создания файла :Статистика:");
            string putb = Console.ReadLine();//вводится путь сохранения файла (статистика)

            StreamWriter f1 = new StreamWriter(put, true);
            f1.Close();

            Console.WriteLine("Хотите ли вы стереть текущий файл?");
            if (Console.ReadLine() == "yes")
            {
                StreamWriter f2 = new StreamWriter(put);
                f2.Write("");
                f2.Close();
            }//стерается содержимое текущего файла (журнал)

            int count = System.IO.File.ReadAllLines(@put).Length;//длина текущего файла (журнал) в строках

            int n = 50;//количество строк таблицы 
            StreamWriter f = new StreamWriter(put, true);//создаю поток который будет записывать данные в конец файла (журнал)
            StreamWriter fS = new StreamWriter(putb);//создаю поток который будет перезаписывать данные в файл (статистика)
            int[] nomer = new int[n];//создаю массив "nomer" (столбец номер посещ.) *типа инт исп для нумерации*
            string[] Nomer = new string[n];//создаю массив "Nomer" (столбец номер посещ.) *типа стринг используется только для шапки*
            string[] Data = new string[n];//создаю массив "Data" (столбец дата посещ.)
            string[] Vremya = new string[n];//создаю массив "Vremya" (столбец время посещ.)
            string[] FIO = new string[n];//создаю массив "FIO" (столбец ФИО посетит.)
            string[] Kkomy = new string[n];//создаю массив "Kkomy" (столбец к кому пришел посетит.)
            string[] FIOpr = new string[n];//создаю массив "FIOpr" (столбец ФИО проверявш.)

            System.IO.FileInfo youfile = new System.IO.FileInfo(@put);// сюда заносится размер файла (журнал)
            if (youfile.Length > 3)
            { count = count - 2; }

            if (youfile.Length <= 3)
            {

                Nomer[0] = "Номер";//создаю элемент шапки (название 1 столбца)
                Data[0] = "Дата";//создаю элемент шапки (название 2 столбца)
                Vremya[0] = "Время";//создаю элемент шапки (название 3 столбца)
                FIO[0] = "Ф.И.О";//создаю элемент шапки (название 4 столбца)
                Kkomy[0] = "К кому";
                FIOpr[0] = "Ф.И.О пр.";//создаю элемент шапки (название 5 столбца)

                Nomer[1] = "------------------------------";
                Data[1] = "------------------------------";
                Nomer[1] = "------------------------------";
                Vremya[1] = "------------------------------";
                FIO[1] = "------------------------------";
                Kkomy[1] = "------------------------------";
                FIOpr[1] = "------------------------------";

                f.Write("{0, -30}|", Nomer[0]);
                f.Write("{0, -30}|", Data[0]);
                f.Write("{0, -30}|", Vremya[0]);
                f.Write("{0, -30}|", FIO[0]);
                f.Write("{0, -30}|", Kkomy[0]);
                f.WriteLine("{0, -30}|", FIOpr[0]);

                f.Write("{0, -30}|", Nomer[1]);
                f.Write("{0, -30}|", Data[1]);
                f.Write("{0, -30}|", Vremya[1]);
                f.Write("{0, -30}|", FIO[1]);
                f.Write("{0, -30}|", Kkomy[1]);
                f.WriteLine("{0, -30}|", FIOpr[1]);//графическое обозначение границ шапки (нижнее подчеркивание)

            }//если файл пустой то в него записываем шапку

            int b = 0;
            int z = 0;
            bool c = false;//нужна для проверки наличия подстроки в строке
            string s1 = "exit";//нужна для проверки наличия подстроки в строке
            double A = 0;//количество посетилтелей администрации
            double M = 0;//количество посетилтелей мероприятий
            double U = 0;//количество посетилтелей учеников
            double w = 0; double v = 0; double w1 = 0; double v1 = 0;//нужны для округления процентов
            for (int i = 2; i < n; i++)//создаю цикл "Ввода и присвоения"
            {
                if (z == 0)
                {
                    Console.WriteLine("-------------------------------------");
                    b = b + 1;
                    nomer[i] = count + 1;//номеру посетителя присваиваем количество строк таблицы без шапки
                    Console.WriteLine("Номер посетителя" + " " + nomer[i]);//присвоение строке "Номер" порядковый номер посещения

                    Data[i] = System.DateTime.Now.ToShortDateString();//присвоение строке "Дата" : даты в данный момент
                    Console.WriteLine("Дата посещения" + " " + Data[i]);

                    Vremya[i] = System.DateTime.Now.ToShortTimeString();//присвоение строке "Время" : времени в данный момент
                    Console.WriteLine("Время посещения" + " " + Vremya[i]);

                    Console.WriteLine("Введите Ф.И.О посетителя");
                    FIO[i] = Console.ReadLine();//ввод с клавиатуры "Ф.И.О" посетителя

                    Console.WriteLine("Введите К кому пришел посетитель");
                    Kkomy[i] = Console.ReadLine();//ввод с клавиатуры "К кому" посетителя
                    if (Kkomy[i] == "A")
                    { A = A + 1; }
                    if (Kkomy[i] == "U")
                    { U = U + 1; }
                    if (Kkomy[i] == "M")
                    { M = M + 1; }
                    Console.WriteLine("Введите Ф.И.О проверявшего");
                    FIOpr[i] = Console.ReadLine();//ввод с клавиатуры "Ф.И.О пр." проверявшего
                    c = FIOpr[i].Contains(s1);//проверка строки "Ф.И.О пр." на наличие подстроки s1(="exit")

                    FIOpr[i] = FIOpr[i].Replace(s1, "");//удаление в строке "Ф.И.О пр." если она есть подстроки s1(="exit")
                    count = count + 1;//счетчик посетителей

                    if (c == true)//если строка имеет подстроку "exit" то совершается выход из программы
                    {
                        Console.WriteLine("Хотите ли вы вывести статистику?");
                        if (Console.ReadLine() == "yes")//проверяет хочет ли пользователь вывести статистику
                        {
                            w = (A / (U + A + M)) * 100;
                            v = w % 1;
                            w1 = (M / (U + A + M)) * 100;
                            v1 = w1 % 1;

                            if (v >= 0.5)
                            { w = w - v + 1; }
                            else
                            { w = w - v; }
                            if (v1 >= 0.5)
                            { w1 = w1 - v1 + 1; }
                            else
                            { w1 = w1 - v1; }//округление процентов

                            if (A + M + U == 0)//если количество посетителей по тпам равно 0 то выводит без процентов
                            {
                                Console.WriteLine("Количество посетителей администрации: " + A);
                                Console.WriteLine("Количество посетителей учеников: " + U);
                                Console.WriteLine("Количество посетителей мероприятий: " + M);
                                Console.WriteLine("----------------------------------------------");
                                Console.WriteLine("Количество посетителей за сессию: " + b);
                                Console.WriteLine("Количество посетителей за все время: " + count);

                                fS.WriteLine("Количество посетителей администрации: " + A);
                                fS.WriteLine("Количество посетителей учеников: " + U);
                                fS.WriteLine("Количество посетителей мероприятий: " + M);
                                fS.WriteLine("----------------------------------------------");
                                fS.WriteLine("Количество посетителей за сессию: " + b);
                                fS.WriteLine("Количество посетителей за все время: " + count);
                            }
                            else
                            {
                                Console.WriteLine("Количество посетителей администрации: " + A);
                                Console.WriteLine("Количество посетителей учеников: " + U);
                                Console.WriteLine("Количество посетителей мероприятий: " + M);
                                Console.WriteLine("----------------------------------------------");
                                Console.WriteLine("Процент посетителей администрации: " + w + "%");
                                Console.WriteLine("Процент посетителей учеников: " + (100 - w - w1) + "%");
                                Console.WriteLine("Процент посетителей учеников: " + w1 + "%");
                                Console.WriteLine("----------------------------------------------");
                                Console.WriteLine("Количество посетителей за сессию: " + b);
                                Console.WriteLine("Количество посетителей за все время: " + count);

                                fS.WriteLine("Количество посетителей администрации: " + A);
                                fS.WriteLine("Количество посетителей учеников: " + U);
                                fS.WriteLine("Количество посетителей мероприятий: " + M);
                                fS.WriteLine("----------------------------------------------");
                                fS.WriteLine("Процент посетителей администрации: " + w + "%");
                                fS.WriteLine("Процент посетителей учеников: " + (100 - w - w1) + "%");
                                fS.WriteLine("Процент посетителей мероприятий: " + w1 + "%");
                                fS.WriteLine("----------------------------------------------");
                                fS.WriteLine("Количество посетителей за сессию: " + b);
                                fS.WriteLine("Количество посетителей за все время: " + count);

                            }
                        }
                        break;
                    }

                }

            }

            int j = 2;
            while (j <= (b + 1))//создаю цикл "Вывода" (гл фишка:сколько строк ввел - столько и выведется (длина таблицы соответствует длине строк)
            {

                f.Write("{0, -30}|", nomer[j]);
                f.Write("{0, -30}|", Data[j]);
                f.Write("{0, -30}|", Vremya[j]);
                f.Write("{0, -30}|", FIO[j]);
                f.Write("{0, -30}|", Kkomy[j]);
                f.WriteLine("{0, -30}|", FIOpr[j]);///вывод в виде таблицы в файл

                j = j + 1;//счетчик
            }
            f.Close();//закрываем поток записи в файл,иначе информация не запишется
            fS.Close();//закрываем поток записи в файл,иначе информация не запишется

        }
    }
}