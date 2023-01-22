using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
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
				if (dB.ID_CheckV2(Student_barcode))
				{
					List<string> rowVal = dB.Gate_Display(Student_barcode);
					List<string> GateBool = dB.GatePassage(Student_barcode);
					Debug.WriteLine($"GATELIST VAL {GateBool[0]} , {GateBool[1]}");

					if (rowVal.Count > 0)
					{
						txtB_studentFName.Text = rowVal[0];
						txtB_studentLName.Text = rowVal[1];
						txtB_studentCourse.Text = rowVal[2];
						dB.GateUpdate(GateBool, Student_barcode);
					}
				}
				else MessageBox.Show("Please Check and Scan Again.");
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
