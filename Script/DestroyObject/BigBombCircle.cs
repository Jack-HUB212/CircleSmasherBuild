using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBombCircle : MonoBehaviour
{
    //these floats will represent the size and speed of the gameobject 
    private float xScale = 2;
    private float yScale = 2;
    private float sizespeed = 1;

    GameManagerSystem GMS; //Links to this script

    private new AudioSource audio;

    void Start()
    {
        //this line finds the gameobject with the tag it is attached to and will also get the Script in the object as well
        GMS = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerSystem>();
        audio = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioSource>();
    }

    void Update()
    {
        SizeMapiulationFunction();
        RaycastHitSizeReductionFunction();
    }

    public void SizeMapiulationFunction()
    {
        //sets the gameobjects scale acording to the two floats used
        transform.localScale = new Vector2(xScale, yScale);
        //these two lines increases the variables called and will also increase the gameobjects scale
        xScale += Time.deltaTime * sizespeed;
        yScale += Time.deltaTime * sizespeed;
        //these if statements tells the object when it reachs a certain scale. Either the player will reduce the object to a certain size or the will reach to a certain size and destroys itself
        if (xScale <= 1)
        {
            Destroy(this.gameObject);
            GMS.score += 100;
            GMS.Timer += 1;
        }
        if (yScale <= 1)
        {
            Destroy(this.gameObject);
            audio.Play();
        }
        if (xScale >= 5)
        {
            Destroy(this.gameObject);
            GMS.Timer -= 10;
        }
        if (yScale >= 5)
        {
            Destroy(this.gameObject);
        }
    }

    public void RaycastHitSizeReductionFunction()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);
            if (hit.collider != null)
            {
                //when the players clicks on this object its size will reduce and the player will gain points as well
                if (hit.collider.tag == "BigBombCircleTag")
                {
                    xScale -= 0.5f;
                    yScale -= 0.5f;
                    GMS.score += 10;
                }
            }


        }
    }
}
