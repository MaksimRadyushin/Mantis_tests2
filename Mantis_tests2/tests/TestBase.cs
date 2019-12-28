﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace mantis_tests
{
    public class TestBase
    {
        protected ApplicationManager app;
        public static bool PERFORM_LONG_UI_CHECKS = true;


        [SetUp]
        protected void SetupApplicationManager()
        {
            app = ApplicationManager.GetInstance();


        }

        public static Random rnd = new Random();

        public static string GenerateRandomString(int max)
        {

            int l = Convert.ToInt32(rnd.NextDouble() * max);
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < l; i++)
            {
                builder.Append(Convert.ToChar(32 + Convert.ToInt32(rnd.NextDouble() * 65)));
            }
            string builderS = builder.ToString();
            return builderS;

        }




    }
}