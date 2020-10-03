using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitCloneMovment : MonoBehaviour
{

    private float Speed = 2f;

    private bool RandomBool;

    private int RandomNumber;

    GameManagerSystem GMS;

    void Start()
    {
        //this line finds the gameobject with the tag it is attached to and will also get the Script in the object as well
        GMS = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerSystem>();
    }

    void Update()
    {
        CloneMovement();
        RandomGenerator();
    }

    void CloneMovement()
    {
        //this object when active will go into a random direaction according to the random int 
        if(RandomNumber == 1)
        {
            transform.Translate(Vector3.up * Time.deltaTime * Speed);
            RandomBool = true;
        }
        if (RandomNumber == 2)
        {
            transform.Translate(Vector3.up * Time.deltaTime * Speed);
            transform.Translate(Vector3.right * Time.deltaTime * Speed);
            RandomBool = true;
        }
        if (RandomNumber == 3)
        {
            transform.Translate(Vector3.right * Time.deltaTime * Speed);
            RandomBool = true;
        }
        if (RandomNumber == 4)
        {
            transform.Translate(Vector3.right * Time.deltaTime * Speed);
            transform.Translate(Vector3.down * Time.deltaTime * Speed);
            RandomBool = true;
        }
        if (RandomNumber == 5)
        {
            transform.Translate(Vector3.down * Time.deltaTime * Speed);
            RandomBool = true;
        }
        if (RandomNumber == 6)
        {
            transform.Translate(Vector3.down * Time.deltaTime * Speed);
            transform.Translate(Vector3.left * Time.deltaTime * Speed);
            RandomBool = true;
        }
        if (RandomNumber == 7)
        {
            transform.Translate(Vector3.left * Time.deltaTime * Speed);
            RandomBool = true;
        }
        if (RandomNumber == 8)
        {
            transform.Translate(Vector3.left * Time.deltaTime * Speed);
            transform.Translate(Vector3.up * Time.deltaTime * Speed);
            RandomBool = true;
        }
    }

    void RandomGenerator()
    {
        //Generators a random number when active
        if (RandomBool == false)
        {
            RandomNumber = Random.Range(0, 9);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //unlike other objects when this object collides with the barrier instead of the spawners 
        if (collision.tag == "Barrier")
        {
            Destroy(this.gameObject);
            GMS.Timer -= 1;
        }
    }
}
