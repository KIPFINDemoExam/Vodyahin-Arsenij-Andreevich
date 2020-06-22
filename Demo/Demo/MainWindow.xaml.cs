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

namespace Demo
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		static public DemoEntities entities = new DemoEntities();

		static public RoutedCommand enter { get; set; }

		public MainWindow()
		{
			enter = new RoutedCommand("enter", typeof(MainWindow));
			InitializeComponent();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			ObservableCollection<User> userList = new ObservableCollection<User>();
			userList = entities.Users.Local;
		}

		private void enter_Executed(object sender, ExecutedRoutedEventArgs e)
		{
			MessageBox.Show("Команда");
		}

		private void enter_CanExecute(object sender, CanExecuteRoutedEventArgs e)
		{
			e.CanExecute = true;
		}
	}
}
