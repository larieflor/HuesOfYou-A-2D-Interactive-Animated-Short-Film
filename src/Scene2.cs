using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scene2 : MonoBehaviour
{
 public TextMeshProUGUI display_player_name;

 public void Awake()
 {
    display_player_name.text = Scene1.scene1.player_name;
 }
 
}
