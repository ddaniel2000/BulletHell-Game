using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadialBulletPattern : MonoBehaviour
{
    //numbers of projectiles to shoot
    private int numberOfProjectiles1 = 18;
    private int numberOfProjectiles2 = 1000;
    //speed of the projectile
    public float projectileSpeed;
    //profab to spawn
    public GameObject bullet;

    //starting position of the bullet
    private Vector3 startPoint;
    //help us find the move direction
    private const float radius = 1f;

    public int timeBeetweenShoots = 1;
    private bool restartCoroutine1 = false;
    private bool restartCoroutine2 = false;

    public float startAngle = 180f, endAngle = 270f;

    void Start()
    {
        StartCoroutine(ShootingPattern1());
    }
    // Update is called once per frame

    void Update()
    {
        if (restartCoroutine1 == true)
        {
            StartCoroutine(ShootingPattern1());
        }
        if (restartCoroutine2 == true)
        {
            StartCoroutine(ShootingPattern2());
        }
    }
    private void SpawnProjectile(int _numberOfProjectiles)
    {
        float angleStep = (endAngle - startAngle) / _numberOfProjectiles;
        float angle = -90f;

        for (int i = 0; i <= _numberOfProjectiles - 1 ; i++)
        {
            float projectileDirXPosition = startPoint.x + Mathf.Sin((angle * Mathf.PI) / 180f) * radius;
            float projectileDirYPosition = startPoint.y + Mathf.Cos((angle * Mathf.PI) / 180f) * radius;

            Vector3 projectileVector = new Vector3(projectileDirXPosition, projectileDirYPosition, 0);
            Vector3 projectileMoveDirection = (projectileVector - startPoint).normalized * projectileSpeed;

            GameObject tmpObj = Instantiate(bullet, startPoint, Quaternion.identity);
            tmpObj.GetComponent<Rigidbody>().velocity = new Vector3(projectileMoveDirection.x, 0, projectileMoveDirection.y);

            angle += angleStep;
        }
    }

    IEnumerator ShootingPattern1()
    {
        restartCoroutine1 = false;
        startPoint = transform.position;
        SpawnProjectile(numberOfProjectiles1);
        yield return new WaitForSeconds(timeBeetweenShoots);

        restartCoroutine2 = true;
    }
    IEnumerator ShootingPattern2()
    {
        restartCoroutine2 = false;
        startPoint = transform.position;
        SpawnProjectile(numberOfProjectiles2);
        yield return new WaitForSeconds(timeBeetweenShoots );

        restartCoroutine1 = true;
    }
}
