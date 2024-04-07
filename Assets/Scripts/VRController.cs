using UnityEngine;
using OculusSampleFramework;

public class VRController : MonoBehaviour
{
    public TeleportPoint teleportPoint;
    public OVRCameraRig cameraRig;

    public OVRRaycaster raycaster;
    public GameObject interactionPoint;

    public GameObject uiMenu;

    private void Update()
    {

        if (Input.GetButtonDown("Teleport"))
        {
            TeleportToLocation(teleportPoint);
        }

        if (Input.GetButtonDown("Interact"))
        {
            InteractWithObject();
        }

        if (Input.GetButtonDown("Menu"))
        {
            ToggleMenu();
        }
    }

    private void TeleportToLocation(TeleportPoint point)
    {
        if (point != null)
        {
            cameraRig.transform.position = point.transform.position;
        }
    }

    private void InteractWithObject()
    {
        RaycastHit hit;
        if (raycaster.Raycast(out hit))
        {
            GameObject hitObject = hit.collider.gameObject;
        }
    }

    private void ToggleMenu()
    {
        uiMenu.SetActive(!uiMenu.activeSelf);
    }
}
