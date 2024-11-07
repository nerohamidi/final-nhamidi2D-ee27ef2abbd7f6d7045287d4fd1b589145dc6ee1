using System;
using System.Collections;
using System.Collections.Generic;
// using System.Numerics;

// using System.Numerics;

// using System.Numerics;
using UnityEngine;

public class log : Enemy
{
    public Rigidbody2D myRigidbody;
    public Transform target;
    public float chaseRadius;
    public float attackRadius;
    public Transform homePosition;
    public Animator anim;
    
    // Start is called before the first frame update
    private void Start()
    {
        currentState = EnemyState.idle;
        myRigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
       target = GameObject.FindWithTag("Player").transform; // transfer holds the location information (scale, rotation, position) 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CheckDistance();    
    }

    void CheckDistance(){
        if(Vector3.Distance(target.position, transform.position) <= chaseRadius && Vector3.Distance(target.position, transform.position) > attackRadius){
           if(currentState == EnemyState.idle || currentState == EnemyState.walk && currentState != EnemyState.stagger){
                Vector3 temp = Vector3.MoveTowards(transform.position, target.position, moveSpeed*Time.deltaTime);
                changeAnim(temp - transform.position);
                myRigidbody.MovePosition(temp);
                
                ChangeState(EnemyState.walk);
                anim.SetBool("wakeUp", true);
                // Debug.Log("Distance " + Vector3.Distance(target.position, transform.position));
                
                // Debug.Log("chaseRadius " + (chaseRadius-1));
                

           }
        }
           else if (Vector3.Distance(target.position, transform.position) > (chaseRadius-1)){
                // Debug.Log("TESTING WORDS " + (chaseRadius-1));
                anim.SetBool("wakeUp",false);
           }
            
        }
    

    private void SetAnimFloat(Vector2 setVector){
        anim.SetFloat("moveX", setVector.x);
        anim.SetFloat("moveY", setVector.y);
    }
    private void changeAnim(Vector2 direction){
        if(Mathf.Abs(direction.x) > Mathf.Abs(direction.y)){
            if(direction.x > 0){
                SetAnimFloat(Vector2.right);
            }else if(direction.x < 0){
                SetAnimFloat(Vector2.left);
            }
        }else if(Mathf.Abs(direction.x) < Mathf.Abs(direction.y)){
            if(direction.y > 0){
                SetAnimFloat(Vector2.up);
            }else if(direction.y < 0){
                SetAnimFloat(Vector2.down);
            }
        }
    }

    private void ChangeState(EnemyState newState){
        if(currentState != newState){
            currentState = newState;
        }
    }

    

    
}
