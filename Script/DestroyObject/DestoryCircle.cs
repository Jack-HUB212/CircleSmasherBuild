using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryCircle : MonoBehaviour
{
    GameManagerSystem GMS;
    public new AudioSource audio;

    void Start()
    {
        //this line finds the gameobject with the tag it is attached to and will also get the Script in the object as well
        GMS = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerSystem>();
        audio = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioSource>();
    }

    void Update()
    {
        OnRayCastClick();
    }

    void OnRayCastClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero); if (hit.collider != null)
            {
                if (hit.collider != null)
                {
                    //When the player clicks on a object with these tags they will gain points that go to the variables in the GMS script and it depends on what object it is.
                    if (hit.collider.tag == "BasicCircle")
                    {
                        Destroy(hit.collider.gameObject);
                        GMS.score += 100;
                        GMS.Timer += 1;
                        audio.Play();
                    }
                    if (hit.collider.tag == "BombCircle")
                    {
                        Destroy(hit.collider.gameObject);
                        GMS.score += 250;
                        GMS.Timer += 1;
                        audio.Play();
                    }
                    if (hit.collider.tag == "GroupCircle")
                    {
                        Destroy(hit.collider.gameObject);
                        GMS.score += 75;
                        GMS.Timer += 1;
                        audio.Play();
                    }
                    if (hit.collider.tag == "CircleClone")
                    {
                        Destroy(hit.collider.gameObject);
                        GMS.score += 100;
                        GMS.Timer += 1;
                        audio.Play();
                    }
                }
            }
        }
    }
}
