using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseCharacterUIManager : MonoBehaviour
{
    [SerializeField] private GameObject _pvpMode;
    [SerializeField] private GameObject _pveMode;

    [SerializeField] private GameObject _gameManager;
    
    // Start is called before the first frame update
    void Start()
    {
        _gameManager = GameObject.Find("GameManager");
        GameManager.GameMode gameMode = _gameManager.GetComponent<GameManager>()._gameMode;

        if (gameMode == GameManager.GameMode.PVE)
        {
            _pveMode.SetActive(true);
            _pvpMode.SetActive(false);
        }
        else if (gameMode == GameManager.GameMode.PVP)
        {
            _pveMode.SetActive(false);
            _pvpMode.SetActive(true);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
