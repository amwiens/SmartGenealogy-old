﻿using SmartGenealogy.Views;

namespace SmartGenealogy
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}