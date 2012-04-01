using System.Windows;
using System.Windows.Controls;
using System.Threading;
using System;
using System.Threading.Tasks;

namespace TPLDemo
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

        void button_Click(object sender, RoutedEventArgs e)
        {
            var task = new Task<string>(ProcessOrder);

            task.Start();

            task.ContinueWith((parentTask) =>
            {
                Application.Current.Dispatcher.Invoke(
                    new Action(() =>
                    {
                        _result.Text = parentTask.Result;
                    }));
            });
        }
    }
}
