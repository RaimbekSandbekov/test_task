using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Button_3 : MonoBehaviour
{
    public TMP_Text textMeshPro;

    bool hasTarget_and_canShoot = false;
    bool can_do_button_3 = false;
    Button_2 button2Script;
    public GameObject img;
    public GameObject projectile;
    public GameObject shooter;
    public GameObject target_CUBE;
    bool can_Start_To_SHOOT = false;
    bool no_more_targets = false;
    float shootForce = 900f;

    public float cooldown = .1f; // Cooldown time
    private float nextShootTime = 0f; // Time when can shoot again

    bool first_Target = true;

    void Start()
    {
        button2Script = GetComponent<Button_2>();
    }
    void Update()
    {
        if (can_do_button_3)    // init button3 click
        {
            if (can_Start_To_SHOOT){    // after 99 cubes spawned
                //print(target_CUBE.GetComponent<Game_Cube>().allowButton2Action);
                if (first_Target)
                {
                    get_Target_Cube();
                    first_Target = false;
                }
                if (no_more_targets == false && Time.time >= nextShootTime)
                {
                    //get_Target_Cube();
                    if(target_CUBE.tag == "Untagged")
                    {
                        get_Target_Cube();
                    }
                    if (hasTarget_and_canShoot)
                    {
                        shoot_the_Projectile_into_Target();
                        //hasTarget_and_canShoot = false;
                        nextShootTime = Time.time + cooldown;
                    }
                }


            }
        }
    }
    
    void shoot_the_Projectile_into_Target()
    {
        GameObject sphere = Instantiate(projectile, shooter.transform.position, shooter.transform.rotation);
        Rigidbody rb = sphere.GetComponent<Rigidbody>();
        if (rb != null)
        {
            Vector3 direction = (target_CUBE.transform.position - shooter.transform.position).normalized;
            rb.AddForce(direction * shootForce, ForceMode.Impulse);
        }
        Destroy(sphere, 3f);
    }
    int randomNumber(int maxNum)
    {                      //works just fine
        System.Random random = new System.Random();
        return random.Next(1, maxNum + 1);
    }

    public void allowButton3()
    {
        can_do_button_3 = true;
        button2Script.startButton2Execution();
        img.SetActive(true);
        textMeshPro.SetText("--");
    }
    public void allow_Shooting_after_final_cube_spawned()
    {
        can_Start_To_SHOOT = true;
    }
    public void get_Target_Cube()
    {
        GameObject[] cubes = GameObject.FindGameObjectsWithTag("Game_Cubes_tag");
        if (cubes.Length == 0)
        {
            print("No cubes left in the scene!");
            hasTarget_and_canShoot = false;
            no_more_targets = true;
            return;
        }
        else
        {
            hasTarget_and_canShoot = true;
        }

        int rando = randomNumber(cubes.Length);
        target_CUBE = cubes[rando - 1];
        textMeshPro.SetText(cubes[rando - 1].name);
        return;
    }
    void Manual_Shooting_TEST()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time >= nextShootTime)
        {
            get_Target_Cube();
            shoot_the_Projectile_into_Target();
            nextShootTime = Time.time + cooldown;
        }
    }

   void looping()
    {
        while (no_more_targets == false && Time.time >= nextShootTime)
        {
            //get_Target_Cube();
            if (target_CUBE.tag == "Untagged")
            {
                get_Target_Cube();
            }
            if (hasTarget_and_canShoot)
            {
                shoot_the_Projectile_into_Target();
                hasTarget_and_canShoot = false;
                nextShootTime = Time.time + cooldown;
            }
        }
    }

















    void allTargetsInfo_1()
    {
        GameObject[] cubes = GameObject.FindGameObjectsWithTag("Game_Cubes_tag");
        if (cubes.Length == 0)
        {
            print("No cubes left in the scene!");
            hasTarget_and_canShoot = false;
            return;
        }
        else
        {
            //print("Cubes in scene: " + cubes.Length.ToString());
            hasTarget_and_canShoot = true;
        }
        int qqq = randomNumber(cubes.Length);
        //print(qqq);
        //print(cubes[qqq - 1].name);  //to refer to index -1 is a must
        textMeshPro.SetText(cubes[qqq - 1].name);
        cubes[qqq - 1].tag = "Untagged";
        Game_Cube cubeScript;
        cubeScript = cubes[qqq - 1].GetComponent<Game_Cube>();
        cubeScript.turnOffButton2Functionality();
        //Destroy(cubes[qqq - 1]);
        return;
    }
    void allTargetsInfo_and_Shoot()
    {
        GameObject[] cubes = GameObject.FindGameObjectsWithTag("Game_Cubes_tag");
        if (cubes.Length == 0)
        {
            print("No cubes left in the scene!");
            hasTarget_and_canShoot = false;
            return;
        }
        else
        {
            hasTarget_and_canShoot = true;
        }

        int rando = randomNumber(cubes.Length);
        target_CUBE = cubes[rando - 1];
        textMeshPro.SetText(cubes[rando - 1].name);

        GameObject sphere = Instantiate(projectile, shooter.transform.position, shooter.transform.rotation);
        Rigidbody rb = sphere.GetComponent<Rigidbody>();
        if (rb != null)
        {
            Vector3 direction = (target_CUBE.transform.position - shooter.transform.position).normalized;
            rb.AddForce(direction * 20, ForceMode.Impulse);
        }
        Destroy(sphere, 3f);
        return;
    }
}
