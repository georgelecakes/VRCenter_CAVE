using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flystick : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(this.transform.position, this.transform.position + this.transform.forward * 20.0f);
    }
}
