﻿namespace BankApp;
public partial class App : Application
{
    public const string DATABASE_NAME = "friends.db";
    public static UserRepository database;
    public static UserRepository Database
    {
        get
        {
            if (database == null)
            {
                database = new UserRepository(
                    Path.Combine(
                        Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DATABASE_NAME));
            }
            return database;
        }
    }
    public App()
    {
        InitializeComponent();

        MainPage = new NavigationPage(new MainPage());
    }
    protected override void OnStart()
    {
    }
    protected override void OnSleep()
    {
    }
    protected override void OnResume()
    {
    }
}