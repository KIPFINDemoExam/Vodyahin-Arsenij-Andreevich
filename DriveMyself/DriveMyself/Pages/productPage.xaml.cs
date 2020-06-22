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

namespace DriveMyself.Pages
{
	/// <summary>
	/// Логика взаимодействия для productPage.xaml
	/// </summary>
	public partial class productPage : Page
	{
		Product product { get; set; }
		MainWindow mainWindow { get; set; }
		public productPage(Product _product, MainWindow _mainWindow)
		{
			InitializeComponent();
			product = _product;
			mainWindow = _mainWindow;
			productGrid.DataContext = product;
			mainGrid.DataContext = product;
		}
		public productPage(MainWindow _mainWindow)
		{
			InitializeComponent();
			product = MainWindow.entities.Products.Add(new Product());
			mainWindow = _mainWindow;
			productGrid.DataContext = product;
			mainGrid.DataContext = product;
		}

		private void BtSave_Click(object sender, RoutedEventArgs e)
		{
			MainWindow.entities.SaveChangesAsync();
			mainWindow.mainFrame.GoBack();
		}

		private void BtDelete_Click(object sender, RoutedEventArgs e)
		{
			MainWindow.entities.Products.Remove(product);
			MainWindow.entities.SaveChangesAsync();
			mainWindow.mainFrame.GoBack();
		}

		private void BtImgDelete_Click(object sender, RoutedEventArgs e)
		{

		}

		private void BtImgBrowse_Click(object sender, RoutedEventArgs e)
		{

		}
	}
}
