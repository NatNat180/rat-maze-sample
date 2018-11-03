﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatBehaviour : MonoBehaviour
{

    private Rigidbody ratBody;
    private float speed = 3f;
    private bool moveToggle = false;

    void Start()
    {
        ratBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Get movement toggle from spacebar
        if (Input.GetKeyDown(KeyCode.Space))
        {
            moveToggle = !moveToggle;
        }

        // mouse movement based on movement toggle
        if (moveToggle)
        {
            ratBody.velocity = transform.forward * speed;
        }
        else
        {
            ratBody.velocity = Vector3.zero;
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.transform.tag == "DirectionalTile")
        {
            DirectionalTile tile = collider.gameObject.GetComponent<DirectionalTile>();
            switch (tile.CurrentDirection)
            {
                case "UP":
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                    break;
                case "RIGHT":
                    transform.rotation = Quaternion.Euler(0, 90, 0);
                    break;
                case "DOWN":
                    transform.rotation = Quaternion.Euler(0, 180, 0);
                    break;
                case "LEFT":
                    transform.rotation = Quaternion.Euler(0, 270, 0);
                    break;
                default:
                    break;
            }
        }
    }
}
