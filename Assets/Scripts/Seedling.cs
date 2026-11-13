using System;
using UnityEngine;

public class Seedling : MonoBehaviour
{
    public event EventHandler<OnWaterReducedEventArgs> OnWaterReduced;
    public class OnWaterReducedEventArgs : EventArgs
    {
        public float waterNormalized;
    }

    private float waterLevelMax = 20f;
    private float waterLevel = 20f;

    private void Update()
    {
        waterLevel -= Time.deltaTime;
        OnWaterReduced?.Invoke(this, new OnWaterReducedEventArgs
        {
            waterNormalized = (float)waterLevel / waterLevelMax
        });
        //if(waterLevel < 0f) { }
    }

    public void Sprinkle()
    {
        FillWater();
    }

    private void FillWater()
    {
        waterLevel = waterLevelMax;
    }
}
