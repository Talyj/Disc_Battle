using UnityEngine;
using Random = UnityEngine.Random;

public class BallMovement : MonoBehaviour
{
    //Ball movement values
    public static Vector3 direction;
    public static float speedBall;
    public float ballSpeed = 5f;

    //Game State value (When the ball spawn the game start)
    public static bool isPlaying;
    public static bool isPlayingSimu;

    void Start()
    {
        //Determine a random direction for the ball to start
        direction = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0);
        isPlaying = true;
        isPlayingSimu = true;
    }

    // Update is called once per frame
    void Update()
    {
        speedBall = ballSpeed;
        transform.position += direction * (Time.deltaTime * speedBall);
    }

    public void OnCollisionEnter(Collision other)
    {
        Bounce(other);
    }

    public void Bounce(Collision collision)
    {
        //If the ball collide with a horizontal wall -> invert the y axis value
        if (collision.gameObject.CompareTag("horWall"))
        {
            direction.y *= -1;
        }
        //If the ball collide with a vertical wall -> invert the x axis value
        if (collision.gameObject.CompareTag("verWall"))
        {
            direction.x *= -1;
        }

        //Same behaviour as the vertical wall but speed up the ball
        if (collision.gameObject.CompareTag("smash"))
        {
            direction.x *= -1;
            ballSpeed += 1f;
        }
    }
}
