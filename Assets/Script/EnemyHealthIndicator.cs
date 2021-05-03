using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthIndicator : MonoBehaviour
{
    public Slider healthBar;
    public Text HPText;
    public Enemy enemyHealth;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        healthBar.maxValue = enemyHealth.maxlife;
        healthBar.value = enemyHealth.life;
        if (enemyHealth.life >= 0)
        {
            HPText.text = "HP:" + enemyHealth.life + "/" + enemyHealth.maxlife;
        }
    }
}
