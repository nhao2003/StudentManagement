using System.Windows;
using System.Windows.Input;

namespace StudentManagement
{
    /// <summary>
    /// Interaction logic for AddNewClass.xaml
    /// </summary>
    public partial class AddNewClass : Window
    {
        public AddNewClass()
        {
            InitializeComponent();
        }
        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            // Get the current window
            Window currentWindow = Window.GetWindow(this);

            // Close the window
            currentWindow?.Close();
        }
    }
}
