using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

[CreateAssetMenu]
public class FloatValue : ScriptableObject, ISerializationCallbackReceiver
{
    // Start is called before the first frame update
    public float initialValue;

    [HideInInspector]
    public float RuntimeValue;
    public void OnAfterDeserialize(){
    
        RuntimeValue = initialValue;
    }

    public void OnBeforeSerialize(){

    }
}
