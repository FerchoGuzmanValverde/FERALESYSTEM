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
using System.Threading;

namespace Ferale
{
    /// <summary>
    /// Lógica de interacción para SplashScreen.xaml
    /// </summary>
    public partial class SplashScreen : Window
    {
        MainWindow m;
        int con = 0, aux = 0;
        Thread animacion;
        public SplashScreen()
        {
            InitializeComponent();
            m = new MainWindow();
            animacion = new Thread(splash);
            animacion.Start();
        }

        void splash()
        {
            while(aux<2)
            {
                while (con < 10)
                {
                    Thread.Sleep(300);
                    imgsplash.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Render,
                        new Action(delegate ()
                        {
                            imgsplash.Source = new BitmapImage(new Uri(@"/img/" + con + ".jpg", UriKind.Relative));
                        }));
                    con++;
                }
                aux++;
                con = 0;
            }
            m.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Render,
                        new Action(delegate ()
                        {
                            m.Show();
                            this.Close();
                        }));
            animacion.Abort();
        }
    }
}
