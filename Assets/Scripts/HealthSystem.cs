using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthSystem : MonoBehaviour
{
    public Slider healthbar;
    public TextMeshProUGUI healthText;
    public PlayerState playerHealth;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = playerHealth.health.ToString("0.0") + "/" + playerHealth.maxHealth.ToString("0.0");
        healthbar.value = playerHealth.health / playerHealth.maxHealth;
    }
}
