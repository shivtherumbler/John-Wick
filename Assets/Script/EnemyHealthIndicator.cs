using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthIndicator : MonoBehaviour
{
    public Slider HealthBar;
    public Text HPText;
    public Enemy EnemyHealth;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        HealthBar.maxValue = EnemyHealth.MaxLife;
        HealthBar.value = EnemyHealth.Life;
        if (EnemyHealth.Life >= 0)
        {
            HPText.text = "HP:" + EnemyHealth.Life + "/" + EnemyHealth.MaxLife;
        }
    }
}
