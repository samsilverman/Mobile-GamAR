using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotController : MonoBehaviour
{

    public float speed = 0.1f;

    public float xLower = -0.78f;
    public float xUpper = 0.78f;
    public float zLower = 0.26f;
    public float zUpper = 0.35f;

    public float checkpointThreshold = 0.1f;
    
    Rigidbody rb;

    Vector3 newDestination;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        MoveToRandom();
    }

    // Update is called once per frame
    void Update()
    {
        
        float dist = Vector3.Distance(this.gameObject.transform.position, newDestination);
        
        if (dist < checkpointThreshold) {
            MoveToRandom();
            //Debug.Log("Picking new spot " + newDestination.x + " " + newDestination.y + " " + newDestination.z);
        }
        
        else {
            //Debug.Log("Moving to " + newDestination.x + " " + newDestination.y + " " + newDestination.z);
            this.gameObject.transform.LookAt(newDestination);
            Quaternion rotation = this.gameObject.transform.rotation;
            this.gameObject.transform.rotation = new Quaternion(0, rotation.y, 0, rotation.w);
            rb.velocity = transform.forward * speed;
        }

    }


    void MoveToRandom() {
        float randX = Random.Range(xLower, xUpper);
        float randZ = Random.Range(zLower, zUpper);
        newDestination = new Vector3(randX, 0, randZ);

    }
}
