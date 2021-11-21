using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public GameObject blackScreen;
    public GameObject particle;
    public Animator sound; 
    public void OnPointerDown(PointerEventData eventData)
    {

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        StartCoroutine(DelayStart());
    }
    IEnumerator DelayStart()
    {
        sound.SetBool("Start", true);
        blackScreen.SetActive(true);
        particle.SetActive(false);
        yield return new WaitForSeconds(1.25f);
        SceneManager.LoadScene("MainScene");
    }
}
