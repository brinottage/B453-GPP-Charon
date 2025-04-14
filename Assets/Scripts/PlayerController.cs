using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private const float GRAVITY = 20;
    private const float MAXFALL = 1500;
    private const float MAXSPEED = 300;
    private const float JUMPFORCE = 590;
    private const float ACCEL = 200;

    private Vector2 movement = Vector2.zero;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal") > 0)
        {
            movement.x = ACCEL;
            //Play run animation
            //Set cat sprite to face right
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            movement.x = -ACCEL;
            //Play run animation
            //Set cat sprite to face left
        }
        else
        {
            //Play standing animation
            movement.x = Mathf.Lerp(movement.x, 0, 0.2f);
        }
        if (IsOnFloor() && Input.GetButtonDown("Jump"))
        {
            movement.y -= JUMPFORCE;
        }
    }

    private void FixedUpdate()
    {
        movement.x = Mathf.Clamp(movement.x, -MAXSPEED, MAXSPEED);
        if (movement.y < MAXFALL)
        {
            movement.y += GRAVITY;
        }
    }

    private bool IsOnFloor()
    {
        RaycastHit2D hit;
        hit = Physics2D.Raycast(transform.position, Vector2.down, 0.3f);
        return hit;
    }
	
}
