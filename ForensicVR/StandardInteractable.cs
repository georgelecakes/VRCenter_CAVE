using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardInteractable : Interactable
{
    public override void OnSelect()
    {
        foreach (MeshRenderer mr in meshRenderers)
        {
            foreach (Material mat in mr.materials)
            {
                mat.SetColor("_EmissionColor", this.selectedEmissionColor);
            }
        }
    }

    public override void OnDeselect()
    {
        foreach (MeshRenderer mr in meshRenderers)
        {
            foreach (Color color in defaultEmissionColors)
            {
                foreach (Material mat in mr.materials)
                {

                    mat.SetColor("_EmissionColor", color);
                }
            }
        }
    }

    public override void OnInterest()
    {
        foreach(MeshRenderer mr in meshRenderers)
        {
            foreach(Material mat in mr.materials)
            {
                mat.SetColor("_EmissionColor", this.interestEmissionColor);
            }
        }
    }

    public override void OnDeinterest()
    {
        foreach (MeshRenderer mr in meshRenderers)
        {
            foreach (Color color in defaultEmissionColors)
            {
                foreach (Material mat in mr.materials)
                {

                    mat.SetColor("_EmissionColor", color);
                }
            }
        }
    }

    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
    }
}
