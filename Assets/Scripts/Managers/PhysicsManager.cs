using UnityEngine;

public class PhysicsManager : MonoBehaviour
{
    [SerializeField] private Rigidbody2D player1;
    [SerializeField] private Rigidbody2D player2;
    [SerializeField] private Rigidbody2D ball;

    private GameConfig config;

    private void Awake()
    {
        config = Resources.Load<GameConfig>("GameConfig");

        ApplySettings(player1, true);
        ApplySettings(player2, true);
        ApplySettings(ball, false);
    }

    private void ApplySettings(Rigidbody2D body, bool isPlayer)
    {
        if (isPlayer)
        {
            body.mass = config.playerMass;
            body.linearDamping = config.playerLinearDamping;
        }
        else
        {
            body.mass = config.ballMass;
            body.linearDamping = config.ballLinearDamping;
        }
    }
}