using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public int attackDamage = 20;
    public int PlayermaxHealth = 100;

    public LayerMask enemyLayers;
    // [SerializeField] bool isShielded = false;




    void Update()
    {
if(PlayermaxHealth>0){
        if (Input.GetButtonDown("Attack"))//left ctrl
        {
            Attack();
        }
        if (Input.GetButtonDown("Shield"))//left alt
        {
            // isShielded = true;
            Shield();
        }
}else{
    Debug.Log("layer dead");
}
      
    }
    private void Attack()
    {

        animator.SetTrigger("IsAttack");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            // Debug.Log("We hit "+enemy.name);
            enemy.GetComponent<EnemyScript>().enemyDamage(attackDamage);

        }
    }
    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
    private void Shield()
    {
        Debug.Log("Shield mode");
        animator.SetTrigger("IsShield");

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        
       string colliderTag= other.gameObject.tag;
        if (colliderTag!= "Ground" && colliderTag!="Enemy" && colliderTag!="Flag")
        {
            if (colliderTag == "Apple")
            {
                PlayermaxHealth += 10;
               
            }
            else if (colliderTag == "Banana")
            {
                PlayermaxHealth += 20;
            }
            else if (colliderTag == "Cherry")
            {
                PlayermaxHealth += 30;
            }
            animator.SetBool("IsDisappear",true);
            Destroy(other.gameObject); 
        }
        if(colliderTag=="Flag"){
             Debug.Log(colliderTag );
            animator.SetBool("IsFlagIdle", true);
            Debug.Log("Level1 finished");
        }
     if(colliderTag=="Enemy"){
         PlayermaxHealth-=10;
     }

        
    }

}
