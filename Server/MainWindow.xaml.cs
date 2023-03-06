﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Server
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ApplicationContext db = new ApplicationContext();
        private CollectionViewSource AccountViewSource;
        core.Server server;
        public MainWindow()
        {
            InitializeComponent();
<<<<<<< HEAD
=======
            AccountViewSource =
               (CollectionViewSource)FindResource(nameof(AccountViewSource));
            Loaded += MainWindowLoaded;
        }
        void MainWindowLoaded(object sender, RoutedEventArgs e)
        {
            server = new core.Server();
            Task serverTask = new Task(server.Start);
            serverTask.Start();
            db.Database.EnsureCreated();
            db.Accounts.Load();
            DataContext = db.Accounts.Local.ToObservableCollection();
            AccountViewSource.Source = DataContext;
>>>>>>> parent of 21aafab (Revert "Added MD5 to passwords")
        }

        private void RegButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                server.tryRegistrateAccount(LoginTextBox.Text, PasswordTextBox.Password);
                MessageBox.Show($"Пользователь {LoginTextBox.Text} зарегестрирован");
                AccountsDataGridUpdate();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void AccountsDataGridUpdate()
        {
            AccountViewSource.Source = null;
            AccountViewSource.Source = db.Accounts.ToList();
        }
    }
}
