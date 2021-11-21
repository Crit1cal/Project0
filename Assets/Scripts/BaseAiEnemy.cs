using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAiEnemy : MonoBehaviour
{
    [HideInInspector] public GameObject targetPlayer;
    [HideInInspector] public Animator enemyAnim;
    [HideInInspector] public SpriteRenderer enemyDestroy;
    [HideInInspector] public GameObject projectile;
    [HideInInspector] public Collider2D hitBox;
    [HideInInspector] public Collider2D BodyhitBox;
    [HideInInspector] public float speed;
    [HideInInspector] public float range;
    [HideInInspector] public float health;
    [HideInInspector] public bool death;
    [HideInInspector] public float fireRate;
    [HideInInspector] public float attackTime;
    [HideInInspector] public bool haveAProjectile;
    [HideInInspector] public float lineOFSite;
    [HideInInspector] public PlayerState playerState;
    [HideInInspector] public float attackDelay;
    [HideInInspector] public bool isdeath = false;
    [HideInInspector] public bool plusKilled = false;
    [HideInInspector] public string skeletontype;
    [HideInInspector] public AudioClip Attack1, Attack2;
    [HideInInspector] public AudioSource audioSrc;
    public AudioClip walkSound;
    private enum State
    {
        Chase,
        Attacking
    }
    private State state;

    byte alpha = 255;
    public bool isAttacking;
    [HideInInspector] public bool canAttackWithMove;

   bool slash, swing, walk;

    private void Start()
    {
        state = State.Chase;
       
    }
    void Update()
    {
        if (skeletontype == "Giant")
        {
            if (state == State.Attacking)
            {
                if (swing == false)
                {
                    swing = true;
                    StartCoroutine(Swing());
                }
            }
        }
        if (isdeath == false)
        {
            switch (state)
            {
                default:
                case State.Chase:
                    enemyAnim.SetBool("isAttacking", false);
                    transform.position = Vector2.MoveTowards(transform.position, targetPlayer.transform.position, speed * Time.deltaTime);
                    enemyAnim.SetBool("isMoving", true);
                    if(walk == false)
                    {
                        walk = true;
                        StartCoroutine(Walking());
                    }
                    
                    if (Vector2.Distance(transform.position, targetPlayer.transform.position) < range)
                    {
                        isAttacking = true;
                        state = State.Attacking;
                    }
                    break;

                case State.Attacking:

                    enemyAnim.SetBool("isMoving", false);
                    if (Time.time > attackDelay)
                    {
                        enemyAnim.SetBool("isAttacking", true);
                        attackDelay = Time.time + fireRate;
                        StartCoroutine(DelayAttack());

                        if (skeletontype == "Warrior")
                        {
                            if (isAttacking == true)
                            {
                                if (slash == false)
                                {
                                    slash = true;
                                    StartCoroutine(Slashing());
                                }
                            }
                        }
                    }
                    else if (Vector2.Distance(transform.position, targetPlayer.transform.position) > lineOFSite)
                    {

                        enemyAnim.SetBool("isAttacking", false);
                        StartCoroutine(DelayMovement());
                    }
                    break;
            }
            // หันไปทางผู้เล่น
            if (transform.position.x < targetPlayer.transform.position.x)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            if (transform.position.x > targetPlayer.transform.position.x)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }


            if (canAttackWithMove == true)
            {
                if (state == State.Attacking)
                {
                    StartCoroutine(StartAttackWithMove());
                }
            }
        }
        if (health <= 0)
        {

            death = true;
            StartCoroutine(Death());
            enemyDestroy.color = new Color32(255, 255, 255, alpha--);
        }

    }
    IEnumerator DelayMovement()
    {
        isAttacking = false;
     
        yield return new WaitForSeconds(0.25f);
        if (isdeath == false)
        {
     
            state = State.Chase;
        }

    }
    IEnumerator DelayAttack()
    {

        yield return new WaitForSeconds(fireRate);

        if (isdeath == false)
        {
            if (haveAProjectile == false)
            {
                if (Vector2.Distance(transform.position, targetPlayer.transform.position) > range)
                {
                    state = State.Chase;
                }
            }
            if (isAttacking == true)
            {
                if (haveAProjectile == true)
                {
                    Instantiate(projectile, transform.position, Quaternion.identity);
                    if (skeletontype == "Archer")
                    {
                        audioSrc.PlayOneShot(Attack2, 0.3f);
                    }
                    if (skeletontype == "Wizard")
                    {
                        audioSrc.PlayOneShot(Attack2, 0.5f);
                    }
                }
            }
        }
    }
    IEnumerator Death()
    {
        if (plusKilled == false)
        {
            plusKilled = true;
            playerState.kill++;
            playerState.health = playerState.health + 2;
            playerState.maxHealth = playerState.maxHealth + 0.3f;
        }
        enemyAnim.SetTrigger("Death");
        isdeath = true;
        hitBox.enabled = false;
        BodyhitBox.enabled = false;
        yield return new WaitForSeconds(2.125f);
        Destroy(this.gameObject);
    }

    IEnumerator StartAttackWithMove()
    {
        yield return new WaitForSeconds(0.75f);
        transform.position = Vector2.MoveTowards(transform.position, targetPlayer.transform.position, 1.5f * Time.deltaTime);
    }
    IEnumerator Slashing()
    {   
        audioSrc.PlayOneShot(Attack2, 0.3f);
        yield return new WaitForSeconds(1.5f);
        slash = false;
    }
    IEnumerator Swing()
    {
        if (isdeath == false)
        {
            audioSrc.PlayOneShot(Attack2, 1);
            yield return new WaitForSeconds(0.25f);
            audioSrc.PlayOneShot(Attack1, 1);
        }
        yield return new WaitForSeconds(0.25f);
        swing = false;
    }
    IEnumerator Walking()
    {
        audioSrc.PlayOneShot(walkSound, 0.2f);
        yield return new WaitForSeconds(0.752f);
        walk = false;
    }
}
