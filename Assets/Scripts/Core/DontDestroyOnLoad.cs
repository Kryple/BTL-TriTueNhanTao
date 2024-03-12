using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
    private static bool _firstLoad = true;

    void Awake()
    {
        if (_firstLoad)
        {
            DontDestroyOnLoad(gameObject);
            _firstLoad = false;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
