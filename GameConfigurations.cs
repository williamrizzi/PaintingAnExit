using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameConfigurations : MonoBehaviour
{

    public bool portuguese;
    public bool english;

    public bool music;
    public bool effects;

    private Text startGameText;
    private Text settingsText;
    private Text languageText;
    private Text musicButtonText;
    //private Text effectsText;
    private Text backText;
    private Text continueText;
    private Text mainMenuText;
    private Text yesText;
    private Text noText;

    private Text restartText;
    private Text mainRestartText;

    private Text resultText;

    private Text inGameText;

    public AudioSource musicSource;


    // Start is called before the first frame update
    void Start()
    {

        english = true;
        portuguese = false;
        music = true;
        effects = true;

        startGameText = GameObject.Find("Play").GetComponentInChildren<Text>();
        settingsText = GameObject.Find("Settings").GetComponentInChildren<Text>();
        languageText = GameObject.Find("Language").GetComponentInChildren<Text>();
        musicButtonText = GameObject.Find("Music").GetComponentInChildren<Text>();
        //effectsText = GameObject.Find("Effects").GetComponentInChildren<Text>();
        backText = GameObject.Find("BackToMenu").GetComponentInChildren<Text>();
        continueText = GameObject.Find("Continue").GetComponentInChildren<Text>();
        mainMenuText = GameObject.Find("BackToMainMenu").GetComponentInChildren<Text>();
        yesText = GameObject.Find("Yes").GetComponentInChildren<Text>();
        noText = GameObject.Find("No").GetComponentInChildren<Text>();

        restartText = GameObject.Find("RestartText").GetComponent<Text>();
        mainRestartText = GameObject.Find("backRestartText").GetComponent<Text>();

        resultText = GameObject.Find("ResultText").GetComponent<Text>();

        inGameText = GameObject.Find("InGameText").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(portuguese == true)
        {
            PortugueseLanguage();
        }
        if(english == true)
        {
            EnglishLanguage();
        }

        if(music == true)
        {
            musicSource.volume = 0.2f;
        }
        else if(music == false)
        {
            musicSource.volume = 0f;
        }

    }

    public void SetLanguage()
    {
        if(english == true)
        {
            portuguese = true;
            english = false;
        }
        else if(portuguese == true)
        {
            english = true;
            portuguese = false;
        }
    }

    public void SetMusic()
    {
        if(music == true)
        {
            music = false;
        }
        else if(music == false)
        {
            music = true;
        }
    }

    public void SetEffects()
    {
        if(effects == true)
        {
            effects = false;
        }
        else if(effects == false)
        {
            effects = true;
        }
    }

    public void MoveText()
    {
        if(portuguese == true)
        {
            inGameText.text = "Use A e D para mover-se";
        }
        else if(english == true)
        {
            inGameText.text = "Use A and D to move";
        }
    }

    public void JumpText()
    {
        if (portuguese == true)
        {
            inGameText.text = "Use ESPAÇO para pular";
        }
        else if (english == true)
        {
            inGameText.text = "Use SPACE to jump";
        }
    }

    public void PortalText()
    {
        if (portuguese == true)
        {
            inGameText.text = "Atravesse o portal para ganhar novas cores";
        }
        else if (english == true)
        {
            inGameText.text = "Cross the portal to gain new colors";
        }
    }

    public void ColorText()
    {
        if (portuguese == true)
        {
            inGameText.text = "Se você pular sua cor muda";
        }
        else if (english == true)
        {
            inGameText.text = "If you jump, your color change";
        }
    }

    public void SetDeathText()
    {
        if(portuguese == true)
        {
            resultText.text = "Morreu!";
        }
        else if(english == true)
        {
            resultText.text = "Died!";
        } 
    }
    public void SetVisibleText()
    {
        resultText.enabled = true;
    }

    public void SetInvisibleText()
    {
        resultText.enabled = false;
    }

    public void SetVictoryText()
    {
        if (portuguese == true)
        {
            resultText.text = "Sobreviveu!";
        }
        else if (english == true)
        {
            resultText.text = "Survived!";
        }
    }

    public void PortugueseLanguage()
    {
        startGameText.text = "Jogar";
        settingsText.text = "Configurações";
        languageText.text = "Português";
        backText.text = "Voltar";
        continueText.text = "Continuar";
        mainMenuText.text = "Menu";
        yesText.text = "Sim";
        noText.text = "Não";
        restartText.text = "Reiniciar";
        mainRestartText.text = "Menu";


        if (music == true)
        {
            musicButtonText.text = "Música On";
        }
        else if(music == false)
        {
            musicButtonText.text = "Música Off";
        }

        if(effects == true)
        {
            //effectsText.text = "Efeitos On";
        }
        else if(effects == false)
        {
            //effectsText.text = "Efeitos Off";
        }
    }

    public void EnglishLanguage()
    {
        startGameText.text = "Play";
        settingsText.text = "Settings";
        languageText.text = "English";
        backText.text = "Back";
        continueText.text = "Continue";
        mainMenuText.text = "Main Menu";
        yesText.text = "Yes";
        noText.text = "No";
        restartText.text = "Restart";
        mainRestartText.text = "Main Menu";

        if (music == true)
        {
            musicButtonText.text = "Music On";
        }
        else if (music == false)
        {
            musicButtonText.text = "Music Off";
        }

        if (effects == true)
        {
            //effectsText.text = "Effects On";
        }
        else if (effects == false)
        {
            //effectsText.text = "Effects Off";
        }
    }
}
