using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Unpause : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public GameObject[] playingUI;
    public GameObject[] menuUI;
    public void OnPointerDown(PointerEventData eventData)
    {
      
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Time.timeScale = 1;
        playingUI[0].SetActive(true);
        playingUI[1].SetActive(true);
        playingUI[2].SetActive(true);
        playingUI[3].SetActive(true);
        playingUI[4].SetActive(true);
        playingUI[5].SetActive(true);

        menuUI[0].SetActive(false);
            // menuUI[1].SetActive(true)

    }

}
