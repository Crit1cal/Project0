using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonWizardState : BaseAiEnemy
{
    public Animator skeleWizardAnim;
    public SpriteRenderer skeleWizardDestroy;
    public GameObject skeleWizardMagicBolt;
    public Collider2D skeleWizardHitbox;
    public Collider2D skeleWizardBodyHitbox;
    public AudioClip attack, hit;
    public AudioSource skeletonSoundSrc;

    public float damageTaken = 2;
    public float defend = 0;
    public float skeleWizardHealth = 3;
    public float skeleWizardSpeed = 1.25f;
    public float skeleWizardRange = 5f;
    public float skeleWizardFireRate = 1.633f;
    public float skeleWizardLOS = 2.5f;
    void Start()
    {
        skeletontype = "Wizard";
        playerState = GameObject.FindWithTag("Player").GetComponent<PlayerState>();
        lineOFSite = skeleWizardLOS;
        enemyAnim = skeleWizardAnim;
        targetPlayer = GameObject.FindWithTag("Player");
        hitBox = skeleWizardHitbox;
        BodyhitBox = skeleWizardBodyHitbox;
        enemyDestroy = skeleWizardDestroy;
        Attack1 = attack;
        Attack2 = attack;
        audioSrc = skeletonSoundSrc;
        projectile = skeleWizardMagicBolt;
        health = skeleWizardHealth;
        speed = skeleWizardSpeed;
        range = skeleWizardRange;
        fireRate = skeleWizardFireRate;
        haveAProjectile = true;
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
        Gizmos.DrawWireSphere(transform.position, skeleWizardRange);
        Gizmos.DrawWireSphere(transform.position, skeleWizardLOS);
    }
}
