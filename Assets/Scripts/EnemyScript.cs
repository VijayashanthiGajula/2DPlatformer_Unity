using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public GameObject EnemyObj;
    public Transform Player;
    public int maxHealth = 100;
    public int currentHealth;
    public Animator animator;

    //attacking player
    public float attackRange = 0.5f;
    public int attackDamage = 1;
    public Transform AttackEnemyPoint;
    public LayerMask PlayerLayer;
    private void Start()
    {
        currentHealth = maxHealth;
    }
    private void Update()
    {
        if (currentHealth > 0 && Vector2.Distance(EnemyObj.transform.position, Player.position) < 2)
        { animator.SetTrigger("IsNear"); }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {

        if (currentHealth > 0)
        {
            animator.SetTrigger("IsNear");
            EnemyAttack();

        }

    }
    public void EnemyAttack()
    {

        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(AttackEnemyPoint.position, attackRange, PlayerLayer);
        foreach (Collider2D player in hitPlayer)
        {
            player.GetComponent<PlayerCombat>().PlayerDamage(attackDamage);
        }
    }
    public void enemyDamage(int damage)
    {
        //Hit animation
        animator.SetTrigger("IsHit");
        currentHealth -= damage;
        if (currentHealth == 0)
        {
            Die();
        }
    }
    void Die()
    {
        animator.SetBool("IsDead", true);
        Destroy(EnemyObj);
    }
}
