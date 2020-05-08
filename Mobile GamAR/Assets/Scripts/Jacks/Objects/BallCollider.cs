using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollider : MonoBehaviour
{
    BallManager ballManager;

    int bounceCount;

    private void Start()
    {
        ballManager = GameObject.FindGameObjectWithTag("BallManager").GetComponent<BallManager>();
        ResetBounce();
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Ground"))
        {
            bounceCount += 1;
        }

        if (collision.gameObject.CompareTag("Respawn"))
        {
            ballManager.MoveBallToDefaultPosition();
        }
    }

    public bool HasBounced()
    {
        return bounceCount > 1;
    }

    public void ResetBounce()
    {
        bounceCount = 0;
    }
}
