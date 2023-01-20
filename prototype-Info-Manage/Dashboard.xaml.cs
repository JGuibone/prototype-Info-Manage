using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
				dB.MySQLInsert(DD);
			}
			else MessageBox.Show("Please Double check your entry. (ID Barcode, Age and cellphone numbers MUST be numbers.");
		}

		private void Dash_Edit(object sender, RoutedEventArgs e)
		{
			DBTest dB= new DBTest();
			Dashboard_data DD = new Dashboard_data();
			if (Dash_IDbar.Text == null || Dash_Course.Text == null || Dash_Fname.Text == null || Dash_Mname.Text == null || Dash_Lname.Text == null || Dash_Age.Text == null || Dash_StuCelNum.Text == null || Dash_StuPGName.Text == null || Dash_StuPGNum.Text == null)
			{
				MessageBox.Show("Please Double check your inputs.");
			}
			else
			{
				DD.ID_barcode = Dash_IDbar.Text;
				DD.ID_course = Dash_Course.Text;
				DD.FirstName = Dash_Fname.Text;
				DD.MiddleName = Dash_Mname.Text;
				DD.LastName = Dash_Lname.Text;
				DD.Age = Dash_Age.Text;
				DD.StudentCell = Dash_StuCelNum.Text;
				DD.StuPGname = Dash_StuPGName.Text;
				DD.StuPGCell = Dash_StuPGNum.Text;
				dB.MySQLEdit(DD);
			}
		}

		private void Dash_Delete(object sender, RoutedEventArgs e)
		{
			DBTest dB = new DBTest();
			string saveIDBAR = Dash_IDbar.Text;
			if (Dash_IDbar.Text == null || Dash_Course.Text == null || Dash_Fname.Text == null || Dash_Mname.Text == null || Dash_Lname.Text == null || Dash_Age.Text == null || Dash_StuCelNum.Text == null || Dash_StuPGName.Text == null || Dash_StuPGNum.Text == null)
			{
				MessageBox.Show("Please Double check your inputs.");
			}
			else
			{
				if (MessageBox.Show("Are you sure you want to delete this students information?", "Confirmation!", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
				{
					dB.MySQLDelete(saveIDBAR);
					//Dash_IDbar.Text = string.Empty;
					//Dash_Course.Text = string.Empty;
					//Dash_Fname.Text = string.Empty;
					//Dash_Mname.Text = string.Empty;
					//Dash_Lname.Text = string.Empty;
					//Dash_Age.Text = string.Empty;
					//Dash_StuCelNum.Text = string.Empty;
					//Dash_StuPGName.Text = string.Empty;
					//Dash_StuPGNum.Text = string.Empty;
				}
				else
				{
					Dash_IDbar.Text=string.Empty;
					Dash_Course.Text = string.Empty;
					Dash_Fname.Text = string.Empty;
					Dash_Mname.Text = string.Empty;
					Dash_Lname.Text = string.Empty;
					Dash_Age.Text = string.Empty;
					Dash_StuCelNum.Text = string.Empty;
					Dash_StuPGName.Text = string.Empty;
					Dash_StuPGNum.Text = string.Empty;
				}
				
			}
		}

		private void Dash_bar_KeyEnter(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Return)
			{
				string ID_BarCode = Dash_IDbar.Text;
				DBTest dB = new DBTest();
				Dashboard_data DD = new Dashboard_data();

				//Debug.WriteLine(ID_BarCode);
				//Debug.WriteLine(dB.ID_CheckV2(ID_BarCode));
				if (dB.ID_CheckV2(ID_BarCode))
				{
					if (DD.checkClassIfNull())
					{
						DD = dB.MySQLSearch(ID_BarCode);
						Dash_IDbar.Text = DD.ID_barcode;
						Dash_Course.Text = DD.ID_course;
						Dash_Fname.Text = DD.FirstName;
						Dash_Mname.Text = DD.MiddleName;
						Dash_Lname.Text = DD.LastName;
						Dash_Age.Text = DD.Age;
						Dash_StuCelNum.Text = DD.StudentCell;
						Dash_StuPGName.Text = DD.StuPGname;
						Dash_StuPGNum.Text = DD.StuPGCell;
					}
				}
				else
				{
					MessageBox.Show("Only Valid ID NUMBER is allowed.");
				}
			}
		}
	}
}