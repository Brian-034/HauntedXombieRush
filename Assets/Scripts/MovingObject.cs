﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour {

    [SerializeField] float speed = 1.5f;
    [SerializeField] float startPosition = 0f;
    [SerializeField] float resetPosition = 0f;

		
	// Update is called once per frame
	protected virtual void  Update () {
        MoveLeft();
	}

    private void MoveLeft()
    {
        if (GameManager.Instance.PlayerActive)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
            if (transform.localPosition.x <= resetPosition)
            {
                Vector3 newPosition = new Vector3(startPosition, transform.position.y,
                    transform.position.z);
                transform.position = newPosition;
            }
        }
     }
}
