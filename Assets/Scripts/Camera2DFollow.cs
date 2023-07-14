using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera2DFollow : MonoBehaviour
{
    public Transform player;
    public float x = 0;
    public float y = 1;
    public float z = -5;
    
    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + new Vector3(x, y, z);
    }
//    public Transform target;
//    public float smoothSpeed = 0.125f;
//    public Vector3 locationOffset;
//    public Vector3 rotationOffset;
//
//    void FixedUpdate()
//    {
//        Vector3 desiredPosition = target.position + target.rotation * locationOffset;
//        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
//        transform.position = smoothedPosition;
//
//        Quaternion desiredrotation = target.rotation * Quaternion.Euler(rotationOffset);
//        Quaternion smoothedrotation = Quaternion.Lerp(transform.rotation, desiredrotation, smoothSpeed);
//        transform.rotation = smoothedrotation;
//    }
}
