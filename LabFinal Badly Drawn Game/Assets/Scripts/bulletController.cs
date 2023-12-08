using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletController : MonoBehaviour
{
    private float bulletSpeed = 20f;

    void Update()
    {

        if (this.transform.position.x > 8 || this.transform.position.x < -8.2)
        {
            Destroy(this.gameObject);
        }

        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        Debug.Log(mousePos);
        Vector2 direction = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);
        direction.Normalize();

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogWarning("Rigidbody2D not found on bulletPrefab");
        }
        else
        {
            rb.AddForce(direction * bulletSpeed, ForceMode2D.Impulse);
        }
    }
}
