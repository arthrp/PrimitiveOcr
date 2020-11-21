using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrimitiveOcr.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private ViewModelBase _content;
        public ViewModelBase Content
        {
            get => _content;
            private set => this.RaiseAndSetIfChanged(ref _content, value);
        }

        public MainWindowViewModel()
        {
            Content = new OcrViewModel();
        }
    }
}
