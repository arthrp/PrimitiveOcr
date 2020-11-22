using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using PrimitiveOcr.ViewModels;
using System.Diagnostics;

namespace PrimitiveOcr.Views
{
    public class OcrView : UserControl
    {
        private OcrViewModel SpecificViewModel => DataContext as OcrViewModel;
        public OcrView()
        {
            InitializeComponent();

            var openImageButton = this.Find<Button>("OpenImageBtn");
            openImageButton.Click += OpenImageButton_Click;
        }

        private async void OpenImageButton_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog()
            {
                AllowMultiple = false,
                Title = "Choose image"
            };

            var path = await dialog.ShowAsync((Window)this.VisualRoot);

            if(path.Length < 1)
            {
                Debug.WriteLine("Nothing is chosen");
                return;
            }

            SpecificViewModel.LoadAndSetText(path[0]);
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

    }
}
