using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;

namespace prototype_Info_Manage
{

	public partial class MainWindow : Window
	{
		private string myConnectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=info_management;";
		
		public MainWindow()
		{
			InitializeComponent();
			Student_bar.Focus();
			Student_bar.Text = string.Empty;
			//keepFocus();
		}

		private void Student_bar_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Return)
			{
				string Student_barcode = Student_bar.Text;
				DBTest dB = new();
				List<string> rowVal = dB.ID_Check(Student_barcode);
				txtB_studentFName.Text = rowVal[0];
				txtB_studentLName.Text = rowVal[1];
				txtB_studentCourse.Text = rowVal[2];

				//Debug.WriteLine(rowVal[0]);
				Student_bar.Text = string.Empty;
			}

		}

		void keepFocus()
		{
			DateTime CurrentTime = DateTime.Now;
			MessageBox.Show($"{CurrentTime}");
		}

		private void OnClick(object sender, MouseButtonEventArgs e)
		{
			MessageBox.Show("Option Has been Clicked");
		}
	}
}
