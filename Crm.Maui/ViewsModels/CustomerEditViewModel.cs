using CommunityToolkit.Maui.Converters;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Crm.Maui.Models;
using Crm.Maui.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace Crm.Maui.ViewsModels
{
    public partial class CustomerEditViewModel : ObservableObject, IQueryAttributable
    {
        [ObservableProperty]
        private Customer _cust;

        protected Func<Customer, Task> ParentRefreshAction { get; set; }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query != null)
            {
                if (query.TryGetValue("Item",out var currentCustomer)) 
                {
                    Cust = (Customer) currentCustomer;
                }
                if (query.TryGetValue("ParameterRefreshAction", out object? parentRefreshAction))
                {
                    ParentRefreshAction = (Func<Customer, Task>) parentRefreshAction;
                }
                query.Clear();
            }
        }

        [RelayCommand]
        public async Task SaveAsync()
        {
            // Guardar el nuevo cliente en la base de datos
            using CrmDbContext dbContext = new CrmDbContext();
            await dbContext.Customers.AddAsync(Cust);
            await dbContext.SaveChangesAsync();

            // Agregamos el nuevo cliente a la coleccion del Customers de la pantalla padre invocando a ParentsRefreshAction
            await ParentRefreshAction(Cust);

            // Regresamos a la pantalla padre
            await Shell.Current.GoToAsync("..");
        }
    }
}
