using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
public class QAScore : MonoBehaviour {

  private int score = 0;
  public Text scoreText;

  // Use this for initialization
  void Start () {
   score = 0;
   scoreText.text = "0";
  }
  
  // Update is called once per frame
  void Update () {
  
  }

  void OnCollisionEnter(Collision collision) {
    if (collision.gameObject.tag == "Wall") {
      score += 100;
      scoreText.text = "" + score.ToString();
    }
  }

}