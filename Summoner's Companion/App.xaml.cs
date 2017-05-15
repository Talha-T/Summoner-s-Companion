﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Summoner_s_Companion
{
    /// <summary>
    /// App.xaml etkileşim mantığı
    /// </summary>
    public partial class App
    {

        private App()
        {
            Resources = base.Resources;
        }

        public new static ResourceDictionary Resources;
    }
}