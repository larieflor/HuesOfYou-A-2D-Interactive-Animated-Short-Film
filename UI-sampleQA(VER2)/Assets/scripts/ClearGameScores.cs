using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearGameScores : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetString("score", "0");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
