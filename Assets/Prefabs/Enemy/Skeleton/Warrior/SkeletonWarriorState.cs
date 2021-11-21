using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonWarriorState : BaseAiEnemy
{
    public Animator skeleWarriorAnim;
    public SpriteRenderer skeleWarriorDestroy;
    public Collider2D skeleWarriorHitbox;
    public Collider2D skeleWarriorBodyHitbox;
    public AudioClip attack,hit;
    public AudioSource skeletonSoundSrc;

    public float damageTaken = 1;
    public float defend = 4;
    public float skeleWarriorHealth = 5;
    public float skeleWarriorSpeed = 1.25f;
    public float skeleWarriorRange = 0.65f;
    public float skeleWarriorFireRate = 2;
    public float skeleWarriorLOS = 2.5f;
    void Start()
    {
        Attack2 = attack;
        Attack1 = attack;
        audioSrc = skeletonSoundSrc;
        skeletontype = "Warrior";
        playerState = GameObject.FindWithTag("Player").GetComponent<PlayerState>();
        lineOFSite = skeleWarriorLOS;
        enemyAnim = skeleWarriorAnim;
        targetPlayer = GameObject.FindWithTag("Player");
        hitBox = skeleWarriorHitbox;
        BodyhitBox = skeleWarriorBodyHitbox;
        enemyDestroy = skeleWarriorDestroy;
        health = skeleWarriorHealth;
        speed = skeleWarriorSpeed;
        range = skeleWarriorRange;
        fireRate = skeleWarriorFireRate;
        haveAProjectile = false;

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerWeapon")
        {
            health = health - damageTaken;
            skeletonSoundSrc.PlayOneShot(hit, 0.6f);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, skeleWarriorRange);
        Gizmos.DrawWireSphere(transform.position, skeleWarriorLOS);
    }
}
