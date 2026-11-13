using UnityEditor;
using UnityEngine;
using UnityEngine.Video;

public class WebGLVideoPlayer : MonoBehaviour
{
    [SerializeField] private VideoPlayer videoPlayer;
    [SerializeField] private string videoFileName = "Tes2.mp4";
    [SerializeField] private SceneChange sceneChange;
    [SerializeField] private SceneAsset sceneAsset;
    

    private void OnEnable()
    {
        if (videoPlayer == null) videoPlayer = GetComponent<VideoPlayer>();
        if (videoPlayer != null) videoPlayer.loopPointReached += OnVideoEnded;
    }

    private void OnDisable()
    {
        if (videoPlayer != null) videoPlayer.loopPointReached -= OnVideoEnded;
    }

    private void OnVideoEnded(VideoPlayer source)
    {
        string sceneName = sceneAsset.name;
        sceneChange.Load(sceneName);
    }

    private void Awake()
    {
        if (videoPlayer == null) videoPlayer = GetComponent<VideoPlayer>();

        // Set source menjadi URL
        videoPlayer.source = VideoSource.Url;

        // Path otomatis yang menunjuk ke folder StreamingAssets di browser
        string videoPath = System.IO.Path.Combine(Application.streamingAssetsPath, videoFileName);
        videoPlayer.url = videoPath;
    }

    public void PlayVideo()
    {
        videoPlayer.Play();
    }
}