using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMazeFMenu : MonoBehaviour
{
    public void LoadTheMaze()
    {
        SceneManager.LoadScene("Maze");
    }
}
