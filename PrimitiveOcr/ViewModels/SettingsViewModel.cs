using PrimitiveOcr.Models;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Reactive;
using System.Text;

namespace PrimitiveOcr.ViewModels
{
    public class SettingsViewModel : ViewModelBase
    {
        public ReactiveCommand<Unit, Unit> Cancel { get; }
        public ReactiveCommand<Unit, SettingsItem> Ok { get; }

        private string _tessCustomFilePath;
        public string TessCustomFilePath
        {
            get => _tessCustomFilePath;
            set => this.RaiseAndSetIfChanged(ref _tessCustomFilePath, value);
        }


        public SettingsViewModel(SettingsItem settingsItem)
        {
            BindFields(settingsItem);
            var isOkEnabled = this.WhenAnyValue(x => x.TessCustomFilePath,
                x => !string.IsNullOrWhiteSpace(x));

            Cancel = ReactiveCommand.Create(() => { });
            Ok = ReactiveCommand.Create(() => AssembleModel(), canExecute: isOkEnabled);
        }

        private SettingsItem AssembleModel()
        {
            return new SettingsItem()
            {
                TessDataFolder = _tessCustomFilePath
            };
        }

        private void BindFields(SettingsItem settingsItem)
        {
            _tessCustomFilePath = settingsItem.TessDataFolder;
        }
    }
}
