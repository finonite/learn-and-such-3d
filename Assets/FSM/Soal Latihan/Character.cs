using UnityEngine;

public class Character : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;

    private int hp = 100;

    void Update()
    {
        // Get input from keyboard (WASD / Arrow Keys)
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        // Combine inputs into a movement direction vector
        Vector3 movement = new Vector3(moveX, moveY, 0f).normalized;

        // Move the player frame-rate independently
        transform.position += movement * moveSpeed * Time.deltaTime;
    }

    // Example function if the enemy needs to deal damage to the character later
    public void TakeDamage(int damageAmount)
    {
        hp -= damageAmount;
        Debug.Log($"Player HP tersisa: {hp}");

        if (hp <= 0)
        {
            Debug.Log("Player telah kalah!");
        }
    }
}