using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadialBulletPattern : MonoBehaviour
{
    //numbers of projectiles to shoot
    private int numberOfProjectiles = 18;

    //speed of the projectile
    public float projectileSpeed;
    //profab to spawn
    public GameObject bullet;

    //starting position of the bullet
    private Vector3 startPoint;
    //help us find the move direction
    private const float radius = 1f;

    public int timeBeetweenShoots = 1;
    private bool restartCoroutine = false;
 

    public float startAngle = 180f, endAngle = 270f;

    void Start()
    {
        StartCoroutine(ShootingPattern());
    }
    // Update is called once per frame

    void Update()
    {
        if (restartCoroutine == true)
        {
            StartCoroutine(ShootingPattern());
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

    IEnumerator ShootingPattern()
    {
        restartCoroutine = false;
        startPoint = transform.position;
        SpawnProjectile(numberOfProjectiles);
        yield return new WaitForSeconds(timeBeetweenShoots);

        restartCoroutine = true;
    }

}
