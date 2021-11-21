using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AttackButtton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool attacking;
    public float clickDelay = 0.15f;
    public void OnPointerDown(PointerEventData pointerEventData)
    {
            StartCoroutine(attackButtonOntrigger());
    }

    public void OnPointerUp(PointerEventData pointerEventData)
    {

    }
    IEnumerator attackButtonOntrigger()
    {
        if (attacking == false)
        {
            attacking = true;
            yield return new WaitForSeconds(clickDelay);
            attacking = false;
        }
    }
}
