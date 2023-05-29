using System.Windows;
using System.Windows.Controls;

namespace StudentManagement.Component.CustomTextBox
{
    /// <summary>
    /// Interaction logic for CustomTextBox.xaml
    /// </summary>
    public partial class CustomTextBox : UserControl
    {
        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register("CustomTitle", typeof(string), typeof(CustomTextBox), new PropertyMetadata("Title"));


        public string TextInput
        {
            get { return (string)GetValue(TextInputProperty); }
            set { SetValue(TextInputProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TextInput.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextInputProperty =
            DependencyProperty.Register("TextInput", typeof(string), typeof(CustomTextBox), new PropertyMetadata("TextInput"));


        public string CustomTitle
        {
            get
            {
                return (string)GetValue(TitleProperty);
            }
            set
            {
                SetValue(TitleProperty, value);
            }
        }
        public CustomTextBox()
        {
            InitializeComponent();
        }
    }
}
