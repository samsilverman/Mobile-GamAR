using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JackUIManager : MonoBehaviour
{
    public GameObject ballUI;
    public GameObject jacksUI;

    // Start is called before the first frame update
    void Start()
    {
        DisableBallUI();
        DisableJacksUI();
    }

    public void EnableBallUI()
    {
        ballUI.SetActive(true);
        jacksUI.SetActive(false);
    }

    public void DisableBallUI()
    {
        ballUI.SetActive(false);
    }

    public void EnableJacksUI()
    {
        ballUI.SetActive(false);
        jacksUI.SetActive(true);
    }

    public void DisableJacksUI()
    {
        jacksUI.SetActive(false);
    }
}
