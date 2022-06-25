using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Factory : MonoBehaviour
{
    void Awake()
    {
        Enemy<Boss> bigBoss = new Enemy<Boss>("BigBoss");
        bigBoss.ScriptComponent.Initialize(
            speed: 4,
            direction: Random.Range(0, 2) * 2 - 1,
            position: new Vector3(0f, 1.9f, 0f)
            );
    }
}
