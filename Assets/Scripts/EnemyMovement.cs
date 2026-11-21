using UnityEngine;

public class EnemyMovement : MonoBehaviour {
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float stopDistance = 0.5f;
    [SerializeField] private float damage = 10f;
    [SerializeField] private float attackInterval = 1.5f;

    
    private Transform targetTransform;
    private bool isAttacking;
    private bool firstArrive = true;
    private float attackTimer = 0f;

    // Dipanggil oleh Spawner saat musuh di-instantiate
    public void SetTarget(Transform target) {
        targetTransform = target;
    }

    private void Update() {
        if (targetTransform == null) return;

        if (!isAttacking) {
            MoveToTarget();
        } else {
            AttackTarget();
        }
    }

    private void MoveToTarget() {
        float distance = Vector3.Distance(transform.position, targetTransform.position);

        if (distance > stopDistance) {
            transform.position = Vector3.MoveTowards(
                transform.position,
                targetTransform.position,
                moveSpeed * Time.deltaTime
            );

            // Orientasi Sprite (Flip)
            //Vector3 direction = targetTransform.position - transform.position;
            //if (direction.x != 0) {
            //    float scaleX = Mathf.Sign(direction.x);
            //    transform.localScale = new Vector3(scaleX, 1, 1);
            //}
        } else {
            // Sampai di lokasi pohon, ganti status ke mode menyerang
            isAttacking = true;
        }
    }

    private void AttackTarget() {
        attackTimer += Time.deltaTime;

        // Eksekusi hit setiap jeda 'attackInterval' detik
        if (attackTimer >= attackInterval || firstArrive) {
            firstArrive = false;
            attackTimer = 0f;

            if (targetTransform.TryGetComponent<Seedling>(out Seedling seedling)) {
                seedling.TakeDamage(damage);
            }
        }
    }
}