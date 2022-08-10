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

namespace UserDatabaseGUIApp
{
    public partial class MainWindow : Window
    {
        

        public MainWindow()
        {
            InitializeComponent();
            GiveDataToGrid();

        }

        public void GiveDataToGrid()
        {
            using(var context = new UserDB())
            {
                var query = from user in context.Users select user;
                UserDataGrid.ItemsSource = query.ToList() ;
            }
        }
    }
}
