using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private const float MAXFALL = 10.5f;
    private const float MAXSPEED = 3.8f;
    [SerializeField] private float JUMPFORCE = 2.5f;
    private const float ACCEL = 2.5f;
    private bool canJump = true;

    private Vector3 movement = Vector3.zero;
    private Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
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
            movement.x = Mathf.Lerp(movement.x, 0, 0.8f);
        }
        if (IsOnFloor() && Input.GetButton("Jump") && canJump)
        {
            rb.AddForce(JUMPFORCE * Vector2.up, ForceMode2D.Impulse);
        }

        movement.x = Mathf.Clamp(movement.x, -MAXSPEED, MAXSPEED);
        if (rb.linearVelocityY > MAXFALL)
        {
            rb.linearVelocityY = MAXFALL;
        }
        transform.position += movement * Time.deltaTime;
    }

    private bool IsOnFloor()
    {
        RaycastHit2D hit;
        hit = Physics2D.Raycast(transform.position, Vector2.down, 0.5f);
        return hit;
    }

    private IEnumerator CanJump()
    {
        canJump = false;
        yield return new WaitForSeconds(0.5f);
        canJump = true;
    }
	
}
