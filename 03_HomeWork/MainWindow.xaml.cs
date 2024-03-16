using _02_HomeWork.Model;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static Program;

namespace _03_HomeWork_Fix
{
    public partial class MainWindow : Window
    {
        Storoom db;

        public MainWindow()
        {
            InitializeComponents();
            db = new Storoom(ConfigurationManager.ConnectionStrings["connStoroom"].ConnectionString);
        }

        private void getProducts(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = db.GetAllProducts();
        }

        private void getSuppliers(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = db.GetAllSuppliers();
        }

        private void createProduct(object sender, RoutedEventArgs e)
        {
           
            Product newProduct = new Product
            {
                Name = productNameTextBox.Text,
                Type = productTypeTextBox.Text,
                Quantity = int.Parse(productQuantityTextBox.Text),
                Cost = int.Parse(productCostTextBox.Text),
                SupplierId = int.Parse(productSupplierIdTextBox.Text) 
            };

           
            db.CreateProduct(newProduct);

         
            dataGrid.ItemsSource = db.GetAllProducts();
        }

        private void createSupplier(object sender, RoutedEventArgs e)
        {
    
            Supplier newSupplier = new Supplier
            {
                Name = supplierNameTextBox.Text 
            };

          
            db.CreateSupplier(newSupplier);

           
            dataGrid.ItemsSource = db.GetAllSuppliers();
        }


        private void updateProduct(object sender, RoutedEventArgs e)
        {
         
            Product selectedProduct = dataGrid.SelectedItem as Product;
            if (selectedProduct != null)
            {
            
                db.UpdateProduct(selectedProduct);

                dataGrid.ItemsSource = db.GetAllProducts();
            }
        }

        private void deleteProduct(object sender, RoutedEventArgs e)
        {
          
            Product selectedProduct = dataGrid.SelectedItem as Product;
            if (selectedProduct != null)
            {
               
                db.DeleteProduct(selectedProduct.Id);
       
                dataGrid.ItemsSource = db.GetAllProducts();
            }
        }

        private void updateSupplier(object sender, RoutedEventArgs e)
        {
        
            Supplier selectedSupplier = dataGrid.SelectedItem as Supplier;
            if (selectedSupplier != null)
            {
        
                db.UpdateSupplier(selectedSupplier);
            
                dataGrid.ItemsSource = db.GetAllSuppliers();
            }
        }

        private void deleteSupplier(object sender, RoutedEventArgs e)
        {
        
            Supplier selectedSupplier = dataGrid.SelectedItem as Supplier;
            if (selectedSupplier != null)
            {
             
                db.DeleteSupplier(selectedSupplier.Id);
         
                dataGrid.ItemsSource = db.GetAllSuppliers();
            }
        }
    }
}
