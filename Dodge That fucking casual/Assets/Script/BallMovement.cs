using UnityEngine;
using Random = UnityEngine.Random;

public class BallMovement : MonoBehaviour
{
    public static Vector3 direction;
    public static float speedBall;
    public float ballSpeed = 5f;
    public static Vector3 ballPosition;

    public static Vector3 ballDefaultPosition;
    public static bool isPlaying;
    public static bool isPlayingSimu;

    // Start is called before the first frame update
    void Start()
    {
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
        if (collision.gameObject.CompareTag("horWall"))
        {
            direction.y *= -1;
        }
        if (collision.gameObject.CompareTag("verWall"))
        {
            direction.x *= -1;
        }

        if (collision.gameObject.CompareTag("smash"))
        {
            direction.x *= -1;
            ballSpeed += 1f;
        }
    }
}
