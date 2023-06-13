using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class CanvasManager : MonoBehaviour
{
    public AudioMixer audioMixer;

    [Header("Buttons")]
    public Button startButton;
    public Button settingsButton;
    public Button backButton;
    public Button quitButton;
    public Button returnToMenuButton;
    public Button resumeGame;
    [Header("Menus")]
    public GameObject mainMenu;
    public GameObject pauseMenu;
    public GameObject settingsMenu;
    [Header("Text")]
    public Text livesText;
    public Text volSliderText;
    [Header("Slider")]
    public Slider volSlider;
    // Start is called before the first frame update
    void Start()
    {
        if (startButton)
            startButton.onClick.AddListener(StartGame);

        if (settingsButton)
            settingsButton.onClick.AddListener(ShowSettingsMenu);

        if (backButton)
            backButton.onClick.AddListener(ShowMainMenu);

        if (quitButton)
            quitButton.onClick.AddListener(Quit);

        if (volSlider)
        {
            volSlider.onValueChanged.AddListener((value) => OnSliderValueChanged(value));
            if (volSliderText)
                volSliderText.text = volSlider.value.ToString();
        }

        if (livesText)
        {
            GameManager.Instance.OnLifeValueChanged.AddListener((value) => UpdateLifeText(value));
            livesText.text = "Lives: " + GameManager.Instance.Lives.ToString();
        }

        if (resumeGame)
            resumeGame.onClick.AddListener(UnpauseGame);

        if (returnToMenuButton)
            returnToMenuButton.onClick.AddListener(LoadTitle);

    }

    void LoadTitle()
    {
        SceneManager.LoadScene("Title");
    }
    void UnpauseGame()
    {
        pauseMenu.SetActive(false);
        //something else needs to be done here.
    }

    void UpdateLifeText(int value)
    {
        livesText.text = "Lives: " + value.ToString();
    }

    void ShowSettingsMenu()
    {
        mainMenu.SetActive(false);
        settingsMenu.SetActive(true);

        if (volSlider && volSliderText)
        {
            float value;
            audioMixer.GetFloat("MasterVol", out value);
            volSlider.value = value + 80;
            volSliderText.text = (Mathf.Ceil(value + 80)).ToString();
        }
    }
    void ShowMainMenu()
    {
        settingsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }
    void StartGame()
    {
        SceneManager.LoadScene("Level");
    }
    void Quit()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    } 

    void OnSliderValueChanged(float value)
    {
        volSliderText.text = value.ToString();
        audioMixer.SetFloat("MasterVol", value - 80);
    }
    
    void Update()
    {
        if (!pauseMenu) return;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenu.SetActive(!pauseMenu.activeSelf);

            //hint for the lab
            if (pauseMenu.activeSelf)
            {
                //do something to pause
            }
            else
            {
                //do something to unpause
            }
                
        }

    }
}
