using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Cinema.ViewModels;

namespace Cinema.Views
{
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
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