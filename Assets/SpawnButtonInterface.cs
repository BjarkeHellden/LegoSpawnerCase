using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnButtonInterface : MonoBehaviour
{
    public ButtonColorScript deleteButton;
    public ButtonColorRandom spawnButton;
    public SpawnLego legoSpawner;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnButton.buttonState == "clicked")
        {
            spawnButton.buttonState = "idle";
            legoSpawner.SpawnFromPool("Lego", spawnButton.randomButtonColor);
        }
        if (deleteButton.buttonState == "purple")
        {
            deleteButton.buttonState = "idle";
            legoSpawner.ClearLegos();
        }
        if (deleteButton.buttonState == "red")
        {
            deleteButton.buttonState = "idle";
            legoSpawner.DeactivateFirstLego();
        }
        if (deleteButton.buttonState == "blue")
        {
            deleteButton.buttonState = "idle";
            legoSpawner.DeactivateLastLego();
        }
    }
}
