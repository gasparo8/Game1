using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBallTrigger : MonoBehaviour
{
    public GameObject iceBallPrefab;
    private float LVL2iceBallx = 1.49f;
    private float LVL2iceBally = 2.85f;
    public float iceBallLifetime = 10f;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameObject iceBall = Instantiate(iceBallPrefab, new Vector2(LVL2iceBallx, LVL2iceBally), Quaternion.identity);
            StartCoroutine(DestroyIceBall(iceBall));
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
