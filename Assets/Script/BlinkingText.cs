using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlinkingText : MonoBehaviour
{
    public Text Text;

    private void Start()
    {
        Text = GetComponent<Text>();
        StartBlinking();
    }

    IEnumerator Blink()
    {
        while (true)
        {
            switch (Text.color.a.ToString())
            {
                case "0":
                    Text.color = new Color(Text.color.r, Text.color.g, Text.color.b, 1);
                    yield return new WaitForSeconds(0.5f);
                    break;

                case "1":
                    Text.color = new Color(Text.color.r, Text.color.g, Text.color.b, 0);
                    yield return new WaitForSeconds(0.5f);
                    break;
            }
        }
    }

    void StartBlinking()
    {
        StopCoroutine("Blink");
        StartCoroutine("Blink");
    }

    void StopBlinking()
    {
        StopCoroutine("Blink");
    }
}

