using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JackUIManager : MonoBehaviour
{
    public GameObject ballUI;

    // Start is called before the first frame update
    void Start()
    {
        DisableBallUI();
    }

    public void EnableBallUI()
    {
        ballUI.SetActive(true);
    }

    public void DisableBallUI()
    {
        ballUI.SetActive(false);
    }
}
