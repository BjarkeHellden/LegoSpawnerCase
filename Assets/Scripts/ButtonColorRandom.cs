using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonColorRandom : MonoBehaviour
{
    public Button randomButton;
    public Color randomButtonColor;
    private Text randomButtonText;
    private bool clickedFlag = false;
    private int numberOfClicks = 0;
    public string buttonState = "idle";

    private void Awake()
    {
        randomButton.onClick.AddListener(ButtonClick);
        randomButtonText = randomButton.GetComponentInChildren<Text>();
    }

    private void ButtonClick()
    {
        randomButtonColor = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1);
        randomButton.GetComponent<Image>().color = randomButtonColor;
        buttonState = "clicked";
    }
}
