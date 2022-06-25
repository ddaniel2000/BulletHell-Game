using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Shooting_3 : MonoBehaviour
{
    private float time;
    private float timeStart = 0f;
    public GameObject shock_Wave;

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
            shock_Wave.SetActive(true);

            //desactivate prev
        }

        //------------------PATTERN 3 ----------
        if (time > 60f)
        {
            shock_Wave.SetActive(false);
            time = timeStart;

            //desactivate prev
        }
    }
}
