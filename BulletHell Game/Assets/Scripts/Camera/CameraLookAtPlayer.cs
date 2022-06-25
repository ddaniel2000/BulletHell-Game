using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLookAtPlayer : MonoBehaviour
{
    public Transform player, cameraTransform;
    public float rorationSpeed;
    public Transform topDownView;
    public Transform thirdPersonView;
    public Transform viwePointForTopDown;


    private bool isUP;
    private bool isDown;
    public bool lookAtPlayer = true;



    float delay = 0.1f;

    void Start()
    {
        
        Cursor.visible = false;
        isDown = true;
        isUP = false;
        
    }
    // Update is called once per frame
    void Update()
    {

        if (lookAtPlayer == true)
        {
            cameraTransform.LookAt(player);
        }
        if (lookAtPlayer == false)
        {
            cameraTransform.LookAt(viwePointForTopDown);
        }
        

        if (Input.GetButtonDown("Switch") && isDown == true)
        {

            Debug.Log("TOP DOWN");
            transform.position = topDownView.transform.position;
            StartCoroutine(TopDownView());

        }
        if (Input.GetButtonDown("Switch") && isUP == true)
        {
            Debug.Log("THIRD PERSON");
            transform.position = thirdPersonView.transform.position;
            StartCoroutine(ThirdPersonView());

        }

        //transform.Rotate(0, rorationSpeed * Time.deltaTime, 0);
    }

    IEnumerator TopDownView()
    {
        
        yield return new WaitForSeconds(delay);
        isUP = true;
        isDown = false;
        lookAtPlayer = false;

    }

    IEnumerator ThirdPersonView()
    {
        
        yield return new WaitForSeconds(delay);
        isUP = false;
        isDown = true;
        lookAtPlayer = true;
    }
}
