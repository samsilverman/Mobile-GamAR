using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManipulationManager : MonoBehaviour
{
    GameObject selectedObject;

    public GameObject handToolbar;
    ToolbarManager toolbarManager;

    public DeckManager deckManager;
    public ChipCaseManager chipCaseManager;

    public Transform arCamera;

    bool isMoving;
    bool isRotating;
    bool isPeaking;

    private void Start()
    {
        DeSelectObject();

        toolbarManager = handToolbar.GetComponent<ToolbarManager>();
    }

    void Update()
    {
        if (selectedObject == null)
        {
            return;
        }

        if (isMoving)
        {
            if (!toolbarManager.GetActive())
            {
                return;
            }
            // y of 0 keeps going below surface... not sure why
            selectedObject.transform.position = new Vector3(
                toolbarManager.toolbarTip.position.x,
                0.01f,
                toolbarManager.toolbarTip.position.z);
        }

        else if (isRotating)
        {
            if (!toolbarManager.GetActive())
            {
                return;
            }

            Transform toolbarTip = toolbarManager.toolbarTip;
            selectedObject.transform.LookAt(toolbarTip);
            Quaternion rotation = selectedObject.transform.rotation;
            selectedObject.transform.rotation = new Quaternion(0, rotation.y, 0, rotation.w);
        }

        else if (isPeaking)
        {
            // TODO: Implement
        }
    }

    public bool SelectObject(GameObject gameObject)
    {
        if (selectedObject != null)
        {
            return false;
        }
        selectedObject = gameObject;
        return true;
    }

    public void DeSelectObject()
    {
        ClearManipulation();
        selectedObject = null;
    }

    public void MoveObject()
    {
        ClearManipulation();
        isMoving = !isMoving;
    }

    public void RotateObject()
    {
        ClearManipulation();
        isRotating = !isRotating;
    }

    public void FlipCard()
    {
        if (selectedObject == null || !selectedObject.CompareTag("Card"))
        {
            return;
        }
        ClearManipulation();
        selectedObject.transform.Rotate(new Vector3(0, 0, 180));

    }

    public void DiscardCard()
    {
        if (selectedObject == null || !selectedObject.CompareTag("Card"))
        {
            return;
        }
        ClearManipulation(); // might be repetitive
        deckManager.DiscardCard(selectedObject);
        DeSelectObject();
    }

    public void PeakCard()
    {
        if (selectedObject == null || !selectedObject.CompareTag("Card"))
        {
            return;
        }

        // TODO: Implement
    }

    public void DiscardChip()
    {
        if (selectedObject == null || !selectedObject.CompareTag("Chip"))
        {
            return;
        }
        ClearManipulation();
        chipCaseManager.DiscardChip(selectedObject);
        DeSelectObject();
    }

    public void ClearManipulation()
    {
        isMoving = false;
        isRotating = false;
        isPeaking = false;
    }

}
