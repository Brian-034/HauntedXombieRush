using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Player : MonoBehaviour {
    [SerializeField] float jumpForce = 10f;
    [SerializeField] AudioClip sfxJump;
    [SerializeField] AudioClip sfxDeath;

    private string paramIsDead = "isDead";
    private string paramYVelocity = "yVelocity";

    private Rigidbody myRigidbody;
    private Animator myAnimator;
    private AudioSource audioSource;

    private bool isJumping;

    private void Awake()
    {
        myRigidbody = GetComponent<Rigidbody>();
        myAnimator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        Assert.IsNotNull(audioSource);
        Assert.IsNotNull(myRigidbody);
        Assert.IsNotNull(myAnimator);
        Assert.IsNotNull(sfxJump);
        Assert.IsNotNull(sfxDeath);
    }

    void Start () {
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
        if (!GameManager.Instance.GameOver &&
            GameManager.Instance.GameStarted)
        {
            if (Input.GetMouseButtonDown(0))
            {
                GameManager.Instance.PlayerStartedGame();
                myRigidbody.useGravity = true; 
                isJumping = true;
                audioSource.PlayOneShot(sfxJump);
            }
        }
    }
    private void UpdateAnimator()
    {
        myAnimator.SetFloat(paramYVelocity, myRigidbody.velocity.y);
    }

    private void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Obstacle":
                audioSource.PlayOneShot(sfxDeath);
                myRigidbody.AddForce(new Vector3( jumpForce/2, jumpForce, jumpForce/2),
                    ForceMode.Impulse);
                GameManager.Instance.PlayerCollided();
                break;
        }
     }
}
