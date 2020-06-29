using UnityEngine;
using System.Collections;

public class VirusBallBehavior : BallBehavior
{
    public static string TAG = "Virus";

    public VirusBallBehavior(Ball ball)
    {
        this.ball = ball;
    }

    public override void HandleOnCollisionEnter2D(Collision2D other)
    {
        Ball otherBall = other.gameObject.GetComponent<Ball>();
        if (otherBall != null) {
            if (this.ball.isOriginalVirus && otherBall.ballType == BallType.NORMAL) {
                Transform transform = ball.transform;
                float x = transform.localScale.x;
                float y = transform.localScale.y;
                transform.localScale = new Vector2(x < 2 ? x * 1.2f : x, y < 2 ? y * 1.2f : y);
            }
            bool isCureBallHit=otherBall.ballType==BallType.CURE;
            if (isCureBallHit && !this.ball.isOriginalVirus) {
                HandleOnCollisionWith(BallType.NORMAL);
            }
        }
    }

    public override void HandleOnCollisionWith(BallType ballType)
    {
        if (ballType == BallType.NORMAL) {
            HandleOnCollisionWithNormalBall();
        }
    }

    private void HandleOnCollisionWithNormalBall()
    {
        ball.ballTransform.TransformsToNormalBall();
    }
}
