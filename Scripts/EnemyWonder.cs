using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWonder : MonoBehaviour
{

    public float speed = 0.4f;
    Vector2 pointA;
    Vector2 pointB;

    // Start is called before the first frame update
    void Start()
    {
        pointA = new Vector2(11, -1.42994f);
        pointB = new Vector2(7, -1.42994f);
    }

    // Update is called once per frame
    void Update()
    {
        float time = Mathf.PingPong(Time.time * speed, 1f);
        transform.position = Vector2.Lerp(pointA, pointB, time);
    }
}
