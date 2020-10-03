using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public bool UpBool;
    public bool DownBool;
    public bool RightBool;
    public bool LeftBool;
    public float Speed;

    private bool isdestroybool = false;

    GameManagerSystem GMS;

    void Start()
    {
        //this line finds the gameobject with the tag it is attached to and will also get the Script in the object as well
        GMS = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerSystem>();
    }

    void Update()
    {
        TranslateMovment();
    }

    public void TranslateMovment()
    {
        //When the one or two of these booleans is active the Gameobject will move in a certain direaction 
        //if two booleans are active the object will move in a diangle direaction
        if(UpBool == true)
        {
            transform.Translate(Vector3.up * Time.deltaTime * Speed);
        }
        if(DownBool == true)
        {
            transform.Translate(Vector3.down * Time.deltaTime * Speed);
        }
        if (RightBool == true)
        {
            transform.Translate(Vector3.right * Time.deltaTime * Speed);
        }
        if (LeftBool == true)
        {
            transform.Translate(Vector3.left * Time.deltaTime * Speed);
        }
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        //When object Instantiate it will collide with the spawner object
        //it will trigger one or two of the booleans and tell it were to go
        if (collision.tag == "LeftUpTag")
        {
            DownBool = true;
            RightBool = true;
        }
        if (collision.tag == "LeftMiddleTag")
        {
            RightBool = true;
        }
        if (collision.tag == "LeftDownTag")
        {
            UpBool = true;
            RightBool = true;             
        }
        if (collision.tag == "MiddleUpTag")
        {
            DownBool = true;
        }
        if (collision.tag == "MiddleDownTag")
        {
            UpBool = true;
        }
        if (collision.tag == "RightUpTag")
        {
            LeftBool = true;
            DownBool = true;
        }
        if (collision.tag == "RightMiddleTag")
        {
            LeftBool = true;
        }
        if (collision.tag == "RightDownTag")
        {
            LeftBool = true;
            UpBool = true;
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        //once the Gameobject has left the spawners collider it will trigger another boolean that will make it destroy itself when hitting another gameobject
        //this was done so when the object was Instantiated it will not be destroyed 
        if (other.tag == "LeftUpTag")
        {
            isdestroybool = true;
        }
        if (other.tag == "LeftMiddleTag")
        {
            isdestroybool = true;
        }
        if (other.tag == "LeftDownTag")
        {
            isdestroybool = true;
        }
        if (other.tag == "MiddleUpTag")
        {
            isdestroybool = true;
        }
        if (other.tag == "MiddleDownTag")
        {
            isdestroybool = true;
        }
        if (other.tag == "RightUpTag")
        {
            isdestroybool = true;
        }
        if (other.tag == "RightMiddleTag")
        {
            isdestroybool = true;
        }
        if (other.tag == "RightDownTag")
        {
            isdestroybool = true;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        //this teels the gameobject to destroy itself once it has hit a certain object with the tag
        //it will also subjact a number from the timer in another script to make the game more dynamic 
        if(isdestroybool == true)
        {
            if (collision.tag == "LeftUpTag")
            {
                Destroy(this.gameObject);
                GMS.Timer -= 1;
            }
            if (collision.tag == "LeftMiddleTag")
            {
                Destroy(this.gameObject);
                GMS.Timer -= 1;
            }
            if (collision.tag == "LeftDownTag")
            {
                Destroy(this.gameObject);
                GMS.Timer -= 1;
            }
            if (collision.tag == "MiddleUpTag")
            {
                Destroy(this.gameObject);
                GMS.Timer -= 1;
            }
            if (collision.tag == "MiddleDownTag")
            {
                Destroy(this.gameObject);
                GMS.Timer -= 1;
            }
            if (collision.tag == "RightUpTag")
            {
                Destroy(this.gameObject);
                GMS.Timer -= 1;
            }
            if (collision.tag == "RightMiddleTag")
            {
                Destroy(this.gameObject);
                GMS.Timer -= 1;
            }
            if (collision.tag == "RightDownTag")
            {
                Destroy(this.gameObject);
                GMS.Timer -= 1;
            }
        }       
    }
}
