using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 2f;
    private Transform player;
    public GameObject enemyPrefab;
    public float spawnInterval = 2f;

    private void Start()
    {
        InvokeRepeating("SpawnEnemy", 0f, spawnInterval);
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, transform.position, Quaternion.identity);
    }

    private void Update()
    {
        // Move towards the player
        Vector2 direction = (player.position - transform.position).normalized;
        GetComponent<Rigidbody2D>().velocity = direction * moveSpeed;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Enemy was hit by a bullet, destroy the enemy
            Destroy(gameObject);
        }
        if (collision.GetComponent<Collider>().CompareTag("Bullet"))
        {
            //example update score �.
            GameObject.Destroy(this.gameObject);
        }

    }
}
