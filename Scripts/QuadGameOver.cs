using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuadGameOver : MonoBehaviour
{
    PlayerController playerController;
    private float moveSpeed;
    private float time = 0;

    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        moveSpeed = playerController.forwardSpeed;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerManager.isGameStarted)
        {
            moveSpeed = playerController.forwardSpeed;
            transform.position += new Vector3(0, 0, 1) * moveSpeed * Time.deltaTime;
        }

        
               
        
    }
}
