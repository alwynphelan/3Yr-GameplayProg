using System.Collections.Generic;
using UnityEngine;

public class seatController : MonoBehaviour
{
    public List<GameObject> seats;
    public List<studentsController> students;
    private int[] seatIndexArray = new int[16];

    private void Start()
    {
        Invoke("AssignSeats", 1);
    }

    public void JumbleSeats()
    {
        for (int i = 0; i < seats.Count; i++)
        {
            seatIndexArray[i] = i;
        }

        for (int i = 0; i < 50;i++)
        {
            int first = Random.Range(0, 16);
            int second = Random.Range(0, 16);

            int temp = seatIndexArray[first];
            //if (first != second)
            {
                seatIndexArray[first] = seatIndexArray[second];
                seatIndexArray[second] = temp;
            }
            
        }
    }

    public void AssignSeats()
    {
        JumbleSeats();
        for (int i = 0; i < students.Count; i++)
        {
            students[i].targetPos = (seats[seatIndexArray[i]].transform.position);
        }
    }
}
