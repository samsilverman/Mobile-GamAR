using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChipCaseManager : MonoBehaviour
{
    public GameObject whiteChipPrefab;
    public GameObject redChipPrefab;
    public GameObject greenChipPrefab;
    public GameObject blueChipPrefab;
    public GameObject blackChipPrefab;

    public Transform whiteChipSpawnPoint;
    public Transform redChipSpawnPoint;
    public Transform greenChipSpawnPoint;
    public Transform blueChipSpawnPoint;
    public Transform blackChipSpawnPoint;

    int whiteChipAmount;
    int redChipAmount;
    int greenChipAmount;
    int blueChipAmount;
    int blackChipAmount;

    float chipDistance = 0.003f;

    private void Start()
    {
        ClearChipAmounts();
    }

    public void CollectChips()
    {
        GameObject[] chips = GameObject.FindGameObjectsWithTag("Chip");

        foreach (GameObject chip in chips)
        {
            Destroy(chip);
        }

        ClearChipAmounts();
    }

    public void IncreaseWhiteChipAmount()
    {
        whiteChipAmount += 1;
    }

    public void DecreaseWhiteChipAmount()
    {
        if (whiteChipAmount > 0)
        {
            whiteChipAmount -= 1;
        }
    }

    public int GetWhiteChipAmount()
    {
        return whiteChipAmount;
    }

    public void IncreaseRedChipAmount()
    {
        redChipAmount += 1;
    }

    public void DecreaseRedChipAmount()
    {
        if (redChipAmount > 0)
        {
            redChipAmount -= 1;
        }
    }

    public int GetRedChipAmount()
    {
        return redChipAmount;
    }

    public void IncreaseGreenChipAmount()
    {
        greenChipAmount += 1;
    }

    public void DecreaseGreenChipAmount()
    {
        if (greenChipAmount > 0)
        {
            greenChipAmount -= 1;
        }
    }

    public int GetGreenChipAmount()
    {
        return greenChipAmount;
    }

    public void IncreaseBlueChipAmount()
    {
        blueChipAmount += 1;
    }

    public void DecreaseBlueChipAmount()
    {
        if (blueChipAmount > 0)
        {
            blueChipAmount -= 1;
        }
    }

    public int GetBlueChipAmount()
    {
        return blueChipAmount;
    }

    public void IncreaseBlackChipAmount()
    {
        blackChipAmount += 1;
    }

    public void DecreaseBlackChipAmount()
    {
        if (blackChipAmount > 0)
        {
            blackChipAmount -= 1;
        }
    }

    public int GetBlackChipAmount()
    {
        return blackChipAmount;
    }

    public void ClearChipAmounts()
    {
        whiteChipAmount = 0;
        redChipAmount = 0;
        greenChipAmount = 0;
        blueChipAmount = 0;
        blackChipAmount = 0;
    }

    public void DealChips()
    {
        for (int i = 0; i < whiteChipAmount; i++)
        {
            Vector3 chipPosition = new Vector3(
                whiteChipSpawnPoint.position.x,
                whiteChipSpawnPoint.position.y + (i * chipDistance),
                whiteChipSpawnPoint.position.z);
            GameObject chip = Instantiate(whiteChipPrefab, chipPosition, whiteChipSpawnPoint.rotation, transform);
        }

        for (int i = 0; i < redChipAmount; i++)
        {
            Vector3 chipPosition = new Vector3(
                redChipSpawnPoint.position.x,
                redChipSpawnPoint.position.y + (i * chipDistance),
                redChipSpawnPoint.position.z);
            GameObject chip = Instantiate(redChipPrefab, chipPosition, redChipSpawnPoint.rotation, transform);
        }

        for (int i = 0; i < greenChipAmount; i++)
        {
            Vector3 chipPosition = new Vector3(
                greenChipSpawnPoint.position.x,
                greenChipSpawnPoint.position.y + (i * chipDistance),
                greenChipSpawnPoint.position.z);
            GameObject chip = Instantiate(greenChipPrefab, chipPosition, greenChipSpawnPoint.rotation, transform);
        }

        for (int i = 0; i < blueChipAmount; i++)
        {
            Vector3 chipPosition = new Vector3(
                blueChipSpawnPoint.position.x,
                blueChipSpawnPoint.position.y + (i * chipDistance),
                blueChipSpawnPoint.position.z);
            GameObject chip = Instantiate(blueChipPrefab, chipPosition, blueChipSpawnPoint.rotation, transform);
        }

        for (int i = 0; i < blackChipAmount; i++)
        {
            Vector3 chipPosition = new Vector3(
                blackChipSpawnPoint.position.x,
                blackChipSpawnPoint.position.y + (i * chipDistance),
                blackChipSpawnPoint.position.z);
            GameObject chip = Instantiate(blackChipPrefab, chipPosition, blackChipSpawnPoint.rotation, transform);
        }

        ClearChipAmounts();
    }
}
