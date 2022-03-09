using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
     
    public int maxHealth=100;
   [SerializeField] int currentHealth;
    public Animator animator;


   private void Start() {
       currentHealth=maxHealth;
   }

   public void enemyDamage(int damage)
    {
     currentHealth-=damage;   
     Debug.Log(currentHealth);
     //Hit animation
     animator.SetTrigger("IsHit");
     if(currentHealth<=0){
         Die();
     }
    }
   void Die(){
        Debug.Log("Enemy dead");
         animator.SetBool("IsDead", true);
         GetComponent<Collider2D>().enabled=false;
         //this.enabled=false;
         
    }
}
