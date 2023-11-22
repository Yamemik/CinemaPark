using System;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Bilding
{
    /// <summary>
    /// Логика взаимодействия для StartWindow.xaml
    /// </summary>
    public partial class StartWindow : Window
    {
        public StartWindow()
        {
            InitializeComponent();
            IB.ImageSource = new BitmapImage(new Uri("background.png", UriKind.Relative));
        }
        private void btnTestGo_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
        private void btnInfoGo_Click(object sender, RoutedEventArgs e)
        {
            InfoWindow infoWindow = new InfoWindow();
            infoWindow.Show();
            this.Close();
        }
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            var a = MessageBox.Show("Выйти из приложения?", "", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            if (a == MessageBoxResult.OK) Application.Current.Shutdown();
        }
    }
}
