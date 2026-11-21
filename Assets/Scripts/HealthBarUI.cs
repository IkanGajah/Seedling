using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    [SerializeField] private GameObject hasHealthGameObject;
    [SerializeField] private Image barImage;
    private IHasHealth hasHealth;
    private void Start() {
        hasHealth = hasHealthGameObject.GetComponent<IHasHealth>(); 
        
        if (hasHealth == null) {
            Debug.LogError("GameObject " + hasHealthGameObject + " tidak punya komponen IHasHealth!");
            return;
        }

        hasHealth.OnHealthReduced += HasHealth_OnHealthReduced;

        barImage.fillAmount = 1f;
        gameObject.SetActive(false);
    }

    private void HasHealth_OnHealthReduced(object sender, IHasHealth.OnHealthReducedEventArgs e) {
        barImage.fillAmount = e.healthNormalized;
        gameObject.SetActive(true);
    }
}
