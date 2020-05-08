using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JacksManager : MonoBehaviour
{
    public Transform defaultJacksPoint;

    public JacksToolbarManager toolbarManager;

    public List<GameObject> jacks;

    bool inHand;

    void Start()
    {
        inHand = false;
        MoveJacksToDefaultPosition();
    }

    void Update()
    {
        // if jacks are in hand, keep all jacks on toolbar
        if (inHand)
        {
            foreach (GameObject jack in jacks)
            {
                jack.transform.position = toolbarManager.toolbarTip.position;
                jack.transform.rotation = toolbarManager.toolbarTip.rotation;
            }
        }

        // if jacks re not in hand and are not falling, set kinematic to true
        else
        {
            foreach (GameObject jack in jacks)
            {
                Rigidbody rb = jack.GetComponent<Rigidbody>();
                if (rb.IsSleeping() && !rb.isKinematic)
                {
                    rb.isKinematic = true;
                }
            }
        }
    }

    public void CollectJacks()
    {
        inHand = true;

        foreach (GameObject jack in jacks)
        {
            Rigidbody rb = jack.GetComponent<Rigidbody>();
            rb.isKinematic = true;
        }
    }

    public void DropJacks()
    {
        inHand = false;

        foreach (GameObject jack in jacks)
        {
            Rigidbody rb = jack.GetComponent<Rigidbody>();
            rb.isKinematic = false;
        }
    }

    public bool IsHoldingJacks()
    {
        return inHand;
    }

    public void MoveJacksToDefaultPosition()
    {
        foreach (GameObject jack in jacks)
        {
            MoveJackToDefaultPosition(jack);
        }
    }

    public void MoveJackToDefaultPosition(GameObject jack)
    {
        // display jacks in a even spaced line

        Rigidbody rb = jack.GetComponent<Rigidbody>();
        rb.isKinematic = true;

        int jackIndex = int.Parse(jack.name.Substring(12, 1));

        float offset = (-4.5f + jackIndex) / 10;

        Vector3 newPostion = new Vector3(
            defaultJacksPoint.position.x + offset,
            defaultJacksPoint.position.y,
            defaultJacksPoint.position.z
            );

        jack.transform.position = newPostion;
    }
}
