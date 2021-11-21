using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeReviveEffect : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(FadeOut());
    }
    IEnumerator FadeOut()
    {
        yield return new WaitForSeconds(0.667f);
        Destroy(this.gameObject);
    }
}
