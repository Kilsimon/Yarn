using UnityEngine;
using UnityEngine.Events;

namespace BrokenWindow.Events
{
    public class GameEventListener : MonoBehaviour, IEventListener
    {
        public GameEvent Event;
        public UnityEvent Response;

        private void OnEnable()
        {
            Event.Listeners.Add(this);
        }

        private void OnDisable()
        {
            Event.Listeners.Remove(this);
        }

        public void OnEventRaised()
        {
            Response.Invoke();
        }
    }
}
