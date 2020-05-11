// NOTE: Jack must have collider attached to empty game object child b/c jack is a trigger

using UnityEngine;

public class JacksCollider : MonoBehaviour
{
    private JacksManager jacksManager;

    private void Start()
    {
        jacksManager = GameObject.FindGameObjectWithTag("JacksManager").GetComponent<JacksManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        // if jack falls off table, reset its postion to default position
        if (collision.gameObject.CompareTag("Respawn"))
        {
            jacksManager.MoveJackToDefaultPosition(gameObject);
        }
    }
}
