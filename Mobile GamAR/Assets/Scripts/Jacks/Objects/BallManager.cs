using UnityEngine;

public class BallManager : MonoBehaviour
{
    public BallCollider ballCollider;

    public Transform defaultBallPoint;

    public JacksToolbarManager toolbarManager;

    public GameObject ball;

    private bool inHand;

    private void Start()
    {
        // ball is not in hand and in default position at start
        inHand = false;
        MoveBallToDefaultPosition();
    }

    private void Update()
    {
        // if ball is in hand, keep ball on toolbar
        if (inHand)
        {
            ball.transform.position = toolbarManager.toolbarTip.position;
        }

        // if ball is not in hand and is not bouncing, isKinematic is true so ball does not move
        else
        {
            Rigidbody rb = ball.GetComponent<Rigidbody>();
            if (rb.IsSleeping() && !rb.isKinematic)
            {
                rb.isKinematic = true;
            }
            
        }
    }

    public void CollectBall()
    {
        inHand = true;
        // isKinematic is true so ball does not fall out of hand
        Rigidbody rb = ball.GetComponent<Rigidbody>();
        rb.isKinematic = true;
    }

    public void DropBall()
    {
        inHand = false;
        // isKinematic is false so ball falls from hand
        Rigidbody rb = ball.GetComponent<Rigidbody>();
        rb.isKinematic = false;
    }

    public bool IsHoldingBall()
    {
        return inHand;
    }

    public void MoveBallToDefaultPosition()
    {
        // isKinematic is true so ball does not move from default position
        Rigidbody rb = ball.GetComponent<Rigidbody>();
        rb.isKinematic = true;

        ball.transform.position = defaultBallPoint.position;
    }
}
