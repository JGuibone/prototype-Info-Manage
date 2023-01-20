using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Interaction logic for CredentialCheck.xaml
    /// </summary>
    public partial class CredentialCheck : Window
    {
		public CredentialCheck()
        {
            InitializeComponent();
			inpb_Bar.Focus();
			inpb_Bar.Text = string.Empty;
		}

		private void inpb_Bar_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Return)
			{
				//MessageBox.Show($"{sender.ToString}");
				//if(sender.ToString)
				string ID_Check = inpb_Bar.Text;
				DBTest dB = new();
				if (dB.NumOnly(ID_Check) && dB.Previlages(ID_Check)[1] != null)
				{
					string[] previlage = dB.Previlages(ID_Check);
					if (Int32.Parse(previlage[1]) >= 10) Show_Dash(previlage);
					else MessageBox.Show("Limitted Previlage.");
				}
				else MessageBox.Show("Please have a valid ID with sufficient access right.");
				inpb_Bar.Text = string.Empty;
			}
		}

		private void Show_Dash(string[] Value)
		{
			Dashboard dashboard = new Dashboard(Value);
			this.Close();
			dashboard.ShowDialog();
		}
	}
}
