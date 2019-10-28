using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BrokenWindow.Events;

public class TestGameEventListener : MonoBehaviour, IEventListener
{
    public GameObject GameObject;
    public GameEvent TestEvent;

    private void Start()
    {
        GameObject.SetActive(false);
    }

    private void OnEnable()
    {
        TestEvent.Listeners.Add(this);
    }

    private void OnDisable()
    {
        TestEvent.Listeners.Remove(this);
    }

    public void OnEventRaised()
    {
        GameObject.SetActive(true);
    }
}
