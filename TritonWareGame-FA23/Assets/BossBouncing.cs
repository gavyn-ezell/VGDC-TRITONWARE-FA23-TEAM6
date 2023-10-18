using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBouncing : StateMachineBehaviour
{
    Transform player;
    Rigidbody2D rb;
    Boss boss;
    new Vector2 randomLocation;

    float time;
    bool end;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rb = animator.GetComponent<Rigidbody2D>();
        boss = animator.GetComponent<Boss>();

        time = Time.time;
        end = false;
        rb.velocity = new Vector2(-1f, 0.2f).normalized * 10;

        switch(Random.Range(0, 3)) {
            case 0:
                rb.velocity = Vector2.Scale(rb.velocity, new Vector2(-1f, 1f));
                break;
            case 1:
                rb.velocity = Vector2.Scale(rb.velocity, new Vector2(1f, -1f));
                break;
            default:
                break;
        }
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss.bouncing = true;

        if (Time.time > time + 5 && !end)
        {
            boss.bouncing = false;
            end = true;
            int rand = Random.Range(0, 2);
            switch (rand)
            {
                case 0:
                    animator.SetTrigger("Attack");
                    break;
                case 1:
                    animator.SetTrigger("Walk");
                    break;
                default:
                    animator.SetTrigger("Attack");
                    break;
            }
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Bounce");
    }
}
