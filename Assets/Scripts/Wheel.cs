using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel : MonoBehaviour
{
    private Rigidbody rb;

    public bool wheelFrontLeft;
    public bool wheelFrontRight;
    public bool wheelRearLeft;
    public bool wheelRearRight;


    [Header("Suspension")]

    public float restLenght;
    public float springTravel;
    public float springStiffness;
    public float damperStiffness;

    private float minLength;
    private float maxLength;
    private float lastLength;
    private float springLength;
    private float springVelocity;
    private float springForce;
    private float damperForce;

    [Header("Wheel")]
    public float steerAngle;
    public float steerTime;

    public float wheelRadius;

    public float vehicleSpeed = 1.5f;

    private Vector3 suspensionForce;
    private Vector3 wheelVelocityLS; //local Space
    private float Fx;
    private float Fy;

    private float wheelAngle;
    private float wheelAngleXAxis;

    public Transform wheelObject;
    public Transform wheelObjectForRotation;

    void Start()
    {
        rb = transform.root.GetComponent<Rigidbody>();

        minLength = restLenght - springTravel;
        maxLength = restLenght + springTravel;
    }

     void Update()
    {
        wheelAngle = Mathf.Lerp(wheelAngle, steerAngle, steerTime * Time.deltaTime);
     
        transform.localRotation = Quaternion.Euler(Vector3.up * wheelAngle);
        wheelObject.localRotation = Quaternion.Euler(Vector3.up * wheelAngle);

        Debug.DrawRay(transform.position, -transform.up * (springLength + wheelRadius), Color.green);

        wheelObject.GetChild(0).Rotate(Vector3.right, rb.velocity.magnitude * 0.5f);       

    }

    void FixedUpdate()
    {
        if(Physics.Raycast(transform.position, -transform.up, out RaycastHit hit, maxLength + wheelRadius))
        {
            lastLength = springLength;

            springLength = hit.distance - wheelRadius;

            springLength = Mathf.Clamp(springLength, minLength, maxLength);
            springVelocity = (lastLength - springLength) / Time.fixedDeltaTime;
            springForce = springStiffness * (restLenght - springLength);
            damperForce = damperStiffness * springVelocity;

            suspensionForce = (springForce+damperForce) * transform.up;

            wheelVelocityLS = transform.InverseTransformDirection(rb.GetPointVelocity(hit.point));
            Fx = Input.GetAxis("Vertical") * vehicleSpeed * springForce;
            Fy = wheelVelocityLS.x * springForce;

            rb.AddForceAtPosition(suspensionForce +(Fx *transform.forward)+(Fy* -transform.right), hit.point);

            wheelObject.position = hit.point;
        }
    }
}
