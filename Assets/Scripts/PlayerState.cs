using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerState :  MonoBehaviour
{
    public float health = 100;
    public float maxHealth;
    public float def = 0;
    public float damageTaken = 1;
    public int kill;
    public int maxKill = 20;
    public int multiplyer = 1;
    public TextMeshProUGUI multiply;
    public TextMeshProUGUI kelled;
    public TextMeshProUGUI revive;
    public PlayerController playerController;
    public GameObject gameOver;
    public GameObject reviveEffect;
    bool isDead;
    int reviveCount;

    public AudioClip getHit, arrowHit, magicHit;
    public AudioSource playerAudioSrc;
    void Start()
    {
        maxHealth = 100;
    }
    void Update()
    {
        if(health > maxHealth)
        {
            health = maxHealth;
        }
        revive.text = "POWER OF REVIVER: " + reviveCount;
        if (kill >= maxKill)
        {
            multiplyer++;
            reviveCount++;
            maxKill = maxKill + (multiplyer - 1) * 20;
            kill = 0;
        }
        kelled.text = kill + "/" + maxKill;
        
        playerController.isDeath = isDead;
        if (health < 0)
        {
            health = 0;
        }
        multiply.text = "x" + multiplyer;
        if (health == 0)
        {
            isDead = true;
            StartCoroutine(Death());
            Death();
        
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Arrow")
        {
           // Debug.Log("hit");
            health = health - 0.9f;// (damageTaken * (def/2));
            playerAudioSrc.PlayOneShot(arrowHit, 0.3f);
        }
        if (collision.gameObject.tag == "Magic")
        {
            // Debug.Log("hit");
            health = health - 0.9f;// (damageTaken * (def/2));
            playerAudioSrc.PlayOneShot(magicHit, 0.4f);
        }
        if (collision.gameObject.tag == "EnemyWeapon")
        {
           // Debug.Log("hit");
            health = health - 1.33f;// (damageTaken * (def/2));
            playerAudioSrc.PlayOneShot(getHit, 0.3f);
        }
        if (collision.gameObject.tag == "GiantWeapon")
        {
           // Debug.Log("hit");
            health = health - 1.5f;// (damageTaken * (def/2));
            playerAudioSrc.PlayOneShot(getHit, 0.3f);
        }
    }

    IEnumerator Death()
    {
        playerController.animator.SetBool("Death", true);
       
        yield return new WaitForSeconds(3);

        if (isDead == true)
        {
            if (reviveCount > 1)
            {
                StartCoroutine(Respawn());
            }
            else if (reviveCount <= 1)
            {
                StartCoroutine(GameOver());
            }
        }

    }
    
    IEnumerator Respawn()
    {
        reviveCount--;
        playerController.animator.SetBool("Revive", true);
        Instantiate(reviveEffect, transform.position, Quaternion.identity);
        playerController.animator.SetBool("Death", false);
        playerController.isDeath = false;
        isDead = false;
        health = maxHealth;
        yield return new WaitForSeconds(0.2f);
        playerController.animator.SetBool("Revive", false);
    }
    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(1f);
        gameOver.SetActive(true);
    }


}
