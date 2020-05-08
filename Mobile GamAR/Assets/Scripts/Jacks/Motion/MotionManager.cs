using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotionManager : MonoBehaviour
{
    public Transform world;

    public float speed;

    bool movingWorldLeft;
    bool movingWorldRight;

    // Start is called before the first frame update
    void Start()
    {
        StopWorldMove();
    }

    // Update is called once per frame
    void Update()
    {
        if (movingWorldLeft)
        {
            world.Rotate(0f, -speed * Time.deltaTime, 0f);
        }

        else if (movingWorldRight)
        {
            world.Rotate(0f, speed * Time.deltaTime, 0f);
        }
    }

    public void MoveWorldLeft()
    {
        movingWorldLeft = true;
    }

    public void MoveWorldRight()
    {
        movingWorldRight = true;
    }

    public void StopWorldMove()
    {
        movingWorldLeft = false;
        movingWorldRight = false;
    }

}
