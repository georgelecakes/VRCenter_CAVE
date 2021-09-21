using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInteractionManager : FlystickInteractionManager
{
    Vector3 worldPointNear = new Vector3();
    Vector3 worldPointFar = new Vector3();

    public override Interactable DetectInterest()
    {
        //Use Mouse to sample locations in space and emulate the flystick in the CAVE
        Vector3 mousePosNear = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane);
        Vector3 mousePosFar = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.farClipPlane);

        worldPointNear = Camera.main.ScreenToWorldPoint(mousePosNear);
        worldPointFar = Camera.main.ScreenToWorldPoint(mousePosFar);
        this.transform.position = worldPointNear;
        this.transform.LookAt(worldPointFar);

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
}
