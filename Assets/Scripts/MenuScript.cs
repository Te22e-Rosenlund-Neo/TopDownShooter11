using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuScript : MonoBehaviour
{
 

public void GameStart(){
    SceneManager.LoadSceneAsync(1);
}
public void GameQuit(){
    Application.Quit();
}
public void GameRestart(){
    SceneManager.LoadSceneAsync(0);
}
}
