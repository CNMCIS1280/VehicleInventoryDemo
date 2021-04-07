using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace VehicleInventory
{
    /// <summary>
    /// Interaction logic for VehicleForm.xaml
    /// </summary>
    public partial class VehicleForm : Window
    {
        public Vehicle Vehicle { get; set; }

        public VehicleForm():this(new Vehicle())
        {                
        }
        public VehicleForm(Vehicle vehicle)
        {
            InitializeComponent();
            Vehicle = vehicle ;
            txbId.Text = vehicle.Id.ToString();
            txbVIN.Text = vehicle.VIN;
            txbMileage.Text = vehicle.Mileage.ToString();
            txbModel.Text = vehicle.Model;
            txbMake.Text = vehicle.Make;
            txbRemarks.Text = vehicle.Remarks;
            txbLastOilChange.Text = vehicle.LastOilChange.ToString();
            txbYear.Text = vehicle.Year.ToString();
            txbColor.Text = vehicle.Color;
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            Vehicle.VIN = txbVIN.Text;
            Vehicle.Mileage = double.Parse(txbMileage.Text);
            Vehicle.Model = txbModel.Text;
            Vehicle.Make = txbMake.Text;
            Vehicle.Remarks = txbRemarks.Text;
            Vehicle.LastOilChange = double.Parse(txbLastOilChange.Text);
            Vehicle.Year = int.Parse(txbYear.Text);
            Vehicle.Color = txbColor.Text;
            this.DialogResult = true;
            this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}
