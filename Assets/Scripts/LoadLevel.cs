using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadLevel : MonoBehaviour
{
    [SerializeField] private string LevelName;
   public void PlayGame()
    {
        SceneManager.LoadScene(LevelName);
    }

    public void QuitLevel()
    {
        Application.Quit();
    }
}
