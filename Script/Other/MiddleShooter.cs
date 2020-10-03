using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddleShooter : MonoBehaviour
{
    public GameObject BigBombCricle;
    public GameObject LiveWireCircle;
    public GameObject TrafficLightCircle;
    public GameObject BigGroupCircle;

    public bool shootBool = false;

    public bool BigBombBool = false;
    public bool LiveWireBool = false;
    public bool TrafficLightBool = false;
    public bool BigGroupBool = false;

    public bool shootingbigbomb = false;
    public bool shootinglivewire = false;
    public bool shootingtrafficlight = false;
    public bool shootingbiggroup = false;

    public float MiddleCooldown = 20f;
    public bool MiddleCooldownBool = false;

    public float randomMiddleCooldown = 10;
    public float randomMiddleCooldownMax = 10;

    public bool randomBool = false;
    public int randomNumberMax = 5000;
    public int randomNumber;

    Collider2D Collider2;

    GameManagerSystem GMS;

    void Start()
    {
        Collider2 = GetComponentInChildren<Collider2D>();
        //this line finds the gameobject with the tag it is attached to and will also get the Script in the object as well
        GMS = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerSystem>();
        randomBool = true;
    }

    void Update()
    {
        ShootFunction();
        RandomGeneratorFunction();
        CountdownFunction();
        ScoreUnlockingFunction();
    }

    void ScoreUnlockingFunction()
    {
        if (GMS.score >= 999)
        {
            shootingbiggroup = true;
        }
        if (GMS.score >= 1999)
        {
            shootingbigbomb = true;
        }
        if(GMS.score >= 2999)
        {
            shootinglivewire = true;
        }
        if(GMS.score >= 3999)
        {
            shootingtrafficlight = true;
        }
    }

    void ShootFunction()
    {
        if (shootBool == true)
        {
            if (shootingbigbomb == true)
            {
                if (randomNumber == 1)
                {
                    Instantiate(BigBombCricle, transform.position, transform.rotation);
                    shootBool = false;
                    MiddleCooldownBool = true;
                    randomBool = false;
                    Collider2.enabled = false;
                    randomNumber = 0;
                }
            }
            if (shootinglivewire == true)
            {
                if (randomNumber == 10)
                {
                    Instantiate(LiveWireCircle, transform.position, transform.rotation);
                    shootBool = false;
                    MiddleCooldownBool = true;
                    randomBool = false;
                    Collider2.enabled = false;
                    randomNumber = 0;
                }
            }
            if (shootingtrafficlight == true)
            {
                if (randomNumber == 100)
                {
                    Instantiate(TrafficLightCircle, transform.position, transform.rotation);
                    shootBool = false;
                    MiddleCooldownBool = true;
                    randomBool = false;
                    Collider2.enabled = false;
                    randomNumber = 0;
                }
            }
            if (shootingbiggroup == true)
            {
                if (randomNumber == 1000)
                {
                    Instantiate(BigGroupCircle, transform.position, transform.rotation);
                    shootBool = false;
                    MiddleCooldownBool = true;
                    randomBool = false;
                    Collider2.enabled = false;
                    randomNumber = 0;
                }
            }
        }
    }

    void RandomGeneratorFunction()
    {
        if (randomBool == true)
        {
            randomNumber = Random.Range(0, randomNumberMax);
            shootBool = true;
        }
    }

    void CountdownFunction()
    {
        if (MiddleCooldownBool == true)
        {
            MiddleCooldown -= Time.deltaTime;
        }
        if (MiddleCooldown <= 0)
        {
            shootBool = true;
            randomMiddleCooldown = randomMiddleCooldownMax;
            MiddleCooldownBool = false;
            Collider2.enabled = true;
            MiddleCooldown = 20f;
        }
        if(MiddleCooldownBool == false)
        {
            randomBool = true;
        }
    }
}
