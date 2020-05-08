using System.Collections.Generic;
using UnityEngine;

public class JacksToolbarManager : MonoBehaviour
{
    public JackUIManager uiManager;

    public Transform toolbarTip;

    public BallManager ballManager;
    public JacksManager jacksManager;

    // boolean indicating an active jacks turn
    private bool jackPlayActive;

    // List of jacks grabbed in current turn
    private List<GameObject> jacksGrabbed;

    private void Start()
    {
        // no jacks turn is active at start of game
        EndJackPlay();
    }

    private void Update()
    {
        // if its an active turn, keep grabbed jacks in hand
        if (jackPlayActive)
        {
            foreach (GameObject jack in jacksGrabbed)
            {
                jack.transform.position = toolbarTip.position;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // if already holding a game piece to drop, ignore other pieces
        // NOTE: HoldingObject is false for jacks held mid turn b/c want to touch ball and jacks
        if (HoldingObject())
        {
            return;
        }

        // if touching the ball...
        if (other.gameObject.CompareTag("Ball"))
        {
            Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();

            // if its a jacks turn, end the turn
            if (jackPlayActive)
            {
                EndJackPlay();
            }

            // if ball is not moving, enable ball UI
            else if (rb.isKinematic)
            {
                uiManager.EnableBallUI();
            }
        }

        // if touching a jack...
        else if (other.gameObject.CompareTag("Jack"))
        {
            Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();

            // if its a jacks turn, grab the jack and increment the jacks grabbed UI text
            if (jackPlayActive)
            {
                jacksGrabbed.Add(other.gameObject);
                uiManager.UpdateJackLabel(jacksGrabbed.Count);

            }

            // if jack is not moving, enable jacks UI
            else if (rb.isKinematic)
            {
                uiManager.EnableJacksUI();
            }
        }
    }

    private bool HoldingObject()
    {
        return ballManager.IsHoldingBall() || jacksManager.IsHoldingJacks();
    }

    public void StartJacksPlay()
    {
        jackPlayActive = true;
        // enable jacks grabbed UI text with default: (0)
        uiManager.UpdateJackLabel(jacksGrabbed.Count);
    }

    private void EndJackPlay()
    {
        jackPlayActive = false;
        jacksGrabbed = new List<GameObject>();
        // reset ball and jacks to default positions
        ballManager.MoveBallToDefaultPosition();
        jacksManager.MoveJacksToDefaultPosition();
    }
}
