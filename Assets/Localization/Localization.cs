using BrokenWindow.Events;
using UnityEngine;

namespace BrokenWindow.Localization
{
    //[CreateAssetMenu(menuName = "USE CreateLocalizationAssets INSTEAD")]
    public class Localization : ScriptableObject
    {
        public Language CurrentLanguage;

        public Language EnglishUS;
        public Language Danish;

        public GameEvent LanguageChangedEvent;

        public void SetCurrentLanguage(Language language)
        {
            CurrentLanguage = language;
            LocalizationManager.Load(language);
            LanguageChangedEvent.Raise();
        }
    }
}