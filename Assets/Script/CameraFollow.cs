using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothTime = 0.3f;

    private Vector3 velocity = Vector3.zero;

    // Update is called once per frame
    void Update()
    {

        //transform.position = Vector3.SmoothDamp(transform.position, new Vector3(target.position.x - 30, target.position.y, target.position.z - 30), ref velocity, smoothTime);

        transform.position = new Vector3(target.position.x, 0f, target.position.z);
    }
}
