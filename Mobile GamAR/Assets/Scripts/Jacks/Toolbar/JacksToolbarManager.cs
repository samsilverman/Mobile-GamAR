using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JacksToolbarManager : MonoBehaviour
{
    public JackUIManager uiManager;

    public Transform toolbarTip;

    public BallManager ballManager;
    public JacksManager jacksManager;

    bool jackPlayActive;
    List<GameObject> jacksGrabbed;

    private void Start()
    {
        EndJackPlay();
    }

    private void Update()
    {
        // if its an active jacks turn...
        if (jackPlayActive)
        {
            //// if ball bounces, end jacks turn
            //if (ballManager.HasBounced())
            //{
            //    EndJackPlay();
            //}
            // keep all grabbed jacks in hand
            //else
            //{
            foreach (GameObject jack in jacksGrabbed)
            {
                jack.transform.position = toolbarTip.position;
            }
            //}
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // if already holding ball or jacks, ignore
        if (HoldingObject())
        {
            return;
        }

        if (other.gameObject.CompareTag("Ball"))
        {
            Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();

            // if its a jacks turn, end the turn and reset all pieces
            if (jackPlayActive)
            {
                EndJackPlay();
            }

            // if ball is not bouncing, enable ball ui
            else if (rb.isKinematic)
            {
                uiManager.EnableBallUI();
            }
        }

        else if (other.gameObject.CompareTag("Jack"))
        {
            Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();

            // if its a jacks turn, grab the jack and increment dispay
            if (jackPlayActive)
            {
                jacksGrabbed.Add(other.gameObject);
                uiManager.UpdateJackLabel(jacksGrabbed.Count);

            }

            // if jack is not being thrown, enable jacks ui
            else if (rb.isKinematic)
            {
                uiManager.EnableJacksUI();
            }
        }
    }

    bool HoldingObject()
    {
        return ballManager.IsHoldingBall() || jacksManager.IsHoldingJacks();
    }

    public void StartJacksPlay()
    {
        jackPlayActive = true;
        uiManager.UpdateJackLabel(jacksGrabbed.Count);
    }

    void EndJackPlay()
    {
        jackPlayActive = false;
        jacksGrabbed = new List<GameObject>();

        ballManager.MoveBallToDefaultPosition();
        jacksManager.MoveJacksToDefaultPosition();
    }
}
