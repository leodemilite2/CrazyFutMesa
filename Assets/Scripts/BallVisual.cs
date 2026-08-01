using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class BallVisual : MonoBehaviour
{
    private void Awake()
    {
        SpriteRenderer renderer =
            GetComponent<SpriteRenderer>();

        BallData ball =
            SaveManager.Instance.GetSelectedBall();

        if (ball != null)
        {
            renderer.sprite = ball.previewSprite;
        }
    }
}