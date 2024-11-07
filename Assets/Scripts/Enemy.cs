using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState{
    idle,
    walk,
    attack,
    stagger
}
public class Enemy : MonoBehaviour
{

    public EnemyState currentState;
    public FloatValue maxHealth;
    public float health;
    public string enemyName;
    public int baseAttack;
    public float moveSpeed;
    // Start is called before the first frame update

    public GameObject grunt;

    private void Awake(){
        grunt.SetActive(false);
        Debug.Log("(in awake function) current health " + health);
        health = maxHealth.initialValue;
    }
    // private void Start(){
    //     health = maxHealth.initialValue;
    // }

    // enemy takes damage and disappears when dead
    private void TakeDamage(float damage){
        Debug.Log("health before damage: " + health);
        health -= damage;
        Debug.Log("health after damage: " + health);
        if(health <= 0){
            this.gameObject.SetActive(false);
        }
            
        
    }
    public void Knock(Rigidbody2D myRigidbody, float knockTime, float damage){
        StartCoroutine(KnockCo(myRigidbody, knockTime));
        TakeDamage(damage);
    }
   private IEnumerator KnockCo(Rigidbody2D myRigidbody, float knockTime){
        if(myRigidbody != null){
            grunt.SetActive(true);
            yield return new WaitForSeconds(knockTime);
            grunt.SetActive(false);
            myRigidbody.velocity = Vector2.zero;
           currentState = EnemyState.idle;
           myRigidbody.velocity = Vector2.zero;
        }
    }

     
}
