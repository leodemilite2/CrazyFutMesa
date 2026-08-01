using UnityEngine;

public class CosmeticApplier : MonoBehaviour
{
    [SerializeField] private SpriteRenderer playerRenderer;
    [SerializeField] private SpriteRenderer ballRenderer;

    private void Start()
    {
        Debug.Log(
            $"selectedTeamId = {SaveManager.Instance.GetSelectedTeamId()}"
        );

        Debug.Log(
            $"selectedBallId = {SaveManager.Instance.GetSelectedBallId()}"
        );

        TeamData team = SaveManager.Instance.GetSelectedTeam();

        BallData ball = SaveManager.Instance.GetSelectedBall();

        Debug.Log($"Aplicando time: {team.itemName}");
        Debug.Log($"Aplicando bola: {ball.itemName}");

        Debug.Log($"Team encontrada: {team}");
        Debug.Log($"Ball encontrada: {ball}");

        if (team != null)
        {
            playerRenderer.sprite = team.previewSprite;
        }

        if (ball != null)
        {
            ballRenderer.sprite = ball.previewSprite;
        }

        Debug.Log(
        $"Depois de aplicar: {ballRenderer.sprite.name}"
        );
    }
}