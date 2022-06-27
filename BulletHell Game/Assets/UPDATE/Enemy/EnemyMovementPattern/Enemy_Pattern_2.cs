using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Pattern_2 : MonoBehaviour
{
    public GameObject player;
    public int timeBeetweenMoves = 3;

    private float speed = 5f;
    private bool restartCoroutine2 = false;
    private Vector3 playerLastPos;
    public CameraShake cameraShake;


    // Start is called before the first frame update
    void Start()
    {
        restartCoroutine2 = true;
    }

    // Update is called once per frame
    void Update()
    {
        

        if (restartCoroutine2 == true)
        {
            StartCoroutine(Pattern2());
        }
        
        
    }


    IEnumerator Pattern2()
    {
        restartCoroutine2 = false;
        yield return new WaitForSeconds(timeBeetweenMoves);
        transform.LookAt(new Vector3(player.transform.position.x, 1.9f, player.transform.position.z));
        playerLastPos = new Vector3(player.transform.position.x, 1.9f, player.transform.position.z);
        yield return new WaitForSeconds(timeBeetweenMoves / 2);
        transform.position = Vector3.Lerp(transform.position, playerLastPos, speed);
        StartCoroutine(cameraShake.Shaking());


        restartCoroutine2 = true;
    }
}
