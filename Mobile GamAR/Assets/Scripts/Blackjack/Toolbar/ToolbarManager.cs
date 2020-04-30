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
            manipulationManager.SelectObject(other.gameObject);
            uiManager.EnableDeckUI();
        }

        else if (other.gameObject.CompareTag("Card"))
        {
            manipulationManager.SelectObject(other.gameObject);
            uiManager.EnableCardUI();
        }

        else if (other.gameObject.CompareTag("Chip Case"))
        {
            manipulationManager.SelectObject(other.gameObject);
            uiManager.EnableChipCaseUI();
        }

        else if (other.gameObject.CompareTag("Chip"))
        {
            manipulationManager.SelectObject(other.gameObject);
            uiManager.EnableChipUI();
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
