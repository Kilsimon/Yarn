using System.Collections.Generic;
using UnityEngine;

namespace BrokenWindow.Localization
{
    public static class LocalizationManager
    {
        private static Dictionary<string, string> translations;

        static LocalizationManager()
        {
            Localization language = Resources.Load<Localization>("Languages");
#if UNITY_EDITOR
            Load(language.EnglishUS);
#else
            Load(language.CurrentLanguage);
#endif
        }

        public static void Load(Language loc)
        {
            translations = new Dictionary<string, string>(loc.Translations.Length);

            // Setup Translations
            for (int i = 0; i < loc.Translations.Length; i++)
            {
                var translation = loc.Translations[i];
                if (translations.ContainsKey(translation.Id))
                {
                    Debug.LogError($"Multiple values for localization: {translation.Id}.\n" +
                        $"A: {translations[translation.Id]}\n" +
                        $"B: {translation.Value}");
                    continue;
                }

                translations.Add(translation.Id, translation.Value);
            }
        }

        public static string GetTranslation(string id)
        {
            if (translations.TryGetValue(id, out string value))
            {
                return value;
            }
            else
            {
                return "<<ERROR: The ID does not exist or is empty>>";
            }
        }
    }
}