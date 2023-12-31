﻿using System;
using System.Collections.Generic; 

namespace main
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int > map = new Dictionary<string, int>();

            Console.Write("Enter file full path: ");
            string path = Console.ReadLine();

            try
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    while (!sr.EndOfStream)
                    {
                        string[] line = sr.ReadLine().Split(',');
                        string name = line[0];
                        int votes = int.Parse(line[1]);

                        if(map.ContainsKey(name))
                        {
                            map[name] += votes;
                        }
                        else
                        {
                            map[name] = votes;
                        }
                    }
                    foreach(var item in map)
                    {
                        Console.WriteLine(item.Key + ": " + item.Value);
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}

