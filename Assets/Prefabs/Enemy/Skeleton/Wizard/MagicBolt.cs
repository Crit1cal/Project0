using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicBolt : MonoBehaviour
{
    Rigidbody2D rb;
    public float velocity = 200;
    public Transform target;
    public SpriteRenderer fadeOut;

    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(MagicDsp());
    }

    void FixedUpdate()
    {
        rb.velocity = transform.up * velocity * Time.deltaTime;
        Vector3 direction = target.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
        rb.rotation = -angle;
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

    IEnumerator MagicDsp()
    {
        yield return new WaitForSeconds(1.5f);
        byte alpha = 255;
        alpha--;
        fadeOut.color = new Color32(255, 255, 255, alpha);
        yield return new WaitForSeconds(1.5f);
        Hit();
    }
}


