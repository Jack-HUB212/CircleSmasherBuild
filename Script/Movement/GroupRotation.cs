using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupRotation : MonoBehaviour
{
    private float speed = 0.5f;
    public Transform center;
    GameManagerSystem GMS;
    public new AudioSource audio;

    void Start()
    {
        //this line finds the gameobject with the tag it is attached to and will also get the Script in the object as well
        GMS = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerSystem>();
        audio = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioSource>();
        //this will find the main object 
        center = GameObject.FindGameObjectWithTag("BigGroupCircle").transform;
    }

    void Update()
    {
        RotationFuntion();
        OnRayCastClick();
    }

    void RotationFuntion()
    {
        Vector3 Axis = new Vector3(0, 0, 2);
        transform.RotateAround(center.position, Axis, speed);
    }

    void OnRayCastClick()
    {
        if (Input.GetMouseButton(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero); if (hit.collider != null)
            {
                if (hit.collider != null)
                {
                    if(hit.collider.tag == "RotateCircle")
                    {
                        Destroy(hit.collider.gameObject);
                        GMS.score += 20;
                        GMS.Timer += 1;
                        audio.Play();
                    }
                }
            }
        }
    }
}
