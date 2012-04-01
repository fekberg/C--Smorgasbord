using System.Windows;
using System.Windows.Controls;
using System.ComponentModel;
using System.Threading;
using System;

namespace BackgroundWorkerDemo
{
    public partial class MainWindow : Window
    {
        private BackgroundWorker _worker = new BackgroundWorker();
        private TextBox _result = new TextBox();
        public MainWindow()
        {
            InitializeComponent();

            _worker.DoWork += worker_DoWork;

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

        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            var orderProcessResult = ProcessOrder();

            Application.Current.Dispatcher.Invoke(
                new Action(() => { _result.Text = orderProcessResult; })
            );
        }

        void button_Click(object sender, RoutedEventArgs e)
        {
            _worker.RunWorkerAsync();
        }
    }
}
