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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Casa.Unidad_4
{
    /// <summary>
    /// Lógica de interacción para Pelotas.xaml
    /// </summary>
    public partial class Pelotas : Window
    {
        public Pelotas()
        {
            InitializeComponent();
        }
        Ellipse elipse;
        private void cnvelipses_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Point posicion = e.GetPosition(cnvelipses);
            Random r = new Random();
           elipse = new Ellipse()
            {
                Width = 30,
                Height = 30,
                Fill = new SolidColorBrush(Color.FromRgb((byte)r.Next(0, 256), (byte)r.Next(0, 256), (byte)r.Next(256)))
            };
            cnvelipses.Children.Add(elipse);
            Canvas.SetLeft(elipse, posicion.X);
            Canvas.SetTop(elipse, posicion.Y);
            DoubleAnimation animacion = new DoubleAnimation()
            {
                To = cnvelipses.ActualHeight - elipse.Height,
                BeginTime = TimeSpan.FromSeconds(0),
                Duration = TimeSpan.FromSeconds(2),
                EasingFunction = new BounceEase
                {
                    Bounces = 5,
                    EasingMode = EasingMode.EaseOut
                }

            };
            elipse.BeginAnimation(Canvas.TopProperty, animacion);
        }

        private void cnvelipses_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (elipse != null)
            {
                if (e.HeightChanged && cnvelipses.ActualHeight > e.PreviousSize.Height)
                {
                    DoubleAnimation animacion = new DoubleAnimation()
                    {
                        To = cnvelipses.ActualHeight - elipse.Height,
                        BeginTime = TimeSpan.FromSeconds(0),
                        Duration = TimeSpan.FromSeconds(2),
                        EasingFunction = new BounceEase
                        {
                            Bounces = 5,
                            EasingMode = EasingMode.EaseOut
                        }

                    };
                    foreach (var el in cnvelipses.Children)
                    {
                        if (el is Ellipse)
                        {
                            ((Ellipse)el).BeginAnimation(Canvas.TopProperty, animacion);
                        }
                    }
                }
                if (e.HeightChanged && cnvelipses.ActualHeight < e.PreviousSize.Height)
                {
                    DoubleAnimation animacion = new DoubleAnimation()
                    {
                        To = cnvelipses.ActualHeight - elipse.Height,
                        BeginTime = TimeSpan.FromSeconds(0),
                        Duration = TimeSpan.FromSeconds(0.01),
                        EasingFunction = new BounceEase
                        {
                            Bounces = 5,
                            EasingMode = EasingMode.EaseOut
                        }

                    };
                    foreach (var el in cnvelipses.Children)
                    {
                        if (el is Ellipse)
                        {
                            ((Ellipse)el).BeginAnimation(Canvas.TopProperty, animacion);
                        }
                    }
                }
                
            }
        }
    }
}
