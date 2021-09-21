using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flystick : MonoBehaviour
{
    Vector3 worldPointNear = new Vector3();
    Vector3 worldPointFar = new Vector3();

    void Start()
    {
        
    }

    void Update()
    {
        PointAt();
    }

    protected void PointAt()
    {
        Vector3 mousePosNear = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane);
        Vector3 mousePosFar = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.farClipPlane);

        worldPointNear = Camera.main.ScreenToWorldPoint(mousePosNear);
        worldPointFar = Camera.main.ScreenToWorldPoint(mousePosFar);
        this.transform.position = worldPointNear;
        this.transform.LookAt(worldPointFar);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(this.transform.position, this.transform.position + this.transform.forward * 20.0f);

        Color temp = Gizmos.color;
        Gizmos.color = Color.cyan;
        Gizmos.DrawSphere(worldPointNear, 0.1f);
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(worldPointFar, 0.1f);

        Gizmos.color = temp;

    }
}
