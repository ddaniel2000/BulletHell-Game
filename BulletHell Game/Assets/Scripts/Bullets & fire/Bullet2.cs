using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet2 : MonoBehaviour
{
    private Vector2 moveDirection;
    private float moveSpeed;





    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 10f;

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(moveDirection * moveSpeed * 2 * Time.deltaTime);
        Object.Destroy(gameObject, 6f);
    }

    //void OnTriggerEnter(Collider other)
    //{
    //    if (other.tag == "Player")
    //    {
    //        player.GetComponent<Health>().ModifyHealth(-10);
    //        Debug.Log("DAMAGE");
    //    }
    //}



    public void SetMoveDirection(Vector2 dir)
    {
        moveDirection = dir;
    }



    private void OnDisable()
    {
        CancelInvoke();
    }
}
