using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody2D rb;
    private GameConfig config;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        config = Resources.Load<GameConfig>("GameConfig");

        if (config != null)
        {
            rb.mass = config.ballMass;
            rb.linearDamping = config.ballLinearDamping;
        }
    }

    private void FixedUpdate()
    {
        if (config == null)
            return;

        if (rb.linearVelocity.magnitude > config.maxBallSpeed)
        {
            rb.linearVelocity =
                rb.linearVelocity.normalized * config.maxBallSpeed;
        }
    }
}