using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Crm.Maui.Models;
using Crm.Maui.Persistence;
using Crm.Maui.Views;
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

        [RelayCommand]
        private async Task ShowNewCustomerFormAsync()
        {
            await Shell.Current.GoToAsync(
                nameof(CustomerEditPage),
                parameters: new Dictionary<string, object>
                {
                    {"ParameterRefreshAction", (Func<Customer, Task>) RefresAddedAsync},
                    {"Item", new Customer() },
                });
        }

        private Task RefresAddedAsync(Customer addedCustomer)
        {
            Customers.Add(addedCustomer);
            return Task.CompletedTask;
        }
    }
}
