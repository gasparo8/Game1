using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBallTrigger : MonoBehaviour
{
    public GameObject iceBallPrefab;
    public float iceBallLifetime = 15f;

    // Store the instantiation positions for each trigger
    public List<Vector2> instantiationPoints = new List<Vector2>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Instantiate an arrow for each position in instantiationPoints list
            foreach (Vector2 position in instantiationPoints)
            {
                GameObject iceBall = Instantiate(iceBallPrefab, position, Quaternion.identity);
                StartCoroutine(DestroyIceBall(iceBall));
            }
        }
    }

        private IEnumerator DestroyIceBall(GameObject iceBall)
        {
            yield return new WaitForSeconds(iceBallLifetime);
            if (iceBall != null)
            {
                Destroy(iceBall);
            }
        }
    }
