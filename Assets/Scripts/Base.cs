using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The droppoint where forklifts drop off resources 
/// </summary>
public class Base : Building
{ 
    public static Base Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    [Serializable]  // this lets the JSON util know to save this shit
    class SaveData
    {
        public Color TeamColor;
    }
}
