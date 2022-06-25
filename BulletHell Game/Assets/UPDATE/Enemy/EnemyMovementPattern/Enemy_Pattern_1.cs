using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Pattern_1 : MonoBehaviour
{
    public Transform[] waypoints;
    public Transform player;

    private float speed = 7f;
    private int waypointIndex;
    private float dist;
    private float time;

    // Start is called before the first frame update
    void Start()
    {
        waypointIndex = 0;
        transform.LookAt(waypoints[waypointIndex].position);
        time = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time > 20f && time < 40f)
        {

            dist = Vector3.Distance(transform.position, waypoints[waypointIndex].position);
            if (dist < 1f)
            {
                IncreaseIndexPatrol1();
            }
            transform.LookAt(waypoints[waypointIndex].position);
            Patrol1();

        }
    }

    void Patrol1()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void IncreaseIndexPatrol1()
    {
        waypointIndex++;

        if (waypointIndex >= waypoints.Length)
        {
            waypointIndex = 0;
        }
        transform.LookAt(waypoints[waypointIndex].position);
    }



}
