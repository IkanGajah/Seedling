using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class SettingsUI : MonoBehaviour
{
    [SerializeField] private Transform settings;

    private void Start()
    {
        Hide();
        
    }
   
    public void Show()
    {
        settings.gameObject.SetActive(true);
    }
    public void Hide()
    {
        settings.gameObject.SetActive(false);
    }
}
