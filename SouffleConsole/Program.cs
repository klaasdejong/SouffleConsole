﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;



namespace SouffleConsole
{
    public class Program
    {
        static void Main(string[] args)
        {                       
            Waiter.MainWaiter();
            WriteLine("This is the end");
            ReadKey();
        }
    }

}
 