using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthIndicator : MonoBehaviour
{
    public Slider healthBar;
    public Text HPText;
    public PlayerHealthManager playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.maxValue = playerHealth.PlayerMaxHealth;
        healthBar.value = playerHealth.PlayerCurrentHealth;
        if (playerHealth.PlayerCurrentHealth >= 0)
        {
            HPText.text = "HP:" + playerHealth.PlayerCurrentHealth + "/" + playerHealth.PlayerMaxHealth;

        }
    }
}
