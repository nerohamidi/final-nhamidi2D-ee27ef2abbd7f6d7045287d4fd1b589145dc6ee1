using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SignalSender : ScriptableObject
{
    // Start is called before the first frame update
    public List<SignalListener> listeners = new List<SignalListener>();

    private void Start(){
        Debug.Log("WRONG CLASS");
    }
    public void Raise()
    {
        for(int i = listeners.Count - 1; i >= 0; i--){
            listeners[i].OnSignalRaised();
        }
    }

     public void RegisterListener(SignalListener listener){
        listeners.Add(listener);
    }

    public void DeRegisterListener(SignalListener listener){
        listeners.Remove(listener);
    }

    
}
