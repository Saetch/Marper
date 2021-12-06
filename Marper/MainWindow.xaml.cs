using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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

namespace Marper
{


    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            if(this.Content is System.Windows.Controls.Grid)
            {
                ConsoleAllocator.ShowConsoleWindow();
                Console.WriteLine("Setting up main Window!");
            }

        }

        override protected void OnContentRendered(EventArgs e)
        {

        }



        private void Loopdiloop()
        {
            Random rnd = new Random();
            String str;
            while (true)
            {
                str = "";
                System.Threading.Thread.Sleep(1000);
                for (int i = 0; i <= rnd.Next() % 12; ++i)
                {
                    str += rnd.Next() % 30 + 67;
                }

               // lstNames.Items.Add(str);
            }
        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void joinGameButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }


}
