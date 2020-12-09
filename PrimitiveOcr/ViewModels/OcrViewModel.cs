using Avalonia.Controls;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Reactive;
using System.Text;
using Avalonia.Controls;
using Avalonia.Dialogs;
using Avalonia.Layout;
using Avalonia.Markup.Xaml;
using System.Diagnostics;

namespace PrimitiveOcr.ViewModels
{
    public class OcrViewModel : ViewModelBase
    {
        private readonly OcrProvider _ocrProvider;
        public ReactiveCommand<Unit, Unit> OpenImage { get; }

        private string _imageText;
        public string ImageText
        {
            get => _imageText;
            set => this.RaiseAndSetIfChanged(ref _imageText, value);
        }

        public OcrViewModel(OcrProvider provider = null)
        {
            _ocrProvider = provider ?? new OcrProvider(@"./Tessdata");
        }

        public void LoadAndSetText(string imagePath)
        {
            var text = _ocrProvider.GetText(imagePath);
            ImageText = text;
        }
    }
}
