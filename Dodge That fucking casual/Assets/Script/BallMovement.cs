using UnityEngine;
using Random = UnityEngine.Random;

public class BallMovement : MonoBehaviour
{
    private Vector3 direction;
    public static float speedBall = 5f;
    public static Vector3 ballPosition;

    public static Vector3 ballDefaultPosition;

    // Start is called before the first frame update
    void Start()
    {
        direction = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0);    
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * Time.deltaTime * speedBall;
    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("horWall"))
        {
            direction.y *= -1;
        }
        if (other.gameObject.CompareTag("verWall") || other.gameObject.CompareTag("smash"))
        {
            direction.x *= -1;
        }
    }
}
