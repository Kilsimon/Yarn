using System.Collections.Generic;
using UnityEngine;

namespace BrokenWindow.Events
{
    [CreateAssetMenu]
    public class GameEvent : ScriptableObject
    {
        public readonly List<IEventListener> Listeners =
            new List<IEventListener>();

        public void Raise()
        {
            for (int i = Listeners.Count - 1; i >= 0; i--)
            {
                Listeners[i].OnEventRaised();
            }
        }
    }
}
