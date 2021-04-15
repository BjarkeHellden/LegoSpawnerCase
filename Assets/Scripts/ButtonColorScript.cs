using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonColorScript : MonoBehaviour
{
    public float timeThreshold = 2;
    public float timeResetThreshold = 5;
    public Image image2SecTimer;
    public Image image5SecTimer;
    public Text textNumOfClicks;
    public Color buttonColor;
    private float timeRemaining;
    private float timeRemainingReset;
    public Button greenButton;
    private Text greenButtonText;
    private int numberOfClicks = 0;
    private int highestNumOfClicks = 0;
    public string buttonState = "idle";

    private void Awake()
    {
        greenButton.onClick.AddListener(greenButtonClick);
        greenButton.GetComponent<Image>().color = Color.green;
        greenButtonText = greenButton.GetComponentInChildren<Text>();
        timeRemaining = timeThreshold;
        timeRemainingReset = timeResetThreshold;
    }

    private void Update()
    {
        ClickLogic(numberOfClicks);

        ChangeColor(highestNumOfClicks);

        ProgressBar(image2SecTimer, timeRemaining, timeThreshold);
        ProgressBar(image5SecTimer, timeRemainingReset, timeResetThreshold);

        textNumOfClicks.text = numberOfClicks.ToString();
    }

    public void greenButtonClick()
    {
        numberOfClicks++;
        timeRemainingReset = timeResetThreshold;
    }

    private void ProgressBar(Image image, float currentValue, float maxValue)
    {
        image.rectTransform.sizeDelta = new Vector2(160 / maxValue * currentValue, 10f);
    }

    private void ClickLogic(int numOfClicks)
    {
        if (numOfClicks > 0)
        {
            timeRemaining -= Time.deltaTime;
            if (timeRemaining < 0)
            {
                timeRemaining = timeThreshold;
                numberOfClicks = 0;
            }

            if (numOfClicks > highestNumOfClicks)
            {
                highestNumOfClicks = numOfClicks;
            }
        }

        if (highestNumOfClicks > 0)
        {
            timeRemainingReset -= Time.deltaTime;
            if (timeRemainingReset < 0)
            {
                timeRemainingReset = timeResetThreshold;
                if(highestNumOfClicks > 4)
                {
                    buttonState = "purple";
                }
                else if(highestNumOfClicks == 2)
                {
                    buttonState = "red";
                }
                else
                {
                    buttonState = "blue";
                }
                
                highestNumOfClicks = 0;
            }
        }
    }

    private void ChangeColor(int numOfClicks)
    {
        switch (numOfClicks)
        {
            case 0:
                buttonColor = Color.green;
                break;
            case 1:
                buttonColor = Color.blue;
                break;
            case 2:
                buttonColor = Color.red;
                break;
            case 5:
                buttonColor = new Color(128f, 0f, 128f); //purple
                break;
            default:
                break;
        }
        greenButton.GetComponent<Image>().color = buttonColor;
    }
}
