using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepScript : MonoBehaviour
{

    public GameObject footstep;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("in start");
        footstep.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("in update");
        if(Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d") ){
            footsteps();
        
          
        }else{
            stopFootsteps();
        }
    }

    void footsteps(){
        footstep.SetActive(true);

    }

    void stopFootsteps(){
        footstep.SetActive(false);
    }
}
