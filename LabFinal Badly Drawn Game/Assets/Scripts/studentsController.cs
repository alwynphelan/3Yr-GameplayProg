using UnityEngine;
using UnityEngine.AI;

public class studentsController : MonoBehaviour
{
    public GameObject[] target;
    private GameObject seat;

    public NavMeshAgent agent;

    public bool showPath;
    public bool showAhead;

    public bool seatTaken = false;
    public Vector2 targetPos;
    // Start is called before the first frame update
    void Start()
    {
        agent.speed = 3f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {      
        agent.SetDestination(targetPos);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == seat)
        {

        }
    }
}
