using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JacksManager : MonoBehaviour
{
    public Transform defaultJacksPoint;

    public JacksToolbarManager toolbarManager;

    public List<GameObject> jacks;

    bool inHand;

    // Start is called before the first frame update
    void Start()
    {
        inHand = false;
        moveJacksToDefaultPosition();
    }

    // Update is called once per frame
    void Update()
    {
        if (inHand)
        {
            foreach (GameObject jack in jacks)
            {
                jack.transform.position = toolbarManager.toolbarTip.position;
                jack.transform.rotation = toolbarManager.toolbarTip.rotation;
            }
        }

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

    public void collectJacks()
    {
        inHand = true;

        foreach (GameObject jack in jacks)
        {
            Rigidbody rb = jack.GetComponent<Rigidbody>();
            rb.isKinematic = true;
        }
    }

    public void dropJacks()
    {
        inHand = false;

        foreach (GameObject jack in jacks)
        {
            Rigidbody rb = jack.GetComponent<Rigidbody>();
            rb.isKinematic = false;
        }
    }

    public bool isHoldingJacks()
    {
        return inHand;
    }

    public void moveJacksToDefaultPosition()
    {
        foreach (GameObject jack in jacks)
        {
            moveJackToDefaultPosition(jack);
        }
    }

    public void moveJackToDefaultPosition(GameObject jack)
    {
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
