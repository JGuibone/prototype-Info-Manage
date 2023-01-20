using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace prototype_Info_Manage
{
	/// <summary>
	/// Interaction logic for Dashboard.xaml
	/// </summary>
	public partial class Dashboard : Window
	{
		private static readonly Regex _regex = new Regex("[^0-9]+");
		public Dashboard(string[] value)	
		{
			InitializeComponent();
			Dash_CurrentUser.Text = value[0];
			Dash_Current_Rank.Text = value[1];
			Dash_IDbar.Focus();
		}

		private void INIT_Upload(object sender, MouseButtonEventArgs e)
		{
			var dialog = new Microsoft.Win32.OpenFileDialog();
			bool? result = dialog.ShowDialog();
			if (result == true)
			{
				// Open document
				string FilaPath = dialog.FileName;
			}
		}

		private void Dash_Insert(object sender, RoutedEventArgs e)
		{
			Dashboard_data DD = new Dashboard_data();
			DBTest dB= new DBTest();

			DD.ID_barcode = Dash_IDbar.Text;
			DD.ID_course = Dash_Course.Text;
			DD.FirstName = Dash_Fname.Text;
			DD.MiddleName = Dash_Mname.Text;
			DD.LastName = Dash_Lname.Text;
			DD.Age = Dash_Age.Text;
			DD.StudentCell = Dash_StuCelNum.Text;
			DD.StuPGname = Dash_StuPGName.Text;
			DD.StuPGCell = Dash_StuPGNum.Text;

			if (DD.CheckValue())
			{
				dB.MySQLinsert(DD);
			}
			else MessageBox.Show("Please Double check your entry. (ID Barcode, Age and cellphone numbers MUST be numbers.");
		}

		private void Dash_Edit(object sender, RoutedEventArgs e)
		{
			string ID_BarCode = Dash_IDbar.Text;
			DBTest dB = new DBTest();
			//dB.MySQLedit(ID_BarCode);


		}

		private void Dash_Delete(object sender, RoutedEventArgs e)
		{

		}
	}
}