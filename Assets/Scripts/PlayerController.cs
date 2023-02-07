using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horiz = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        float verti = Input.GetAxis("Vertical") * Time.deltaTime * speed;
        Vector3 direction = new Vector3(horiz, 0f, verti);
        transform.Translate(direction);
    }
}
