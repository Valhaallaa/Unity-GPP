using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{

    public Color activeColor, notActiveColor;

    public Image[] _img;  


    [SerializeField]
    private GameObject menuObj;
    [SerializeField]
    private GameObject helpObj;   

    public void StartClick()
    {
        SceneManager.LoadScene(1);
    }

    public void StartHover()
    {
        _img[0].color = activeColor;
    }

    public void HelpHover()
    {
        _img[1].color = activeColor;
    }
    public void HelpClick()
    {
        helpObj.SetActive(true);
        menuObj.SetActive(false);
    }

    public void BackHover()
    {
        _img[3].color = activeColor;
    }
    public void Back()
    {
        helpObj.SetActive(false);
        menuObj.SetActive(true);
    }
    public void QuitHover()
    {
        _img[2].color = activeColor;
    }

    public void QuitApp()
    {
        Application.Quit();
    }

    public void OnPointerExit()
    {
        for (int i = 0; i < 4; i++)
        {
            _img[i].color = notActiveColor;
        }
    }


}
