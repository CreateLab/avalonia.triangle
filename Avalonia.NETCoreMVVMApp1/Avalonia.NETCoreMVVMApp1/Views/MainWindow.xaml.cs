using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Avalonia.NETCoreMVVMApp1.Views
{
    public class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var btn = this.FindControl<Button>("Start");
            btn.Click += (sender, args) =>
            {
                var cntrl = this.FindControl<ItemsControl>("Control");
             
            };
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
        
        
    }
}