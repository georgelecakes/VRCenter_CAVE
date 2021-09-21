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

        HandleInterest(interactable);

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
        //We are hitting nothing
        if (interactable == null)
        {
            if (interestObject != null)
            {
                interestObject.OnDeinterest();
                interestObject = null;
            }
            return;
        }
        //We are hitting something
        else
        {
            //We have something selected
            if(interactable == selectedObject)
            {
                //do nothing, this object is already selected
                return;
            }
        }

        //There was no prior object of interest
        if(!interestObject)
        {
            interestObject = interactable;
            interactable.OnInterest();
        }
        //We have a prior of interest and need to turn it off
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

    private void OnGUI()
    {
        GUILayout.BeginVertical();
        if (this.interestObject != null)
        {
            GUILayout.Label("Interest: " + this.interestObject.name);
        }
        else
        {
            GUILayout.Label("Interest: " + "None");
        }
        if (this.selectedObject != null)
        {
            GUILayout.Label("Selected: " + this.selectedObject.name);
        }
        else
        {
            GUILayout.Label("Selected: " + "None");
        }
        GUILayout.EndVertical();
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
            interestObject = null;
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
