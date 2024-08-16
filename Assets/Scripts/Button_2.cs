using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_2 : MonoBehaviour
{
    Button_1 button1Script;

    void Start()
    {
        button1Script = GetComponent<Button_1>();
    }

    public void startButton2Execution()
    {
        button1Script.shutAllButtons();
        button1Script.canSpawn();
        button1Script.allowButton2Functionality();
    }
}
