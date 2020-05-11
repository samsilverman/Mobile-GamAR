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
    private int whiteChipAmount;
    private int redChipAmount;
    private int greenChipAmount;
    private int blueChipAmount;
    private int blackChipAmount;

    // Lists of dealt chips
    private List<GameObject> dealtWhiteChips;
    private List<GameObject> dealtRedChips;
    private List<GameObject> dealtGreenChips;
    private List<GameObject> dealtBlueChips;
    private List<GameObject> dealtBlackChips;

    // spacing between chips stacked
    private float chipDistance = 0.003f;

    // lists of chips to collect
    private List<GameObject> collectedChips;

    // individual chip to discard
    private GameObject discardedChip;

    private void Start()
    {
        // initalizations
        dealtWhiteChips = new List<GameObject>();
        dealtRedChips = new List<GameObject>();
        dealtGreenChips = new List<GameObject>();
        dealtBlueChips = new List<GameObject>();
        dealtBlackChips = new List<GameObject>();

        collectedChips = new List<GameObject>();

        discardedChip = null;

        // no chip to deal at start
        ClearChipAmounts();
    }

    private void Update()
    {
        // if there are chips to collect
        if (collectedChips.Count > 0)
        {
            // create copy of collectedChips to allow removal in loop without errors
            GameObject[] collectedChipsCopy = collectedChips.ToArray();

            // move each collected chip towards chip case (animation)
            foreach (GameObject collectedChip in collectedChipsCopy)
            {
                collectedChip.transform.position = Vector3.MoveTowards(collectedChip.transform.position, transform.position, Time.deltaTime);
                // if collected chip is at the chip case, remove from collectedChips (done animation)
                if (collectedChip.transform.position == transform.position)
                {
                    collectedChips.Remove(collectedChip);
                }
            }

            // if all collected chips are at the chip case
            if (collectedChips.Count == 0)
            {
                // remove all chips from game
                GameObject[] chips = GameObject.FindGameObjectsWithTag("Chip");

                foreach (GameObject chip in chips)
                {
                    Destroy(chip);
                }
            }
        }

        // if there are white chips to deal
        if (dealtWhiteChips.Count > 0)
        {
            // number of white chips in correct deal location
            int doneChipsCount = 0;

            // move each white chip to correct deal location
            for (int i = 0; i < dealtWhiteChips.Count; i++)
            {
                // deal position (allows for stacking)
                Vector3 chipPosition = new Vector3(
                    whiteChipSpawnPoint.position.x,
                    whiteChipSpawnPoint.position.y + (i * chipDistance),
                    whiteChipSpawnPoint.position.z);
                // (animation)
                dealtWhiteChips[i].transform.position = Vector3.MoveTowards(dealtWhiteChips[i].transform.position, chipPosition, Time.deltaTime);

                // if white chip in correct location, increment doneChipsCount 
                if (dealtWhiteChips[i].transform.position == chipPosition)
                {
                    doneChipsCount += 1;
                }
            }

            // if # of doneChipsCount equals # of chips to deal, then clear chips to deal (done animation)
            if (doneChipsCount == dealtWhiteChips.Count)
            {
                dealtWhiteChips = new List<GameObject>();
            }
        }

        // if there are red chips to deal... (same process as white chips to deal)
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

        // if there are green chips to deal... (same process as white chips to deal)
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

        // if there are blue chips to deal... (same process as white chips to deal)
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

        // if there are black chips to deal... (same process as white chips to deal)
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

        // if there is a chip to discard
        if (discardedChip != null)
        {
            // move chip to discard towards chip case (animation)
            discardedChip.transform.position = Vector3.MoveTowards(discardedChip.transform.position, transform.position, Time.deltaTime);

            // if chip to discard is at the chip case, remove from discardedChip (done animation)
            if (discardedChip.transform.position == transform.position)
            {
                // remove chip to discard from game
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
        // for each chip specified by their amount, add chip to game and add chip to specified dealtChips List for animation

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
