using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractionManager : MonoBehaviour
{
    protected Interactable interestObject = null;
    protected Interactable selectedObject = null;

    //Handles how interest is detected
    public abstract Interactable DetectInterest();

    public abstract void HandleInterest(Interactable iteractable);

    //Handles determining if a user has tried to make a selection
    public abstract bool DetectSelection();

    //Handles after a selection is detected with detect selection
    public abstract void HandleSelection();

    protected virtual void Start()
    {
    }

    protected virtual void Update()
    {
    }
}
