using UnityEngine;
using UnityEngine.AI;

public class QEnemyFSM : MonoBehaviour
{
    public QEnemyState currentState;

    public Transform player;

    public float chaseDistance = 10f;
    public float attackDistance = 2f;

    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        currentState = QEnemyState.Patrol;
    }

    void Update()
    {
        float distance =
            Vector3.Distance(transform.position,
                player.position);

        switch (currentState)
        {
            case QEnemyState.Patrol:

                Patrol();

                if (distance < chaseDistance)
                {
                    currentState = QEnemyState.Chase;
                }

                break;

            case QEnemyState.Chase:

                Chase();

                if (distance < attackDistance)
                {
                    currentState = QEnemyState.Attack;
                }

                if (distance > chaseDistance)
                {
                    currentState = QEnemyState.Patrol;
                }

                break;

            case QEnemyState.Attack:

                Attack();

                if (distance > attackDistance)
                {
                    currentState = QEnemyState.Chase;
                }

                break;
        }
    }

    void Patrol()
    {
        agent.isStopped = false;
    }

    void Chase()
    {
        agent.SetDestination(player.position);
    }

    void Attack()
    {
        agent.isStopped = true;

        Debug.Log("Enemy Attack");
    }
}