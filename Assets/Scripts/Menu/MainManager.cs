using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{

    public static MainManager Instance; // Instance is the Singleton
    public Color TeamColor;

    private void Awake()
    {
        // this if-statement stops duplicate gameObjects being saved
        // when go from any scene back to the scene that intitialized this
        if (Instance != null)  // if Instance was already set,
        {
            Destroy(gameObject); // destroy this new classes instance
            return; // exit method
        }

        // set this.gameObject
        Instance = this;

        // after starting app, a new folder in Heirarcy
        // will be created and hold the gameObject (this)
        // that was passed in as a param. 
        DontDestroyOnLoad(gameObject); 
    }
}
