using System.Collections;
using System.Collections.Generic;
using Dasis.DesignPattern;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{

    public enum GameMode
    {
        PVP = 0,
        PVE
    }

    public GameMode _gameMode; 
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
