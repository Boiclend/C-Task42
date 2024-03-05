using System;
using System.Collections.Generic;

// Требуется написать свой Bruteforce т. е. пользователь вводит какой-то пароль и программа методом перебора всех возможных вариантов находит этот пароль.
// Предполагается, что программа не может отработать и не найти пароль. Ограничение перебора осуществляется пользователем,
// т.е  будут ли включены в перебор цифры, заглавные буквы, символы и т. д.

// Рекомендую ограничить длину вводимого пароля до 4-х символов, больше не надо,
// иначе программа долго будет работать. Еще лучше, если на этапе разработки программы,
// длина пароля будет 2 — 3 символа. Кроме того, задайте в программе множество допустимых символов пароля.
// Например, в пароле могут использоваться только цифры и/или буквы, это заметно поможет ускорить процесс отладки программы-брутфорса.


class Program
{
    static string Input(string str)
    {
        Console.Write(str);
        return Console.ReadLine();
    }

    static void Main()
    {
        string strPassword;
        do
        {
            strPassword = Input("Введите пароль: ");
            if (strPassword.Length < 1)
            {
                Console.WriteLine("Пожалуйста, введите пароль");
            } 
        } while (strPassword.Length < 1);

        string strChars = "";
        do
        {
            Console.WriteLine("Введите '+' если пароль включает... или 'Enter' что бы пропустить");
            if (Input("Маленькие буквы: ") == "+")
            {
                strChars += "qwertyuiopasdfghjklzxcvbnm";
            } 
            if (Input("Большие буквы: ") == "+") 
            {
                strChars += "QWERTYUIOPASDFGHJKLZXCVBNM";
            }
            if (Input("Цифры: ") == "+") 
            {
                strChars += "0123456789";
            }
            if (Input("Символы: ") == "+") 
            {
                strChars += " `~!@#$%^&*()_+=-][}{\\';|:/.,<>?\"";
            }
            if (strChars.Length < 1) 
            {
                Console.WriteLine("Пожалуйста, выберите условия");
            }
        } while (strChars.Length < 1);

        bool c = true;
        bool f = false;
        int size = strPassword.Length;
        int sizeChars = strChars.Length;
        int[] index = new int[size];
        string strBruteforce = new string(' ', size);

        Console.WriteLine("Условия: " + strChars);
        Console.WriteLine("Длина пароля: " + size);
        Console.WriteLine("Длина словаря: " + sizeChars);
        Console.WriteLine("Количество вариантов пароля: " + Math.Pow(sizeChars, size));
        Console.WriteLine("Пожалуйста подождите...");

        while (true)
        {
            for (int i = size - 1; i >= 0; --i)
            {
                if (i != 0)
                {
                    if (index[i] == sizeChars)
                    {
                        index[i] = 0;
                        index[i - 1]++;
                    }
                }
            }

            for (int i = 0; i < size; ++i) strBruteforce = strBruteforce.Remove(i, 1).Insert(i, strChars[index[i]].ToString());
            c = true;
            if (strBruteforce == strPassword)
            {
                Console.WriteLine("Ваш пароль: " + strBruteforce);
                c = false;
                f = true;
                break;
            }
            c = false;
            for (int i = 0; i < size; ++i)
            {
                if (index[i] != sizeChars - 1)
                {
                    c = true;
                    break;
                }
            }
            if (!c) 
            {
                break;
            }
            index[size - 1]++;
        }
        if (!f) 
        {
            Console.WriteLine("Ошибка выбора символов");
        }
    }
}
