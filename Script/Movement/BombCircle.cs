using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BombCircle : MonoBehaviour
{
    private Rigidbody2D RB;
    Vector3 lastVelocity;
    public int CountDown = 5;
    public Text NumberCount;
    GameManagerSystem GMS;

    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        StartCoroutine(OnCountDown()); //this will start the timer when the object Instantiates in the scene

        //this line finds the gameobject with the tag it is attached to and will also get the Script in the object as well
        GMS = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerSystem>();
    }

    void Update()
    {
        lastVelocity = RB.velocity;
        NumberCount.text = "" + CountDown;
        OnCountDown();

        //This Statement is active when the timer has reached zero 
        if(CountDown == 0) 
        {
            Destroy(this.gameObject);
            GMS.Timer -= 10;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        //this object is different from the others becasue when this objects hits another object with a collider that is not triggered and will reflect 
        var speed = lastVelocity.magnitude;
        var direction = Vector3.Reflect(lastVelocity.normalized, collision.contacts[0].normal);
        RB.velocity = direction * Mathf.Max(speed, 2f);
    }

    IEnumerator OnCountDown()
    {
        //this coroutine will act as a timer because it will use a whole number
        while(CountDown > 0)
        {
            yield return new WaitForSeconds(1f);
            CountDown--;
        }
        
    }
}
