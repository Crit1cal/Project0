using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 15;
    public Animator animator;
    public float cooldown = 0.19f;
    public float maxTime = 0.5f;
    public int maxCombo = 4;
    public FixedJoystick fixedJoystick;
    public AttackButtton attackButtton;
    public PlayerState healtPlayer;
    public AudioClip stepSound, swingSound1, swingSound2, swingSound3 ;
    public AudioSource audioSrc;
    [HideInInspector] public bool isDeath = false;
    int combo = 0;
    float lastTime;
    bool attack1, attack2, attack3, isRunning;
    
    void Awake()
    {
        StartCoroutine(Melee());

    }
    void FixedUpdate()
    {
        if(isDeath == false)
        {
            if (Mathf.Abs(fixedJoystick.Horizontal) + Mathf.Abs(fixedJoystick.Vertical) > 0)
            {
                animator.SetBool("isRunning", true);
                if (isRunning == false)
                {
                    StartCoroutine(RunningSound());
                }
            }
            else
            {
                animator.SetBool("isRunning", false);
            }

            if (fixedJoystick.Horizontal > 0)// Input.GetAxis("Horizontal")
            {
                transform.Translate(transform.right * speed * fixedJoystick.Horizontal * Time.deltaTime);
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
            if (fixedJoystick.Horizontal < 0)// Input.GetAxis("Horizontal")
            {
                transform.Translate(transform.right * speed * fixedJoystick.Horizontal * Time.deltaTime);
                transform.eulerAngles = new Vector3(0, -180, 0);
            }
            if (fixedJoystick.Vertical > 0)// Input.GetAxis("Vertical")
            {
                transform.Translate(transform.up * speed * fixedJoystick.Vertical * Time.deltaTime);
            }
            if (fixedJoystick.Vertical < 0)// Input.GetAxis("Vertical")
            {
                transform.Translate(transform.up * speed * fixedJoystick.Vertical * Time.deltaTime);
            }
    
        }
    }

    void Update()
    {
        if(isDeath == false)
        {
            if (combo == 1)
            {
                animator.SetBool("Attack1", true);
                if (attack1 == false)
                {
                    StartCoroutine(Attack1());
                }
            }
            else
            {
                animator.SetBool("Attack1", false);
            }
            if (combo == 2)
            {
                animator.SetBool("Attack2", true);
                if (attack2 == false)
                {
                    StartCoroutine(Attack2());
                }
            
            }
            else
            {
                animator.SetBool("Attack2", false);
            }
            if (combo == 3)
            {
                animator.SetBool("Attack3", true);
                if (attack3 == false)
                {
                    StartCoroutine(Attack3());
                }
            }
            else
            {
                animator.SetBool("Attack3", false);
            }


        }

    }
    //Attack
    IEnumerator Melee()
    {
        if(isDeath == false)
        {
            while (true)
            {
                if (attackButtton.attacking == true)
                {
                    combo++;
                    lastTime = Time.time;
                    animator.SetBool("isAttacking", true);
                    animator.SetBool("isRunning", false);
                    while ((Time.time - lastTime) < maxTime && combo < maxCombo)
                    {
                        if (attackButtton.attacking && (Time.time - lastTime) > cooldown)
                        {
                            combo++;
                            animator.SetBool("isRunning", false);
                            animator.SetBool("isAttacking", true);
                            lastTime = Time.time;
                        }
                        yield return null;
                    }
                    combo = 0;
                    yield return new WaitForSeconds(cooldown - (Time.time - lastTime));
                    animator.SetBool("isAttacking", false);
                }
                yield return null;
            }
        }
     
    }
    IEnumerator Attack1()
    {
        attack1 = true;
        audioSrc.PlayOneShot(swingSound1, 0.5f);
        yield return new WaitForSeconds(0.6f);
        attack1 = false;
    }
    IEnumerator Attack2()
    {
        attack2 = true;
        audioSrc.PlayOneShot(swingSound2, 0.5f);
        yield return new WaitForSeconds(0.6f);
        attack2 = false;
    }
    IEnumerator Attack3()
    {
        attack3 = true;
        audioSrc.PlayOneShot(swingSound3, 0.5f);
        yield return new WaitForSeconds(0.6f);
        attack3 = false;
    }

    IEnumerator RunningSound()
    {
        isRunning = true;
        if(isRunning == true)
        {
               audioSrc.PlayOneShot(stepSound, 0.5f);
        }
    
        yield return new WaitForSeconds(1.08f);
        isRunning = false;
    }
}
