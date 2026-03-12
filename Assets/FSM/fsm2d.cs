using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fsm2d : MonoBehaviour
{
    public enum State
    {
        Idle,
        Chase,
        Attack
    }

    public State currentState;
    public Transform player;
    public float speed = 2;

    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.position);

        switch(currentState)
        {
            case State.Idle:
                if(distance < 2)
                {
                    currentState = State.Chase;
                }
                break;
            case State.Chase:
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
                if(distance < 1)
                {
                    currentState = State.Attack;
                } else if(distance > 4)
                {
                    currentState = State.Idle;
                }
                break;
            case State.Attack:
                print("Enemy Attacking");
                if(distance > 1)
                {
                    currentState = State.Chase;
                }
                break;
        }
    }
}
