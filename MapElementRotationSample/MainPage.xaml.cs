using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Maps;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace MapElementRotationSample
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private List<InterestPoint> InitInterestPoints(BasicGeoposition location)
        {
            List<InterestPoint> points = new List<InterestPoint>();
            points.Add(new InterestPoint {
                ImageSourceUri = new Uri("ms-appx:///Assets/mappin.png"),
                Location = new Geopoint(location),
                Rotate=new RotateTransform
                {
                    Angle=15,
                    CenterX=28.5,
                    CenterY=88
                },
                Translate=new TranslateTransform
                {
                    X=-28.5,
                    Y=-90
                }
            });

            return points;
        }

        private void myAdd_Click(object sender, RoutedEventArgs e)
        {
            mapItems.ItemsSource = InitInterestPoints(myMap.Center.Position);
        }

        private void btnRotate_Click(object sender, RoutedEventArgs e)
        {
            var points = mapItems.ItemsSource as List<InterestPoint>;
            points[0].Rotate.Angle += 10;
        }
    }

    public class InterestPoint
    {
        public Uri ImageSourceUri { get; set; }
        public Geopoint Location { get; set; }
        public RotateTransform Rotate{ get; set; }
        public TranslateTransform Translate { get; set; }
        public Point CenterPoint { get; set; }
    }
}
