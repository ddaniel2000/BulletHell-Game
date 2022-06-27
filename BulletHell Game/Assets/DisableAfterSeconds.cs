using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableAfterSeconds : MonoBehaviour
{
    private bool startCoroutine = false;
    public float disblerTime = 2f;
    // Start is called before the first frame update
    void Start()
    {
        startCoroutine = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (startCoroutine == true)
        {
            StartCoroutine(Disable());
        } 
            
    }
    public void DisableGameObject()
    {
        startCoroutine = true;
    }

    IEnumerator Disable()
    {
        yield return new WaitForSeconds(disblerTime);
        gameObject.SetActive(false);
    }
}
