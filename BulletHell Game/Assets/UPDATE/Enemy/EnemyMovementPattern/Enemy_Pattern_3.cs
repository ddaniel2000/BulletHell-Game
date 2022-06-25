using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Pattern_3 : MonoBehaviour
{
    private bool enableCoroutine = false;
    public GameObject player;

    public int xPos;
    public int zPos;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(nextPosition());
        enableCoroutine = true;
    }

    void Update()
    {
        if (enableCoroutine == true)
        {
            StartCoroutine(nextPosition());
        }
        transform.LookAt(new Vector3(player.transform.position.x, 1.9f, player.transform.position.z));
    }

    IEnumerator nextPosition()
    {
        enableCoroutine = false;
        xPos = Random.Range(-10, 10);
        zPos = Random.Range(-20, -2);
        int waitForNextPosition = Random.Range(4, 6);

        yield return new WaitForSeconds(waitForNextPosition);
        transform.position = new Vector3(xPos, 1.9f, zPos);
        enableCoroutine = true;

    }
}