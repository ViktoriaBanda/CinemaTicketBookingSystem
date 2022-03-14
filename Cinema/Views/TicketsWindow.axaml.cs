using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Cinema.Views
{
    public class TicketsWindow : Window
    {
        public TicketsWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}