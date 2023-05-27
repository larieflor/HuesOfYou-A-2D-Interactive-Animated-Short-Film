using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Firebase.Firestore;
using Firebase.Extensions;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreText;
    // Start is called before the first frame update


    void Start()
    {

    }


    public void SaveScore()
    {
        string existingScores = PlayerPrefs.GetString("score");
        // Create 0 score if first time used
        if (existingScores == null)
        {
            ResetScore();
        }
        // Append 1 on the string with a comma separator
        PlayerPrefs.SetString("score", existingScores + ",1");
        Debug.Log(PlayerPrefs.GetString("score"));
    }


    public void DisplayTotalScore()
    {
        FirebaseFirestore db = FirebaseFirestore.DefaultInstance;

        int sum = 0;
        string[] scoreArray;
        string existingScores = PlayerPrefs.GetString("score");
        scoreArray = existingScores.Split(",");
        foreach (string i in scoreArray)
        {
            Debug.Log(i.Length);
            if (i.Length > 0)
            {
                sum = sum + int.Parse(i);
            }
            // if(i!=null || i!=""){
            //     Debug.Log(int.Parse(i));
            // }

            //
        }
        Debug.Log($"Sum: {sum}");

        if (scoreText)
        {
            scoreText.text = sum.ToString();
        }



        Dictionary<string, object> userscore = new Dictionary<string, object>
        {
                { "score", sum },
        };

        db.Collection("users").AddAsync(userscore).ContinueWithOnMainThread(task => {
            Debug.Log("Added data.");
        });


    }

    public void ResetScore()
    {
        PlayerPrefs.SetString("score", "0");
        if (scoreText)
        {
            scoreText.text = "0";
        }

    }



    // Update is called once per frame
    void Update()
    {

    }
}