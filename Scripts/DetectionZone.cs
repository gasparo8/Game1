using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionZone : MonoBehaviour
{
    public List<Collider2D> detectedColliders = new List<Collider2D>();
    Collider2D col;
    Player player;
    public int takeDamage = 35;
    private bool playerInZone = false;
    private bool damageApplied = false;
    public float initialDelay = 0.5f;
    public float damageDelay = 0.01f;


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
            yield return new WaitForSeconds(initialDelay);

            if (detectedColliders.Contains(player.GetComponent<Collider2D>()))
            {
                damageApplied = false;
                yield return new WaitForSeconds(damageDelay);

                if (playerInZone && detectedColliders.Contains(player.GetComponent<Collider2D>()) && !damageApplied)
                {
                    player.TakeDamage(takeDamage);
                    damageApplied = true;
                }
            }
        }
    }
}
