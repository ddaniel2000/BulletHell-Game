using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Boss : Enemy
{


    void Start()
    {
        Collider.size = new Vector3(1, 2, 1);
        transform.localScale = new Vector3(3, 3, 3);
    }

    void FixedUpdate()
    {
        MovementPattern();
    }

    protected override void MovementPattern()
    {
        Body.velocity = new Vector3(1 * Direction, Body.velocity.y, 1 * Direction);

        if (Body.velocity.y == 0f)
        {
            Body.AddForce(new Vector3(1, 50, 1));
        }
    }
}
