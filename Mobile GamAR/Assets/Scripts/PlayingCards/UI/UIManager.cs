using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject DeckUI;
    public GameObject CardUI;
    public GameObject chipCaseUI;
    public GameObject chipUI;

    private ChipCaseManager chipCaseManager;
    public Text whiteChipText;
    public Text redChipText;
    public Text greenChipText;
    public Text blueChipText;
    public Text blackChipText;

    private void Start()
    {
        DisableDeckUI();
        DisableCardUI();
        DisableChipCaseUI();
        DisableChipUI();

        chipCaseManager = GameObject.FindGameObjectWithTag("Chip Case").GetComponent<ChipCaseManager>();
    }

    public void EnableDeckUI()
    {
        DeckUI.SetActive(true);
        DisableCardUI();
        DisableChipCaseUI();
        DisableChipUI();
    }

    public void DisableDeckUI()
    {
        DeckUI.SetActive(false);
    }

    public void EnableCardUI()
    {
        CardUI.SetActive(true);
        DisableDeckUI();
        DisableChipCaseUI();
        DisableChipUI();
    }

    public void DisableCardUI()
    {
        CardUI.SetActive(false);
    }

    public void EnableChipCaseUI()
    {
        chipCaseUI.SetActive(true);
        DisableDeckUI();
        DisableCardUI();
        DisableChipUI();

        chipCaseManager.ClearChipAmounts();
        UpdateChipUI();
    }

    public void DisableChipCaseUI()
    {
        chipCaseUI.SetActive(false);
    }

    public void EnableChipUI()
    {
        chipUI.SetActive(true);
        DisableDeckUI();
        DisableCardUI();
        DisableChipCaseUI();
    }

    public void DisableChipUI()
    {
        chipUI.SetActive(false);
    }

    public void UpdateChipUI()
    {
        whiteChipText.text = "White:\n" + chipCaseManager.GetWhiteChipAmount().ToString();
        redChipText.text = "Red:\n" + chipCaseManager.GetRedChipAmount().ToString();
        greenChipText.text = "Green:\n" + chipCaseManager.GetGreenChipAmount().ToString();
        blueChipText.text = "Blue:\n" + chipCaseManager.GetBlueChipAmount().ToString();
        blackChipText.text = "Black:\n" + chipCaseManager.GetBlackChipAmount().ToString();
    }
}
