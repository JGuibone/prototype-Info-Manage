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
using System.Windows.Shapes;

namespace prototype_Info_Manage
{
	/// <summary>
	/// Interaction logic for DB_edit.xaml
	/// </summary>
	public partial class DB_edit : Window
	{
		public DB_edit()
		{
			InitializeComponent();
		}

		private void inpb_Bar_KeyDown(object sender, KeyEventArgs e)
		{
			DBTest dB = new();
			Dashboard_data DD = new Dashboard_data();
			if (e.Key == Key.Return)
			{
				string ID_Check = inpb_Bar.Text;
				
				DD = dB.MySQLedit(ID_Check);
				//return DD;

				//if (dB.NumOnly(ID_Check) && dB.Previlages(ID_Check)[1] != null)
				//{
				//	string[] previlage = dB.Previlages(ID_Check);
				//	if (Int32.Parse(previlage[1]) >= 10) Show_Dash(previlage);
				//	else MessageBox.Show("Limitted Previlage.");
				//}
				//else MessageBox.Show("Please have a valid ID with sufficient access right.");
				//inpb_Bar.Text = string.Empty;
			}
			//return DD;
			
		}
	}
}
