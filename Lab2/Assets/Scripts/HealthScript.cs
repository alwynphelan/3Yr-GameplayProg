using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    public float randX;
    public float randY;
    private float respawnTime;
    // Start is called before the first frame update
    void Start()
    {
        randX = Random.Range(-3.51f, 9.32f);
        randY = Random.Range(-3.32f, 4.31f);

        Vector3 newPosition = new Vector3(randX, randY, transform.position.z);
        transform.position = newPosition;
    }

    private void Update()
    {
        respawnTime += .00001f;
    }
    // Update is called once per frame
    public void respawn()
    {
        transform.position = new Vector3(5f, 5f, transform.position.z);
        randX = Random.Range(-3.22f, 8.78f);
        randY = Random.Range(-2.82f, 3.61f);

        Vector3 newPosition = new Vector3(randX, randY, transform.position.z);
        transform.position = newPosition;
        respawnTime = 0f;

    }
}
