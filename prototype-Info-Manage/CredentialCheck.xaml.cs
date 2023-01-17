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
    /// Interaction logic for CredentialCheck.xaml
    /// </summary>
    public partial class CredentialCheck : Window
    {
        
        public CredentialCheck()
        {
            InitializeComponent();
            FirstRun();

		}

        void FirstRun()
        {
            ID_CredentialCheck.Text = string.Empty;
            ID_CredentialCheck.Focus();
        }
	}
}
