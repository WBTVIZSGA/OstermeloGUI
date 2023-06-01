using Ostermelo.Data.Models;
using Ostermelo.Data.Repositories;
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
using System.Windows.Shapes;

namespace Ostermelo
{
    /// <summary>
    /// Interaction logic for DeliveryWindow.xaml
    /// </summary>
    public partial class DeliveryWindow : Window
    {
        public DeliveryModel Delivery { get; private set; }

        public DeliveryWindow()
        {
            InitializeComponent();
            this.Delivery= new DeliveryModel() { BindedDate = DateTime.Today };
            this.DataContext = this.Delivery;

            cboPartner.ItemsSource = new GenericRepository<PartnerModel>().GetAll();
            cboPartner.DisplayMemberPath = "Name";
            cboPartner.SelectedValuePath = "Id";

            cboJuice.ItemsSource = new GenericRepository<JuiceModel>().GetAll();
            cboJuice.DisplayMemberPath = "Name";
            cboJuice.SelectedValuePath = "Id";
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (CheckData())
            {
                this.Delivery = new DeliveryRepositry().Insert(this.Delivery);
                this.DialogResult = true;
                this.Close();
            }
        }

        private bool CheckData()
        {
            if (Delivery.PartnerId == 0)
            {
                cboPartner.IsDropDownOpen = true;
                return false;
            }
            if (Delivery.JuiceId == 0)
            {
                cboJuice.IsDropDownOpen = true;
                return false;
            }
            if (Delivery.BindedDate < DateTime.Today || Validation.GetHasError(dpDate))
            {
                dpDate.Focus();
                return false;
            }
            if (Delivery.Pack <= 0 || Validation.GetHasError(txtPack))
            {
                txtPack.Focus();
                return false;
            }
            return true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}
