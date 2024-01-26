using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject topLeftTyre, topRightTyre, bottomLeftTyre, bottomRightTyre;
    private Rigidbody _carRb;

    private float speed = 100.0f, tyreRotationSpeed = 150.0f, rotationSpeedY = 10.0f;
    private float _brakeForce = 150.0f;

    // Start is called before the first frame update
    void Start()
    {
        _carRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveCar();
    }

    void MoveCar()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        //transform.Translate(Vector3.forward * verticalInput * speed * Time.deltaTime);
        _carRb.AddForce(transform.forward * verticalInput * speed);

        //transform.Translate(Vector3.right * horizontalInput * speed * Time.deltaTime);
        Quaternion deltaRotation = Quaternion.Euler(0, horizontalInput * rotationSpeedY * Time.deltaTime, 0);

        _carRb.MoveRotation(_carRb.rotation * deltaRotation);

        if (verticalInput != 0)
        {
            if (verticalInput > 0)
            {
                topLeftTyre.transform.Rotate(Vector3.right, tyreRotationSpeed * Time.deltaTime);
                topRightTyre.transform.Rotate(Vector3.right, tyreRotationSpeed * Time.deltaTime);
                bottomLeftTyre.transform.Rotate(Vector3.right, tyreRotationSpeed * Time.deltaTime);
                bottomRightTyre.transform.Rotate(Vector3.right, tyreRotationSpeed * Time.deltaTime);
            }
            else if (verticalInput < 0)
            {
                topLeftTyre.transform.Rotate(Vector3.right, -tyreRotationSpeed * Time.deltaTime);
                topRightTyre.transform.Rotate(Vector3.right, -tyreRotationSpeed * Time.deltaTime);
                bottomLeftTyre.transform.Rotate(Vector3.right, -tyreRotationSpeed * Time.deltaTime);
                bottomRightTyre.transform.Rotate(Vector3.right, -tyreRotationSpeed * Time.deltaTime);
            }
        }
        else if (horizontalInput != 0)
        {
            if (horizontalInput > 0)
            {
                topLeftTyre.transform.rotation = Quaternion.Euler(0f, 35f, 0f);
                topRightTyre.transform.rotation = Quaternion.Euler(0f, 35f, 0f);
            }
            else if (horizontalInput < 0)
            {
                topLeftTyre.transform.rotation = Quaternion.Euler(0f, -35f, 0f);
                topRightTyre.transform.rotation = Quaternion.Euler(0f, -35f, 0f);
            }
        }
    }
}
