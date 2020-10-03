using UnityEngine;

public class LiveWire : MonoBehaviour
{
    GameObject Cirlce1Live;
    GameObject Circle2Live;
    GameObject Circle3Live;
    GameObject Circle4Live;
    GameObject Circle5Live;

    SpriteRenderer Sprite1;
    SpriteRenderer Sprite2;
    SpriteRenderer Sprite3;
    SpriteRenderer Sprite4;
    SpriteRenderer Sprite5;

    Collider2D collider1;
    Collider2D collider2;
    Collider2D collider3;
    Collider2D collider4;
    Collider2D collider5;

    public bool rangeBool = false;
    public int rangeRandom;
    public int[] rangearray;

    public bool range1 = false;
    public bool range2 = false;
    public bool range3 = false;
    public bool range4 = false;
    public bool range5 = false;

    public bool ChosenBool1 = false;
    public bool ChosenBool2 = false;
    public bool ChosenBool3 = false;
    public bool ChosenBool4 = false;
    public bool ChosenBool5 = false;

    private bool ChoosenBool = false;

    GameManagerSystem GMS;

    public new AudioSource audio;

    void Start()
    {
        //Finds the object in this group by name instead of tag 
        Cirlce1Live = GameObject.Find("Bolt1");
        Circle2Live = GameObject.Find("Bolt2");
        Circle3Live = GameObject.Find("Bolt3");
        Circle4Live = GameObject.Find("Bolt4");
        Circle5Live = GameObject.Find("Bolt5");

        //
        Sprite1 = this.transform.Find("Bolt1").GetComponentInChildren<SpriteRenderer>();
        Sprite2 = this.transform.Find("Bolt2").GetComponentInChildren<SpriteRenderer>();
        Sprite3 = this.transform.Find("Bolt3").GetComponentInChildren<SpriteRenderer>();
        Sprite4 = this.transform.Find("Bolt4").GetComponentInChildren<SpriteRenderer>();
        Sprite5 = this.transform.Find("Bolt5").GetComponentInChildren<SpriteRenderer>();

        //
        collider1 = this.transform.Find("Bolt1").GetComponentInChildren<Collider2D>();
        collider2 = this.transform.Find("Bolt2").GetComponentInChildren<Collider2D>();
        collider3 = this.transform.Find("Bolt3").GetComponentInChildren<Collider2D>();
        collider4 = this.transform.Find("Bolt4").GetComponentInChildren<Collider2D>();
        collider5 = this.transform.Find("Bolt5").GetComponentInChildren<Collider2D>();

        audio = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioSource>();

        //this line finds the gameobject with the tag it is attached to and will also get the Script in the object as well
        GMS = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerSystem>();
    }

    void Awake()
    {
        rangeBool = true;
    }

    void Update()
    {
        RandomGeneratorFunction();
        ClickDestroyCircle();
    }

    void ClickDestroyCircle()
    {
        if (Input.GetMouseButton(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero); if (hit.collider != null)
            {
                if (hit.collider != null)
                {
                    //once the player has clicked on a certain circle a boolean will be activated and will choose another circle to be postive.
                    if (hit.collider.tag == "PostiveCricle")
                    {
                        ChoosenBool = true;
                        GMS.score += 150;
                        GMS.Timer += 1;
                        audio.Play();
                    }
                }

            }
        }
    }

    void RandomGeneratorFunction()
    {
        //When this objects is Instantiate it will produce two types of objects. One of these objects will be coded with a certain tag and the player will be able to click on it and destroy it
        if (rangeBool == true)
        {
            rangeRandom = Random.Range(0, 6);
        }
        if (ChosenBool1 == true && ChosenBool2 == true && ChosenBool3 == true && ChosenBool4 == true && ChosenBool5 == true)
        {
            Destroy(this.gameObject);
        }
        if (rangeRandom == 0)
        {
            rangeBool = true;
        }

        if (rangeRandom == 1)
        {
            rangeBool = false;
            Sprite1.color = Color.red;
            range1 = true;
            Cirlce1Live.tag = ("PostiveCricle");
        }
        if (range1 == true && rangeRandom == 1 && ChoosenBool == true)
        {
            rangeBool = true;
            ChoosenBool = false;
            Sprite1.enabled = false;
            collider1.enabled = false;
            ChosenBool1 = true;

        }
        if (ChosenBool1 == true && rangeRandom == 1)
        {
            rangeBool = true;
        }

        if (rangeRandom == 2)
        {
            rangeBool = false;
            Sprite2.color = Color.red;
            range2 = true;
            Circle2Live.tag = ("PostiveCricle");
        }
        if (range2 == true && rangeRandom == 2 && ChoosenBool == true)
        {
            rangeBool = true;
            ChoosenBool = false;
            Sprite2.enabled = false;
            collider2.enabled = false;
            ChosenBool2 = true;

        }
        if (ChosenBool2 == true && rangeRandom == 2)
        {
            rangeBool = true;
        }

        if (rangeRandom == 3)
        {
            rangeBool = false;
            Sprite3.color = Color.red;
            range3 = true;
            Circle3Live.tag = ("PostiveCricle");
        }
        if (range3 == true && rangeRandom == 3 && ChoosenBool == true)
        {
            rangeBool = true;
            ChoosenBool = false;
            Sprite3.enabled = false;
            collider3.enabled = false;
            ChosenBool3 = true;

        }
        if (ChosenBool3 == true && rangeRandom == 3)
        {
            rangeBool = true;
        }

        if (rangeRandom == 4)
        {
            rangeBool = false;
            Sprite4.color = Color.red;
            range4 = true;
            Circle4Live.tag = ("PostiveCricle");
        }
        if (range4 == true && rangeRandom == 4 && ChoosenBool == true)
        {
            rangeBool = true;
            ChoosenBool = false;
            Sprite4.enabled = false;
            collider4.enabled = false;
            ChosenBool4 = true;

        }
        if (ChosenBool4 == true && rangeRandom == 4)
        {
            rangeBool = true;
        }

        if (rangeRandom == 5)
        {
            rangeBool = false;
            Sprite5.color = Color.red;
            range5 = true;
            Circle5Live.tag = ("PostiveCricle");
        }
        if (range5 == true && rangeRandom == 5 && ChoosenBool == true)
        {
            rangeBool = true;
            ChoosenBool = false;
            Sprite5.enabled = false;
            collider5.enabled = false;
            ChosenBool5 = true;

        }
        if (ChosenBool5 == true && rangeRandom == 5)
        {
            rangeBool = true;
        }
    }
}
