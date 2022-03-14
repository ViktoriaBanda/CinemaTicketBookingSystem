using System;
using System.IO;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Cinema.Models;
using Cinema.ViewModels;
using Cinema.Views;

namespace Cinema
{
    public class App : Application
    {
        private const string USERDATABASE_NAME = "Users";
        private static UserBaseModel _userDataBase;
        
        private const string TICKETSBASE_NAME = "Tickets";
        private static TicketsBaseModel _ticketsDataBase;
        
        private const string FILMSBASE_NAME = "Films";
        private static FilmsBaseModel _filmsDataBase;
        
        public static MainWindow MainWindow;
        public static UserBaseModel UserDataBase
        {
            get
            {
                if (_userDataBase == null)
                {
                    var folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                    var dataBasePath = Path.Combine(folderPath, USERDATABASE_NAME);
                    _userDataBase = new UserBaseModel(dataBasePath);
                    
                    //очистка БД пользователей
                    //_userDataBase.ClearDataBase();
                }

                return _userDataBase;
            }
        }
        
        public static TicketsBaseModel TicketsDataBaseModel
        {
            get
            {
                if (_ticketsDataBase == null)
                {
                    var folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                    var ticketsBasePath = Path.Combine(folderPath, TICKETSBASE_NAME);
                    _ticketsDataBase = new TicketsBaseModel(ticketsBasePath);
                    
                    //очистка БД билетов
                    //_ticketsDataBase.ClearDataBase();
                }

                return _ticketsDataBase;
            }
        }
        
        public static FilmsBaseModel FilmsDataBase
        {
            get
            {
                if (_filmsDataBase == null)
                {
                    var folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                    var dataBasePath = Path.Combine(folderPath, FILMSBASE_NAME);
                    _filmsDataBase = new FilmsBaseModel(dataBasePath);
                }

                return _filmsDataBase;
            }
        }
        
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = new MainWindow
                {
                   DataContext = new MainWindowViewModel(),
                };
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}