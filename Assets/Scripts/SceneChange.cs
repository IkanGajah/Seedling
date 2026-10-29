using System;
using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChange : MonoBehaviour
{
    [SerializeField] private Image image;

    private void Start()
    {
        StartCoroutine(FadeOut());
    }

    public void Load(SceneAsset sceneAsset) {
        string sceneName = sceneAsset.name;
        StartCoroutine(Loader(sceneName));
    }

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
