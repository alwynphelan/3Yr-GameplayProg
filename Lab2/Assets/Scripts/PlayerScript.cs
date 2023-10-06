using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public GameObject bullet;
    public Transform firePoint;

    public float bulletTimer;
    public float bulletTimeMax = 0.02f;

    public GameObject follow;
    public GameObject enemy;

    private int timer;
    private int dashTimer;

    private void Update()
    {
        // Player movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(horizontalInput, verticalInput);
        GetComponent<Rigidbody2D>().velocity = movement * moveSpeed;

        bulletTimer -= Time.deltaTime;

        if (bulletTimer <= 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(bullet, firePoint.position, Quaternion.identity);
                bulletTimer = bulletTimeMax;
            }

        }

        if (timer > 0)
        {
            timer--;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Player collided with an enemy, trigger game over
            //this.transform.position = new Vector3(-2.5f, -2.5f, 0);
            if (timer == 0)
            {
                timer = 1500;
                GameManager.instance.Death();
            }
        }
        if (collision.gameObject.CompareTag("Health"))
        {
            FindAnyObjectByType<HealthScript>().respawn();
            FindAnyObjectByType<GameManager>().lifeIncrease();
        }
    }

}
