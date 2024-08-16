using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_4 : MonoBehaviour
{
    Button_1 button1Script;
    Button_2 button2Script;

    bool startButton4OtherFunctions = false;
    private float currentTime = 0f;
    private float delayTime = 20f;
    int randomCubeIndex;

    void Start()
    {
        button1Script = GetComponent<Button_1>();
        button2Script = GetComponent<Button_2>();
    }
    public void setRandomCubeToBePredator()
    {
        button2Script.startButton2Execution();
        randomCubeIndex = Random.Range(1,button1Script.maxCubesAmount + 1);
        //print(randomCubeIndex);
        startButton4OtherFunctions = true;
    }
    private void Update()
    {
        if (startButton4OtherFunctions)
        {
            currentTime += Time.deltaTime;
            if (currentTime >= delayTime)
            {
                loopThruAllGameCubes();
                startButton4OtherFunctions = false;
            }
        }
    }
    void loopThruAllGameCubes()
    {
        GameObject[] allGameCubes = GameObject.FindGameObjectsWithTag("Game_Cubes_tag");

        foreach (GameObject gameCube in allGameCubes)
        {
            if(gameCube.GetComponent<Game_Cube>().currentIndexOfSpawn == randomCubeIndex)
            {
                gameCube.GetComponent<Transform>().localScale = new Vector3(0.8f, 0.8f, 0.8f);
                gameCube.GetComponent<Game_Cube>().predatorSetup();
                break;
            }
        }
    }
}
