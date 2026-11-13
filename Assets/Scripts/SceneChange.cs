using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class SceneChange : MonoBehaviour
{
    [SerializeField] private Image image;

    private void Start()
    {
        StartCoroutine(FadeOut());
    }

    // Runtime entry point: call this from any other script.
    public void Load(string sceneName)
    {
        StartCoroutine(Loader(sceneName));
    }

#if UNITY_EDITOR
    // Kept so existing editor / button usage with a SceneAsset still works.
    public void Load(SceneAsset sceneAsset)
    {
        Load(sceneAsset.name);
    }
#endif

    private IEnumerator Loader(string sceneName)
    {
        float t = 0f;
        float dur = 1f;
        Color c = image.color;
        while (t < dur)
        {
            t += Time.deltaTime;
            c.a = t / dur;
            image.color = c;
            yield return null;
        }
        SceneManager.LoadScene(sceneName);
    }

    private IEnumerator FadeOut()
    {
        float t = 0f;
        float dur = 1.5f;
        Color c = image.color;
        while (t < dur)
        {
            t += Time.deltaTime;
            c.a = 1f - (t / dur);
            image.color = c;
            yield return null;
        }
    }

    public static void Quit() {
        Application.Quit();
    }
}
