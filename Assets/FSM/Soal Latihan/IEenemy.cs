using UnityEngine;

public class IEenemy : MonoBehaviour
{
    // Define the states as per instructions
    public enum EnemyState
    {
        Idle,
        Chase,
        Attack
    }

    [Header("State Machine")]
    public EnemyState currentState = EnemyState.Idle;

    [Header("Movement & AI Settings")]
    public float moveSpeed = 3f;
    public float chaseRange = 7f;
    public float attackRange = 2f;

    private Transform playerTransform;

    void Start()
    {
        // Automatically find the player by tag
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            playerTransform = player.transform;
        }
        else
        {
            Debug.LogWarning("Player GameObject with tag 'Player' not found in the scene!");
        }
    }

    void Update()
    {
        if (playerTransform == null) return;

        // Calculate distance to player
        float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);

        // State switching logic based on distance
        DetermineState(distanceToPlayer);

        // Execute behavior based on current state
        HandleStateBehavior();
    }

    private void DetermineState(float distance)
    {
        if (distance <= attackRange)
        {
            currentState = EnemyState.Attack;
        }
        else if (distance <= chaseRange)
        {
            currentState = EnemyState.Chase;
        }
        else
        {
            currentState = EnemyState.Idle;
        }
    }

    private void HandleStateBehavior()
    {
        switch (currentState)
        {
            case EnemyState.Idle:
                PerformIdle();
                break;

            case EnemyState.Chase:
                PerformChase();
                break;

            case EnemyState.Attack:
                PerformAttack();
                break;
        }
    }

    private void PerformIdle()
    {
        // Idle behavior (Stay still)
        // You could add a small pacing mechanic here later if desired
    }

    private void PerformChase()
    {
        // Move towards the player's position
        Vector3 direction = (playerTransform.position - transform.position).normalized;
        
        // If 2D game, keep Z axis locked to 0
        direction.z = 0; 

        transform.position += direction * moveSpeed * Time.deltaTime;
        
        Debug.Log("Enemy is chasing the player!");
    }

    private void PerformAttack()
    {
        // Attack behavior logic
        Debug.Log("Enemy is attacking the player close-range!");
    }

    // Optional: Draw visualization rings in the editor scene window
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, chaseRange);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}