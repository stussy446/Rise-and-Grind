using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Move : StateMachineBehaviour
{
    [Tooltip("how fast boss chases player")][SerializeField] float moveSpeed = 2.5f;
    [Tooltip("distance from player when boss attacks")][SerializeField] float attackRange = 3f;
    [Tooltip("length of time before boss flips")][SerializeField] float flipDelay = 2f;


    Transform player;
    Rigidbody2D bossRigidBody;
    Transform bossTransform;
    SpriteRenderer bossSprite;
    MonoBehaviour mb;



    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        bossRigidBody = animator.GetComponent<Rigidbody2D>();
        bossTransform = GameObject.FindGameObjectWithTag("Boss").transform;
        bossSprite = GameObject.FindGameObjectWithTag("Boss").GetComponent<SpriteRenderer>();
        mb = GameObject.FindObjectOfType<MonoBehaviour>();
    }


    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Vector2 target = new Vector2(player.position.x, player.position.y);
        Vector2 newPosition = Vector2.MoveTowards(bossRigidBody.position, target, moveSpeed * Time.fixedDeltaTime);
        bossRigidBody.MovePosition(newPosition);

        if (player.transform.position.x < bossTransform.position.x && bossTransform.eulerAngles.y != 0)
        {
            mb.StartCoroutine(FlipBoss(0));
        }
        else if (player.transform.position.x > bossTransform.position.x && bossTransform.eulerAngles.y != 180)
        {
            mb.StartCoroutine(FlipBoss(180));
        }


        if (Vector2.Distance(player.position, bossRigidBody.position) <= attackRange)
        {
            animator.SetTrigger("Attack");
        }

    }


    IEnumerator FlipBoss(int angle)
    {
     
        yield return new WaitForSeconds(flipDelay);
        if (bossTransform != null)
        {
            bossTransform.eulerAngles = new Vector3(0, angle, 0);
        }
    }


    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack");

    }

}