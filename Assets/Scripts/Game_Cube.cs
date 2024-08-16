using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Cube : MonoBehaviour
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

    public GameObject digit1_1;
    public GameObject digit1_2;
    public GameObject digit1_3;
    public GameObject digit1_4;
    public GameObject digit1_5;
    public GameObject digit1_6;
    public GameObject digit2_1;
    public GameObject digit2_2;
    public GameObject digit2_3;
    public GameObject digit2_4;
    public GameObject digit2_5;
    public GameObject digit2_6;

    public int currentIndexOfSpawn = 0;

    public bool allowButton2Action = false;
    float minForce = 1f;
    float maxForce = 2f;
    private Rigidbody rb;
    public bool isPredator = false;
    bool targetIsSet = false;
    int targetIndex;
    int currTargInd = 0;
    int realTargInd;
    bool needsNewTarget = true;
    bool startSeekingTarg = false;
    GameObject target;

    GameObject scriptManager;
    Button_3 butt3_reference;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        scriptManager = GameObject.Find("All Scripts");
        butt3_reference = scriptManager.GetComponent<Button_3>();
    }

    void Awake()
    {
        setRandomColor(gameObject);
    }

    void FixedUpdate()
    {
        if (allowButton2Action)
        {
            InvokeRepeating("AddRandomForce", 0.1f, 0.8f);
        }
        if (gameObject.tag == "Predator"){
            target = Find_Target();
            Seek_Target(target);
        }
    }
    GameObject Find_Target()
    {
        GameObject[] cubes = GameObject.FindGameObjectsWithTag("Game_Cubes_tag");
        float shortestDistance = Mathf.Infinity;
        GameObject nearestCube = null;
        foreach (GameObject cube in cubes)
        {
            float distanceToCube = Vector3.Distance(transform.position, cube.transform.position);
            //print(distanceToCube);
            if (distanceToCube < shortestDistance)
            {
                shortestDistance = distanceToCube;
                nearestCube = cube;
            }
        }
        return nearestCube;
    }
    void Seek_Target(GameObject target)
    {
        if(target == null)
        {
            return;
        }
        //print(target.GetComponent<Game_Cube>().currentIndexOfSpawn);
        float forceAmount = 5f;   // Amount of force applied to move towards the target
        if (target != null)
        {
            Vector3 direction = target.transform.position - transform.position;
            direction.Normalize();
            rb.AddForce(direction * forceAmount, ForceMode.Impulse);
        }
    }
    public void predatorSetup()
    {
        allowButton2Action = false;
        CancelInvoke("AddRandomForce");
        gameObject.tag = "Predator";
    }
    void OnCollisionEnter(Collision collision)
    {
        if(gameObject.tag == "Game_Cubes_tag"){
            if ((collision.gameObject.CompareTag("Predator")))
            {
                Destroy(gameObject);
            }
            if ((collision.gameObject.CompareTag("Projectile")))
            {
                if (butt3_reference.target_CUBE.name == gameObject.name)
                {
                    turnOffButton2Functionality();
                    //butt3_reference.get_Target_Cube();
                }
            }
        }
    }
    public void setButton2Functionality() // cube moves around
    {
        allowButton2Action = true;
    }
    public void turnOffButton2Functionality()
    {
        allowButton2Action = false;
        CancelInvoke("AddRandomForce");
        gameObject.tag = "Untagged";
        //butt3_reference.get_Target_Cube();
    }
    public void setIndexForLabels(int setNumb)
    {
        currentIndexOfSpawn = setNumb;
        int digit1 = currentIndexOfSpawn / 10;
        int digit2 = currentIndexOfSpawn % 10;
        //print(digit1+" "+ digit2);
        setLabels(digit1, digit2);
    }

    void setLabels(int digit1, int digit2)
    {
        switch (digit1)
        {
            case 0:
                setDigits1(label0);
                break;
            case 1:
                setDigits1(label1);
                break;
            case 2:
                setDigits1(label2);
                break;
            case 3:
                setDigits1(label3);
                break;
            case 4:
                setDigits1(label4);
                break;
            case 5:
                setDigits1(label5);
                break;
            case 6:
                setDigits1(label6);
                break;
            case 7:
                setDigits1(label7);
                break;
            case 8:
                setDigits1(label8);
                break;
            case 9:
                setDigits1(label9);
                break;
            default:
                break;
        }
        switch (digit2)
        {
            case 0:
                setDigits2(label0);
                break;
            case 1:
                setDigits2(label1);
                break;
            case 2:
                setDigits2(label2);
                break;
            case 3:
                setDigits2(label3);
                break;
            case 4:
                setDigits2(label4);
                break;
            case 5:
                setDigits2(label5);
                break;
            case 6:
                setDigits2(label6);
                break;
            case 7:
                setDigits2(label7);
                break;
            case 8:
                setDigits2(label8);
                break;
            case 9:
                setDigits2(label9);
                break;
            default:
                break;
        }
    }

    void setDigits1(Texture2D label)
    {
        digit1_1.GetComponent<Renderer>().material.mainTexture = label;
        digit1_2.GetComponent<Renderer>().material.mainTexture = label;
        digit1_3.GetComponent<Renderer>().material.mainTexture = label;
        digit1_4.GetComponent<Renderer>().material.mainTexture = label;
        digit1_5.GetComponent<Renderer>().material.mainTexture = label;
        digit1_6.GetComponent<Renderer>().material.mainTexture = label;
    }
    void setDigits2(Texture2D label)
    {
        digit2_1.GetComponent<Renderer>().material.mainTexture = label;
        digit2_2.GetComponent<Renderer>().material.mainTexture = label;
        digit2_3.GetComponent<Renderer>().material.mainTexture = label;
        digit2_4.GetComponent<Renderer>().material.mainTexture = label;
        digit2_5.GetComponent<Renderer>().material.mainTexture = label;
        digit2_6.GetComponent<Renderer>().material.mainTexture = label;
    }

    void setRandomColor(GameObject obj)
    {
        int randomNumber = Random.Range(1, 9);
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
            case 8:
                obj.GetComponent<Renderer>().material.color = Color.white;
                break;
            default:
                break;
        }
    }

    void AddRandomForce()
    {
        Vector3 forceDirection = new Vector3(Random.Range(-1f, 1f), Random.Range(-0.01f, 0.01f), Random.Range(-1f, 1f)).normalized;
        float forceRange = Random.Range(minForce, maxForce);

        rb.AddForce(forceDirection * forceRange, ForceMode.Impulse);
    }

}


