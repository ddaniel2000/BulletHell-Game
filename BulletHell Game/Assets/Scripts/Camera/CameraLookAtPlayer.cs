using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLookAtPlayer : MonoBehaviour
{
    public Transform player, cameraTransform;
    public float rorationSpeed;

    void Start()
    {
        
        Cursor.visible = false;
        
    }
    // Update is called once per frame
    void Update()
    {
        cameraTransform.LookAt(player);

        //transform.Rotate(0, rorationSpeed * Time.deltaTime, 0);
    }
}
