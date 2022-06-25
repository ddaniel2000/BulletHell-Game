using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableAfterSeconds : MonoBehaviour
{
    private bool startCoroutine = false;
    // Start is called before the first frame update
    void Start()
    {
        startCoroutine = false;
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
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
    }
}
