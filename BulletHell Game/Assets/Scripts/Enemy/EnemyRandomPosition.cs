using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRandomPosition : MonoBehaviour
{
    Animator bossAnim;
    public Transform target;
    public float bossSpeed;
    bool enableAct = true;
    int atkStep;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        bossAnim = GetComponent<Animator>();
        enableAct = true;

        rb = GetComponent<Rigidbody>();

    }

    void FixedUpdate()
    {
        rb.velocity = bossSpeed * transform.forward;
        //Debug.Log(rb.velocity);
    }

    void RotateBoss()
    {
        Vector3 direction = target.position - transform.position;

        transform.localRotation =
            Quaternion.Slerp(transform.localRotation,
            Quaternion.LookRotation(direction), 5 * Time.deltaTime);
    }

    void MoveBoss()
    {
        if ((target.position - transform.position).magnitude >= 10)
        {
            bossAnim.SetBool("Walk", true);
            rb.AddForce(transform.forward * bossSpeed);

        }

        if ((target.position - transform.position).magnitude < 10)
        {
            bossAnim.SetBool("Walk", false);
        }
    }



    // Update is called once per frame
    void Update()
    {
        RotateBoss();
        if (enableAct == true)
        {
            MoveBoss();

        }
    }

    void BossAttak()
    {
        if ((target.position - transform.position).magnitude < 10)
        {
            switch (atkStep)
            {
                case 0:
                    atkStep += 1;
                    bossAnim.Play("Spell_Projectile");
                    break;
                case 1:
                    atkStep += 1;
                    bossAnim.Play("Spell_DeployDrones");
                    break;
                case 2:
                    atkStep += 1;
                    bossAnim.Play("Spell_Laser");
                    break;
                case 3:
                    atkStep += 1;
                    bossAnim.Play("Spell_ShockWave");
                    break;

            }
        }
    }

    void FreezeBoss()
    {
        enableAct = false;
    }

    void UnFreezeBoss()
    {
        enableAct = true;
    }



}

