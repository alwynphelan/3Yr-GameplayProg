using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followerScript : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject player;
    private float distance;
    public float velocity = 2.0f;
    void Start()
    {
        player = GameObject.Find("PlayerEmpty/PlayerSprite");
    }

    // Update is called once per frame
    void Update()
    {
       transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, velocity * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            // Player collided with an enemy, trigger game over
            Destroy(this.gameObject);
            GameManager.instance.Scoring();
        }
    }
}
