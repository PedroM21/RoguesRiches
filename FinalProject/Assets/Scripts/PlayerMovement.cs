using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] AnimationStateChanger animationStateChanger;
    [SerializeField] Transform body;
    private Rigidbody2D rb;

    public float moveSpeed = 5.0f;
    public float dashSpeed;
    private float dashCoolDown = 8f;
    private float dashCoolDownTimer = 0f;
    private bool isDashing = false;

    private Vector3 moveDir;
    private Vector3 dashDir;

    private enum State
    {
        Normal,
        Dash
    }

    private State state;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        state = State.Normal;

    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case State.Normal:

                float moveX = 0f;
                float moveY = 0f;

                // Checks for player input and moves towards the corresponding direction.
                if (Input.GetKey(KeyCode.W))
                {
                    moveY = 1f;
                }
                if (Input.GetKey(KeyCode.S))
                {
                    moveY = -1f;
                }
                if (Input.GetKey(KeyCode.A))
                {
                    moveX = -1f;
                }
                if (Input.GetKey(KeyCode.D))
                {
                    moveX = 1f;
                }
                moveDir = new Vector3(moveX, moveY).normalized;

                // Checks for movement, sets animation to run if moving and flips player horizontally if moving left.
                if(moveX != 0 || moveY != 0)
                {
                    if (moveX > 0)
                    {
                        body.localScale = new Vector3(2, 2, 2);
                        animationStateChanger.ChangeAnimationState("Run");
                    }
                    else if (moveX < 0)
                    {
                        body.localScale = new Vector3(-2, 2, 2);
                        animationStateChanger.ChangeAnimationState("Run");
                    }
                }
                else
                {
                    animationStateChanger.ChangeAnimationState("Idle");
                }

                if (Input.GetKeyDown(KeyCode.LeftShift) && !isDashing)
                {
                    dashDir = moveDir;
                    dashSpeed = 25f;
                    state = State.Dash;
                    isDashing = true;
                    dashCoolDownTimer = dashCoolDown;
                    animationStateChanger.ChangeAnimationState("Dodge");
                    
                }
                break;
            case State.Dash:
                float dashSpeedDropMultiplier = 2f;
                dashSpeed -= dashSpeed * dashSpeedDropMultiplier * Time.deltaTime;

                float minDashSpeed = 5f;
                if (dashSpeed < minDashSpeed)
                {
                    animationStateChanger.ChangeAnimationState("Idle");
                    state = State.Normal;
                }
                break;
        }

        // Checks if player has dashed and starts a count down for the cool down.
        if (isDashing)
        {
            dashCoolDownTimer -= Time.deltaTime;
            if (dashCoolDownTimer <= 0f)
            {
                isDashing = false;
            }
        }
    }

    private void FixedUpdate()
    {
        switch (state)
        {
            case State.Normal:
                rb.velocity = moveDir * moveSpeed;
                break;
            case State.Dash:
                rb.velocity = dashDir * dashSpeed;
                break;
        }
    }
}
