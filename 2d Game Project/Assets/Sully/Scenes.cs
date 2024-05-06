using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Scenes : MonoBehaviour
{
    // Start is called before the first frame update
    public void loadMainMenu(string sceneName)
    {
        Time.timeScale = 1f;
        Destroy(GameObject.Find("Global Audio"));
        SceneManager.LoadScene(sceneName);
    }
}
