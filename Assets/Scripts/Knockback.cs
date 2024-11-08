using System.Collections;
using System.Collections.Generic;
// using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;

public class Knockback : MonoBehaviour
{

    public float thrust;
    public float knockTime;
    public float damage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("breakable") && this.gameObject.CompareTag("Player")){
            Debug.Log("SPONGEBOB");
            other.GetComponent<pot>().Smash();
        }
        if(other.gameObject.CompareTag("enemy") || other.gameObject.CompareTag("Player")){
            Rigidbody2D hit =  other.GetComponent<Rigidbody2D>();
            Vector2 difference = hit.transform.position - transform.position;
                difference = difference.normalized * thrust; 
                hit.AddForce(difference, ForceMode2D.Impulse);
            if(hit != null){
                if(other.gameObject.CompareTag("enemy") && other.isTrigger){
                    hit.GetComponent<Enemy>().currentState = EnemyState.stagger;
                    other.GetComponent<Enemy>().Knock(hit, knockTime, damage);
                }
                if(other.gameObject.CompareTag("Player")){
                    if(other.GetComponent<PlayerMovement>().currentState != PlayerState.stagger){
                        hit.GetComponent<PlayerMovement>().currentState = PlayerState.stagger;
                        other.GetComponent<PlayerMovement>().Knock(knockTime, damage);
                    }
                    
                }
                
                // StartCoroutine(KnockCo(hit));
            }
        }
    }

    // private IEnumerator KnockCo(Rigidbody2D enemy){
    //     if(enemy != null && currentState != EnemyState.stagger){
    //         yield return new WaitForSeconds(knockTime);
    //         enemy.velocity = Vector2.zero;
    //        enemy.GetComponent<Enemy>().currentState = EnemyState.idle;
    //     }
    // }
}
