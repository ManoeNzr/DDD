using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;




public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    [Header("Main Menus")]
    public GameObject pauseMenuUI;
    public GameObject settingsMenuUI;

    [Header("Settings Panels")]
    public GameObject visualsPanel;
    public GameObject soundPanel;
    public GameObject controlsPanel;

    public InputActionAsset inputActions;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                if (settingsMenuUI.activeSelf)
                {
                    OpenPauseMenu();
                }
                else
                {
                    Resume();
                }
            }
            else
            {
                Pause();
            }
        }
    }


    void LateUpdate()
    {

        if (GameIsPaused)
        {
            if (Cursor.lockState != CursorLockMode.None || !Cursor.visible)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
    }



    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        settingsMenuUI.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        inputActions.FindActionMap("Player").Disable();
        //inputActions.FindActionMap("UI").Enable();
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        settingsMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        inputActions.FindActionMap("Player").Enable();
        //inputActions.FindActionMap("UI").Disable();
    }


    public void OpenPauseMenu()
    {
        pauseMenuUI.SetActive(true);
        settingsMenuUI.SetActive(false);
    }

    public void OpenSettings()
    {
        pauseMenuUI.SetActive(false);
        settingsMenuUI.SetActive(true);
        OpenVisualsPanel();
    }

    public void OpenVisualsPanel()
    {
        visualsPanel.SetActive(true);
        soundPanel.SetActive(false);
        controlsPanel.SetActive(false);
    }

    public void OpenSoundPanel()
    {
        visualsPanel.SetActive(false);
        soundPanel.SetActive(true);
        controlsPanel.SetActive(false);
    }

    public void OpenControlsPanel()
    {
        visualsPanel.SetActive(false);
        soundPanel.SetActive(false);
        controlsPanel.SetActive(true);
    }

    public void QuitGame()
    {

        Time.timeScale = 1f;
        GameIsPaused = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SceneManager.LoadScene("MainMenu");
        
    }
}
