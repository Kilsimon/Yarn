using System;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace BrokenWindow.Editors
{
    public class CreateLocalizationAssets : EditorWindow
    {
        private string data;
        private Vector2 scrollPoint;

        [MenuItem("2nd Floor/Create Localization Assets")]
        public static void OpenWindow()
        {
            var window = GetWindow<CreateLocalizationAssets>();
            window.titleContent = new GUIContent("Create Localization Asset");
            window.Show();
        }

#pragma warning disable 0649

        [Serializable]
        internal partial class SheetsLocalization
        {
            public SheetLocalization[] Localizations;
        }

        [Serializable]
        internal class SheetLocalization
        {
            public string Language;
            public Localization.Translation[] Translations;
        }

#pragma warning restore 0649

        private void OnGUI()
        {
            using (var scroll = new EditorGUILayout.ScrollViewScope(scrollPoint))
            {
                data = EditorGUILayout.TextArea(data, GUILayout.ExpandHeight(true));
                scrollPoint = scroll.scrollPosition;
            }

            try
            {
                if (!string.IsNullOrWhiteSpace(data))
                {
                    var localizations = JsonUtility.FromJson<SheetsLocalization>(data);

                    if (GUILayout.Button("Save"))
                    {
                        string localizationPath = Path.Combine(Application.dataPath, "Data", "Localization");
                        string resourcePath = Path.Combine(Application.dataPath, "Resources", "Languages.asset");

                        Directory.Delete(localizationPath, true);

                        var resources = (Localization.Localization)Resources.Load("Localizations.asset");
                        if (resources == null)
                        {
                            resources = CreateInstance<Localization.Localization>();
                            AssetDatabase.CreateAsset(resources, "Assets/Resources/Localizations.asset");
                            resources.LanguageChangedEvent = AssetDatabase.LoadAssetAtPath<Events.GameEvent>("Assets/Data/UI/Language Changed Event.asset");

                            if (resources.LanguageChangedEvent == null)
                            {
                                Debug.LogError("Unable to find Language Changed Event, please set this up manually");
                            }
                        }

                        Directory.CreateDirectory(localizationPath);

                        foreach (var localization in localizations.Localizations)
                        {
                            var language = CreateInstance<Localization.Language>();
                            language.Translations = localization.Translations;

                            AssetDatabase.CreateAsset(language, string.Concat("Assets/Data/Localization/", localization.Language, ".asset"));

                            switch (localization.Language)
                            {
                                case "English":
                                    resources.CurrentLanguage = language;
                                    resources.EnglishUS = language;
                                    break;

                                case "Dansk":
                                    resources.Danish = language;
                                    break;

                                default:
                                    Debug.LogError("Unknown Language " + localization.Language);
                                    break;
                            }
                        }

                        AssetDatabase.Refresh();
                    }
                }

                return;
            }
            catch (Exception)
            {
                //Debug.LogError(ex);
            }

            EditorGUILayout.LabelField("Unable to save, inivalid json");
        }
    }
}