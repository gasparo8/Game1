using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demon : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    private Rigidbody2D rb;
    public Animator animator;

    [SerializeField] private EnemyFlash flashEffect;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(int damage)
     {
        currentHealth -= damage;

        {
            flashEffect.Flash();
        }

    }
}
