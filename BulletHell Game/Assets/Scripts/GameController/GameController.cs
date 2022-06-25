using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public GameObject enemy;

    public float time;
    private float timeStart = 0f;

    public float startPattern_1 = 0f;
    public float endPattern_1 = 60f;
    public float startPattern_2 = 60.2f;
    public float endPattern_2 = 120f;
    public float startPattern_3 = 120.2f;
    public float endPattern_3 = 180f;


    // Start is called before the first frame update
    void Start()
    {
        time = timeStart;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (Input.GetButtonDown("Pattern_1"))
        {
            time = startPattern_1;

        }
        if (Input.GetButtonDown("Pattern_2"))
        {
            time = startPattern_2;
        }
        if (Input.GetButtonDown("Pattern_3"))
        {
            time = startPattern_3;
        }

        //Debug.Log(time);

        //Movement Pattern of the enemy

        //------------------PATTERN 1 ----------
        if (time > startPattern_1 && time < endPattern_1)
        {


            enemy.GetComponent<Enemy_Pattern_1>().enabled = true;
            enemy.GetComponent<Enemy_Pattern_2>().enabled = false;
            enemy.GetComponent<Enemy_Pattern_3>().enabled = false;
            //Debug.Log("PATTERN _ 1");

        }
        //------------------PATTERN 2 ----------
        if (time > startPattern_2 && time < endPattern_2)
        {

            enemy.GetComponent<Enemy_Pattern_1>().enabled = false;
            enemy.GetComponent<Enemy_Pattern_2>().enabled = true;
            enemy.GetComponent<Enemy_Pattern_3>().enabled = false;
            //Debug.Log("PATTERN _ 2");

        }

        //------------------PATTERN 3 ----------
        if (time > startPattern_3)
        { 

            enemy.GetComponent<Enemy_Pattern_1>().enabled = false;
            enemy.GetComponent<Enemy_Pattern_2>().enabled = false;
            enemy.GetComponent<Enemy_Pattern_3>().enabled = true;
            if (time > endPattern_3)
            {
                time = timeStart;
            }
            //Debug.Log("PATTERN _ 3");

        }

        

       

    }

}
