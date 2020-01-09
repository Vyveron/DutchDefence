using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Bullet : MonoBehaviour
{
    public float speed;
    [HideInInspector] public float damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Health health = collision.GetComponent<Health>();
        gameObject.SetActive(false);
        health.Modify(-damage);
    }
}
