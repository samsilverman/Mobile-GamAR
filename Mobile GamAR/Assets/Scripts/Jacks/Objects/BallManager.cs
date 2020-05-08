using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    public Transform defaultBallPoint;

    public JacksToolbarManager toolbarManager;

    public GameObject ball;

    bool inHand;

    // Start is called before the first frame update
    void Start()
    {
        inHand = false;
        moveBallToDefaultPosition();
    }

    // Update is called once per frame
    void Update()
    {
        if (inHand)
        {
            ball.transform.position = toolbarManager.toolbarTip.position;
        }


        else
        {
            Rigidbody rb = ball.GetComponent<Rigidbody>();
            if (rb.IsSleeping() && !rb.isKinematic)
            {
                rb.isKinematic = true;
            }
            
        }
    }

    public void collectBall()
    {
        inHand = true;

        Rigidbody rb = ball.GetComponent<Rigidbody>();
        rb.isKinematic = true;
    }

    public void dropBall()
    {
        inHand = false;

        Rigidbody rb = ball.GetComponent<Rigidbody>();
        rb.isKinematic = false;
    }

    public bool isHoldingBall()
    {
        return inHand;
    }

    public void moveBallToDefaultPosition()
    {
        Rigidbody rb = ball.GetComponent<Rigidbody>();
        rb.isKinematic = true;

        ball.transform.position = defaultBallPoint.position;
    }

}
