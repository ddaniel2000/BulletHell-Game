using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Pattern_2 : MonoBehaviour
{
    public Transform player;
    public int timeBeetweenMoves = 4;

    private float time;
    private float speed = 7f;
    private bool restartCoroutine2 = false;

    Vector3 pointToMove;
    Vector3 playerPosition;



    // Start is called before the first frame update
    void Start()
    {
        restartCoroutine2 = true;
    }

    // Update is called once per frame
    void Update()
    {
        playerPosition = new Vector3(player.position.x, 1.9f, player.position.z);

        if (restartCoroutine2 == true)
        {
            StartCoroutine(Patrol2Coroutine());
        }
    }

    void Patrol2()
    {
        transform.position = Vector3.MoveTowards(transform.position, pointToMove, speed / 3);
    }

    IEnumerator Patrol2Coroutine()
    {
        restartCoroutine2 = false;
        pointToMove = playerPosition;
        transform.LookAt(pointToMove);
        yield return new WaitForSeconds(3f);
        Patrol2();

        yield return new WaitForSeconds(timeBeetweenMoves);
        restartCoroutine2 = true;

    }
}
