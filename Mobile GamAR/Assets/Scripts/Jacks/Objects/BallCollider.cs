using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollider : MonoBehaviour
{
    BallManager ballManager;

    private void Start()
    {
        ballManager = GameObject.FindGameObjectWithTag("BallManager").GetComponent<BallManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Respawn"))
        {
            ballManager.moveBallToDefaultPosition();
        }
    }
}
