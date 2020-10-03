using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerSystem : MonoBehaviour
{
    //Esstial Variables broadcasts through other scripts but hidden in Gameobject Inscpector
    public float score = 0;
    
    public int Levels = 1;
    [HideInInspector]
    public int Timer = 50;

    private Text ScoreTitleText;
    private Text ScoreText;
    private Text LevelText;
    private Text TimerText;

    public SpriteRenderer Barier1;
    public SpriteRenderer Barier2;
    public SpriteRenderer Barier3;
    public SpriteRenderer Barier4;

    private bool resetTimerBool = false;
    private bool Level2Bool = false;
    private bool Level2ReachedBool = false;
    private bool Level3Bool = false;
    private bool Level3ReachedBool = false;
    private bool Level4Bool = false;
    private bool Level4ReachedBool = false;
    private bool Level5Bool = false;
    private bool Level5ReachedBool = false;
    private bool Level6Bool = false;
    private bool Level6ReachedBool = false;
    private bool Level7Bool = false;
    private bool Level7ReachedBool = false;
    private bool Level8Bool = false;
    private bool Level8ReachedBool = false;

    private bool GamePauseBool = false;

    public Button PlayButton;
    public Button MuteButton;
    public Button MuteIconButton;
    private Button ResetButton;

    public GameObject Menu;
    public GameObject ResetMenu;

    private Image MuteIcon;

    public GameObject LeftupGameobject;
    public GameObject LeftMidleGameobject;
    public GameObject LeftDownGameobject;
    public GameObject MiddleUpGameobject;
    public GameObject MiddleDownGameobject;
    public GameObject RightUpGameobject;
    public GameObject RightMiddleGameobject;
    public GameObject RightDownGameobject;
    public GameObject MiddleGameobject;

    public new AudioSource audio;
    public AudioSource negtiveaudio;

    private bool AudioMuteBool = false;


    void Start()
    {
        //These lines of code allow the script to find gameobjects in the scene.
        //Gameobjects in scene by using the tags. This is beneficial because Tags do not take up memory.

        ScoreText = GameObject.FindGameObjectWithTag("ScoreTextTag").GetComponent<Text>();
        LevelText = GameObject.FindGameObjectWithTag("LevelTextTag").GetComponent<Text>();
        TimerText = GameObject.FindGameObjectWithTag("TimerTextTag").GetComponent<Text>();
        ScoreTitleText = GameObject.FindGameObjectWithTag("ScoreTitleText").GetComponent<Text>();

        PlayButton = GameObject.FindGameObjectWithTag("PlayButtonTag").GetComponent<Button>();
        MuteButton = GameObject.FindGameObjectWithTag("MuteButtonTag").GetComponent<Button>();
        MuteIconButton = GameObject.FindGameObjectWithTag("UnMuteIconTag").GetComponent<Button>();
        ResetButton = GameObject.FindGameObjectWithTag("ResetButtonTag").GetComponent<Button>();

        LeftupGameobject = GameObject.FindGameObjectWithTag("LeftUpTag");
        LeftMidleGameobject = GameObject.FindGameObjectWithTag("LeftMiddleTag");
        LeftDownGameobject = GameObject.FindGameObjectWithTag("LeftDownTag");
        MiddleUpGameobject = GameObject.FindGameObjectWithTag("MiddleUpTag");
        MiddleDownGameobject = GameObject.FindGameObjectWithTag("MiddleDownTag");
        MiddleGameobject = GameObject.FindGameObjectWithTag("MiddleTag");
        RightUpGameobject = GameObject.FindGameObjectWithTag("RightUpTag");
        RightMiddleGameobject = GameObject.FindGameObjectWithTag("RightMiddleTag");
        RightDownGameobject = GameObject.FindGameObjectWithTag("RightDownTag");

        //Finds the gameobject and gets the Image Component 
        MuteIcon = GameObject.FindGameObjectWithTag("MuteIconTag").GetComponent<Image>();

        //Finds the Object with the Audiosource 
        audio = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioSource>();
        negtiveaudio = GameObject.FindGameObjectWithTag("NegtiveAudio").GetComponent<AudioSource>();

        //When the game begins the Objects that instantiate the circles won't produce right away while the menu is active 
        LeftupGameobject.SetActive(false);
        LeftMidleGameobject.SetActive(false);
        LeftDownGameobject.SetActive(false);
        MiddleUpGameobject.SetActive(false);
        MiddleGameobject.SetActive(false);
        MiddleDownGameobject.SetActive(false);
        RightDownGameobject.SetActive(false);
        RightMiddleGameobject.SetActive(false);
        RightUpGameobject.SetActive(false);

        //Singnals the Coroutine in the Update to run the timer Until it hits zero
        StartCoroutine(OnTimerDown());

        //The Buttons in the scene are able to access spefic functions by using a callback function
        PlayButton.onClick.AddListener(OnButtonClickUpdate);
        MuteButton.onClick.AddListener(OnButtonMuteAudio);
        MuteIconButton.onClick.AddListener(OnButtonMuteAudio);
        ResetButton.onClick.AddListener(OnClickReset);

        GamePauseBool = true;

        Menu = GameObject.FindGameObjectWithTag("Background");
        ResetMenu = GameObject.FindGameObjectWithTag("ResetMenu");

        //When the game starts the ResetMenu is Hidden but it is also accessed by the Script
        ResetMenu.SetActive(false);
    }

    void Update()
    {
        //Calls These Function while in Update
        OnScoreUpdate();
        OnLevelUpdate();
        OnTextUpdate();
        OnPauseStart();
        OnGameOverUpdate();
    }

    void OnTextUpdate()
    {
        //Enables Edit to text and display varibles in a text UI
        ScoreText.text = "" + score;
        LevelText.text = "Level= " + Levels;
        TimerText.text = "" + Timer;
    }

    void OnScoreUpdate()
    {
        //When the score variable pass a certain number the levels int will go up
        //the levels int will change to a specific number and will set 2 bools to true
        // and the one boolean in the if statement will be set to true so it wont be called
        //constantly in the Update Function
        if (Level2ReachedBool == false)
        {
            if (score >= 4999)
            {
                Levels = 2;
                Level2Bool = true;
                Level2ReachedBool = true;
            }
        }
        if (Level3ReachedBool == false)
        {
            if (score >= 9999)
            {
                Levels = 3;
                Level3Bool = true;
                Level3ReachedBool = true;
            }
        }
        if (Level4ReachedBool == false)
        {
            if (score >= 14999)
            {
                Levels = 4;
                Level4Bool = true;
                Level4ReachedBool = true;
            }
        }
        if (Level5ReachedBool == false)
        {
            if (score >= 19999)
            {
                Levels = 5;
                Level5Bool = true;
                Level5ReachedBool = true;
            }
        }
        if (Level6ReachedBool == false)
        {
            if (score >= 29999)
            {
                Levels = 6;
                Level6Bool = true;
                Level6ReachedBool = true;
            }
        }
        if (Level7ReachedBool == false)
        {
            if (score >= 39999)
            {
                Levels = 7;
                Level7Bool = true;
                Level7ReachedBool = true;
            }
        }
        if (Level8ReachedBool == false)
        {
            if (score >= 49999)
            {
                Levels = 8;
                Level8Bool = true;
                Level8ReachedBool = true;
            }
        }
    }

    void OnGameOverUpdate()
    {
        //Once the timer hits zero the time scale is set to zero, 
        // the Timer Iemulator is stopped and the instantiate objects are diabled and the reset menu will appear
        if (Timer == 0)
        {
            StopCoroutine(OnTimerDown());
            resetTimerBool = true;
            ResetMenu.SetActive(true);
            Time.timeScale = 0;
            LeftupGameobject.SetActive(false);
            LeftMidleGameobject.SetActive(false);
            LeftDownGameobject.SetActive(false);
            MiddleUpGameobject.SetActive(false);
            MiddleGameobject.SetActive(false);
            MiddleDownGameobject.SetActive(false);
            RightDownGameobject.SetActive(false);
            RightMiddleGameobject.SetActive(false);
            RightUpGameobject.SetActive(false);
        }
    }

    void OnClickReset()
    {
        //Although seen as an Warning switch it does not delay game progress
        Application.LoadLevel(Application.loadedLevel); //Resets scene
    }

    void OnLevelUpdate()
    {
        //Once the level int goes to a certain number more
        // time will be added and objects in the scene will change colour and 
        // the boolean will be set to false so it wont be called repeatly in the Update
        if (Level2Bool == true)
        {
            if (Levels == 2)
            {
                Timer += 10;
                Barier1.color = Color.blue;
                Barier2.color = Color.blue;
                Barier3.color = Color.blue;
                Barier4.color = Color.blue;
                ScoreText.color = Color.blue;
                LevelText.color = Color.blue;
                TimerText.color = Color.blue;
                ScoreTitleText.color = Color.blue;
                Level2Bool = false;
            }
        }
        if (Level3Bool == true)
        {
            if (Levels == 3)
            {
                Timer += 10;
                Barier1.color = Color.green;
                Barier2.color = Color.green;
                Barier3.color = Color.green;
                Barier4.color = Color.green;
                ScoreText.color = Color.green;
                LevelText.color = Color.green;
                TimerText.color = Color.green;
                ScoreTitleText.color = Color.green;
                Level3Bool = false;
            }
        }
        if (Level4Bool == true)
        {
            if (Levels == 4)
            {
                Timer += 10;
                Barier1.color = Color.cyan;
                Barier2.color = Color.cyan;
                Barier3.color = Color.cyan;
                Barier4.color = Color.cyan;
                ScoreText.color = Color.cyan;
                LevelText.color = Color.cyan;
                TimerText.color = Color.cyan;
                ScoreTitleText.color = Color.cyan;
                Level4Bool = false;
            }
        }
        if (Level5Bool == true)
        {
            if (Levels == 5)
            {
                Timer += 10;
                Barier1.color = Color.yellow;
                Barier2.color = Color.yellow;
                Barier3.color = Color.yellow;
                Barier4.color = Color.yellow;
                ScoreText.color = Color.yellow;
                LevelText.color = Color.yellow;
                TimerText.color = Color.yellow;
                ScoreTitleText.color = Color.yellow;
                Level5Bool = false;
            }
        }
        if (Level6Bool == true)
        {
            if (Levels == 6)
            {
                Timer += 10;
                Barier1.color = Color.magenta;
                Barier2.color = Color.magenta;
                Barier3.color = Color.magenta;
                Barier4.color = Color.magenta;
                ScoreText.color = Color.magenta;
                LevelText.color = Color.magenta;
                TimerText.color = Color.magenta;
                ScoreTitleText.color = Color.magenta;
                Level6Bool = false;
            }
        }
        if (Level7Bool == true)
        {
            if (Levels == 7)
            {
                Timer += 10;
                Barier1.color = Color.gray;
                Barier2.color = Color.gray;
                Barier3.color = Color.gray;
                Barier4.color = Color.gray;
                ScoreText.color = Color.gray;
                LevelText.color = Color.gray;
                TimerText.color = Color.gray;
                ScoreTitleText.color = Color.gray;
                Level7Bool = false;
            }
        }
        if (Level8Bool == true)
        {
            if (Levels == 8)
            {
                Timer += 10;
                Barier1.color = Color.black;
                Barier2.color = Color.black;
                Barier3.color = Color.black;
                Barier4.color = Color.black;
                ScoreText.color = Color.black;
                LevelText.color = Color.black;
                TimerText.color = Color.black;
                ScoreTitleText.color = Color.black;
                Level8Bool = false;
            }
        }

    }

    void OnPauseStart()
    {
        //The boolean in this function can create a pause state when it is set to true like a on/off switch
        if (GamePauseBool == true)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    void OnButtonClickUpdate()
    {
        //This function is called when the player clicks the play button and will activate the game
        GamePauseBool = false;
        Menu.SetActive(false);

        audio.Play();

        LeftupGameobject.SetActive(true);
        LeftMidleGameobject.SetActive(true);
        LeftDownGameobject.SetActive(true);
        MiddleUpGameobject.SetActive(true);
        MiddleGameobject.SetActive(true);
        MiddleDownGameobject.SetActive(true);
        RightDownGameobject.SetActive(true);
        RightMiddleGameobject.SetActive(true);
        RightUpGameobject.SetActive(true);
    }

    void OnButtonMuteAudio()
    {
        if (AudioMuteBool == false)
        {
            audio.mute = true;
            AudioMuteBool = true;
            MuteIcon.enabled = true;
        }
        else
        {
            audio.mute = false;
            AudioMuteBool = false;
            MuteIcon.enabled = false;
        }
    }

    // This Function is a timer that will count down from the timer varriable to zero 
    // as long as the the boolean in the function is set to false else it will not activate or just stop
    // it is also counting down in whole numbers instead
    IEnumerator OnTimerDown()
    {
        while (resetTimerBool == false)
        {
            yield return new WaitForSeconds(1f);
            Timer--;
        }
    }
}
