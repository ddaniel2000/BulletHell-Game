using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShockWave : MonoBehaviour
{


    public float timer = 0f;
    public float growTime = 6f;
    public float maxSize = 3000f;

    public bool isMaxSize = false;
    private Vector3 startScale;
    private Vector3 maxScale;
    // Start is called before the first frame update
    void Start()
    {
        startScale = transform.localScale;
        maxScale = new Vector3(maxSize, maxSize, 2);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        transform.localScale = Vector3.Lerp(startScale, maxScale, timer / growTime);
        Object.Destroy(gameObject, 6f);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Shield")
        {
            Destroy(gameObject, 0.01f);
        }
    }

}
