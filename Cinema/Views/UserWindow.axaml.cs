using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Cinema.Views
{
    public class UserWindow : Window
    {
        public UserWindow()
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