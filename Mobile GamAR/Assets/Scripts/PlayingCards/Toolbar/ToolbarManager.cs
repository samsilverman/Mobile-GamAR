using UnityEngine;

public class ToolbarManager : MonoBehaviour
{
    public UIManager uiManager;
    public ManipulationManager manipulationManager;

    public Transform toolbarTip;

    private bool isActive;

    private void Start()
    {
        manipulationManager.DeSelectObject();
        isActive = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        // select deck if collided
        if (other.gameObject.CompareTag("Deck"))
        {
            bool result = manipulationManager.SelectObject(other.gameObject);
            if (result)
            {
                // enable deck ui if selected
                uiManager.EnableDeckUI();
            }
        }

        // select card if collided
        else if (other.gameObject.CompareTag("Card"))
        {
            bool result = manipulationManager.SelectObject(other.gameObject);
            if (result)
            {
                // enable card if selected
                uiManager.EnableCardUI();
            }
        }

        // select chip case if collided
        else if (other.gameObject.CompareTag("Chip Case"))
        {
            bool result = manipulationManager.SelectObject(other.gameObject);
            if (result)
            {
                // enable chip case ui if selected
                uiManager.EnableChipCaseUI();
            }
        }

        // select chip if collided
        else if (other.gameObject.CompareTag("Chip"))
        {
            bool result = manipulationManager.SelectObject(other.gameObject);
            if (result)
            {
                // enable chip ui if selected
                uiManager.EnableChipUI();
            }
        }
    }

    // change active state of toolbar (called on imagetargetfound and imagetargetnotfound)
    public void SetActive()
    {
        isActive = !isActive;
    }

    public bool GetActive()
    {
        return isActive;
    }
}
