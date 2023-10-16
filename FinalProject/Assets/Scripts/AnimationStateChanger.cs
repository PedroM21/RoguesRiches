using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateChanger : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] string currentState = "Idle";

    // Starts player with idle animation
    private void Start()
    {
        ChangeAnimationState(currentState);
    }

    // Changes animation state and returns if animation is the same
    public void ChangeAnimationState(string newAnimationState)
    {
        if (newAnimationState == currentState)
            return;

        currentState = newAnimationState;
        animator.Play(newAnimationState);
    }

}
