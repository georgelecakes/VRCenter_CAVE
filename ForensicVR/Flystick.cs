using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flystick : MonoBehaviour
{

    Vector3 worldPoint = new Vector3();

    void Start()
    {
        
    }

    void Update()
    {
        PointAt();
    }

    protected void PointAt()
    {
        Vector2 mousePos = Input.mousePosition;
        worldPoint = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, Camera.main.nearClipPlane));
 
        this.transform.LookAt(worldPoint);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(this.transform.position, this.transform.position + this.transform.forward * 20.0f);

        Color temp = Gizmos.color;
        Gizmos.color = Color.cyan;
        Gizmos.DrawSphere(worldPoint, 0.1f);
        Gizmos.color = temp;

    }
}
