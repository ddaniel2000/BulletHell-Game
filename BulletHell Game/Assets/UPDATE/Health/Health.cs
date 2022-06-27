using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Health : MonoBehaviour
{


    [SerializeField]
    private int maxHealth = 100;

    public GameObject cam;
    public int currentHealth;
    private float time;
    public float timeBeetweenHits = 2f;
    public event Action<float> OnHealthPctChanged = delegate { };
    private bool canTakeDamage = false;

    private void OnEnable()
    {
        currentHealth = maxHealth;
    }

    public void ModifyHealth(int amount)
    {
        currentHealth += amount;

        float currentHealthPct = (float)currentHealth / (float)maxHealth;
        OnHealthPctChanged(currentHealthPct);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time < timeBeetweenHits)
        {
            canTakeDamage = true;
            time = 0f;
        }
        Debug.Log(currentHealth);

        if (currentHealth > 0)
        {
            gameObject.GetComponent<ThirdPersonMovement>().enabled = true;
            cam.GetComponent<rotatePointWithMouse>().enabled = true;
        }
        else if (currentHealth < 0)
        {
            gameObject.GetComponent<ThirdPersonMovement>().enabled = false;
            cam.GetComponent<rotatePointWithMouse>().enabled = false;
        }

        if (gameObject.transform.position.y < -6)
        {
            ModifyHealth(-1000);
        }
    }

    //void OnCollisionEnter(Collision collisionInfo)
    //{
    //    if (collisionInfo.collider.tag == "Bullet")
    //    {
    //        //Debug.Log("DAMAGED");
    //        ModifyHealth(-10);
    //    }
    //}
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet") ;
        {
            if (canTakeDamage == true)
            {
                ModifyHealth(-2);
                canTakeDamage = false;
            }

        }
    }

}
