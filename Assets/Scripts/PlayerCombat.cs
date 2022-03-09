using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;
    public Transform attackPoint;
    public float attackRange=0.5f;
    public int attackDamage=20;

    public LayerMask enemyLayers;
   // [SerializeField] bool isShielded = false;

 

    
    void Update()
    {
        if (Input.GetButtonDown("Attack"))//left ctrl
        {
            Attack();
        }
        if (Input.GetButtonDown("Shield") )//left alt
        {
            // isShielded = true;
            Shield();
        }
    }
    private void Attack()
    {
       
        animator.SetTrigger("IsAttack");
        Collider2D[] hitEnemies=Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach(Collider2D enemy in hitEnemies)
        {
        // Debug.Log("We hit "+enemy.name);
       enemy.GetComponent<EnemyScript>().enemyDamage(attackDamage);
             
               }
    }
    void OnDrawGizmosSelected(){
        if(attackPoint==null){
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
    private void Shield()
    {
        Debug.Log("Shield mode");
        animator.SetTrigger("IsShield");

    }
}
