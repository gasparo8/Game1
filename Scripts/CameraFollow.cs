using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform player;

    private Vector3 tempPos;

    [SerializeField]
    private float minX, maxX;

    // Start is called before the first frame update
    void Start()
    {
        //FindWithTag is function within GameObject that will locate Player (because tag). .transform gets transform propoerty from player.
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame. LateUpdate is called after all update calculations are finished (i.e. player movement).
    void LateUpdate()
    {
        //transform.position is equal to current position of camera
        //tempPos.x is storing x position of player
        tempPos = transform.position;
        tempPos.x = player.position.x;

        if (tempPos.x < minX)
            tempPos.x = minX;

        if (tempPos.x > maxX)
            tempPos.x = maxX;


        transform.position = tempPos;
    }
}