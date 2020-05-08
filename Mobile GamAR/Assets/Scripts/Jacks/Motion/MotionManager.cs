using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotionManager : MonoBehaviour
{
    public Transform world;

    public float speed;

    bool movingLeft;
    bool movingRight;

    // Start is called before the first frame update
    void Start()
    {
        StopMove();
    }

    // Update is called once per frame
    void Update()
    {
        if (movingLeft)
        {
            world.Rotate(0f, speed * Time.deltaTime, 0f);
        }

        else if (movingRight)
        {
            world.Rotate(0f, -speed * Time.deltaTime, 0f);
        }
    }

    public void MoveLeft()
    {
        movingLeft = true;
    }

    public void MoveRight()
    {
        movingRight = true;
    }

    public void StopMove()
    {
        movingLeft = false;
        movingRight = false;
    }

}
