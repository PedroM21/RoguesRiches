using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
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

                if (Input.GetKeyDown(KeyCode.LeftShift) && !isDashing)
                {
                    dashDir = moveDir;
                    dashSpeed = 25f;
                    state = State.Dash;
                    isDashing = true;
                    dashCoolDownTimer = dashCoolDown;
                }
                break;
            case State.Dash:
                float dashSpeedDropMultiplier = 2f;
                dashSpeed -= dashSpeed * dashSpeedDropMultiplier * Time.deltaTime;

                float minDashSpeed = 5f;
                if (dashSpeed < minDashSpeed)
                {
                    state = State.Normal;
                }
                break;
        }

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
