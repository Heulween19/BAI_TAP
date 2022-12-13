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
using System.Windows.Shapes;

namespace User_WpfApp
{
    /// <summary>
    /// Interaction logic for Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void btnUserForm_Click(object sender, RoutedEventArgs e)
        {
            FormUser f = new FormUser();
            f.Show();
            this.Close();

        }

        private void btnRoleForm_Click(object sender, RoutedEventArgs e)
        {
            FormRole r = new FormRole();
            r.Show();
            this.Close();
        }
    }
}
