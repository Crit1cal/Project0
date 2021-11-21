using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonArcherState : BaseAiEnemy
{
    public Animator skeleArcherAnim;
    public SpriteRenderer skeleArcherDestroy;
    public GameObject skeleArcherArrow;
    public Collider2D skeleArcherHitbox;
    public Collider2D skeleArcherBodyHitbox;
    public AudioClip Draw, Shoot, hit;
    public AudioSource skeletonSoundSrc;

    public float damageTaken = 1;
    public float defend = 1;
    public float skeleArcherHealth = 3;
    public float skeleArcherSpeed = 1.25f;
    public float skeleArcherRange = 6;
    public float skeleArcherFireRate = 2.334f;
    public float skeleArcherLOS = 8.5f;

    void Start()
    {
        audioSrc = skeletonSoundSrc;
        Attack1 = Draw;
        Attack2 = Shoot;

        skeletontype = "Archer";
        playerState = GameObject.FindWithTag("Player").GetComponent<PlayerState>();
        lineOFSite = skeleArcherLOS;
        enemyAnim = skeleArcherAnim;
        BodyhitBox = skeleArcherBodyHitbox;
        targetPlayer = GameObject.FindWithTag("Player");
        hitBox = skeleArcherHitbox;
        enemyDestroy = skeleArcherDestroy;
        health = skeleArcherHealth;
        speed = skeleArcherSpeed;
        range = skeleArcherRange;
        haveAProjectile = true;
        projectile = skeleArcherArrow;
        fireRate = skeleArcherFireRate;
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
        Gizmos.DrawWireSphere(transform.position, skeleArcherRange);
        Gizmos.DrawWireSphere(transform.position, skeleArcherLOS);
    }
}
