using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_1_Comment : MonoBehaviour
{
    public Texture2D label0;
    public Texture2D label1;
    public Texture2D label2;
    public Texture2D label3;
    public Texture2D label4;
    public Texture2D label5;
    public Texture2D label6;
    public Texture2D label7;
    public Texture2D label8;
    public Texture2D label9;

    public GameObject gameCube;
    public Transform spawnPosition1;
    public Transform spawnPosition2;
    public Transform spawnPosition3;
    public Transform spawnPosition4;

    bool doSpawn = false;

    public int maxCubesAmount = 99;
    int currentCubesAmount = 0;

    float interval = 0.15f; 
    private float timer = 0f;
    bool doButton2 = false;

    public GameObject button1;
    public GameObject button2;
    public GameObject button3;
    public GameObject button4;


    void Start()
    {
        
    }

    void Update()
    {
        if (doSpawn)
        {
            shutAllButtons();
            timer += Time.deltaTime;

            if (timer >= interval)
            {
                currentCubesAmount += 1;
                GameObject spawnedObject1 = Instantiate(gameCube, spawnPosition1.position, Quaternion.EulerAngles(45, 45, 45));
                spawnedObject1.GetComponent<Game_Cube>().setIndexForLabels(currentCubesAmount);
                if (doButton2)
                {
                    spawnedObject1.GetComponent<Game_Cube>().setButton2Functionality();
                }
                //GameObject spawnedObject2 = Instantiate(gameCube, spawnPosition2.position, Quaternion.EulerAngles(45, 45, 45));
                // GameObject spawnedObject3 = Instantiate(gameCube, spawnPosition3.position, Quaternion.EulerAngles(45, 45, 45));
                // GameObject spawnedObject4 = Instantiate(gameCube, spawnPosition4.position, Quaternion.EulerAngles(45, 45, 45));

                //var q = spawnedObject1.transform.Find("Digit-1");
                //q.GetComponentInParent<Renderer>().material.mainTexture = label9;

                //List<GameObject> Digit_oneS = new List<GameObject>();

                /*
                foreach(GameObject child in spawnedObject1.GetComponentsInChildren<GameObject>())
                {
                    if (child.name == "Digit-1"){
                        //Digit_oneS.Add(child);
                        child.GetComponent<Renderer>().material.mainTexture = label7;
                    }
                }
                */

                //print(spawnedObject1.transform.childCount);

                /*
                Transform[] allChild;
                allChild = new Transform[spawnedObject1.transform.childCount];
                for (int i = 0; i < allChild.Length; i++)
                {
                    allChild[i] = transform.GetChild(i);
                    //transform.GetChild(i).GetComponent<Renderer>().material.mainTexture = label7;
                    print("child foudn");
                }
                print("==================================");
                */

                timer = 0f;
            }
        }
        if (currentCubesAmount >= maxCubesAmount)
        {
            doSpawn = false;
        }
    }

    public void allowButton2Functionality()
    {
        doButton2 = true;
    }

    public void setRandomColor(GameObject obj)
    {
        int randomNumber = Random.Range(1, 8);
        switch (randomNumber)
        {
            case 1:
                obj.GetComponent<Renderer>().material.color = Color.yellow;
                break;
            case 2:
                obj.GetComponent<Renderer>().material.color = Color.red;
                break;
            case 3:
                obj.GetComponent<Renderer>().material.color = Color.cyan;
                break;
            case 4:
                obj.GetComponent<Renderer>().material.color = Color.blue;
                break;
            case 5:
                obj.GetComponent<Renderer>().material.color = Color.green;
                break;
            case 6:
                obj.GetComponent<Renderer>().material.color = Color.gray;
                break;
            case 7:
                obj.GetComponent<Renderer>().material.color = Color.magenta;
                break;
            default:
                break;
        }
    }

    public void canSpawn()
    {
        doSpawn = true;
    }

    public void spawn()
    {
        GameObject spawnedObject = Instantiate(gameCube, spawnPosition1.position, Quaternion.EulerAngles(45,45,45));
    }

    public void shutAllButtons()
    {
        button1.SetActive(false);
        button2.SetActive(false);
        button3.SetActive(false);
        button4.SetActive(false);
    }
}
