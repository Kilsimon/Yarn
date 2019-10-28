using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BrokenWindow.Events;
using BrokenWindow.Localization;

public class ChangeLanguage : MonoBehaviour, IEventListener
{
    public GameEvent GameEvent;
    public Localization Language;

    private void OnEnable()
    {
        GameEvent.Listeners.Add(this);
    }

    private void OnDiable()
    {
        GameEvent.Listeners.Remove(this);
    }

    public void OnEventRaised()
    {
        Localization language = Resources.Load<Localization>("Languages");
        if (Language.CurrentLanguage == language.EnglishUS)
        {
            LocalizationManager.Load(language.Danish);
            Language.CurrentLanguage = language.Danish;
        } else if (Language.CurrentLanguage == language.Danish)
        {
            LocalizationManager.Load(language.EnglishUS);
            Language.CurrentLanguage = language.EnglishUS;
        }
    }
}
