﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace Blacklighting
{
    public partial class EditPage : PhoneApplicationPage
    {
        public EditPage()
        {
            InitializeComponent();
        }

        private void Send_Click(object sender, EventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/MessagePage.xaml", UriKind.Relative));
        }
    }
}