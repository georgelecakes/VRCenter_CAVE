using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlystickInteractionManager : InteractionManager
{
    public Transform flystickBody = null;
    [SerializeField] LayerMask layerMask;
    [SerializeField] float raycastDistance = 50.0f;

    protected override void Update()
    {
        Interactable interactable = DetectInterest();

        if (interactable)
        {
            HandleInterest(interactable);
        }

        if(DetectSelection())
        {
            HandleSelection();
        }
    }

    public override Interactable DetectInterest()
    {
        Ray ray = new Ray(flystickBody.position,
                    flystickBody.forward);
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo, raycastDistance, layerMask))
        {
            Interactable interactable = hitInfo.collider.gameObject.GetComponent<Interactable>();
            if (interactable)
            {
                return interactable;
            }
        }
        return null;
    }

    public override bool DetectSelection()
    {
        if(Input.GetKeyUp(KeyCode.E))
        {
            return true;
        }
        return false;
    }

    public override void HandleInterest(Interactable interactable)
    {
        if(!interestObject)
        {
            interestObject = interactable;
            interactable.OnInterest();
        }
        else
        {
            if(interestObject != interactable)
            {
                interestObject.OnDeinterest();
                interestObject = interactable;
                interestObject.OnInterest();
            }
        }
    }

    public override void HandleSelection()
    {
        if(interestObject)
        {
            //Object is already selected, ignore
            if(interestObject == selectedObject)
            {
                return;
            }
            //New interactable is selected
            if (selectedObject)
            {
                selectedObject.OnDeselect();
            }

            selectedObject = interestObject;
            selectedObject.OnSelect();

        }
        //No object of interest, this is a reset to deselect
        else
        {
            if(selectedObject)
            {
                selectedObject.OnDeselect();
                selectedObject = null;
            }
        }
    }
}
