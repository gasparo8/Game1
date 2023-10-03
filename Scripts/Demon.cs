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
