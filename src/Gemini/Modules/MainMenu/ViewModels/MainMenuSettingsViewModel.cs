using System.Collections.Generic;
using System.ComponentModel.Composition;
using Caliburn.Micro;
using Gemini.Framework.Themes;
using Gemini.Modules.Settings;

namespace Gemini.Modules.MainMenu.ViewModels
{
    [Export(typeof (ISettingsEditor))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class MainMenuSettingsViewModel : PropertyChangedBase, ISettingsEditor
    {
        private readonly IThemeManager _themeManager;

        private readonly static List<string> _availableLanguages = new List<string> {
            string.Empty,
            "en",
            "de",
            "ru",
            "zh-Hans",
            "ko",
        };

        private ITheme _selectedTheme;
        private string _selectedLanguage;
        private bool _autoHideMainMenu;

        [ImportingConstructor]
        public MainMenuSettingsViewModel(IThemeManager themeManager)
        {
            _themeManager = themeManager;
            SelectedTheme = themeManager.CurrentTheme;
            AutoHideMainMenu = Properties.Settings.Default.AutoHideMainMenu;
            SelectedLanguage = Properties.Settings.Default.LanguageCode;
        }

        public IEnumerable<ITheme> Themes => _themeManager.Themes;

        public ITheme SelectedTheme
        {
            get => _selectedTheme;
            set
            {
                if (value.Equals(_selectedTheme))
                    return;
                _selectedTheme = value;
                NotifyOfPropertyChange(() => SelectedTheme);
            }
        }

        public IEnumerable<string> Languages => _availableLanguages;

        public string SelectedLanguage
        {
            get => _selectedLanguage;
            set
            {
                if (value.Equals(_selectedLanguage))
                    return;
                _selectedLanguage = value;
                NotifyOfPropertyChange(() => SelectedLanguage);
            }
        }

        public bool AutoHideMainMenu
        {
            get => _autoHideMainMenu;
            set
            {
                if (value.Equals(_autoHideMainMenu))
                    return;
                _autoHideMainMenu = value;
                NotifyOfPropertyChange(() => AutoHideMainMenu);
            }
        }

        public string SettingsPageName => Properties.Resources.SettingsPageGeneral;

        public string SettingsPagePath => Properties.Resources.SettingsPathEnvironment;

        public void ApplyChanges()
        {
            Properties.Settings.Default.ThemeName = SelectedTheme.GetType().Name;
            Properties.Settings.Default.AutoHideMainMenu = AutoHideMainMenu;
            Properties.Settings.Default.LanguageCode = SelectedLanguage;
            Properties.Settings.Default.Save();
        }
    }
}