using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Demon : MonoBehaviour
{
    public int maxHealth = 1000;
    public int currentHealth;
    private Rigidbody2D rb;
    public Animator animator;

    public DemonHealth demonhealthBar;

    [SerializeField] private EnemyFlash flashEffect;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        currentHealth = maxHealth;
        demonhealthBar.SetMaxHealthDemon(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 1000 && currentHealth >= 666)
        {
            animator.SetBool("ArrowRain", true);
            animator.SetBool("Vulnerable", false);
            animator.SetBool("IceAttack", false); // Ensure others are set to false
            animator.SetBool("ComboAttack", false);
            animator.SetBool("Death", false);
        }

        else if (currentHealth <= 665 && currentHealth >= 334)
        {
            animator.SetBool("ArrowRain", false);
            animator.SetBool("Vulnerable", false);
            animator.SetBool("IceAttack", true);
            animator.SetBool("ComboAttack", false);
            animator.SetBool("Death", false);
        }

        else if (currentHealth <= 333 && currentHealth >= 1)
        {
            animator.SetBool("ArrowRain", false);
            animator.SetBool("Vulnerable", false);
            animator.SetBool("IceAttack", false);
            animator.SetBool("ComboAttack", true);
            animator.SetBool("Death", false);
        }

        else if (currentHealth <= 0)
        {
            animator.SetBool("ArrowRain", false);
            animator.SetBool("Vulnerable", false);
            animator.SetBool("IceAttack", false);
            animator.SetBool("ComboAttack", false);
            animator.SetBool("Death", true);
        }
    }


    public void TakeDamage(int damage)
     {
        currentHealth -= damage;
        demonhealthBar.SetHealthDemon(currentHealth);

        {
            flashEffect.Flash();
        }
    }
}

/* https://tinyurl.com/ytunnoqw */