using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Vector3 centrePoint;
    public float smoothSpeed = 0.125f;
    public Vector3 campos;
    public Transform target;
    public Vector2 limitPos;
    void Start()
    {
        Vector2 centrePoint = new Vector2 (0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        campos.x = Mathf.Clamp(centrePoint.x + ((target.position.x - centrePoint.x) / 2.2f), -limitPos.x, limitPos.x);
        campos.y = Mathf.Clamp(centrePoint.y + ((target.position.y - centrePoint.x )/ 2.2f), -limitPos.y, limitPos.y);
        campos.z = -10;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, campos, smoothSpeed);
        transform.position = smoothedPosition;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, limitPos);
    }
}
