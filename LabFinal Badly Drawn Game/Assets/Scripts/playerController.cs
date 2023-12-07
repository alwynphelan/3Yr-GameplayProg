using UnityEngine;

public class playerController : MonoBehaviour
{
    public float moveSpeed = 10f;
    public GameObject bulletPrefab;

    public float bulletSpeed = 20f;

    private GameObject bullet;
    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(horizontalInput, verticalInput);
        GetComponent<Rigidbody2D>().velocity = movement * moveSpeed;

        if (Input.GetMouseButtonDown(0)) // Change this to your input method
        {
            Shoot();
        }

        if ( bullet == null )
        {
            return;
        }
        if (bullet.transform.position.x > 8 || bullet.transform.position.x < -8.2)
        {
            Destroy(bullet);
        }
    }

    void Shoot()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        Vector2 direction = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);
        direction.Normalize();

        bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(direction * bulletSpeed, ForceMode2D.Impulse);
    }
}
