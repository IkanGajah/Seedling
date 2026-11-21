using System;
using UnityEngine;

public class Seedling : MonoBehaviour, IHasHealth
{
    public event EventHandler<OnWaterReducedEventArgs> OnWaterReduced;
    public event EventHandler<IHasHealth.OnHealthReducedEventArgs> OnHealthReduced;
    public class OnWaterReducedEventArgs : EventArgs
    {
        public float waterNormalized;
    }
    
    public class OnHealthReducedEventArgs : EventArgs
    {
        public float healthNormalized;
    }

    private float waterLevelMax = 20f;
    private float waterLevel = 20f;
    private float healthMax = 100f;
    private float currentHealth = 100f;

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

    public void TakeDamage(float damageAmount) {
        currentHealth -= damageAmount;

        OnHealthReduced?.Invoke(this, new IHasHealth.OnHealthReducedEventArgs {
            healthNormalized = (float)currentHealth / healthMax
        });
        // Supaya darah tidak tembus angka minus
        if (currentHealth <= 0f) {
            currentHealth = 0f;
            Debug.Log("Seedling mati!");
            // Nanti di sini bisa trigger event OnDead atau lapor ke GameManager
        }

        Debug.Log("Sisa darah Seedling: " + currentHealth);
    }
}
