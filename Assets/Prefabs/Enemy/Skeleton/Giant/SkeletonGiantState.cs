using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonGiantState : BaseAiEnemy
{
    public Animator skeleGiantAnim;
    public SpriteRenderer skeleGiantDestroy;
    public Collider2D skeleGiantHitbox;
    public Collider2D skeleGiantBodyHitbox;
    public AudioClip swing1, swing2, hit;
    public AudioSource skeletonSoundSrc;

    public float damageTaken = 1f;
    public float defend = 1;
    public float skeleGiantHealth = 6;
    public float skeleGiantSpeed = 0.5f;
    public float skeleGiantRange = 2;
    public float skeleGiantFireRate = 3;
    public float skeleGiantLOS = 3;
   

    void Start()
    {
        skeletontype = "Giant";
        playerState = GameObject.FindWithTag("Player").GetComponent<PlayerState>();
        lineOFSite = skeleGiantLOS;
        Attack1 = swing1;
        Attack2 = swing2;
        audioSrc = skeletonSoundSrc;
        enemyAnim = skeleGiantAnim;
        targetPlayer = GameObject.FindWithTag("Player");
        hitBox = skeleGiantHitbox;
        BodyhitBox = skeleGiantBodyHitbox;
        enemyDestroy = skeleGiantDestroy;
        health = skeleGiantHealth;
        speed = skeleGiantSpeed;
        range = skeleGiantRange;
        haveAProjectile = false;
        fireRate = skeleGiantFireRate;
        canAttackWithMove = true;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerWeapon")
        {
            health = health - damageTaken;
            audioSrc.PlayOneShot(hit, 0.6f);
        }
    }


    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, skeleGiantRange);
        Gizmos.DrawWireSphere(transform.position, skeleGiantLOS);
    }
}
