using UnityEngine;
using UnityEngine.UI;

public class WaterLevelUI : MonoBehaviour
{
    [SerializeField] private Seedling seedling;
    [SerializeField] private Image barImage;

    private void Start()
    {
        seedling.OnWaterReduced += Seedling_OnWaterReduced;

        barImage.fillAmount = 0f;
    }

    private void Seedling_OnWaterReduced(object sender, Seedling.OnWaterReducedEventArgs e)
    {
        barImage.fillAmount = e.waterNormalized;
    }
}
