using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrows : MonoBehaviour
{
    Rigidbody2D rb;
    public float velocity = 200;
    public Transform target;

    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        Vector3 direction = target.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
        rb.rotation = -angle;
    }

    void FixedUpdate()
    {
        rb.velocity = transform.up * velocity * Time.deltaTime;
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "BlockMap")
        {
            Hit();
        }
        if (other.gameObject.tag == "Player")
        {
            Hit();
        }
        if (other.gameObject.tag == "PlayerWeapon")
        {
            Hit();
        }
    }
    void Hit()
    {
        Destroy(this.gameObject);
    }
}


