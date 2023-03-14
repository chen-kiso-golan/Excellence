﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities_Log;
using static Utilities_Log.LogManager;

namespace Market.Entities
{
    public class MainManager
    {
        private static readonly MainManager instance = new MainManager();
        public static MainManager Instance { get { return instance; } }



        public LogManager log;

        public DepartmentManager DepartmentManager;

        public ProductManager ProductManager;



        private MainManager()
        {
            AppDomainInitializer();
        }

        private void AppDomainInitializer()
        {
            try
            {
                log = new LogManager(providerType.Console);
                DepartmentManager = new DepartmentManager(log);
                ProductManager = new ProductManager(log);
                log.LogEvent(@"Entities \ MainManager \ AppDomainInitializer ran Successfully - ");
            }
            catch (Exception ex)
            {
                log.LogException($@"An Exception occurred while initializing the {ex.StackTrace} : {ex.Message}", ex);
            }
        }
    }
}