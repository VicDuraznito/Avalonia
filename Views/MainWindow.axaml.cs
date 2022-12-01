using Avalonia.Controls;

namespace ADSAvaloniaPractice.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        void TreeButton_Clicked(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            Window1 x = new Window1();
            x.Show();
            this.Close();
        }
        void GraphButton_Clicked(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            GraphWindow x = new GraphWindow();
            x.Show();
            this.Close();
        }
    }
}
