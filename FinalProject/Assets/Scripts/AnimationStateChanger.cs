using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateChanger : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] string currentState = "Idle";

    private void Start()
    {
        ChangeAnimationState(currentState);
    }

    public void ChangeAnimationState(string newAnimationState)
    {
        if (newAnimationState == currentState)
            return;

        currentState = newAnimationState;
        animator.Play(newAnimationState);
    }

}
