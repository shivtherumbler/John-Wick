using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DisplayScore : MonoBehaviour
{
    public GameObject score;

    // Start is called before the first frame update
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Arcade Death")
        {
            score.SetActive(true);

        }

        else
        {
            score.SetActive(false);
        }
    }

}
