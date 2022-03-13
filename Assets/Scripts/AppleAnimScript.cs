using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AppleAnimScript : MonoBehaviour
{
    public Animator anim;
    public GameObject Player;
    public HealthBarScript hb;
    PlayerCombat PC;
    public AudioSource FruitSound;
    // Start is called before the first frame update
    void Start()
    {
        PC = Player.GetComponent<PlayerCombat>();
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            anim.SetBool("IsDisappear", true);
            FruitSound.Play();
            Destroy(gameObject);
             PC.CurrentHealth += 10;
             hb.SetHealth(PC.CurrentHealth);
        }
    }
}
