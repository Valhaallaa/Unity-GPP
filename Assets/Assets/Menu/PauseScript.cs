using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PauseScript : MonoBehaviour
{

    public Color activeColor, notActiveColor;
    [SerializeField]
    private Image _pauseImg;
    [SerializeField]
    private Image _playImg;
    [SerializeField]
    private Image _rtrnImg;
    [SerializeField]
    private Image _quitImg;

    [SerializeField]
    private GameObject pauseButton; 
    [SerializeField]
    private GameObject playButton;
    [SerializeField]
    private GameObject quitButton;
    [SerializeField]
    private GameObject pausePanel; 

    private void Start()
    {
        _playImg.color = notActiveColor;
        _pauseImg.color = notActiveColor;
        _rtrnImg.color = notActiveColor;
        _quitImg.color = notActiveColor;        
    }
    public void Pause()
    {
        Time.timeScale = 0;
        pauseButton.SetActive(false);
        playButton.SetActive(true);
        pausePanel.SetActive(true);
    }

    public void PlayHover()
    {
        _playImg.color = activeColor;
    }

    public void PlayClick()
    {
        Time.timeScale = 1;
        pauseButton.SetActive(true);
        playButton.SetActive(false);
        pausePanel.SetActive(false);
    }


    public void Quit()
    {
        #if UNITY_EDITOR
        //Application.Quit() does not work in the editor so UnityEditor.Application.isPlaying needs to be set to false to end the game
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }
    
    public void MenuHover()
    {
        _rtrnImg.color = activeColor;
    }
    public void MenuClick()
    {
        SceneManager.LoadScene(0);
    }
    public void PauseAndQuitHover()
    {
        _pauseImg.color = activeColor;     
        _quitImg.color = activeColor;
    }

    public void OnPointerExit()
    {
         _pauseImg.color = notActiveColor;
         _playImg.color = notActiveColor;
         _rtrnImg.color = notActiveColor;
         _quitImg.color = notActiveColor;

    }
}
