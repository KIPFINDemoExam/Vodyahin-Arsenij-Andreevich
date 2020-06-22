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
using DriveMyself.Pages;

namespace DriveMyself.Pages
{
	/// <summary>
	/// Логика взаимодействия для productListPage.xaml
	/// </summary>
	public partial class productListPage : Page
	{
		ObservableCollection<Product> productCollection { get; set; } = new ObservableCollection<Product>();
		MainWindow mainWindow { get; set; }
		public productListPage(MainWindow _mainWindow)
		{
			InitializeComponent();
			mainWindow = _mainWindow;
		}

		private void LoadProducts()
		{
			productCollection.Clear();
			foreach (Product p in MainWindow.entities.Products)
			{
				bool is_fitered = true;
				if (productFilterManuf.SelectedIndex != -1)
					if (p.Manufacturer != productFilterManuf.SelectedItem)
						is_fitered = false;
				if (productFilterTitle.Text.Length > 0)
					if (!p.Title.Contains(productFilterTitle.Text))
						is_fitered = false;
				if (productFilterDescr.Text.Length > 0)
					if (p.Description != null)
					{
						if (!p.Description.Contains(productFilterDescr.Text))
							is_fitered = false;
					}
					else
						is_fitered = false;
				if (is_fitered)
					productCollection.Add(p);
			}
			productList.ItemsSource = productCollection;
		}

		private void Page_Loaded(object sender, RoutedEventArgs e)
		{
			LoadProducts();
		}

		private void ProductFilterName_TextChanged(object sender, TextChangedEventArgs e)
		{
			LoadProducts();
		}

		private void ProductFilterDescr_TextChanged(object sender, TextChangedEventArgs e)
		{
			LoadProducts();
		}

		private void ProductFilterManuf_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			LoadProducts();
		}

		private void BtCreate_Click(object sender, RoutedEventArgs e)
		{
			productPage productPage = new productPage(mainWindow);
			mainWindow.mainFrame.Navigate(productPage);
		}

		private void BtEdit_Click(object sender, RoutedEventArgs e)
		{
			productPage productPage = new productPage(productList.SelectedItem as Product, mainWindow);
			mainWindow.mainFrame.Navigate(productPage);
		}

		private void BtDelete_Click(object sender, RoutedEventArgs e)
		{
			MainWindow.entities.Products.Remove(productList.SelectedItem as Product);
			MainWindow.entities.SaveChangesAsync();
			LoadProducts();
		}
	}
}
