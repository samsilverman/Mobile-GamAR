using UnityEngine;
using UnityEngine.UI;

public class JackUIManager : MonoBehaviour
{
    public GameObject ballUI;
    public GameObject jacksUI;

    public GameObject leftButton;
    public GameObject rightButton;

    public Text jackCountText;

    private void Start()
    {
        // disable all UIs at start
        DisableMoveUI();
        DisableBallUI();
        DisableJacksUI();
    }

    public void EnableMoveUI()
    {
        leftButton.SetActive(true);
        rightButton.SetActive(true);
    }

    public void DisableMoveUI()
    {
        leftButton.SetActive(false);
        rightButton.SetActive(false);
    }

    public void EnableBallUI()
    {
        ballUI.SetActive(true);
        DisableJacksUI();
    }

    public void DisableBallUI()
    {
        ballUI.SetActive(false);
    }

    public void EnableJacksUI()
    {
        DisableBallUI();
        ClearJackLabel();
        jacksUI.SetActive(true);
    }

    public void DisableJacksUI()
    {
        ClearJackLabel();
        jacksUI.SetActive(false);
    }

    public void UpdateJackLabel(int count)
    {
        jackCountText.text = "(" + count.ToString() + ")";
    }

    private void ClearJackLabel()
    {
        jackCountText.text = "";
    }
}
