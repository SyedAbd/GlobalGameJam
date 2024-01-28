using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointTrack : MonoBehaviour
{
    [SerializeField] int Checkpoints = 0;
    private List<string> triggeredCheckpoints = new List<string>();

    // Start is called before the first frame update
    void Start()
    {

    }

    private void FixedUpdate()
    {
        if (Checkpoints == 9)
        {
            // End game here
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the checkpoint has not been triggered before
        if (!triggeredCheckpoints.Contains(other.tag))
        {
            Checkpoints++;
            triggeredCheckpoints.Add(other.tag);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
