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
using Marper.Cntrl;
using System.Threading;
namespace Marper
{

    

    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int State { get; set; } = 0;
        internal Controller Cntrl { get; set; } = null;

        protected Thread updaterThread;
        public MainWindow()
        {
            InitializeComponent();
            if(this.Content is System.Windows.Controls.Grid)
            {
                ConsoleAllocator.ShowConsoleWindow();
                Console.WriteLine("Setting up main Window!");

                Random rnd = new Random();
                Color cl = new Color()
                {
                    A = 0xFF,
                    G = (byte)(rnd.Next() % 256),
                    B = (byte)(rnd.Next() % 256),
                    R = (byte)(rnd.Next() % 256)
                };

                gridColor0.Color = cl;

                cl = new Color()
                {
                    A = 0xFF,
                    G = (byte)(rnd.Next() % 256),
                    B = (byte)(rnd.Next() % 256),
                    R = (byte)(rnd.Next() % 256)
                };
                gridColor1.Color = cl;
            }
            SwitchBackgroundRandomFiveSeconds();


        }

        private void SwitchBackgroundRandomFiveSeconds()
        {
            updaterThread = new Thread(Loopdiloop);
            updaterThread.Start();
        }

        internal void StartGameWithController(Controller c)
        {
            this.Cntrl = c;
            this.State = 1;
        }

        override protected void OnContentRendered(EventArgs e)
        {

        }

        protected override void OnClosed(EventArgs e)
        {
            this.updaterThread.Abort();
            this.updaterThread.Join();
            base.OnClosed(e);
        }

        private void Loopdiloop()
        {
            Random rnd = new Random();
            while (true)
            {
                System.Threading.Thread.Sleep(5000);

                randomColorButton_Click(new Object(), new RoutedEventArgs());


            }
        }



        private void randomColorButton_Click(object sender, RoutedEventArgs e)
        {
            int count = 0;
            this.Dispatcher.Invoke(() => {
               count = backgroundGrid.Children.Count;
            });

            for (int i = 0; i < count; ++i)
            {
                this.Dispatcher.Invoke(() => {
                    Console.WriteLine(backgroundGrid.Children[i]);
                });
                
            }
            Random rnd = new Random();
            Color cl = new Color()
            {
                A = 0xFF,
                G = (byte)(rnd.Next() % 256),
                B = (byte)(rnd.Next() % 256),
                R = (byte)(rnd.Next() % 256)
            };
            if(rnd.Next() % 2 == 0)
            {
                this.Dispatcher.Invoke(() => {
                    gridColor0.Color = cl;
                });
                
            }
            else
            {
                this.Dispatcher.Invoke(() => {
                    gridColor1.Color = cl;
                });

            }
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void JoinGameButton_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void HostButton_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();    
        }

        private void SinglePlayerButton_Click(object sender, RoutedEventArgs e)
        {
            updaterThread.Abort();

            Game.Singleplayer(this);
        }

    }


}
