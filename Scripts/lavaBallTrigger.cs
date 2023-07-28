using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lavaBallTrigger : MonoBehaviour
{
    public GameObject lavaBallPrefab;
    private bool lavaBallInstantiated = false; // Flag to track if a lava ball has been instantiated

    // Store the instantiation positions for each trigger
    public List<Vector2> instantiationPoints = new List<Vector2>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!lavaBallInstantiated && collision.CompareTag("Player"))
        {
            // Instantiate a lavaBall only if it hasn't been already
            foreach (Vector2 position in instantiationPoints)
            {
                GameObject lavaBall = Instantiate(lavaBallPrefab, position, Quaternion.identity);
            }

            lavaBallInstantiated = true; // Set the flag to true to prevent further instantiation
            StartCoroutine(WaitAndResetLavaBallInstantiation());
        }
    }

    private IEnumerator WaitAndResetLavaBallInstantiation()
    {
        yield return new WaitForSeconds(2f); // Adjust the duration based on your lava ball's behavior
        lavaBallInstantiated = false; // Allow the next lava ball to be instantiated after a delay
    }
}
