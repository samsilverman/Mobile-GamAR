using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JacksCollider : MonoBehaviour
{
    JacksManager jacksManager;

    private void Start()
    {
        jacksManager = GameObject.FindGameObjectWithTag("JacksManager").GetComponent<JacksManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Respawn"))
        {
            jacksManager.MoveJackToDefaultPosition(gameObject);
        }
    }
}
