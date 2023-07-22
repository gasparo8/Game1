using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTrigger : MonoBehaviour
{
    public GameObject arrowPrefab;
    public float arrowLifetime = 5f;

    // Store the instantiation positions for each trigger
    public List<Vector2> instantiationPoints = new List<Vector2>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Instantiate an arrow for each position in instantiationPoints list
            foreach (Vector2 position in instantiationPoints)
            {
                GameObject arrow = Instantiate(arrowPrefab, position, Quaternion.identity);
                StartCoroutine(DestroyIceBall(arrow));
            }
        }
    }
        private IEnumerator DestroyIceBall(GameObject arrow)
        {
            yield return new WaitForSeconds(arrowLifetime);
            if (arrow != null)
            {
                Destroy(arrow);
            }
        }
    }
