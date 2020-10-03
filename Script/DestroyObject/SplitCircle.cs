using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitCircle : MonoBehaviour
{
    [HideInInspector]
    public GameObject SplitCircleClone;
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
        onclickraycast();
    }

    void onclickraycast()
    {
        if (Input.GetMouseButton(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero); if (hit.collider != null)
            {
                if (hit.collider != null)
                {
                    if (hit.collider.tag == "SplitCircle")
                    {
                        Instantiate(SplitCircleClone, transform.position, transform.rotation);
                        Destroy(hit.collider.gameObject);
                        GMS.score += 50;
                        audio.Play();
                    }
                }

            }
        }
    }
}

