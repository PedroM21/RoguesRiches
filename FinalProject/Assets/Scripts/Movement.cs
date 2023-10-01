using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] AnimationStateChanger animationStateChanger;
    [SerializeField] float speed = 1f;
    [SerializeField] Transform body;

    private float activeMoveSpeed;
    public float dashSpeed;

    public float dashLength = 0.5f;
    public float dashCooldown = 1f;

    private float dashCounter;
    private float dashCoolCounter;

    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        activeMoveSpeed = speed;
    }

    private void FixedUpdate()
    {
        Vector3 vel = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            vel.y = 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            vel.y = -1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            vel.x = -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            vel.x = 1;
        }
        MoveRB(vel);

        //rb.velocity = vel * activeMoveSpeed;
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if(dashCoolCounter <= 0 && dashCounter <= 0)
            {
                activeMoveSpeed = dashSpeed;
                dashCounter = dashLength;
            }
        }

        if (dashCounter > 0)
        {
            dashCounter -= Time.deltaTime;

            if(dashCounter <= 0)
            {
                activeMoveSpeed = speed;
                dashCoolCounter = dashCooldown;
            }
        }

        if(dashCoolCounter > 0)
        {
            dashCoolCounter -= Time.deltaTime;
        }

    }

    public void MoveTransform(Vector3 vel)
    {
        transform.position += vel * speed * Time.deltaTime;
    }

    public void MoveRB(Vector3 vel)
    {
        rb.velocity = vel * speed;
        if(vel.magnitude > 0)
        {
            animationStateChanger.ChangeAnimationState("Run");

            if(vel.x > 0)
            {
                body.localScale = new Vector3(2, 2, 2);
            }
            else if (vel.x < 0)
            {
                body.localScale = new Vector3(-2, 2, 2);
            }

        }
        else
        {
            animationStateChanger.ChangeAnimationState("Idle");
        }
    }

    public void StepMove(Vector3 direction)
    {
        transform.position += direction;
    }

}
