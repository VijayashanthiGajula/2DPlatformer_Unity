using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;
    public GameObject Player;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public int attackDamage = 20;
    public int PlayermaxHealth = 100;
    public int CurrentHealth;
    //public HealthBar healthbar;

    public LayerMask enemyLayers;
    // [SerializeField] bool isShielded = false;
    public HealthBarScript hb;
     public AudioSource ClangAudioSource;
    


    private void Start()
    {
        CurrentHealth = PlayermaxHealth;
        hb.SetMaxHealth(PlayermaxHealth);
    }

    // void TakeDamage(int damage)
    // {
    //     CurrentHealth -= damage;
    //     hb.SetHealth(CurrentHealth);

    // }

    void Update()
    {
        if (PlayermaxHealth > 0)
        {
            if (Input.GetButtonDown("Attack"))//left ctrl
            {
                Attack();
            }
            if (Input.GetButtonDown("Shield"))//left alt
            {
                // isShielded = true;
                Shield();
            }
        }
        else
        {
            Debug.Log("layer dead");
        }

    }
    private void Attack()
    {

        animator.SetTrigger("IsAttack");
         ClangAudioSource.Play();
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            // Debug.Log("We hit "+enemy.name);
            enemy.GetComponent<EnemyScript>().enemyDamage(attackDamage);
            // if (enemy.GetComponent<EnemyScript>().currentHealth <= 0)
            // {
            //     Destroy(enemy);
            // }

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
       public void PlayerDamage(int damage)
    {
        //Hit animation
        animator.SetTrigger("IsHit");
         CurrentHealth -= damage;
           if (CurrentHealth <= 0)
        {
             animator.SetBool("IsDead", true);
            Destroy(Player, 1);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {

        string colliderTag = other.gameObject.tag;
        
        if (colliderTag == "Flag")
        {
            Debug.Log(colliderTag);
            animator.SetBool("IsFlagIdle", true);
            Debug.Log("Level1 finished");
        }
        if (colliderTag == "Enemy")
        {
            CurrentHealth -= 10;
            animator.SetTrigger("IsHit");
        }
        hb.SetHealth(CurrentHealth);

    }
}
