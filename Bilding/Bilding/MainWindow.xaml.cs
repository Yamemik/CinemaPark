using System.Windows;
namespace Bilding
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            new MainLogic(spAlp, spAnswer, picture);
        }
        private void miClose_Click(object sender, RoutedEventArgs e)
        {
            var a = MessageBox.Show("Вы точно хотите выйти?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (a == MessageBoxResult.Yes) Application.Current.Shutdown();
        }
        private void miRules_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Написать название конструкции или предмета на картинке\n" +
                "Чтобы удалить букву нажмите на нее в поле ввода.");
        }
        private void miAbout_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Название: Информационно-аналитическая\n система по проектированию зданий\n" +
                            "Производитель: Yamemik\n" +
                            "ver. 1.0.0\n" +
                            "Разработал: Лонгортов Р.Ю.\n" +
                            "Проверил: Каримова Э.С.");
        }
        private void miToMenu_Click(object sender, RoutedEventArgs e)
        {
            StartWindow startWindow = new StartWindow();
            startWindow.Show();
            this.Close();
        }
        private void miHelp_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"{MainLogic.currentAnswer}");
        }
    }
}
