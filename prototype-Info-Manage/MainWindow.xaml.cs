using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;

namespace prototype_Info_Manage
{

	public partial class MainWindow : Window
	{
		
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
				DBTest db2= new DBTest();
				DBTest db3= new DBTest();
				if (dB.NumOnly(Student_barcode))
				{
					List<string> GateBool = dB.GatePassage(Student_barcode);
					Debug.WriteLine($"GATELIST VAL {GateBool[0]} , {GateBool[1]}");
					List<string> rowVal = db2.ID_Check(Student_barcode);
					if (rowVal.Count > 0)
					{
						txtB_studentFName.Text = rowVal[0];
						txtB_studentLName.Text = rowVal[1];
						txtB_studentCourse.Text = rowVal[2];
						dB.GateUpdate(GateBool, Student_barcode);
						//else dB.GateUpdate(GateBool[0], Student_barcode);
					}
				}
				else
				{
					MessageBox.Show("Only Numbers are allowed.");
				}
				//Debug.WriteLine(rowVal[0]);
				Student_bar.Text = string.Empty;
			}

		}

		private void OnClick(object sender, MouseButtonEventArgs e)
		{
			CredentialCheck credentialCheck = new CredentialCheck();
			credentialCheck.Owner = this;
			credentialCheck.ShowDialog();
			//credentialCheck.Show();
		}
	}
}
