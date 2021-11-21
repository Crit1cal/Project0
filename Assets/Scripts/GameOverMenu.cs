using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool isHold;
    public void OnPointerDown(PointerEventData eventData)
    {
        isHold = true;
        StartCoroutine(HoldToQuit());
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isHold = false;
        SceneManager.LoadScene("MainScene");
    }

    IEnumerator HoldToQuit()
    {
        yield return new WaitForSeconds(2);
        if(isHold == true) 
        {
            Application.Quit();
        }
    }
}
