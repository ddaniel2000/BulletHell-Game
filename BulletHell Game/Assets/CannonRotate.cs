using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonRotate : MonoBehaviour
{
    public GameObject player;

    void Update()
    {
        transform.LookAt(new Vector3(player.transform.position.x, 1.9f, transform.position.z));
    }
}
