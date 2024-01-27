using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    private Rigidbody playerRb;
    private Vector3 offset = new Vector3(0, 115, -400);
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = player.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 playerForward = (playerRb.velocity + playerRb.transform.forward).normalized;
        transform.position = Vector3.Lerp(transform.position, player.position + (player.transform.TransformVector(offset)) + playerForward * (-5f),
            speed * Time.deltaTime);
        transform.LookAt(player);
    }
}