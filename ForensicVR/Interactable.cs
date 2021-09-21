using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    [SerializeField]
    protected Color interestEmissionColor = Color.red;
    [SerializeField]
    protected Color selectedEmissionColor = Color.blue;
    [SerializeField]
    protected Color[] defaultEmissionColors;

    protected MeshRenderer[] meshRenderers;

    protected virtual void Awake()
    {
        meshRenderers = this.transform.GetComponentsInChildren<MeshRenderer>();
        InitDefaultEmissionColor();
    }

    protected void InitDefaultEmissionColor()
    {
        if ((meshRenderers != null) && meshRenderers.Length > 0)
        {
            defaultEmissionColors = new Color[meshRenderers.Length];
            for( int i = 0; i < meshRenderers.Length; i++)
            {
                defaultEmissionColors[i] = meshRenderers[i].material.GetColor("_EmissionColor");
            }
        }
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
