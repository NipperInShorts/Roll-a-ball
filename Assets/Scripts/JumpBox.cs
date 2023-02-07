using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBox : MonoBehaviour
{
    public float jumpForce = 20f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody rbPlayer = other.GetComponent<Rigidbody>();

            rbPlayer.AddForce(other.transform.up * jumpForce, ForceMode.Impulse);
        }
    }
}
