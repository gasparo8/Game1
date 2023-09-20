using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ArrowRain : StateMachineBehaviour
{
    public GameObject arrowPrefab;
    public float spawnInterval = .5f;
    public Vector2 spawnRange = new Vector2(-10, 10);

    private float timer = 0f;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = 0f;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            timer = 0f;

            Vector3 spawnPosition = new Vector3(Random.Range(spawnRange.x, spawnRange.y), 10, 0);
            Instantiate(arrowPrefab, spawnPosition, Quaternion.identity);
        }
    }

    // OnStateExit is called when a transition ends, and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Perform cleanup when the state exits
    }
}