/*
 * void seekTarget()
    {
        //realTargInd;
        Vector3 direction = (target.transform.position - transform.position).normalized;
        Vector3 seekForceVector = direction * 1 * Time.fixedDeltaTime;
        rb.AddForce(seekForceVector * 22, ForceMode.Impulse);
        //add to end
        //needsNewTarget = true;
    }
    void findNewTarget()
    {
        GameObject[] allGameCubes = GameObject.FindGameObjectsWithTag("Game_Cubes_tag");
        targetIndex = Random.Range(1, allGameCubes.Length);

        for (int i = 0; i <= allGameCubes.Length; i++)
        {
            if (i == targetIndex)
            {
                realTargInd = allGameCubes[i].GetComponent<Game_Cube>().currentIndexOfSpawn;
                targetIsSet = true;
                target = allGameCubes[i];
                startSeekingTarg = true;
                needsNewTarget = false;
                break;
            }
            //currTargInd++;
        }
        //print(realTargInd);
    }


void OnCollisionEnter(Collision collision)
    {
        if (isPredator)
        {
            if (collision.gameObject.CompareTag("Game_Cubes_tag"))
            {
               //Destroy(collision.gameObject);
               if(gameObject.GetComponent<Game_Cube>().currentIndexOfSpawn == realTargInd)
               {
                    startSeekingTarg = false;
                    needsNewTarget = true;
                    Destroy(collision.gameObject);
               }
            }
        }
    }
*/