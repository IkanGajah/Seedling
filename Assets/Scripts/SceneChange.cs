using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public static void Load(SceneAsset sceneAsset) {
        string sceneName = sceneAsset.name;
        SceneManager.LoadScene(sceneName);
    }

    public static void Quit() {
        Application.Quit();
    }
}
