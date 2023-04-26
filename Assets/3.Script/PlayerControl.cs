using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField]private Rigidbody player_r;
    [SerializeField]private float speed = 8f;
    private bool isUsingVelocity = false;

    // Start is called before the first frame update
    void Start()
    {
        player_r = transform.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Backspace)) {
            isUsingVelocity = !isUsingVelocity;
        }

        if (isUsingVelocity) {
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 value = new Vector3(x, 0, z) * speed;
            
            player_r.velocity = value;
        } else {
            if (Input.GetKey(KeyCode.W)) {
                player_r.AddForce(0, 0, speed);
            } else if (Input.GetKey(KeyCode.S)) {
                player_r.AddForce(0, 0, -speed);
            } else if (Input.GetKey(KeyCode.A)) {
                player_r.AddForce(-speed, 0, 0);
            } else if (Input.GetKey(KeyCode.D)) {
                player_r.AddForce(speed, 0, 0);
            }
        }

        
    }
}
