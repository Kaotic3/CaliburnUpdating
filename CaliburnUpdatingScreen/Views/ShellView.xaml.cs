using CaliburnUpdatingScreen.ViewModels;
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

namespace CaliburnUpdatingScreen.Views
{
    /// <summary>
    /// Interaction logic for ShellView.xaml
    /// </summary>
    public partial class ShellView : Window
    {
        public ShellView()
        {
            InitializeComponent();

            this.MouseLeftButtonDown += delegate { this.DragMove(); };

            ShellViewModel vm = new ShellViewModel();
            this.DataContext = vm;
            if (ShellViewModel.CloseAction == null)
                ShellViewModel.CloseAction = new Action(this.Close);
        }
    }
}
