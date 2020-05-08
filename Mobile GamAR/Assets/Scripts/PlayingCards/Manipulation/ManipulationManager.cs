using UnityEngine;

public class ManipulationManager : MonoBehaviour
{
    private GameObject selectedObject;

    public GameObject handToolbar;
    private ToolbarManager toolbarManager;

    public DeckManager deckManager;
    public ChipCaseManager chipCaseManager;

    public Transform arCamera;

    private bool isMoving;
    private bool isRotating;

    private void Start()
    {
        // initalization
        toolbarManager = handToolbar.GetComponent<ToolbarManager>();

        // no object selected at start
        DeSelectObject();
    }

    private void Update()
    {
        // if an object is not selected, ignore
        if (selectedObject == null)
        {
            return;
        }

        // if moving an object...
        if (isMoving)
        {
            // ignore if toolbar is not active
            if (!toolbarManager.GetActive())
            {
                return;
            }
            // move object based off toolbar postion (keeping it level with surface)
            selectedObject.transform.position = new Vector3(
                toolbarManager.toolbarTip.position.x,
                0.01f,
                toolbarManager.toolbarTip.position.z);
        }

        // if object is rotating...
        else if (isRotating)
        {
            // ignore if toolbar is not active
            if (!toolbarManager.GetActive())
            {
                return;
            }

            // rotate object based off toolbar postion (keeping it level with surface)
            Transform toolbarTip = toolbarManager.toolbarTip;
            selectedObject.transform.LookAt(toolbarTip);
            Quaternion rotation = selectedObject.transform.rotation;
            selectedObject.transform.rotation = new Quaternion(0, rotation.y, 0, rotation.w);
        }
    }

    public bool SelectObject(GameObject gameObject)
    {
        // if another object is selected, ignore
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
        ClearManipulation();
        deckManager.DiscardCard(selectedObject);
        DeSelectObject();
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
    }
}
