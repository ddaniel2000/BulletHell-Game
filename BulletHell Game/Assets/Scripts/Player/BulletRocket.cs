using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletRocket : MonoBehaviour
{
    public float timeUntilDestroy = 0.3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Object.Destroy(gameObject, timeUntilDestroy);
    }
    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Player")
        {
            Debug.Log("MORT");
        }
    }
}
