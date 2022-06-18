using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpRandomPosition : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(nextPosition());
    }

    IEnumerator nextPosition()
    {
        
        int xPos = Random.Range(-13, 13);
        int zPos = Random.Range(-13, 13);
        int waitForNextPosition = Random.Range(1, 3);

        yield return new WaitForSeconds(waitForNextPosition);
        transform.position = new Vector3(xPos , 0, zPos);
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            transform.position = new Vector3(100, 0, 0);
            StartCoroutine(nextPosition());
        }
    }
}
