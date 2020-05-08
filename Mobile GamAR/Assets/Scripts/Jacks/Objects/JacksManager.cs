using System.Collections.Generic;
using UnityEngine;

public class JacksManager : MonoBehaviour
{
    public Transform defaultJacksPoint;

    public JacksToolbarManager toolbarManager;

    public List<GameObject> jacks;
    private bool inHand;

    private void Start()
    {
        // jacks are not in hand and in default position at start
        inHand = false;
        MoveJacksToDefaultPosition();
    }

    private void Update()
    {
        // if jacks are in hand, keep jacks on toolbar
        if (inHand)
        {
            foreach (GameObject jack in jacks)
            {
                jack.transform.position = toolbarManager.toolbarTip.position;
                jack.transform.rotation = toolbarManager.toolbarTip.rotation;
            }
        }

        // if jacks are not in hand and are not falling, isKinematic is true so jacks do not move
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
        // isKinematic is true so jacks do not fall out of hand
        foreach (GameObject jack in jacks)
        {
            Rigidbody rb = jack.GetComponent<Rigidbody>();
            rb.isKinematic = true;
        }
    }

    public void DropJacks()
    {
        inHand = false;
        // isKinematic is false so jacks fall from hand
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
        // isKinematic is true so jacks fo not move from default position
        Rigidbody rb = jack.GetComponent<Rigidbody>();
        rb.isKinematic = true;

        // access jackIndex based off number in jack's GameObject name
        int jackIndex = int.Parse(jack.name.Substring(12, 1));

        // space jacks evenly apart using jackIndex for placement 
        float offset = (-4.5f + jackIndex) / 100;
        Vector3 newPostion = new Vector3(
            defaultJacksPoint.position.x + offset,
            defaultJacksPoint.position.y,
            defaultJacksPoint.position.z
            );

        jack.transform.position = newPostion;
    }
}
