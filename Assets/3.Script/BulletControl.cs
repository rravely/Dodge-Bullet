using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour
{   
    private float speed = 5f;
    private Rigidbody bulletRigidbody;

    void Start() {
        bulletRigidbody = GetComponent<Rigidbody>();
        bulletRigidbody.velocity = transform.forward * speed;
    }

    void OnTriggerEnter(Collider collider) {
        if (collider.CompareTag("Wall")) {
            Destroy(gameObject);
        } else if (collider.CompareTag("Player")) {
            Debug.Log("플레이어 아파");
        }
    }


}
