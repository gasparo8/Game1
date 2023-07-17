using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBall : MonoBehaviour
{
    [HideInInspector]
    public float speed;
    private Rigidbody2D iceBall;

    // Start is called before the first frame update
    void Start()
    {
        iceBall = GetComponent<Rigidbody2D>();
        speed = -2f;
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        //applying speed to x and leaving the y alone by keeping it at iceBall.velocity.y
        iceBall.velocity = new Vector2(speed, iceBall.velocity.y);
    }
}