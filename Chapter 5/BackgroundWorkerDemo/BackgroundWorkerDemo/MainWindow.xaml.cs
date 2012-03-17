using System.Windows;
using System.Windows.Controls;
using System.ComponentModel;
using System.Threading;

namespace BackgroundWorkerDemo
{
    public partial class MainWindow : Window
    {
        private BackgroundWorker _worker = new BackgroundWorker();

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

            Content = panel;

        }

        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            Thread.Sleep(2000);
        }

        void button_Click(object sender, RoutedEventArgs e)
        {
            _worker.RunWorkerAsync();
        }
    }
}
