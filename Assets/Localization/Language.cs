using UnityEngine;

namespace BrokenWindow.Localization
{
    //[CreateAssetMenu(menuName = "USE CreateLocalizationAssets INSTEAD")] 
    public class Language : ScriptableObject
    {
        public Translation[] Translations;
    }
}