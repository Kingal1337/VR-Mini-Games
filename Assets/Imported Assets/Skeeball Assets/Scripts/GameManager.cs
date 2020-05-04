using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    //Makes game manager public static so can access this from other scripts
    public static GameManager gm;
    [Tooltip ("skii ball object")]
    public GameObject skiiBall;
    [Tooltip("skii ball clone")]
    public GameObject clone;
    [Tooltip("skii ball teleport location object")]
    public GameObject teleportLocation;
    [Tooltip("score text object")]
    public GameObject scoreObject;
    //[Tooltip("play text object")]
    //public GameObject playObject;
    [Tooltip("Time text object")]
    public GameObject TimeObject;
    [Tooltip("game over text object")]
    public GameObject gameOverObject;

    [Tooltip("skii ball teleport transform properties")]
    public Transform teleportTransformLocation;

    [Tooltip("game over text")]
    public TextMeshPro gameOver;
    [Tooltip("time text")]
    public TextMeshPro time;
    //[Tooltip("play text")]
    //public TextMeshPro play;
    [Tooltip("score text")]
    public TextMeshPro score;

    [Tooltip("checks to see if game is running")]
    public bool isGameActive=false;
    [Tooltip("checks to see if it is the first time playing game within a single continuous run")]
    public bool secondGameOverCheck = false;
    [Tooltip("sets the speed of the skii ball to a random value between 11000f-14500f")]
    public bool randomSkiiballSpeeds = true;

    [Tooltip("count down timer seconds remaining")]
    public float timeLeft;

    [Tooltip("sound for ball rolling")]
    public AudioSource ballRolling;
    [Tooltip("sound for ball respawning")]
    public AudioSource ballRespawning;
    [Tooltip("sound for background arcade")]
    public AudioSource arcadeSounds;
    [Tooltip("sound for bgm")]
    public AudioSource music;
    [Tooltip("sound for ball thumps")]
    public AudioSource thump;

    [Tooltip("skii ball machine built in score text")]
    [SerializeField] GameObject scoreTextAsset;
    [Tooltip("skii ball machine built in time text")]
    [SerializeField] GameObject timeTextAsset;

    //Controls game over animation scene
    [SerializeField] private Animator gameOverAnimationController;

    //behind the scenes storage variable for initial time
    private float originalTime;

    private void Awake()
    {
        //has higher priority than start solving text lag on start
        score.text = "0";
        scoreObject.SetActive(false);
        TimeObject.SetActive(false);
        gameOverObject.SetActive(false);
    }
    void Start()
    {
        //Makes sure that Game Manager is visible to other scripts
        if (gm==null)
        {
            gm = this.gameObject.GetComponent<GameManager>();
        }
        music.Play();
        arcadeSounds.Play();
        //set the current time to the startTime specified
        originalTime = timeLeft;
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameActive)
        {
            //starts timer on a delay to sync with ball spawn
            Invoke("StartCounter", 1f);
        }
        else
        {
            //resets all game info to default
            timeLeft = originalTime;
            scoreTextAsset.SetActive(true);
            timeTextAsset.SetActive(true);
            gameOverObject.SetActive(false);
            gameOverAnimationController.SetBool("GameOverAnimationActive", false);
            secondGameOverCheck = false;
        }
        

    }

    void GameOver()
    {
        //game over conditions
        scoreObject.SetActive(false);
        TimeObject.SetActive(false);
        scoreTextAsset.SetActive(false);
        timeTextAsset.SetActive(false);
        gameOverObject.SetActive(true);
        Invoke("GameOverAnimation", 1f);
    }
    void GameOverAnimation()
    {
        //plays animation set on game over text
        gameOverAnimationController.SetBool("GameOverAnimationActive", true);
    }

    void StartCounter()
    {
        //starts game countdown timer seen on screen
        timeLeft -= Time.deltaTime;
        int timeLeftInt = (int)timeLeft;
        time.text = timeLeftInt.ToString();
        if (timeLeft < 0)
        {
            GameOver();
        }
    }
}
