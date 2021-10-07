using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{

    public GameController gameCtrl;
    public GameConfigurations gameConfig;
    private CameraFollow cameraCtrl;
    private PlayerCollisions coliderCtrl;
    private SkullAnimCtrl animCtrl;
    private PlayerMoviment moveCtrl;

    private GameObject playButton;
    private GameObject settingsButton;
    private GameObject languageButton;
    private GameObject musicButton;
    //private GameObject effectsButton;
    private GameObject backButton;
    private GameObject continueButton;
    private GameObject mainMenuButton;
    private GameObject yesButton;
    private GameObject noButton;
    private GameObject pauseButton;
    private GameObject restartButton;
    private GameObject mainMenuInGameButton;

    public NevoaScript nevoaCtrl;

    private Text inGameText;

    public AudioClip audioButton;
    public AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
        

        gameCtrl = GameObject.Find("GameController").GetComponent<GameController>();
        gameConfig = GameObject.Find("GameController").GetComponent<GameConfigurations>();
        cameraCtrl = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFollow>();
        coliderCtrl = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCollisions>();
        animCtrl = GameObject.FindGameObjectWithTag("Player").GetComponent<SkullAnimCtrl>();
        moveCtrl = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMoviment>();

        playButton = GameObject.Find("Play");
        settingsButton = GameObject.Find("Settings");
        languageButton = GameObject.Find("Language");
        musicButton = GameObject.Find("Music");
        //effectsButton = GameObject.Find("Effects");
        backButton = GameObject.Find("BackToMenu");
        continueButton = GameObject.Find("Continue");
        mainMenuButton = GameObject.Find("BackToMainMenu");
        yesButton = GameObject.Find("Yes");
        noButton = GameObject.Find("No");
        pauseButton = GameObject.Find("Pause");

        restartButton = GameObject.Find("Restart");
        mainMenuInGameButton = GameObject.Find("BackToMenuInGame");

        inGameText = GameObject.Find("InGameText").GetComponent<Text>();

        audioSource = gameObject.GetComponent<AudioSource>();

        MainMenu();
    }

    // Update is called once per frame
    void Update()
    {
        EventSystem.current.SetSelectedGameObject(null);

    }

    IEnumerator ActiveInGameText()
    {
        inGameText.enabled = true;
        yield return new WaitForSeconds(2f);
        inGameText.enabled = false;
    }

    // Buttons Functions
    public void Play()
    {
        audioSource.clip = audioButton;
        audioSource.Play();
        cameraCtrl.cameraStatus = CameraFollow.CameraMoviment.InGame;
        gameCtrl.PlayMatch();
        //Restart tutorial Texts
        coliderCtrl.ResetFirstTexts();
        coliderCtrl.endGame = false;
        InGame();
        gameConfig.MoveText();
        nevoaCtrl.blockTimer = false;
        StartCoroutine("ActiveInGameText");
        gameCtrl.gameStatus = GameController.GameManage.InGame;
    }
    
    public void Settings()
    {
        SettingsMenu();
        gameCtrl.gameStatus = GameController.GameManage.Settings;
    }

    public void Language()
    {
        gameConfig.SetLanguage();
    }

    public void Music()
    {
        gameConfig.SetMusic();
    }

    public void Effects()
    {
        gameConfig.SetEffects();
    }

    public void Back()
    {
        MainMenu();
        gameCtrl.gameStatus = GameController.GameManage.Menu;
    }

    public void Pause()
    {
        PauseMenu();
        nevoaCtrl.blockTimer = true;
        if (animCtrl.poseStatus == SkullAnimCtrl.AnimationPose.Walk)
        {
            animCtrl.WalkOff();
            animCtrl.poseStatus = SkullAnimCtrl.AnimationPose.Idle;
            animCtrl.IdleOn();
            animCtrl.PlayIdle();
            moveCtrl.grounded = true;
        }
        gameCtrl.gameStatus = GameController.GameManage.Pause;
    }

    public void Continue()
    {   
        InGame();
        nevoaCtrl.blockTimer = false;
        moveCtrl.grounded = true;
        if (animCtrl.poseStatus == SkullAnimCtrl.AnimationPose.Walk)
        {   
            animCtrl.WalkOff();
            animCtrl.poseStatus = SkullAnimCtrl.AnimationPose.Idle;
            animCtrl.IdleOn();
            animCtrl.PlayIdle();            
        }
        cameraCtrl.SetFreeze(false);
        gameCtrl.gameStatus = GameController.GameManage.InGame;
    }

    public void MainMenuButton()
    {
        Choice();
    }

    public void Yes()
    {
        cameraCtrl.ResetBlackScreen();
        cameraCtrl.SetFreeze(true);
        cameraCtrl.cameraStatus = CameraFollow.CameraMoviment.Menu;
        MainMenu();
        gameCtrl.gameStatus = GameController.GameManage.Menu;
    }

    public void No()
    {
        PauseMenu();
        gameCtrl.gameStatus = GameController.GameManage.Pause;
    }

    public void SetPause()
    {
        if(gameCtrl.gameStatus == GameController.GameManage.InGame)
        {
            Pause();
        }
        if (gameCtrl.gameStatus == GameController.GameManage.Pause)
        {
            Continue();
            cameraCtrl.SetFollow(true);            
        }
    }

    public void Restart()
    {
        
        gameConfig.SetInvisibleText();
        nevoaCtrl.blockTimer = false;
        nevoaCtrl.timer = 0;
        gameCtrl.RestartMatch();
        coliderCtrl.endGame = false;
        gameCtrl.gameStatus = GameController.GameManage.InGame;
        InGame();
    }
    
    public void InGameReturnToMenu()
    {
        gameConfig.SetInvisibleText();
        cameraCtrl.ResetBlackScreen();
        cameraCtrl.SetFreeze(true);
        cameraCtrl.cameraStatus = CameraFollow.CameraMoviment.Menu;        
        MainMenu();
        gameCtrl.gameStatus = GameController.GameManage.Menu;
    }

    // Layout Display
    public void MainMenu()
    {
        playButton.SetActive(true);
        settingsButton.SetActive(true);
        languageButton.SetActive(false);
        musicButton.SetActive(false);
        //effectsButton.SetActive(false);
        backButton.SetActive(false);
        continueButton.SetActive(false);
        mainMenuButton.SetActive(false);
        yesButton.SetActive(false);
        noButton.SetActive(false);
        pauseButton.SetActive(false);
        restartButton.SetActive(false);
        mainMenuInGameButton.SetActive(false);
    }

    public void SettingsMenu()
    {
        playButton.SetActive(false);
        settingsButton.SetActive(false);
        languageButton.SetActive(true);
        musicButton.SetActive(true);
        //effectsButton.SetActive(true);
        backButton.SetActive(true);
        continueButton.SetActive(false);
        mainMenuButton.SetActive(false);
        yesButton.SetActive(false);
        noButton.SetActive(false);
        pauseButton.SetActive(false);
        restartButton.SetActive(false);
        mainMenuInGameButton.SetActive(false);
    }

    public void PauseMenu()
    {
        playButton.SetActive(false);
        settingsButton.SetActive(false);
        languageButton.SetActive(false);
        musicButton.SetActive(true);
        //effectsButton.SetActive(true);
        backButton.SetActive(false);
        continueButton.SetActive(true);
        mainMenuButton.SetActive(true);
        yesButton.SetActive(false);
        noButton.SetActive(false);
        pauseButton.SetActive(false);
        restartButton.SetActive(false);
        mainMenuInGameButton.SetActive(false);
    }

    public void Choice()
    {
        playButton.SetActive(false);
        settingsButton.SetActive(false);
        languageButton.SetActive(false);
        musicButton.SetActive(false);
        //effectsButton.SetActive(false);
        backButton.SetActive(false);
        continueButton.SetActive(false);
        mainMenuButton.SetActive(false);
        yesButton.SetActive(true);
        noButton.SetActive(true);
        pauseButton.SetActive(false);
        restartButton.SetActive(false);
        mainMenuInGameButton.SetActive(false);
    }

    public void InGame()
    {
        playButton.SetActive(false);
        settingsButton.SetActive(false);
        languageButton.SetActive(false);
        musicButton.SetActive(false);
        //effectsButton.SetActive(false);
        backButton.SetActive(false);
        continueButton.SetActive(false);
        mainMenuButton.SetActive(false);
        yesButton.SetActive(false);
        noButton.SetActive(false);
        pauseButton.SetActive(true);
        restartButton.SetActive(false);
        mainMenuInGameButton.SetActive(false);
    }

    public void DeathMenu()
    {
        playButton.SetActive(false);
        settingsButton.SetActive(false);
        languageButton.SetActive(false);
        musicButton.SetActive(false);
        //effectsButton.SetActive(false);
        backButton.SetActive(false);
        continueButton.SetActive(false);
        mainMenuButton.SetActive(false);
        yesButton.SetActive(false);
        noButton.SetActive(false);
        pauseButton.SetActive(false);
        restartButton.SetActive(true);
        mainMenuInGameButton.SetActive(true);
    }

    public void ButtonsOff()
    {
        playButton.SetActive(false);
        settingsButton.SetActive(false);
        languageButton.SetActive(false);
        musicButton.SetActive(false);
        //effectsButton.SetActive(false);
        backButton.SetActive(false);
        continueButton.SetActive(false);
        mainMenuButton.SetActive(false);
        yesButton.SetActive(false);
        noButton.SetActive(false);
        pauseButton.SetActive(false);
        restartButton.SetActive(false);
        mainMenuInGameButton.SetActive(false);
    }
}
