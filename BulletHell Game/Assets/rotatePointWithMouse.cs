using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotatePointWithMouse : MonoBehaviour
{
    public Vector2 turn;
    public GameObject codeOfCamera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        turn.x += Input.GetAxis("Mouse X");
        turn.y += Input.GetAxis("Mouse Y");
        //turn.x = Mathf.Clamp(turn.x, -38, 38);

        // dezactivate the rotation of the camrea when is topDownView because is destubing
        if (codeOfCamera.GetComponent<CameraLookAtPlayer>().lookAtPlayer == true)
        {
            transform.localRotation = Quaternion.Euler(/*turn.y*/ 0, turn.x, 0);
        }


    }
}
