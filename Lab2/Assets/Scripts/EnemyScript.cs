using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float moveSpeed;
    public GameObject enemyPrefab;
    public float spawnInterval = 2f;

    private void Start()
    {
    }

    private void Update()
    {
        // Move towards the player
        transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);
        if (transform.position.y < -4.5)
        {
            transform.position = new Vector3(transform.position.x, 5.5f, transform.position.z);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Bullet"))
        {
            //example update score ….
            GameObject.Destroy(this.gameObject);
            GameManager.instance.Scoring();
        }
    }

}
