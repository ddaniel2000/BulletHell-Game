using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{

    public GameObject turrete_1;
    public GameObject turrete_2;
    public GameObject laser_insideEnemy;
    public GameObject shockWave;
    public GameObject enemyTurrete;

    private float time;
    private float timeStart = 0f;

    public GameObject gameManager;
    // Start is called before the first frame update

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        time = gameManager.GetComponent<GameController>().time;

        //Debug.Log(time);

        if (time > 2f && time < 3f)
        {
            laser_insideEnemy.SetActive(true);

            turrete_1.SetActive(false);
            turrete_2.SetActive(false);
            shockWave.SetActive(false);
            enemyTurrete.SetActive(false); 

        }

        if (time > 26f && time < 27f)
        {

            turrete_2.SetActive(true);
            laser_insideEnemy.SetActive(false);

        }

        //------------------PATTERN 2 ----------
        if (time > 60f && time < 61f)
        {
            enemyTurrete.SetActive(true);

            turrete_1.SetActive(false);
            turrete_2.SetActive(false);
            laser_insideEnemy.SetActive(false);
            shockWave.SetActive(false);


        }

        //------------------PATTERN 3 ----------
        if (time > 120f && time < 121f)
        {
            shockWave.SetActive(true);

            turrete_1.SetActive(false);
            turrete_2.SetActive(false);
            laser_insideEnemy.SetActive(false);
            enemyTurrete.SetActive(false);


            //desactivate prev
        }

        //------------------PATTERN 3 ----------
        if (time > 160f)
        {

            time = timeStart;

            //desactivate prev
        }
    }
}
