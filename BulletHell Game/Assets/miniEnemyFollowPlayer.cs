using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class miniEnemyFollowPlayer : MonoBehaviour
{

    public float timer = 0f;
    public float growTime = 20f;
    public float maxSize = 1.5f;
    public float speed = 2f;
    public Rigidbody rb;
    public GameObject _player;

    public bool isMaxSize = false;
    private Vector3 startScale;
    private Vector3 maxScale;
    // Start is called before the first frame update
    void Start()
    {
        startScale = new Vector3(0, 0, 0);
        maxScale = new Vector3(maxSize, maxSize, maxSize);
        _player = GameObject.Find("Player");
        rb = gameObject.GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        transform.localScale = Vector3.Lerp(startScale, maxScale, growTime);

        if (rb.velocity.y == 0)
        {
            transform.LookAt(_player.transform.position);
            transform.position = Vector3.Lerp(transform.position, _player.transform.position, speed / 10);
        }
        
        Object.Destroy(gameObject, 9f);
    }

}
