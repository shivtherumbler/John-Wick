using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthIndicator : MonoBehaviour
{
    public Slider HealthBar;
    public Text HPText;
    public PlayerHealthManager PlayerHealth;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HealthBar.maxValue = PlayerHealth.PlayerMaxHealth;
        HealthBar.value = PlayerHealth.PlayerCurrentHealth;
        if (PlayerHealth.PlayerCurrentHealth >= 0)
        {
            HPText.text = "HP:" + PlayerHealth.PlayerCurrentHealth + "/" + PlayerHealth.PlayerMaxHealth;

        }
    }
}
