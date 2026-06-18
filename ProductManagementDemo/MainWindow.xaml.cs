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
using System.Windows.Navigation;
using System.Windows.Shapes;
using BusinessObjects;
using Services;

namespace ProductManagementDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IProductService productService;
        private ICategoryService categoryService;

        public MainWindow()
        {
            InitializeComponent();
            productService = new ProductService();
            categoryService = new CategoryService();
            LoadData();
        }

        private void LoadData()
        {
            // Load products into DataGrid
            dgData.ItemsSource = null;
            dgData.ItemsSource = productService.GetProducts();

            // Load categories into ComboBox
            cboCategory.ItemsSource = null;
            cboCategory.ItemsSource = categoryService.GetCategories();
            cboCategory.DisplayMemberPath = "CategoryName";
            cboCategory.SelectedValuePath = "CategoryId";
        }

        private void dgData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgData.SelectedItem is Product selectedProduct)
            {
                txtProductID.Text = selectedProduct.ProductId.ToString();
                txtProductName.Text = selectedProduct.ProductName;
                txtPrice.Text = selectedProduct.UnitPrice.ToString();
                txtUnitsInStock.Text = selectedProduct.UnitsInStock.ToString();
                cboCategory.SelectedValue = selectedProduct.CategoryId;
            }
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtProductName.Text))
                {
                    MessageBox.Show("Please enter Product Name!", "Warning",
                        MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                Product newProduct = new Product(
                    int.Parse(txtProductID.Text == "" ? "0" : txtProductID.Text),
                    txtProductName.Text,
                    cboCategory.SelectedValue != null ? (int)cboCategory.SelectedValue : 1,
                    (short)int.Parse(txtUnitsInStock.Text == "" ? "0" : txtUnitsInStock.Text),
                    decimal.Parse(txtPrice.Text == "" ? "0" : txtPrice.Text)
                );

                productService.SaveProduct(newProduct);
                LoadData();
                MessageBox.Show("Product created successfully!", "Success",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dgData.SelectedItem == null)
                {
                    MessageBox.Show("Please select a product to update!", "Warning",
                        MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                Product updatedProduct = new Product(
                    int.Parse(txtProductID.Text),
                    txtProductName.Text,
                    cboCategory.SelectedValue != null ? (int)cboCategory.SelectedValue : 1,
                    (short)int.Parse(txtUnitsInStock.Text == "" ? "0" : txtUnitsInStock.Text),
                    decimal.Parse(txtPrice.Text == "" ? "0" : txtPrice.Text)
                );

                productService.UpdateProduct(updatedProduct);
                LoadData();
                MessageBox.Show("Product updated successfully!", "Success",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dgData.SelectedItem == null)
            {
                MessageBox.Show("Please select a product to delete!", "Warning",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var result = MessageBox.Show("Are you sure you want to delete this product?",
                "Confirm Delete", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                Product selectedProduct = (Product)dgData.SelectedItem;
                productService.DeleteProduct(selectedProduct);
                LoadData();
                MessageBox.Show("Product deleted successfully!", "Success",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                ClearForm();
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ClearForm()
        {
            txtProductID.Text = "";
            txtProductName.Text = "";
            txtPrice.Text = "";
            txtUnitsInStock.Text = "";
            cboCategory.SelectedIndex = -1;
            dgData.SelectedItem = null;
        }
    }
}