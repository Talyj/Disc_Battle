using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private static Vector3 lastDirectionIntent;
    private float playerSpeed = 10;
    public bool isPlayer;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement(isPlayer);
        lastDirectionIntent = lastDirectionIntent.normalized;
    }

    private void FixedUpdate()
    {
        gameObject.transform.localPosition += lastDirectionIntent * (Time.deltaTime * playerSpeed);
    }
    
    private void Movement(bool isPlayer)
    {
        if (isPlayer)
        {
            // Get key down (Z,Q,S,D) 
            if (Input.GetKey(KeyCode.D))
            {
                lastDirectionIntent += Vector3.right;
            }
            if (Input.GetKey(KeyCode.Q))
            {
                lastDirectionIntent +=  Vector3.left;
            }
            if (Input.GetKey(KeyCode.Z))
            {
                lastDirectionIntent +=  Vector3.up;
            }
            if (Input.GetKey(KeyCode.S))
            {
                lastDirectionIntent +=  Vector3.down;
            }
            if (!Input.GetKey(KeyCode.Z) && !Input.GetKey(KeyCode.Q) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D))
            {
                // Si on lâche la touche on s'arrête
                lastDirectionIntent = Vector3.zero;
            }
        }
        else
        {
            // Get key down (Z,Q,S,D) 
            if (Input.GetKey(KeyCode.RightArrow))
            {
                lastDirectionIntent += Vector3.right;
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                lastDirectionIntent +=  Vector3.left;
            }
            if (Input.GetKey(KeyCode.UpArrow))
            {
                lastDirectionIntent +=  Vector3.up;
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                lastDirectionIntent +=  Vector3.down;
            }
            if (!Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.DownArrow) && !Input.GetKey(KeyCode.RightArrow))
            {
                // Si on lâche la touche on s'arrête
                lastDirectionIntent = Vector3.zero;
            }
        }
    }
}
