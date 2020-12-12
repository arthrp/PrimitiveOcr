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
        private SettingsItem _settings;
        public ViewModelBase Content
        {
            get => _content;
            private set => this.RaiseAndSetIfChanged(ref _content, value);
        }
        public OcrViewModel OcrVm { get; set; }

        public MainWindowViewModel()
        {
            _settings = new SettingsItem() { TessDataFolder = @"./Tessdata" };
            Content = new OcrViewModel(_settings);
        }

        public void OpenSettingsPage()
        {
            var vm = new SettingsViewModel(_settings);
            Content = vm;

            Observable.Merge<SettingsItem>(vm.Ok, vm.Cancel.Select(_ => (SettingsItem)null))
                .Take(1)
                .Subscribe(model =>
                {
                    _settings = (model != null) ? model : _settings;
                    Content = new OcrViewModel(_settings);
                });
        }
    }
}
