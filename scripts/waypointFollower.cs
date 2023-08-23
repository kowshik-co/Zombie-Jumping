using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waypointFollower : MonoBehaviour
{
    [SerializeField] GameObject[] WP;
    int currentWP = 0;

    [SerializeField] float speed = 2f;


    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, WP[currentWP].transform.position) < .1f)
        {
            currentWP++;

            if(currentWP >= WP.Length)
            {
                currentWP = 0;
            }
        }

        transform.position = Vector3.MoveTowards(transform.position, WP[currentWP].transform.position, speed * Time.deltaTime);
    }
}
