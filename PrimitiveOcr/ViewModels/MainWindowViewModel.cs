using PrimitiveOcr.Models;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Reactive.Linq;
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
        public OcrViewModel OcrVm { get; set; }

        public MainWindowViewModel()
        {
            Content = new OcrViewModel();
        }

        public void OpenSettingsPage()
        {
            var vm = new SettingsViewModel();
            Content = vm;

            Observable.Merge<SettingsItem>(vm.Ok, vm.Cancel.Select(_ => (SettingsItem)null))
                .Take(1)
                .Subscribe(model =>
                {
                    Content = new OcrViewModel();
                });
        }
    }
}
