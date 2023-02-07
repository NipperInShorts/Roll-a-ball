using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [SerializeField] GameObject player;
    public float smoothSpeed = 0.125f;
    public Vector3 offset = new Vector3(0.0f, 5.5f, -10f);
    public float mouseLookHSpeed = 10.0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 endPosition = player.transform.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, endPosition, smoothSpeed);
        transform.position = smoothedPosition;

        if (Input.GetMouseButton(1))
        {
            Debug.Log("Camera look");
        }
    }
}
