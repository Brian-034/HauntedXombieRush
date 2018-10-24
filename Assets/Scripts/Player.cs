using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    [SerializeField] float jumpForce = 10f;

    private string paramIsDead = "isDead";
    private string paramYVelocity = "yVelocity";

    private Rigidbody myRigidbody;
    private Animator myAnimator;

    private bool isJumping;

	void Start () {
        myRigidbody = GetComponent<Rigidbody>();
        myAnimator = GetComponent<Animator>();
	}
	
	void Update () {
        CheckForInput();
        UpdateAnimator();
	}

    private void FixedUpdate()
    {
        HandleJump();
    }

    private void HandleJump()
    {
        if (isJumping)
        {
            isJumping = false;
            myRigidbody.velocity = new Vector2(0, 0);
            myRigidbody.AddForce(new Vector2(0, jumpForce), ForceMode.Impulse);
        }
    }

    private void CheckForInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isJumping = true;
        }
    }
    private void UpdateAnimator()
    {
        myAnimator.SetFloat(paramYVelocity, myRigidbody.velocity.y);
    }
}
