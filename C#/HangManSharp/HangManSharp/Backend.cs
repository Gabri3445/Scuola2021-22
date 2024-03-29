﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HangManSharp
{
    internal class Backend
    {
        public string GetWord() => File.ReadLines("words").Skip(Random.Shared.Next(1000)).Take(1).FirstOrDefault();

        public class ConsoleSpinner
        {
            int counter;
            public ConsoleSpinner()
            {
                counter = 0;
            }
            public void Turn()
            {
                counter++;
                switch (counter % 4)
                {
                    case 0: Console.Write("/"); break;
                    case 1: Console.Write("-"); break;
                    case 2: Console.Write("\\"); break;
                    case 3: Console.Write("|"); break;
                }
                Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
            }
        }

        public int[] Compare(char[] str, string input)
        {
            int[] arr = new int[str.Length];
            char[] inputChar = input.ToCharArray();

            if(str.Length != input.Length)
            {
                return null;
            }

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == inputChar[i])
                    arr[i] = 1;
                else
                {
                    for (int j = 0; j < str.Length; j++)
                    {
                        if (inputChar[i] == str[j])
                            arr[i] = 2;
                    }
                }
            }

            return arr;
        }

        public void Print(int[] arr, string input)
        {
            char[] inputChar = input.ToCharArray();
            for (int i = 0; i < input.Length; i++)
            {
                switch (arr[i])
                {
                    case 0: 
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(inputChar[i]);
                        break;
                    case 1:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(inputChar[i]);
                        break;
                    case 2:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(inputChar[i]);
                        break;
                    default:
                        Console.Write("Error");
                        Environment.Exit(1);
                        break;
                }
            }
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public static void RemoveCurrentConsoleLine()
        {
            int currentCursorLine = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentCursorLine);
        }
    }
}