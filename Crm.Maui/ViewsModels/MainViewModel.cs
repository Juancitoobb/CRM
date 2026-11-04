using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Crm.Maui.Models;
using Crm.Maui.Persistence;
using Microsoft.Maui.Layouts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Crm.Maui.ViewsModels
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<Customer> _customers;

        [ObservableProperty]
        private bool _refreshing;

        [RelayCommand]
        private async Task LoadCustomersAsync()
        {
            await Task.Run(
                () =>
                {
                    using CrmDbContext dbContext = new CrmDbContext();

                    Customers = new ObservableCollection<Customer>(dbContext.Customers);
                    Refreshing = false;
                }
                );
        }

        [RelayCommand]
        private void Showing()
        {
            Refreshing = true;
        }
    }
}
