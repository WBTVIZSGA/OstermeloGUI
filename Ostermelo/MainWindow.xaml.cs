using Ostermelo.Data.Models;
using Ostermelo.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Ostermelo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DeliverySearchModel searchModel= new DeliverySearchModel();
        ObservableCollection<DeliveryModel> deliveries = new ObservableCollection<DeliveryModel>();

        public MainWindow()
        {
            InitializeComponent();
            grpSearch.DataContext = this.searchModel;
            dgList.ItemsSource = this.deliveries;

            Loaded += (sender, e) =>
            {
                cboPartner.ItemsSource = new GenericRepository<PartnerModel>().GetAll().Select(p => new
                {
                    Id = (int?)p.Id,
                    p.Name,
                })
                .Union
                (
                    new List<dynamic>() 
                    { 
                        new { Id = (int?)null, Name = ""} 
                    }
                )
                .OrderBy(p => p.Name);
                cboPartner.DisplayMemberPath = "Name";
                cboPartner.SelectedValuePath = "Id";

                var juices = new GenericRepository<JuiceModel>().GetAll().Select(j => new
                {
                    Id = (int?)j.Id,
                    j.Name
                }).ToList();
                juices.Insert(0, new { Id = (int?)null, Name = "" });

                cboJuice.ItemsSource = juices;
                cboJuice.DisplayMemberPath = "Name";
                cboJuice.SelectedValuePath = "Id";
            };
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            this.deliveries = new ObservableCollection<DeliveryModel>(new DeliveryRepositry().Search(this.searchModel));
            dgList.ItemsSource = this.deliveries;
        }

        private void NewButton_Click(object sender, RoutedEventArgs e)
        {
            var wnd = new DeliveryWindow();
            if (wnd.ShowDialog() == true)
            {
                this.deliveries.Add(wnd.Delivery);
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
