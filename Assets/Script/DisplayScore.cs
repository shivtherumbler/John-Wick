using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DisplayScore : MonoBehaviour
{
    public GameObject score;
   // public GameObject kills;

    // Start is called before the first frame update
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Arcade Death")
        {
            score.SetActive(true);
            //kills.SetActive(true);

        }

        else
        {
            score.SetActive(false);
            //kills.SetActive(false);
        }
    }

}
