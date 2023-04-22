using System.Collections.Generic;
 using UnityEngine;
 using UnityEngine.SceneManagement;
 
 
 public class DontDestroyOnSelectedScenes : MonoBehaviour
 {
     [Tooltip("Names of the scenes this object should stay alive in when transitioning into")]
     public List<string> sceneNames;
 
     [Tooltip("A unique string identifier for this object, must be shared across scenes to work correctly")]
     public string instanceName;
 
          private void Start()
     {
         DontDestroyOnLoad(this.gameObject);
 
         
         SceneManager.sceneLoaded += OnSceneLoaded;
     }
 
     void OnSceneLoaded(Scene scene, LoadSceneMode mode)
     {
         
         CheckForDuplicateInstances();
 
         
         CheckIfSceneInList();
     }
 
     void CheckForDuplicateInstances()
     {
         
         DontDestroyOnSelectedScenes[] collection = FindObjectsOfType<DontDestroyOnSelectedScenes>();
 
         
         foreach (DontDestroyOnSelectedScenes obj in collection)
         {
             if(obj != this) 
             {
                 if (obj.instanceName == instanceName)
                 {
                     Debug.Log("Duplicate object in loaded scene, deleting now...");
                     DestroyImmediate(obj.gameObject);
                 }
             }
         }
     }
 
     void CheckIfSceneInList()
     {
         
         string currentScene = SceneManager.GetActiveScene().name;
 
         if (sceneNames.Contains(currentScene))
         {
             
         }
         else
         {
             
             SceneManager.sceneLoaded -= OnSceneLoaded;
             DestroyImmediate(this.gameObject);
         }
     }
 }