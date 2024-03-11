using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonListener : MonoBehaviour, IPointerClickHandler
{
    public GameObject PauseCanvas;
    private bool isPaused;

    enum SceneID
    {
        MAIN_MENU = 0,
        CHOOSE_MODE,
        CHOOSE_CHARACTER,
        GAME_PLAY
    }
    
    

    public void OpenMainMenu()
    {
        SceneManager.LoadScene((int)SceneID.MAIN_MENU); 
    }

    public void OpenChooseModeScene()
    {
        SceneManager.LoadScene((int)SceneID.CHOOSE_MODE);
    }
    
    public void OpenChoosingPlayerScene()
    {
        SceneManager.LoadScene((int)SceneID.CHOOSE_CHARACTER);
    }
    
    public void OpenGameplay()
    {
        SceneManager.LoadScene((int)SceneID.GAME_PLAY);
    }

    public void Restart()
    {
        // AudioManager.Instance.ButtonSelectEffect();
        OpenGameplay();
        Time.timeScale = 1;
    }
     
    public void Exit()
    {
        // AudioManager.Instance.ButtonSelectEffect();
        OpenMainMenu();
        Time.timeScale = 1;
    }

    
    public void Resume()
    {
        // AudioManager.Instance.ButtonSelectEffect();
        PauseCanvas.SetActive(false);
        Time.timeScale = 1;

        GameObject.Find("ChessBoard").GetComponent<BoardManager>().isPaused = false;
    }

    public void Pause()
    {
        // AudioManager.Instance.ButtonSelectEffect();
        PauseCanvas.SetActive(true);
        Time.timeScale=0;

        GameObject.Find("ChessBoard").GetComponent<BoardManager>().isPaused = true;
    }

    public void Description()
    {
        // AudioManager.Instance.ButtonSelectEffect();
        Application.OpenURL("https://www.wikiboardgames.com/quoridor-rules/");
    }

    public void StartCommunity()
    {
        Application.OpenURL("https://bgcommunity-1fe2b.web.app/");
    }

    public void OnPointerClick(PointerEventData eventData)
    {

        // if (eventData.clickCount == 1)
        // {
        //     string name = EventSystem.current.currentSelectedGameObject.name;
        //
        //     switch (name)
        //     {
        //         case "QuoridorButton":
        //             ShareCanvas.QuoridorPreview.SetActive(true);
        //             break;
        //     }
        //
        // }

        if (eventData.clickCount == 2)
        {
            string name=EventSystem.current.currentSelectedGameObject.name;
            
            switch(name)
            {
                case "CommunityButton":
                    StartCommunity();
                    break;
                case "QuoridorButton":
                    OpenGameplay();
                    break;
            }
        }
                throw new System.NotImplementedException();
    }

    
}
