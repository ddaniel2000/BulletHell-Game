using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBullet : MonoBehaviour
{

    public float speed = 10f;
    // Start is called before the first frame update
    void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0f, 0f, speed * Time.deltaTime));
        Object.Destroy(gameObject, 3f);
    }
    //    void OnTriggerEnter(Collider other)
    //{
    //    if (other.tag == "Player")
    //    {
    //        Debug.Log("MORT");
    //    }
    //}
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Shield")
        {
            Destroy(gameObject, 0.01f);
        }
    }
}
