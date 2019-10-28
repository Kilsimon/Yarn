using BrokenWindow.Events;
using BrokenWindow.Localization;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;


[RequireComponent(typeof(DialogueRunner))]
public class OvergrownDialogeRunner : MonoBehaviour
{
    public DialogueRunner DialogueRunner;
    private Dictionary<string, GameEvent> eventDict;

    private void Awake()
    {
        GameEvent[] gameEvents = Resources.FindObjectsOfTypeAll<GameEvent>();
        eventDict = new Dictionary<string, GameEvent>(gameEvents.Length);

        foreach (GameEvent ge in gameEvents)
        {
            Debug.Assert(!eventDict.ContainsKey(ge.name));
            eventDict.Add(ge.name, ge);
            Debug.Log(ge.name);
        }

        DialogueRunner.dialogue.library.RegisterFunction("event", 1, ps =>
        {
            string requestedEvent = ps[0].AsString;
            if (eventDict.TryGetValue(requestedEvent, out GameEvent ge))
            {
                ge.Raise();
            }
            else
            {
                Debug.LogError("Dialog is requesting unknown event: " + requestedEvent, this);
            }
        });
        
        DialogueRunner.dialogue.library.RegisterFunction("loc", 1, ps =>
        {
            LocalizationManager.GetTranslation(ps[0].AsString);
            Debug.Log("Node Called:" + LocalizationManager.GetTranslation(ps[0].AsString));
        });


    }
}
