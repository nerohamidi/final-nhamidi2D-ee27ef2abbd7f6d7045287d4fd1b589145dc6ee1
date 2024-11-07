using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SignalListener : MonoBehaviour
{

    public SignalSender signal;
    public UnityEvent signalEvent;
    public void OnSignalRaised()
    {
        // Debug.Log("A SIGNAL IS BEING ENVOKED");
        signalEvent.Invoke();
    }

    

    private void OnDisable(){
        signal.DeRegisterListener(this);
    }

    private void OnEnable(){
        signal.RegisterListener(this);
    }

   
}
