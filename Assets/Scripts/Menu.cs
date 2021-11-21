using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Menu : MonoBehaviour ,IPointerDownHandler,IPointerUpHandler
{
    public GameObject[] playingUI;
    public GameObject[] menuUI;
    public void OnPointerDown(PointerEventData eventData)
    {
          
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Time.timeScale = 0;
        playingUI[0].SetActive(false);
        playingUI[1].SetActive(false);
        playingUI[2].SetActive(false);
        playingUI[3].SetActive(false);
        playingUI[4].SetActive(false);
        playingUI[5].SetActive(false);

        menuUI[0].SetActive(true);
       // menuUI[1].SetActive(true);

    }

}
