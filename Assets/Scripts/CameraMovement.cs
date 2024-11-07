using System.Collections;
using System.Collections.Generic;
// using System.Numerics;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform target;
    public float smoothing;
    public Vector2 maxPosition;
    public Vector2 minPosition;
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(transform.position != target.position){
            Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);
            
            targetPosition.x = Mathf.Clamp(targetPosition.x,
                                        minPosition.x,
                                        maxPosition.x);

            //the clamp function locks the position to the set max and min values 
            targetPosition.y = Mathf.Clamp(targetPosition.y, minPosition.y, maxPosition.y);

            // moves position of first parameter to second parameter 
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing);
        }
    }
}
