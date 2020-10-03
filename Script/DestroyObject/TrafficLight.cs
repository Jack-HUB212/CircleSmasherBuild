using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLight : MonoBehaviour
{
    GameObject redlightcircle;
    GameObject yellowlightcircle;
    GameObject greenlightcircle;

    private float RedCooldown = 2f;
    private float YellowCooldown = 2f;
    private float GreenCooldown = 2f;

    public int RedRange;
    public int YellowRange;
    public int GreenRange;

    private bool RedBool = false;
    private bool YellowBool = false;
    private bool GreenBool = false;

    private bool RedBoolRange = false;
    private bool YellowBoolRange = false;
    private bool GreenBoolRange = false;

    private bool destroyRedBool = false;
    private bool destroyYellowBool = false;
    private bool destroyGreenBool = false;

    GameManagerSystem GMS;

    private new AudioSource audio;

    void Start()
    {
        redlightcircle = GameObject.FindGameObjectWithTag("RedCircle");
        yellowlightcircle = GameObject.FindGameObjectWithTag("YellowCircle");
        greenlightcircle = GameObject.FindGameObjectWithTag("GreenCircle");

        //this line finds the gameobject with the tag it is attached to and will also get the Script in the object as well
        GMS = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerSystem>();
        audio = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioSource>();
    }

    void Update()
    {
        RedLightChange();
        YellowLightChange();
        GreenLightChange();
        RangeRandomGenerator();
        CooldownFunction();
        OnRayCastClick();

        //once all the child objects are destroyed and these booleans are active the patrent object will destroy self
        if(destroyRedBool == true && destroyYellowBool == true && destroyGreenBool == true)
        {
            Destroy(this.gameObject);
        }
    }

    void RangeRandomGenerator()
    {
        //each child object will have their own range and when that range hits a spefic number it will activate in a different function 
        if (RedBool == false)
        {
            RedRange = Random.Range(0, 400);
        }
        if (YellowBool == false)
        {
            YellowRange = Random.Range(0, 500);
        }
        if (GreenBool == false)
        {
            GreenRange = Random.Range(0, 300);
        }
    }

    //each of these functions when active will make the one of the child object appear when they reach a certain variable 
    void RedLightChange()
    {
        if (RedRange == 4)
        {
            redlightcircle.SetActive(false);
            RedBoolRange = true;
        }
    }

    void YellowLightChange()
    {
        if (YellowRange == 5)
        {
            yellowlightcircle.SetActive(false);
            YellowBoolRange = true;
        }
    }

    void GreenLightChange()
    {
        if (GreenRange == 3)
        {
            greenlightcircle.SetActive(false);
            GreenBoolRange = true;
        }
    }

    //
    void CooldownFunction()
    {
        if(RedBoolRange == true)
        {
            RedCooldown -= Time.deltaTime;
        }
        if(RedCooldown <= 0)
        {
            RedBoolRange = false;
            redlightcircle.SetActive(true);
            RedCooldown = 2f;
            RedBool = false;
        }

        if(YellowBoolRange == true)
        {
            YellowCooldown -= Time.deltaTime;
        }
        if(YellowCooldown <= 0)
        {
            YellowBoolRange = false;
            yellowlightcircle.SetActive(true);
            YellowCooldown = 2f;
            YellowBool = false;
        }

        if(GreenBoolRange == true)
        {
            GreenCooldown -= Time.deltaTime;
        }
        if(GreenCooldown <= 0)
        {
            GreenBoolRange = false;
            greenlightcircle.SetActive(true);
            GreenCooldown = 2f;
            GreenBool = false;
        }
    }
    void OnRayCastClick()
    {
        if (Input.GetMouseButton(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero); if (hit.collider != null)
            {
                if (hit.collider != null)
                {
                    if (hit.collider.tag == "RedCircle")
                    {
                        Destroy(hit.collider.gameObject);
                        GMS.score += 50;
                        GMS.Timer += 1;
                        RedBool = true;
                        destroyRedBool = true;
                        audio.Play();
                    }
                    if (hit.collider.tag == "YellowCircle")
                    {
                        Destroy(hit.collider.gameObject);
                        GMS.score += 100;
                        GMS.Timer += 1;
                        YellowBool = true;
                        destroyYellowBool = true;
                        audio.Play();
                    }
                    if (hit.collider.tag == "GreenCircle")
                    {
                        Destroy(hit.collider.gameObject);
                        GMS.score += 200;
                        GMS.Timer += 1;
                        GreenBool = true;
                        destroyGreenBool = true;
                        audio.Play();
                    }

                }
            }
        }
    }
}
