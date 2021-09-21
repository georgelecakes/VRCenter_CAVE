using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{

    protected virtual void Awake()
    {
    }

    protected virtual void Start()
    {
    }

    protected virtual void Update()
    {
    }

    public abstract void OnInterest();
    public abstract void OnDeinterest();
    public abstract void OnSelect();
    public abstract void OnDeselect();

}
