using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Flying : MonoBehaviour
{
    public Vector2 direction = new Vector2(-1f, 0f);
    public float speed = 3f;
    public float waveSpeed = 1f;
    public float amplitude = 1f;

    private float _timeSinceStart;
    private Rigidbody2D _rigidbody;


    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _timeSinceStart = 0f;
    }
    private void Update()
    {
        RefreshVelocity();
        _timeSinceStart += Time.deltaTime;
    }

    protected virtual void RefreshVelocity()
    {
        Vector2 velocity = direction.normalized * speed;
        Vector2 sinewave = new Vector2(0f, Mathf.Sin(_timeSinceStart * waveSpeed) * amplitude);

        _rigidbody.velocity = velocity + sinewave;
    }
}
