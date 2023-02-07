using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerController : MonoBehaviour
{

    public float speed = 10f;
    public float jumpHeight = 10f;

    public TextMeshPro scoreText;

    private float score = 0;
    private float numberOfCollectibles = 0;

    private SphereCollider sphereCollider;
    private Rigidbody rb;
    
    
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        sphereCollider = gameObject.GetComponent<SphereCollider>();
        numberOfCollectibles = GameObject.FindObjectsOfType<Collectible>().Length;
    }

    private void Update()
    {
        if (IsGrounded() && Input.GetButtonDown("Jump")) {
            rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
        }      
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical);
        rb.AddForce(direction * speed);

    }

    private bool IsGrounded()
    {
        float extraHeightTest = .01f;
        bool hit = Physics.Raycast(sphereCollider.bounds.center, Vector3.down, sphereCollider.bounds.extents.y + extraHeightTest);
        Color rayColor;
        if (hit)
        {
            rayColor = Color.green;
        }
        else
        {
            rayColor = Color.red;
        }
        Debug.DrawRay(sphereCollider.bounds.center, Vector3.down * (sphereCollider.bounds.extents.y + extraHeightTest), rayColor);
        return hit;
    }

    public void CollectPickUp() {
        score++;
        scoreText.text = $"Score: {score}/{numberOfCollectibles}";
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Respawn")) {
            SceneManager.LoadScene(0);
        }

        if (other.CompareTag("Final")) {
           ShowScore();
        }
    }

    public void ShowScore() {
        scoreText.gameObject.SetActive(true);
    }
}
