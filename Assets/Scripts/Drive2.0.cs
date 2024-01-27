using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelController : MonoBehaviour
{
    [SerializeField] WheelCollider frontRight, frontLeft, backRight, backLeft;

    [SerializeField] Transform frontRightMesh, frontLeftMesh, backRightMesh, backLeftMesh;

    public float acceleration = 700f, brakingForce = 500f, maxTurnAngle = 15f;

    private float _currentAcceleration = 0f, _currentBrakingForce = 0f, _currentTurnAngle = 0f;

    [SerializeField] private Camera mainCamera, hoodCamera;

    [SerializeField] private GameObject instructionsPanel;

    private void Start()
    {
        instructionsPanel.SetActive(true);

        StartCoroutine(SetInstructionsPanel());
    }

    private void FixedUpdate()
    {
        DriveCar();
        SwitchCamera();
    }

    /// <summary>
    /// "DriveCar" method controls all the functionalities related to car movements and braking
    /// </summary>
    void DriveCar()
    {
        Move();
        Steer();
        Brake();
    }

    void Steer()
    {
        _currentTurnAngle = maxTurnAngle * Input.GetAxis("Horizontal");

        frontRight.steerAngle = _currentTurnAngle;
        frontLeft.steerAngle = _currentTurnAngle;
    }

    void Move()
    {
        _currentAcceleration = acceleration * Input.GetAxis("Vertical");

        frontRight.motorTorque = _currentAcceleration;
        frontLeft.motorTorque = _currentAcceleration;

        UpdateWheelRotation(frontRight, frontRightMesh);
        UpdateWheelRotation(frontLeft, frontLeftMesh);
        UpdateWheelRotation(backRight, backRightMesh);
        UpdateWheelRotation(backLeft, backLeftMesh);
    }

    void Brake()
    {
        if (Input.GetKey(KeyCode.Space))
            _currentBrakingForce = brakingForce;
        else
            _currentBrakingForce = 0f;

        frontRight.brakeTorque = _currentBrakingForce;
        frontLeft.brakeTorque = _currentBrakingForce;
        backRight.brakeTorque = _currentBrakingForce;
        backLeft.brakeTorque = _currentBrakingForce;
    }

    void UpdateWheelRotation(WheelCollider col, Transform tr)
    {
        Vector3 position;
        Quaternion rotation;

        col.GetWorldPose(out position, out rotation);

        tr.position = position;
        tr.rotation = rotation;
    }

    void SwitchCamera()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            mainCamera.enabled = !mainCamera.enabled;
            hoodCamera.enabled = !hoodCamera.enabled;
        }
    }

    IEnumerator SetInstructionsPanel()
    {
        yield return new WaitForSeconds(3);
        instructionsPanel.SetActive(false);
    }
}
