using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    public Animator animator;
    public Rigidbody body;
    void Update()
    {
        animator.SetFloat("speed", Mathf.Abs(body.velocity.x)/2.5f);
    }

    public void TriggerLight () {
        animator.SetTrigger("poner bombilla");
    }

    public void TriggerExtintor () {
        animator.SetTrigger("usar extintor");
    }

    public void TriggerJump () {
        animator.SetTrigger("jump");
    }
}
