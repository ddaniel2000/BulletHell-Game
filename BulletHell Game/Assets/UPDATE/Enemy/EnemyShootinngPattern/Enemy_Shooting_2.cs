using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Shooting_2 : MonoBehaviour
{

    private float time;
    private float timeStart = 0f;
    public GameObject turrete_3;

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

            turrete_3.SetActive(true);
        }
        if (time > 60f)
        {
            turrete_3.SetActive(false);
            time = timeStart;
        }
    }
}
