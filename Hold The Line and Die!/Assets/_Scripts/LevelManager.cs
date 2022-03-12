using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public enum Scene { MENU_SCENE = 0, LVL1 = 1, GAMEOVER_SCENE = 2 }
    /// <summary>
    /// Loads a new scene.
    /// </summary>
    /// <param name="sceneIndex">The build index of the scene to be loaded</param>
    /// 
    public static void Load(Scene sceneIndex)
    {
        SceneManager.LoadScene((int)sceneIndex);
    }
    /// <summary>
    /// Loads a new scene.
    /// </summary>
    /// <param name="sceneIndex">The build index of the scene to be loaded</param>
    public static void Load(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    /// <summary>
    /// Exits the application.
    /// </summary>
    public static void Quit()
    {
        Application.Quit();
    }
}
