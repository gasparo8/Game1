using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
public class DetectionZone : MonoBehaviour
{
    public List<Collider2D> detectedColliders = new List<Collider2D>();
    Collider2D col;
    Player player;
    public int takeDamage = 35;
 
    private void Awake()
    {
        col = GetComponent<Collider2D>();
        player = GameObject.FindWithTag("Player").GetComponent<Player>();   
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        detectedColliders.Add(collision);

        // Start a timer to check if the player is still in the list after 1 second.
        StartCoroutine(CheckPlayerInList());
    }

    
    private void OnTriggerExit2D(Collider2D collision)
    {
        detectedColliders.Remove(collision);
    }

    
    private IEnumerator CheckPlayerInList()
    {
        yield return new WaitForSeconds(1);

        // If the player is still in the list, damage them.
        if (detectedColliders.Contains(player.GetComponent<Collider2D>()))
        {
            player.TakeDamage(takeDamage);
        }
    }
}
*/
public class DetectionZone : MonoBehaviour
{
    public List<Collider2D> detectedColliders = new List<Collider2D>();
    Collider2D col;
    Player player;
    public int takeDamage = 35;
    private bool playerInZone = false;

    private void Awake()
    {
        col = GetComponent<Collider2D>();
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        detectedColliders.Add(collision);

        if (collision.gameObject.CompareTag("Player"))
        {
            if (!playerInZone)
            {
                playerInZone = true;
                StartCoroutine(DamagePlayerRepeatedly());
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        detectedColliders.Remove(collision);

        if (collision.gameObject.CompareTag("Player"))
        {
            if (playerInZone && detectedColliders.Find(x => x.CompareTag("Player")) == null)
            {
                playerInZone = false;
                StopCoroutine(DamagePlayerRepeatedly());
            }
        }
    }

    private IEnumerator DamagePlayerRepeatedly()
    {
        while (playerInZone)
        {
            yield return new WaitForSeconds(1);

            if (detectedColliders.Contains(player.GetComponent<Collider2D>()))
            {
                player.TakeDamage(takeDamage);
            }
        }
    }
}