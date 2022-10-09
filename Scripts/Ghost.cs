using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    [HideInInspector]
    public float speed;


    private Rigidbody2D myBody;

    // Start is called before the first frame update
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();

        speed = -2;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //applying spped to x and leaving the y alone by keeping it at myBody.velocity.y
        myBody.velocity = new Vector2(speed, myBody.velocity.y);
    }



}//class
