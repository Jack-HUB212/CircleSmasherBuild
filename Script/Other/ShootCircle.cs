using UnityEngine;

public class ShootCircle : MonoBehaviour
{

    public GameObject BasicCircle;
    public GameObject GroupCircle;
    public GameObject BombCircle;
    public GameObject SplitCircle;

    public bool BasicRandomBool = false;
    public bool GroupRandomBool = false;
    public bool BombRandomBool = false;
    public bool SplitRandomBool = false;

    public int BasicRandomNumber;
    public int GroupRandomNumber;
    public int BombRandomNumber;
    public int SplitRandomNumber;

    private int BasicRandomNumberMax = 1500;
    private int GroupRandomNumberMax = 10000;
    private int BombRandomNumberMax = 25000;
    private int SplitRandomNumberMax = 4000;

    public bool GroupCircleBool = false;
    public bool BombCircleBool = false;
    public bool SplitCircleBool = false;

    public bool shootingBasic = false;
    public bool shootingGroup = false;
    public bool shootingBomb = false;
    public bool shootingSplit = false;

    public bool CooldownBasicBool = false;
    public bool CooldownGroupBool = false;
    public bool CooldownBombBool = false;
    public bool CooldownSplitBool = false;

    public float BasicFloat = 5;
    private float BasicFloatmax = 5;

    public float GroupFloat = 8;
    private float GroupFloatmax = 8;

    public float BombFloat = 10;
    private float BombFloatmax = 10;

    public float SplitFloat = 6;
    public float SplitFloatmax = 6;

    GameManagerSystem GMS;

    void Start()
    {
        //Disables the spawn object on awake
        BasicRandomBool = true;
        GroupRandomBool = true;
        BombRandomBool = true;
        SplitRandomBool = true;

        //this line finds the gameobject with the tag it is attached to and will also get the Script in the object as well
        GMS = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerSystem>();
    }

    public void Update()
    {
        ShootFunction();
        RandomGeneratorFunction();
        CountDownFunction();
        ScoreUnlockingFunction();
    }

    void ScoreUnlockingFunction()
    {
        //when the player has reached a certain score they will unlock a new stage and a new object will Instantiate 
        if (GMS.score >= 4999)
        {
            GroupCircleBool = true;
        }
        if(GMS.score >= 14999)
        {
            BombCircleBool = true;
        }
        if(GMS.score >= 49999)
        {
            SplitCircleBool = true;
        }
    }

    public void ShootFunction()
    {
        //when the random function generators a spefic number it will tell a boolean to be true 
        //the number will also be set to zero to stop further Instantiations 
        if (BasicRandomNumber == 1)
        {
            shootingBasic = true;
            BasicRandomNumber = 0;
        }

        if (GroupCircleBool == true)
        {
            if (GroupRandomNumber == 10)
            {
                shootingGroup = true;
                GroupRandomNumber = 0;
            }
        }

        if (BombCircleBool == true)
        {
            if (BombRandomNumber == 100)
            {
                shootingBomb = true;
                BombRandomNumber = 0;
            }
        }

        if (SplitCircleBool == true)
        {
            if (SplitRandomNumber == 1000)
            {
                shootingSplit = true;
                SplitRandomNumber = 0;
            }
        }

        //when a boolean is activated it will Instantiate a gameobject according to its function
        //it will also be set to false to stop further Instantiations 
        //when a boolean is active it will set another boolean to false to stop it generatoring other numbers and stopping other Instantiations 
        if (shootingBasic == true)
        {
            Instantiate(BasicCircle, transform.position, transform.rotation);
            shootingBasic = false;
            CooldownBasicBool = true;
            BasicRandomBool = false;
        }
        if (shootingGroup == true)
        {
            Instantiate(GroupCircle, transform.position, transform.rotation);
            shootingGroup = false;
            CooldownGroupBool = true;
            GroupRandomBool = false;
        }
        if (shootingBomb == true)
        {
            Instantiate(BombCircle, transform.position, transform.rotation);
            shootingBomb = false;
            CooldownBombBool = true;
            BombRandomBool = false;
        }
        if (shootingSplit == true)
        {
            Instantiate(SplitCircle, transform.position, transform.rotation);
            shootingSplit = false;
            CooldownSplitBool = true;
            SplitRandomBool = false;
        }
    }

    public void RandomGeneratorFunction()
    {
        //this function generators a random number for each object to be Instantiated from this gameobject
        //when a boolean coreponsding with this function is activated it will start Instantiating new Gameobjects
        if (BasicRandomBool == true)
        {
            BasicRandomNumber = Random.Range(0, BasicRandomNumberMax);
        }

        if(GroupRandomBool == true)
        {
            GroupRandomNumber = Random.Range(0, GroupRandomNumberMax);
        }

        if(BombRandomBool == true)
        {
            BombRandomNumber = Random.Range(0, BombRandomNumberMax);
        }

        if(SplitRandomBool == true)
        {
            SplitRandomNumber = Random.Range(0, GroupRandomNumberMax);
        }
    }

    public void CountDownFunction()
    {
        //this function is a cooldown for the spawn object so it does not Instantiate objects repeatlly 
        //it will also deactive and other booleans to halt other progress
        if (CooldownBasicBool == true)
        {
            BasicFloat -= Time.deltaTime;
        }
        if (BasicFloat <= 0)
        {
            BasicRandomBool = true;
            BasicFloat = BasicFloatmax;
            CooldownBasicBool = false;
        }

        if (CooldownGroupBool == true)
        {
            GroupFloat -= Time.deltaTime;
        }
        if (GroupFloat <= 0)
        {
            GroupRandomBool = true;
            GroupFloat = GroupFloatmax;
            CooldownGroupBool = false;
        }

        if (CooldownBombBool == true)
        {
            BombFloat -= Time.deltaTime;
        }
        if (BombFloat <= 0)
        {
            BombRandomBool = true;
            BombFloat = BombFloatmax;
            CooldownBombBool = false;
        }

        if (CooldownSplitBool == true)
        {
            SplitFloat -= Time.deltaTime;
        }
        if (SplitFloat <= 0)
        {
            SplitRandomBool = true;
            SplitFloat = SplitFloatmax;
            CooldownSplitBool = false;
        }
    }
}
