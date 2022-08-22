using UnityEngine;

public class LerpMover : MonoBehaviour
{

    [SerializeField] Transform start;
    [SerializeField] Transform end;
    [SerializeField] Transform enemyTransform;
    [SerializeField] float enemySpeed = 3f;

    private float positionPercent;
    private int direction = 1;
    Animator animator;

    private void Start()
    {
        if (GetComponentInChildren<Animator>() != null)
        {
            animator = GetComponentInChildren<Animator>();
        }
    }

    void Update()
    {
        MoveEnemy();
        SwitchEnemyDirectionIfNeeded();
    }

    private void MoveEnemy()
    {
        float distance = Vector3.Distance(start.position, end.position);
        float speedForDistance = enemySpeed / distance;

        positionPercent += Time.deltaTime * direction * speedForDistance;

        enemyTransform.position = Vector3.Lerp(start.position, end.position, positionPercent);
    }

    private void SwitchEnemyDirectionIfNeeded()
    {
        if (positionPercent >= 1 && direction == 1)
        {
            animator.SetBool("MovingRight", false);
            direction = -1;
        }
        else if (positionPercent <= 0 && direction == -1)
        {
            animator.SetBool("MovingRight", true);
            direction = 1;
        }
    }
}
