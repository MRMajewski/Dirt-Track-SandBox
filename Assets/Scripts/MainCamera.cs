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


    public bool IsGameStarted = false;

    public Transform cameraPositionMenu;
    public Transform cameraPositionGame;

    private void Awake()
    {
        camera = this.gameObject.GetComponent<Camera>();
        transform.position = cameraPositionMenu.transform.position;
        transform.rotation = cameraPositionMenu.transform.rotation;
    }

    private void Update()
    {
        FOVUpdate();
        if (IsGameStarted)
        {
            UpdatePosition();          
        }

        else
            CameraMovementInMainMenu();

    }

    private void FOVUpdate()
    {
        float speed = vehicleRB.velocity.magnitude;

        float targetViewSize = ortoSizeDefault + (speed * speedMultiplier);

        camera.fieldOfView = Mathf.Lerp(
            ortoSizeDefault,
            targetViewSize,
            smoothSpeed);
    }

    private void UpdatePosition()
    {
        Vector3 targetPosition = target.position + offset;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, targetPosition, smoothSpeed);

        transform.position = smoothPosition;
    }


    void CameraMovementInMainMenu()
    {
       // RotatingCamera();
    }

    private void RotatingCamera()
    {
        camera.transform.Rotate(0f, 0f, 0.1f);

    }

    public void switchCameraAngels()
    {

        StartCoroutine(switchCamera());

    }

    IEnumerator switchCamera()
    {
        var animSpeed = 1f;

        Vector3 pos = cameraPositionMenu.transform.position;
        Quaternion rot = cameraPositionMenu.transform.rotation;

        float progress = 0.0f;  //This value is used for LERP

        while (progress < 1.0f)
        {
            camera.transform.position = Vector3.Lerp(pos, cameraPositionGame.transform.position, progress);
            camera.transform.rotation = Quaternion.Lerp(rot, cameraPositionGame.transform.rotation, progress);
            yield return new WaitForEndOfFrame();
            progress += Time.deltaTime * animSpeed;
        }

        //Set final transform
        camera.transform.position = cameraPositionGame.transform.position;
        camera.transform.rotation = cameraPositionGame.transform.rotation;
    }

}
