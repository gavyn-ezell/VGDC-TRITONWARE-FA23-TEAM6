using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWalking : StateMachineBehaviour
{
    public float speed = 4;

    Transform player;
    Rigidbody2D rb;

    float time;
    bool end;

    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();

        time = Time.time;
        end = false;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Vector2 target = new Vector2(player.position.x, player.position.y);
        Vector2 newPosition = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
        rb.MovePosition(newPosition);

        if(Time.time > time + 5 && !end)
        {
            end = true;
            switch (Random.Range(0, 2))
            {
                case 0:
                    animator.SetTrigger("Attack");
                    GameObject.Find("Anim").GetComponent<Animator>().SetTrigger("Shoot");
                    break;
                case 1:
                    animator.SetTrigger("Bounce");
                    GameObject.Find("Anim").GetComponent<Animator>().SetTrigger("Bounce");
                    break;
                default:
                    animator.SetTrigger("Attack");
                    GameObject.Find("Anim").GetComponent<Animator>().SetTrigger("Shoot");
                    break;
            }
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Walk");
    }
}
