using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShockWaveShoot : MonoBehaviour
{
    public GameObject shockWaveBullet;
    public GameObject shootPoint;

    public float timeBeetweenShoots = 1f;
    private float delay;

    // Start is called before the first frame update
    void Start()
    {
        delay = timeBeetweenShoots;
    }

    // Update is called once per frame
    void Update()
    {

        delay -= Time.deltaTime;
        if (delay < 0)
        {
            Shoot();
            delay = timeBeetweenShoots;
        }
        // Debug.Log(delay);
    }

    public void Shoot()
    {
        Instantiate(shockWaveBullet, shootPoint.transform.position, shootPoint.transform.rotation);
    }


}
