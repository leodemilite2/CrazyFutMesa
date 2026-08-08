using UnityEngine;

public class AreaEffect : MonoBehaviour
{
    [SerializeField]
    private AreaEffectType effectType;

    [Header("Quem é afetado")]
    [SerializeField]
    private bool affectBall = true;

    [SerializeField]
    private bool affectPlayer = true;

    [Header("Atrito")]
    [SerializeField]
    private float beerLinearDamping = 8f;

    [SerializeField]
    private float iceLinearDamping = 0.05f;

    private float originalLinearDamping;

    [Header("Fan")]
    [SerializeField]
    private FanDirection fanDirection = FanDirection.Right;

    [SerializeField]
    private float fanForce = 5f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!IsAffected(other))
            return;

        Rigidbody2D rb = other.attachedRigidbody;

        if (rb == null)
            return;

        switch (effectType)
        {
            case AreaEffectType.Beer:

                originalLinearDamping = rb.linearDamping;
                rb.linearDamping = beerLinearDamping;

                break;

            case AreaEffectType.Ice:

                originalLinearDamping = rb.linearDamping;
                rb.linearDamping = iceLinearDamping;

                break;

            case AreaEffectType.Fan:

                // Vamos implementar depois.
                break;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!IsAffected(other))
            return;

        Rigidbody2D rb = other.attachedRigidbody;

        if (rb == null)
            return;

        switch (effectType)
        {
            case AreaEffectType.Beer:
            case AreaEffectType.Ice:

                rb.linearDamping = originalLinearDamping;

                break;

            case AreaEffectType.Fan:

                break;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (effectType != AreaEffectType.Fan)
            return;

        if (!other.CompareTag("BallTag"))
            return;

        Rigidbody2D rb = other.attachedRigidbody;

        if (rb == null)
            return;

        rb.AddForce(
            GetFanDirection() * fanForce,
            ForceMode2D.Force
        );
    }

    private bool IsAffected(Collider2D other)
    {
        if (other.CompareTag("BallTag"))
            return affectBall;

        if (other.CompareTag("PlayerTag"))
            return affectPlayer;

        return false;
    }

    private Vector2 GetFanDirection()
    {
        switch (fanDirection)
        {
            case FanDirection.Right:
                return Vector2.right;

            case FanDirection.Left:
                return Vector2.left;

            case FanDirection.Up:
                return Vector2.up;

            case FanDirection.Down:
                return Vector2.down;

            default:
                return Vector2.right;
        }
    }
}