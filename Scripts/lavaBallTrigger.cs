using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lavaBallTrigger : MonoBehaviour
{
    public GameObject lavaBallPrefab;
    public float lavaBallLifetime = 5f;

    // Store the instantiation positions for each trigger
    public List<Vector2> instantiationPoints = new List<Vector2>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Instantiate an lavaBall for each position in instantiationPoints list
            foreach (Vector2 position in instantiationPoints)
            {
                GameObject lavaBall = Instantiate(lavaBallPrefab, position, Quaternion.identity);
                /*StartCoroutine(DestroyIceBall(arrow));*/
            }
        }
    }
}

    /*
    private IEnumerator DestroyIceBall(GameObject arrow)
    {
        yield return new WaitForSeconds(arrowLifetime);
        if (arrow != null)
        {
            Destroy(arrow);
        }
    }
}
    */