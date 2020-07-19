using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;

    public float smoothSpeed = 10f;

    public bool b_useAutoOffset = true;

    private Vector3 velocity;

    void Start()
    {
        if(b_useAutoOffset)
            offset = transform.position - target.position;
    }

    void LateUpdate()
    {
        if (target == null)
        {
            Debug.LogError("No target assigned");
            return;
        }

        Vector3 desiredPosition = target.position + offset;
        //Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;
    }
}
