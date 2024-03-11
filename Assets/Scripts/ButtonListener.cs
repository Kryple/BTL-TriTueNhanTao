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
    private int _mainMenuSceneID = 0;
    private int _gameplaySceneID = 1;
    
    
    public void StartQuoridor()
    {
        SceneManager.LoadScene(_gameplaySceneID);
        
    }

    public void StartMenu()
    {
        SceneManager.LoadScene(_mainMenuSceneID);
        //ShareCanvas.FirstCanvas.SetActive(false);

    }

    public void AddGame()
    {
        
    }

    public void Restart()
    {
        // AudioManager.Instance.ButtonSelectEffect();
        StartQuoridor();
        Time.timeScale = 1;
    }
     
    public void Exit()
    {
        // AudioManager.Instance.ButtonSelectEffect();
        StartMenu();
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
                    StartQuoridor();
                    break;
                case "GameAddButton":
                    AddGame();
                    break;
            }
        }
                throw new System.NotImplementedException();
    }
}
