using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteractableDetector : MonoBehaviour
{
    //  Player
    [SerializeField] private GameObject playerModel;

    //  Camera
    [SerializeField] private Camera playerCamera;
    Vector2 cameraCenterPoint;

    //  Interaction
    [SerializeField] private float INTERACTION_DETECTION_RADIUS = 15f;  //  Detection, but has to be in range of the objects themselves to interact with
    Interactable detectedInteractable;

    //  UI elements
    [SerializeField] private InteractableNameLabel interactableNameLabel;


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
        Interactable placeholderInteractable;
        detectedInteractable = null;

        //  Cast a ray from camera to centre point of the screen
        Ray ray = playerCamera.ScreenPointToRay(cameraCenterPoint);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, INTERACTION_DETECTION_RADIUS))
        {
            placeholderInteractable = hit.collider.GetComponent<Interactable>();

            //  Debug
            if (placeholderInteractable != null)
            {
                float distanceBetweenPlayerAndInteractable = Vector3.Distance(placeholderInteractable.transform.position, playerModel.transform.position);
                //Debug.Log(detectedInteractable.InteractionRadius + " " + distanceBetweenPlayerAndInteractable);

                if (placeholderInteractable.InteractionRadius > distanceBetweenPlayerAndInteractable)
                {
                    //  Pass this interactable into the detectedInteractable property, so other classes can use it
                    detectedInteractable = placeholderInteractable;
                    interactableNameLabel.Appear(detectedInteractable);
                    //Debug.Log("Interactable name: " + detectedInteractable.gameObject.name + ", NOT within interaction radius.");
                }
                else
                {
                    interactableNameLabel.Disappear();
                    //Debug.Log("Interactable name: " + detectedInteractable.gameObject.name + ", within interaction radius.");
                }
            }
            else
                interactableNameLabel.Disappear();
        }
        else
            interactableNameLabel.Disappear();
    }
}
