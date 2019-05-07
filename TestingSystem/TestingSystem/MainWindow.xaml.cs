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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TestingSystem.Views;

namespace TestingSystem
{
    public partial class MainWindow : Window
    {
        string mainTitle = "Testing System";
        SystemContext context;

        StartView startView;

        public MainWindow()
        {
            InitializeComponent();

            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            context = new SystemContext();
            InitStyle();
            InitViews();
            GoToStartView();
        }

        private void InitStyle()
        {
            var style = new ResourceDictionary();
            style.Source = new Uri(@"StyleResources.xaml", UriKind.Relative);
            Application.Current.Resources = style;
        }

        private void InitViews()
        {
            startView = new StartView(context);

            startView.DataContext = this;
        }

        private void GoToStartView()
        {
            Title = mainTitle;
           // startView.userNameTextBox.Focus();
            //startView.userNameTextBox.Text = "";
            this.DataContext = startView;
        }
    }
}
