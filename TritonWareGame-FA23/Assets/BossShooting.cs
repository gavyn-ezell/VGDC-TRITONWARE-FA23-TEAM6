using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShooting : StateMachineBehaviour
{
    Transform player;
    Rigidbody2D rb;
    Boss boss;

    float time;
    bool end;

    float attackTime;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rb = animator.GetComponent<Rigidbody2D>();
        boss = animator.GetComponent<Boss>();

        time = Time.time;
        attackTime = Time.time;
        end = false;

        rb.velocity = Vector2.zero;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(Time.time > attackTime) {
            attackTime += 0.3f;
            boss.shoot = true;
            // Instantiate(bullet, animator.transform.position, Quaternion.Euler(animator.transform.rotation.eulerAngles - Vector3.forward * Random.Range(85, 95)));
        }

        if (Time.time > time + 5 && !end)
        {
            end = true;
            int rand = Random.Range(0, 2);
            switch (rand)
            {
                case 0:
                    animator.SetTrigger("Bounce");
                    break;
                case 1:
                    animator.SetTrigger("Walk");
                    break;
                default:
                    animator.SetTrigger("Walk");
                    break;
            }
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack");
    }
}
