using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolbarManager : MonoBehaviour
{
    public UIManager uiManager;
    public ManipulationManager manipulationManager;

    public Transform toolbarTip;

    bool isActive;

    private void Start()
    {
        manipulationManager.DeSelectObject();
        isActive = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Deck"))
        {
            bool result = manipulationManager.SelectObject(other.gameObject);
            if (result)
            {
                uiManager.EnableDeckUI();
            }
        }

        else if (other.gameObject.CompareTag("Card"))
        {
            bool result = manipulationManager.SelectObject(other.gameObject);
            if (result)
            {
                uiManager.EnableCardUI();
            }
        }

        else if (other.gameObject.CompareTag("Chip Case"))
        {
            bool result = manipulationManager.SelectObject(other.gameObject);
            if (result)
            {
                uiManager.EnableChipCaseUI();
            }
        }

        else if (other.gameObject.CompareTag("Chip"))
        {
            bool result = manipulationManager.SelectObject(other.gameObject);
            if (result)
            {
                uiManager.EnableChipUI();
            }
        }
    }

    public void SetActive()
    {
        isActive = !isActive;
    }

    public bool GetActive()
    {
        return isActive;
    }
}
