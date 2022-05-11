using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractableDetector : MonoBehaviour
{
    [SerializeField] private Camera playerCamera;
    Vector2 cameraCenterPoint;

    [SerializeField] private float INTERACTION_DETECTION_RADIUS = 15f;  //  Detection, but has to be in range of the objects themselves to interact with
    Interactable detectedInteractable;

    public Interactable DetectedInteractable
    {
        get { return detectedInteractable; }
    }

    private void Awake()
    {
        //cameraCenterPoint = new Vector2(playerCamera.pixelWidth / 2, playerCamera.pixelHeight / 2);
        cameraCenterPoint = new Vector2(Screen.width / 2, Screen.height / 2);
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

        if (Physics.Raycast(ray, out hit, INTERACTION_DETECTION_RADIUS))
        {
            detectedInteractable = hit.collider.GetComponent<Interactable>();

            //  Debug
            // if (detectedInteractable != null)
            // {
            //     float distanceBetweenPlayerAndInteractable = (detectedInteractable.gameObject.transform.position - transform.position).magnitude;

            //     Debug.Log(detectedInteractable.InteractionRadius + " " + distanceBetweenPlayerAndInteractable);

            //     if (detectedInteractable.InteractionRadius > distanceBetweenPlayerAndInteractable)
            //         Debug.Log("Interactable name: " + detectedInteractable.gameObject.name + ", NOT within interaction radius.");
            //     else
            //         Debug.Log("Interactable name: " + detectedInteractable.gameObject.name + ", within interaction radius.");
            // }
        }
    }
}
