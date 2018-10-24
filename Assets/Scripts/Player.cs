using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    [SerializeField] float jumpForce = 100f;

    private Rigidbody rigidbody;

    private bool isJumping;

	// Use this for initialization
	void Start () {
        rigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        CheckForInput();
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
            rigidbody.velocity = new Vector2(0, 0);
            rigidbody.AddForce(new Vector2(0, jumpForce), ForceMode.Impulse);
        }
    }

    private void CheckForInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isJumping = true;
        }
    }
}
