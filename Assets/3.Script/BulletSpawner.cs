using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    [SerializeField]private float rotateSpeed = 10f; 
    [SerializeField]private float maxAngle, minAngle;
    private bool direction = true;

    //GameObject
    private GameObject player;
    [SerializeField]private GameObject bulletPrefab;

    //Spawn time
    float timeSpawn = 0f;
    float spawnRate = 2f;

    void Start() {
        player = GameObject.FindWithTag("Player");
    }

    void Update() {
        Rotate();
        RaycastPlayer();
    }

    void Rotate() {
        if (transform.eulerAngles.y > maxAngle - 1) {
            direction = false;
        }
        else if (transform.eulerAngles.y < minAngle + 1) {
            direction = true;
        }
        if (direction) {
            transform.Rotate(0, Time.deltaTime * rotateSpeed, 0f);
        } else {
            transform.Rotate(0, -Time.deltaTime * rotateSpeed, 0f);
        }
    }

    void RaycastPlayer() {
        timeSpawn += Time.deltaTime;

        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit rayObject)) {
            if (rayObject.collider.tag.Equals("Player") && timeSpawn > spawnRate) {
                //총알 생성하기
                GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
                bullet.transform.LookAt(player.transform);

                timeSpawn = 0f; //생성함 표시
            }
        }
        Debug.DrawRay(transform.position, transform.forward * 10f, Color.red);
    }
}
