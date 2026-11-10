using Crm.Maui.Views;

namespace Crm.Maui
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            // Registrmos las rutas que están en la jerarquia visual del Shell
            Routing.RegisterRoute(
                nameof(CustomerEditPage),
                typeof(CustomerEditPage));
        }
    }
}
