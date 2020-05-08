// NOTE: Ball must have collider attached to empty game object child b/c ball is a trigger

using UnityEngine;

public class BallCollider : MonoBehaviour
{
    private BallManager ballManager;

    private void Start()
    {
        ballManager = GameObject.FindGameObjectWithTag("BallManager").GetComponent<BallManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        // if ball falls off table, reset its postion to default position
        if (collision.gameObject.CompareTag("Respawn"))
        {
            ballManager.MoveBallToDefaultPosition();
        }
    }
}
