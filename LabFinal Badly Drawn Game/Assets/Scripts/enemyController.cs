using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.UI.Image;

public class enemyController : MonoBehaviour
{
    public NavMeshAgent agent;
    public RaycastHit2D[] students;

    private float iter = 0;

    public GameObject enemy;
    public int hordeCount = 0;

    void Start()
    {
        students = new RaycastHit2D[16];
        transform.position = new Vector3(-5f, 7.53f, 0);

        agent.speed = 3.5f;
        iter = 2;
    }

    void FixedUpdate()
    {
        float shortest = Mathf.Infinity;
        int shortIndex = -1;
        int hit = Physics2D.CircleCast(transform.position, 30, new Vector2(0,0), new ContactFilter2D(), students, Mathf.Infinity);

        for (int i = 0; i < hit; i++)
        {
            if (students[i].collider.tag == "Student")
            {
                float dist = Vector2.Distance(this.transform.position, students[i].transform.position);
                if (dist < shortest)
                {
                    shortest = dist;
                    shortIndex = i;
                }
            }
        }

        if (shortIndex >= -2)
        {

            if (students[shortIndex].transform.position != null)
            {
                agent.SetDestination(students[shortIndex].transform.position);

            }
        }

        if (hordeCount >= 3)
        {
            GameManager.instance.gameLose();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            transform.position = new Vector3(-5f, 7.53f, 0);
            Destroy(collision.gameObject);
            GameManager.instance.Score();
        }
        if (collision.tag == "Student")
        {
            Destroy(collision.gameObject);
            Instantiate(this);
            hordeCount++;
        }
    }
}
