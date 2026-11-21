using System;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IHasHealth {
    public event EventHandler<IHasHealth.OnHealthReducedEventArgs> OnHealthReduced;
    public class OnHealthReducedEventArgs : EventArgs {
        public float healthNormalized;
    }

    [Header("Health Settings")]
    [SerializeField] private float healthMax = 30f;
    [SerializeField] private float damageOnClick = 10f; // Darah berkurang tiap 1x klik

    private float currentHealth;

    private void Start() {
        currentHealth = healthMax;
    }

    // Dipanggil otomatis oleh Unity saat objek BER-COLLIDER diklik oleh mouse/tap
    private void OnMouseDown() {
        TakeDamage(damageOnClick);
    }

    public void TakeDamage(float amount) {
        currentHealth -= amount;
        OnHealthReduced?.Invoke(this, new IHasHealth.OnHealthReducedEventArgs {
            healthNormalized = (float)currentHealth / healthMax
        });
        if (currentHealth <= 0) {
            Die();
        }
    }

    private void Die() {
        // Bisa dipasangi animasi hancur / partikel efek sebelum Destroy
        Destroy(gameObject);
    }
}