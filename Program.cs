﻿using System;

namespace projdbkeepr
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ApplicationSettingsFactory appSettingsFactory = 
                new ApplicationSettingsFactory(args);
            Console.WriteLine("Hello World!");
        }
    }
}