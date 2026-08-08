using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class BallVisual : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private CircleCollider2D ballCollider;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        ballCollider = GetComponentInParent<CircleCollider2D>();

        if (ballCollider == null)
        {
            Debug.LogError("BallVisual: CircleCollider2D não encontrado no objeto pai.");
            return;
        }

        BallData ball = SaveManager.Instance.GetSelectedBall();

        if (ball != null && ball.previewSprite != null)
        {
            spriteRenderer.sprite = ball.previewSprite;
        }

        AdjustVisualSize();
    }

    private void AdjustVisualSize()
    {
        if (spriteRenderer.sprite == null || ballCollider == null)
            return;

        // Tamanho desejado baseado no collider
        float targetDiameter = ballCollider.radius * 2f;

        // Tamanho da sprite em unidades do mundo,
        // considerando o tamanho original da própria sprite.
        float spriteWidth = spriteRenderer.sprite.bounds.size.x;
        float spriteHeight = spriteRenderer.sprite.bounds.size.y;

        float spriteDiameter = Mathf.Max(spriteWidth, spriteHeight);

        if (spriteDiameter <= 0)
            return;

        float scaleFactor = targetDiameter / spriteDiameter;

        transform.localScale = Vector3.one * scaleFactor;
    }
}