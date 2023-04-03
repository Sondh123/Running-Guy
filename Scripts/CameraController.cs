using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Transform player;
    private Vector3 offset;

    void Start()
    {
        //target = GameObject.FindGameObjectWithTag("Player").transform;
        offset = transform.position - target.position;
    }

    void LateUpdate()
    {
        if (PlayerManager.isGameStarted)
        {
            Vector3 newPosition = new Vector3(transform.position.x, transform.position.y, offset.z + target.position.z);
            transform.position = Vector3.Lerp(transform.position, newPosition, 0.6f);

            if (transform.position.z > player.position.z)
            {
                PlayerManager.gameOver = true;
            }
        }
 
    }
}
