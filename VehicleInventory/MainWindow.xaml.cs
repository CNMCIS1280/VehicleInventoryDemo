using System;
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

namespace VehicleInventory
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Vehicle> vehicles;
        VehicleService service = new VehicleService();
        public MainWindow()
        {
            InitializeComponent();
            vehicles = service.GetAll();
            lbVehicles.ItemsSource = vehicles;

        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            VehicleForm form = new VehicleForm();

            if (form.ShowDialog() == true)
            {
                //we have a good item add it to the list
                //Add the new Vehicle to database
                service.AddItem(form.Vehicle);
                //Refresh the lisbox
                vehicles = service.GetAll();
                lbVehicles.ItemsSource = vehicles;
                lbVehicles.Items.Refresh();
            };
        }

        private void lbVehicles_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Vehicle vehicle = (Vehicle)lbVehicles.SelectedItem;
            VehicleForm form = new VehicleForm(vehicle);
            if(form.ShowDialog()== true)
            {
                //Update the vehicle in the database 
                service.UpdateItem(vehicle);
                //Refresh the lb
                vehicles = service.GetAll();
                lbVehicles.ItemsSource = vehicles;
                lbVehicles.Items.Refresh();
            }
        }
    }
}
