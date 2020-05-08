using UnityEngine;

public class MotionManager : MonoBehaviour
{
    // world to move
    public Transform world;

    // speed of directional movement
    public float speed;

    // booleans to indicate directional movement
    private bool movingWorldLeft;
    private bool movingWorldRight;

    private void Start()
    {
        // stop any world movement when game starts
        StopWorldMove();
    }

    private void Update()
    {
        // if movingWorldLeft, rotate world right to simulate moving left
        if (movingWorldLeft)
        {
            world.Rotate(0f, -speed * Time.deltaTime, 0f);
        }
        // if movingWorldRight, rotate world left to simulate moving right
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
