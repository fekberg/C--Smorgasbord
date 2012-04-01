using System.Windows;
using System.Windows.Controls;
using System.Threading;
using System;
using System.Threading.Tasks;
using System.ComponentModel;

namespace TPLAsyncDemo
{
    public partial class MainWindow : Window
    {
        private TextBox _result = new TextBox();
        public MainWindow()
        {
            InitializeComponent();


            var button = new Button
            {
                Content = @"Process data",
            };

            button.Click += button_Click;

            var panel = new StackPanel();
            panel.Children.Add(button);
            panel.Children.Add(_result);

            Content = panel;

        }

        private string ProcessOrder()
        {
            Thread.Sleep(2000);

            return DateTime.Now.ToString();
        }

        private async void ProcessOrderAsync()
        {
            var processOrderResult =
                Task<string>.Factory.StartNew(ProcessOrder);

            _result.Text = await processOrderResult;
        }

        void button_Click(object sender, RoutedEventArgs e)
        {
            ProcessOrderAsync();
        }
    }
}
