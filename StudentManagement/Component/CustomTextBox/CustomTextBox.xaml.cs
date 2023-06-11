using CommunityToolkit.Mvvm.ComponentModel;
using StudentManagement.Component.Regulation.ValidationRules;
using StudentManagement.Model;
using StudentManagement.Models;
using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace StudentManagement.Component.CustomTextBox
{
    /// <summary>
    /// Interaction logic for CustomTextBox.xaml
    /// </summary>
    public partial class CustomTextBox : UserControl
    {
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
        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register("CustomTitle", typeof(string), typeof(CustomTextBox), new PropertyMetadata("Title"));


        public string TextInput
        {
            get { return (string)GetValue(TextInputProperty); }
            set {
                MessageBox.Show("t");
                SetValue(TextInputProperty, value); }
        }
        // Using a DependencyProperty as the backing store for TextInput.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextInputProperty =
            DependencyProperty.Register("TextInput", typeof(string), typeof(CustomTextBox), new PropertyMetadata("TextInput"));


        public ValidationRule ValidRule
        {
            get { return (ValidationRule)GetValue(ValidRuleProperty); }
            set
            {
                SetValue(ValidRuleProperty, value);
                
            }
        }
        // Using a DependencyProperty as the backing store for TextInput.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ValidRuleProperty =
            DependencyProperty.Register("ValidRule", typeof(ValidationRule), typeof(CustomTextBox), new PropertyMetadata(null));

        public CustomTextBox()
        {
            InitializeComponent();
        }
    }
}
