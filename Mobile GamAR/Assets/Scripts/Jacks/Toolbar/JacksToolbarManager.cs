using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JacksToolbarManager : MonoBehaviour
{
    public JackUIManager uiManager;

    public Transform toolbarTip;

    public BallManager ballManager;
    public JacksManager jacksManager;

    private void OnTriggerEnter(Collider other)
    {
        if (holdingObject())
        {
            return;
        }

        if (other.gameObject.CompareTag("Ball"))
        {
            Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
            if (rb.isKinematic)
            {
                uiManager.EnableBallUI();
            }
        }

        else if (other.gameObject.CompareTag("Jack"))
        {
            Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
            if (rb.isKinematic)
            {
                uiManager.EnableJacksUI();
            }
        }
    }

    bool holdingObject()
    {
        return ballManager.isHoldingBall() || jacksManager.isHoldingJacks();
    }
}
