using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy<T> where T : Enemy
{
    public GameObject GameObject;
    public T ScriptComponent;

    public Enemy(string name)
    {
        GameObject = new GameObject(name);
        ScriptComponent = GameObject.AddComponent<T>();
    }
}


//abstract means a modifier for a function that need to be modified
public abstract class Enemy : MonoBehaviour
{
    public Rigidbody Body;
    public MeshFilter Mesh;
    public BoxCollider Collider;

    public int Speed;
    public int Direction;

    public GameObject Player;

    //protected = only classes that inherited from class enemy
    protected abstract void MovementPattern();

    void Awake()
    {
        //Add common components
        Body = gameObject.AddComponent<Rigidbody>();
        Mesh = gameObject.AddComponent<MeshFilter>();
        Collider = gameObject.AddComponent<BoxCollider>();

        //Set common mesh
        Mesh.mesh = Resources.Load<Mesh>("Boss");
        Body.collisionDetectionMode = CollisionDetectionMode.Continuous;

        gameObject.tag = "Enemy";
        //gameObject.layer = LayerMask.NameToLayer("Boss");
    }

    //Insert all unique values to be determined at instantiation here


    public virtual void Initialize(int speed, int direction, Vector3 position)
    {
        Speed = speed;
        Direction = direction;
        transform.position = position;
    }
}



public abstract class MiniBoss : Enemy
{

}