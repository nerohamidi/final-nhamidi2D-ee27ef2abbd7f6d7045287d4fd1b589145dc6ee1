using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("patrick");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("breakable")){
            Debug.Log("SPONGEBOB");
            other.GetComponent<pot>().Smash();
        }
    }
}
