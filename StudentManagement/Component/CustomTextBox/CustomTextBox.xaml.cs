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
using System.Windows.Navigation;
using System.Windows.Shapes;

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
        { get
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
