using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStopRocket : MonoBehaviour
{


    public GameObject playerObject;
    bool playerStopped;

    private float timeLeft;
    public float timeLimit = 0.3f;
    public float timeToDestroy = 0.1f;
    public bool timerOn = false;

    public GameObject warningSign;
    
    public GameObject rocket;

    void Start()
    {
        timeLeft = timeLimit;
    }
    void Update()
    {
        playerStopped = playerObject.GetComponent<ThirdPersonMovement>().isStationary;
        if (playerStopped == false)
        {
            timeLeft = timeLimit;
            

        }
        if (playerStopped == true && timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
        }

        if (timeLeft < 0)
        {
            StartCoroutine(SpawnRocket());
        }
        
    }

    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Player")
        {
            Debug.Log("MORT");
        }
    }

    IEnumerator SpawnRocket()
    {
        warningSign.SetActive(true);
        Instantiate(rocket, transform.position + new Vector3(0, 10, 0), Quaternion.identity);

        timeLeft = timeLimit;
        yield return new WaitForSeconds(timeLimit);
        warningSign.SetActive(false);
        playerStopped = false;
    }
}
