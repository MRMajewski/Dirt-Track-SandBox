using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{

    public Transform target;
    public Vector3 offset;
    public Rigidbody vehicleRB;
    private Camera camera;

    public float speedMultiplier;
    public float ortoSizeDefault;


    public float smoothSpeed = 0.125f;

    private void Awake()
    {
        camera = this.gameObject.GetComponent<Camera>();
    }

    void LateUpdate()
    {
        Vector3 targetPosition = target.position + offset;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, targetPosition, smoothSpeed);

        transform.position = smoothPosition;

    }

    private void Update()
    {
        float speed = vehicleRB.velocity.magnitude;

        float targetViewSize = ortoSizeDefault + (speed *speedMultiplier);

        camera.fieldOfView = Mathf.Lerp(
            ortoSizeDefault,
            targetViewSize,
            smoothSpeed);

    }
}
