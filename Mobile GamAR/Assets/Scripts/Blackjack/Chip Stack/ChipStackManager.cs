using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChipStackManager : MonoBehaviour
{
    float chipDistance = 0.003f;

    Stack<GameObject> chips;

    // Called on objects that are instantiated
    private void Awake()
    {
        chips = new Stack<GameObject>();
    }

    public void AddChipToStack(GameObject chip)
    {
        chip.transform.position = new Vector3(
            transform.position.x,
            transform.position.y + (chips.Count * chipDistance),
            transform.position.z);
        chips.Push(chip);
    }

    //TODO: Implement
    public void RemoveChipFromStack()
    {
        GameObject chip = chips.Pop();
        Destroy(chip);
        if (chips.Count == 0)
        {
            DeleteChipStack();
        }
    }

    public void DeleteChipStack()
    {
        foreach (GameObject chip in chips)
        {
            Destroy(chip);
        }
        Destroy(gameObject);
    }

    public int GetChipStackSize()
    {
        return chips.Count;
    }
}
