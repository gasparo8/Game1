using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demon_Movement : StateMachineBehaviour
{ 
    public float speed = 5.5f;
    Transform demonR;
    Transform demonL;
    Rigidbody2D rb;
   /* Vector2 target;*/
 

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        demonL = GameObject.FindGameObjectWithTag("Demon Left Point").transform;
        demonR = GameObject.FindGameObjectWithTag("Demon Right Point").transform;
        rb = animator.GetComponent<Rigidbody2D>();
        /*target = demonR.position;*/
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)

    {
        Vector2 target = new Vector2(demonR.position.x, rb.position.y);

        Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
        rb.MovePosition(newPos);

        /*
        if (newPos.x > demonR.position.x)
        {
            target = demonL.position;
        }
        else if (newPos.x < demonL.position.x)
        {
            target = demonR.position;
        }
        */
    }

    //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
     
    }

}
