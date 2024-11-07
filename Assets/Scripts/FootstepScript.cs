using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepScript : MonoBehaviour
{

    public GameObject footstep;
    // Start is called before the first frame update
    void Start()
    {

        footstep.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("w")){
            footsteps();
        }else if(Input.GetKey("a")){
            footsteps();
        }else if(Input.GetKey("s")){
            footsteps();
        }
    }

    void footsteps(){
        footstep.SetActive(true);

    }

    void stopFootsteps(){
        footstep.SetActive(false);
    }
}
