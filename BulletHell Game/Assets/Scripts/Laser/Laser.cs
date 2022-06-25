using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public GameObject bullet;
    public Transform player;
    public Vector3 direction;
    public GameObject shootPoint;

    public float timeBeetweenShoots = 0.8f;

    private float delay;
    
    // Start is called before the first frame update
    void Start()
    {
        delay = timeBeetweenShoots;
    }

    // Update is called once per frame
    void Update()
    {
        direction = new Vector3 (player.position.x, 0, player.position.z);
        transform.LookAt(direction, Vector3.left);

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
        Instantiate(bullet, shootPoint.transform.position, shootPoint.transform.rotation);
    }
}
