﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using XamlingCore.Portable.View.ViewModel;

namespace XamlingCore.Samples.View.MasterDetailHome
{
    public class HomeItemViewModel : XViewModel
    {
        public ICommand NextPageCommand { get; set; }
        
        public HomeItemViewModel()
        {
            Title = "Home";
            NextPageCommand = new Command(_nextPage);
        }

        void _nextPage()
        {
            NavigateTo<AnotherItemViewModel>();
        }
    }
}