using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Shooting_1 : MonoBehaviour
{

    public GameObject turrete_2;
    public GameObject laser_insideEnemy;

    private float time;
    private float timeStart = 0f;

    // Start is called before the first frame update
    void Start()
    {
        time = timeStart;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time > 0f && time < 0.1f)
        {
            //activate current
            laser_insideEnemy.SetActive(true);



        }
        if (time > 0f && time < 0.1f)
        {
            laser_insideEnemy.SetActive(true);

        }

        if (time > 20f && time < 20.1f)
        {
            turrete_2.SetActive(false);
            //laser_1.SetActive(true);
            //laser_2.SetActive(true);
        }
        if (time > 26f && time < 26.1f)
        {

            turrete_2.SetActive(true);
            laser_insideEnemy.SetActive(false);

        }

        if (time > 60f)
        {
            turrete_2.SetActive(false);
            laser_insideEnemy.SetActive(false);
            time = timeStart;
        }

    }
}
