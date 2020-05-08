using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    public BallCollider ballCollider;

    public Transform defaultBallPoint;

    public JacksToolbarManager toolbarManager;

    public GameObject ball;

    bool inHand;

    void Start()
    {
        inHand = false;
        MoveBallToDefaultPosition();
    }

    void Update()
    {
        // if ball is in hand, keep ball on toolbar
        if (inHand)
        {
            ball.transform.position = toolbarManager.toolbarTip.position;
        }

        // if ball is not in hand and is done bouncing, set ball to kinematic
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

        Rigidbody rb = ball.GetComponent<Rigidbody>();
        rb.isKinematic = true;
    }

    public void DropBall()
    {
        inHand = false;
        Rigidbody rb = ball.GetComponent<Rigidbody>();
        rb.isKinematic = false;
        ballCollider.ResetBounce();
    }

    public bool IsHoldingBall()
    {
        return inHand;
    }

    public void MoveBallToDefaultPosition()
    {
        Rigidbody rb = ball.GetComponent<Rigidbody>();
        rb.isKinematic = true;

        ball.transform.position = defaultBallPoint.position;
    }

    public bool HasBounced()
    {
        return ballCollider.HasBounced();
    }

}
