using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public Wheel[] wheels;

    [Header("Car Specs")]

    public float wheelBase;
    public float rearTrack;
    public float turnRadius;

    [Header("Inputs")]

    public float VehicleSpeed = 0.5f;
    public float steerInput;

    public  float ackermannAngleLeft;
    public float ackermannAngleRight;

    void Update()
    {
        steerInput = Input.GetAxis("Horizontal");

        if (steerInput > 0)
        {
            ackermannAngleLeft = Mathf.Rad2Deg * Mathf.Atan(wheelBase / (turnRadius + (rearTrack / 2))) * steerInput;
            ackermannAngleRight = Mathf.Rad2Deg * Mathf.Atan(wheelBase / (turnRadius - (rearTrack / 2))) * steerInput;
        } 
        else if (steerInput<0)
        {
            ackermannAngleLeft = Mathf.Rad2Deg * Mathf.Atan(wheelBase / (turnRadius - (rearTrack / 2))) * steerInput;
            ackermannAngleRight = Mathf.Rad2Deg * Mathf.Atan(wheelBase / (turnRadius + (rearTrack / 2))) * steerInput;
        }
        else
        {
            ackermannAngleLeft = 0;
            ackermannAngleRight = 0;
        }

        foreach (Wheel w in wheels)
        {
            if (w.wheelFrontLeft)
            {
                w.steerAngle = ackermannAngleLeft;
                w.vehicleSpeed = VehicleSpeed;
            }
                         
            if (w.wheelFrontRight)
            {
                w.steerAngle = ackermannAngleRight;
                w.vehicleSpeed = VehicleSpeed;
            }

            if (w.wheelRearLeft)
            { 
                w.steerAngle = ackermannAngleRight *-1f;
                w.vehicleSpeed = VehicleSpeed;
            }

            if (w.wheelRearRight)
            {
                w.steerAngle = ackermannAngleLeft *-1f;
                w.vehicleSpeed = VehicleSpeed;
            }

        }
        
    }
}
