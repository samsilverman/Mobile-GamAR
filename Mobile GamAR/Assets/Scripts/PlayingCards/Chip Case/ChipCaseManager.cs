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

    // amount of each chip to deal
    int whiteChipAmount;
    int redChipAmount;
    int greenChipAmount;
    int blueChipAmount;
    int blackChipAmount;

    List<GameObject> dealtWhiteChips;
    List<GameObject> dealtRedChips;
    List<GameObject> dealtGreenChips;
    List<GameObject> dealtBlueChips;
    List<GameObject> dealtBlackChips;

    // spacing between chips stacked
    float chipDistance = 0.003f;

    List<GameObject> collectedChips;

    GameObject discardedChip;

    private void Start()
    {
        dealtWhiteChips = new List<GameObject>();
        dealtRedChips = new List<GameObject>();
        dealtGreenChips = new List<GameObject>();
        dealtBlueChips = new List<GameObject>();
        dealtBlackChips = new List<GameObject>();

        collectedChips = new List<GameObject>();

        discardedChip = null;

        ClearChipAmounts();
    }

    private void Update()
    {
        // move chips towards chipCase
        if (collectedChips.Count > 0)
        {
            //create copy of collectedChips to allow removal without errors
            GameObject[] collectedChipsCopy = collectedChips.ToArray();

            foreach (GameObject collectedChip in collectedChipsCopy)
            {
                collectedChip.transform.position = Vector3.MoveTowards(collectedChip.transform.position, transform.position, Time.deltaTime);
                // remove collectedChip from collectedChips if at chipCase
                if (collectedChip.transform.position == transform.position)
                {
                    collectedChips.Remove(collectedChip);
                }
            }

            // remove all chips once at chipCase
            if (collectedChips.Count == 0)
            {
                GameObject[] chips = GameObject.FindGameObjectsWithTag("Chip");

                foreach (GameObject chip in chips)
                {
                    Destroy(chip);
                }
            }
        }

        if (dealtWhiteChips.Count > 0)
        {
            int doneChipsCount = 0;

            for (int i = 0; i < dealtWhiteChips.Count; i++)
            {
                Vector3 chipPosition = new Vector3(
                    whiteChipSpawnPoint.position.x,
                    whiteChipSpawnPoint.position.y + (i * chipDistance),
                    whiteChipSpawnPoint.position.z);
                dealtWhiteChips[i].transform.position = Vector3.MoveTowards(dealtWhiteChips[i].transform.position, chipPosition, Time.deltaTime);

                if (dealtWhiteChips[i].transform.position == chipPosition)
                {
                    doneChipsCount += 1;
                }
            }

            if (doneChipsCount == dealtWhiteChips.Count)
            {
                dealtWhiteChips = new List<GameObject>();
            }
        }

        if (dealtRedChips.Count > 0)
        {
            int doneChipsCount = 0;

            for (int i = 0; i < dealtRedChips.Count; i++)
            {
                Vector3 chipPosition = new Vector3(
                    redChipSpawnPoint.position.x,
                    redChipSpawnPoint.position.y + (i * chipDistance),
                    redChipSpawnPoint.position.z);
                dealtRedChips[i].transform.position = Vector3.MoveTowards(dealtRedChips[i].transform.position, chipPosition, Time.deltaTime);

                if (dealtRedChips[i].transform.position == chipPosition)
                {
                    doneChipsCount += 1;
                }
            }

            if (doneChipsCount == dealtRedChips.Count)
            {
                dealtRedChips = new List<GameObject>();
            }
        }

        if (dealtGreenChips.Count > 0)
        {
            int doneChipsCount = 0;

            for (int i = 0; i < dealtGreenChips.Count; i++)
            {
                Vector3 chipPosition = new Vector3(
                    greenChipSpawnPoint.position.x,
                    greenChipSpawnPoint.position.y + (i * chipDistance),
                    greenChipSpawnPoint.position.z);
                dealtGreenChips[i].transform.position = Vector3.MoveTowards(dealtGreenChips[i].transform.position, chipPosition, Time.deltaTime);

                if (dealtGreenChips[i].transform.position == chipPosition)
                {
                    doneChipsCount += 1;
                }
            }

            if (doneChipsCount == dealtGreenChips.Count)
            {
                dealtGreenChips = new List<GameObject>();
            }
        }

        if (dealtBlueChips.Count > 0)
        {
            int doneChipsCount = 0;

            for (int i = 0; i < dealtBlueChips.Count; i++)
            {
                Vector3 chipPosition = new Vector3(
                    blueChipSpawnPoint.position.x,
                    blueChipSpawnPoint.position.y + (i * chipDistance),
                    blueChipSpawnPoint.position.z);
                dealtBlueChips[i].transform.position = Vector3.MoveTowards(dealtBlueChips[i].transform.position, chipPosition, Time.deltaTime);

                if (dealtBlueChips[i].transform.position == chipPosition)
                {
                    doneChipsCount += 1;
                }
            }

            if (doneChipsCount == dealtBlueChips.Count)
            {
                dealtBlueChips = new List<GameObject>();
            }
        }

        if (dealtBlackChips.Count > 0)
        {
            int doneChipsCount = 0;

            for (int i = 0; i < dealtBlackChips.Count; i++)
            {
                Vector3 chipPosition = new Vector3(
                    blackChipSpawnPoint.position.x,
                    blackChipSpawnPoint.position.y + (i * chipDistance),
                    blackChipSpawnPoint.position.z);
                dealtBlackChips[i].transform.position = Vector3.MoveTowards(dealtBlackChips[i].transform.position, chipPosition, Time.deltaTime);

                if (dealtBlackChips[i].transform.position == chipPosition)
                {
                    doneChipsCount += 1;
                }
            }

            if (doneChipsCount == dealtBlackChips.Count)
            {
                dealtBlackChips = new List<GameObject>();
            }
        }

        if (discardedChip != null)
        {
            discardedChip.transform.position = Vector3.MoveTowards(discardedChip.transform.position, transform.position, Time.deltaTime);

            if (discardedChip.transform.position == transform.position)
            {
                Destroy(discardedChip);
                discardedChip = null;
            }
        }
    }

    public void CollectChips()
    {
        // add all chips in scene to collectedChips
        GameObject[] chips = GameObject.FindGameObjectsWithTag("Chip");
        foreach (GameObject chip in chips)
        {
            collectedChips.Add(chip);
        }
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
            GameObject chip = Instantiate(whiteChipPrefab, transform.position, transform.rotation, transform);
            chip.transform.Rotate(90f, 0f, 0f);
            dealtWhiteChips.Add(chip);
        }

        for (int i = 0; i < redChipAmount; i++)
        {
            GameObject chip = Instantiate(redChipPrefab, transform.position, transform.rotation, transform);
            chip.transform.Rotate(90f, 0f, 0f);
            dealtRedChips.Add(chip);
        }

        for (int i = 0; i < greenChipAmount; i++)
        {
            GameObject chip = Instantiate(greenChipPrefab, transform.position, transform.rotation, transform);
            chip.transform.Rotate(90f, 0f, 0f);
            dealtGreenChips.Add(chip);
        }

        for (int i = 0; i < blueChipAmount; i++)
        {
            GameObject chip = Instantiate(blueChipPrefab, transform.position, transform.rotation, transform);
            chip.transform.Rotate(90f, 0f, 0f);
            dealtBlueChips.Add(chip);
        }

        for (int i = 0; i < blackChipAmount; i++)
        {
            GameObject chip = Instantiate(blackChipPrefab, transform.position, transform.rotation, transform);
            chip.transform.Rotate(90f, 0f, 0f);
            dealtBlackChips.Add(chip);
        }

        ClearChipAmounts();
    }

    public void DiscardChip(GameObject chip)
    {
        discardedChip = chip;
    }
}
