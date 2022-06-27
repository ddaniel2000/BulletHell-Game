using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEneymiesTurrete : MonoBehaviour
{
    private bool restartCoroutine = true;
    [SerializeField] int timeBeetweenSpawns = 1;
    public GameObject miniEnemyPrefab;
    // Start is called before the first frame update
    void Start()
    {
        restartCoroutine = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (restartCoroutine == true)
            StartCoroutine(nextPosition());
    }


    IEnumerator nextPosition()
    {
        restartCoroutine = false;
        int xPos = Random.Range(-10, 10);
        int zPos = Random.Range(-20, -2);
        int waitForNextPosition = Random.Range(5, 15);
        transform.position = new Vector3(xPos, 10, zPos);
        Instantiate(miniEnemyPrefab, transform.position, transform.rotation);
        yield return new WaitForSeconds(timeBeetweenSpawns);
        restartCoroutine = true;

    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Shield"))
        {
            Destroy(this);
        }
    }
}
