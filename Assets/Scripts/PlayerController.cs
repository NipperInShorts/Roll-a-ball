using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerController : MonoBehaviour
{

    public float speed = 10f;

    private Rigidbody rb;
    private float score = 0;
    private float numberOfCollectibles = 0;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        numberOfCollectibles = GameObject.FindObjectsOfType<Collectible>().Length;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical);
        rb.AddForce(direction * speed);
    }

    public void CollectPickUp() {
        score++;

        Debug.Log($"Score:  {score}");
        Debug.Log($"Collections:  {numberOfCollectibles}");
        Debug.Log("Pickup Collected");
    }
}
