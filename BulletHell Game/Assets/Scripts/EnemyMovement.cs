using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float movementSpeed = 20f;
    public float rotationSpeed = 20f;

    private bool isWandering= false;
    private bool isRotationLeft = false;
    private bool isRotationRight = false;
    private bool isWalking = false;

    Rigidbody rb;
        
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    void Update()
    {
        if(isWandering == false)
        {
            StartCoroutine(Wonder());
        }

        if (isRotationRight == true)
        {
            transform.Rotate(transform.up * Time.deltaTime * rotationSpeed);
        }

        if (isRotationLeft == true)
        {
            transform.Rotate(transform.up * Time.deltaTime * -rotationSpeed);
        }

        if (isWalking == true)
        {
            rb.AddForce(transform.forward * movementSpeed);
        }
    }


    IEnumerator Wonder()
    {
        int rotationTime = Random.Range(1, 3);
        int rotateWait = Random.Range(1, 2);
        int rotateDirection = Random.Range(2, 10);
        int walkWait = Random.Range(1, 2);
        int walkTime = Random.Range(1, 10);

        isWandering = true;

        yield return new WaitForSeconds(walkWait);

        isWalking = true;

        yield return new WaitForSeconds(walkTime);

        isWalking = false;

        yield return new WaitForSeconds(rotateWait);

        if (rotateDirection == 1)
        {
            isRotationLeft = true;
            yield return new WaitForSeconds(rotationTime);
            isRotationLeft = false;
        }
        if (rotateDirection == 1)
        {
            isRotationRight = true;
            yield return new WaitForSeconds(rotationTime);
            isRotationRight = false;
        }

        isWandering = false;

    }
}
