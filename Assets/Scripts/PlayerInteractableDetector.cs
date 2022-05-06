using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractableDetector : MonoBehaviour
{
    [SerializeField] private Camera playerCamera;
    Vector2 cameraCenterPoint;

    private void Awake()
    {
        //cameraCenterPoint = new Vector2(playerCamera.pixelWidth / 2, playerCamera.pixelHeight / 2);
        cameraCenterPoint = new Vector2(Screen.width / 2, Screen.height / 2);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        DetectInteractable();
    }

    void DetectInteractable()
    {
        //  Cast a ray from camera to centre point of the screen
        Ray ray = playerCamera.ScreenPointToRay(cameraCenterPoint);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 10))
        {
            Debug.Log("ray hit");

            Interactable interactable = hit.collider.GetComponent<Interactable>();

            if (interactable != null)
            {
                Debug.Log("Interactable name: " + interactable.gameObject.name);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(Vector3.zero, Vector3.one * 90);
        Gizmos.DrawRay(playerCamera.ScreenPointToRay(cameraCenterPoint).origin,
            playerCamera.ScreenPointToRay(cameraCenterPoint).direction * 120);
    }
}
