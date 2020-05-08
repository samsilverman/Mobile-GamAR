using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JacksToolbarManager : MonoBehaviour
{
    public JackUIManager uiManager;

    public Transform toolbarTip;

    GameObject ball;
    List<GameObject> jacks;

    // Start is called before the first frame update
    void Start()
    {
        ball = null;
        jacks = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ball != null)
        {
            ball.transform.position = toolbarTip.position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            uiManager.EnableBallUI();
            ball = other.gameObject;
            Rigidbody rb = ball.GetComponent<Rigidbody>();
            rb.isKinematic = true;
        }
    }

    public void dropBall()
    {
        ball = null;
    }
}
