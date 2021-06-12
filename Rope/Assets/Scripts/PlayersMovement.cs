
using UnityEngine;


public class PlayersMovement : MonoBehaviour
{
    public Rigidbody2D player1;
    public Transform groundCheckP1;

    public Rigidbody2D player2;
    public Transform groundCheckP2;

    const float speed = 15.0f;
    const float jumpForce = 90.0f;
    const float maximumVelocity = 20.0f;


    // Update is called once per frame
    void Update()
    {
        // This makes a raycast in order to know if he's touching the ground in order to jump, (because it doesn't make sense if he's in the
        // air and jumping mid air, bruh).
        // Ground Checks for Player 1 position
        RaycastHit2D hit = Physics2D.Raycast(groundCheckP1.position, -Vector2.up, 0.2f);
        // Ground checks for player 2 position
        RaycastHit2D hit2 = Physics2D.Raycast(groundCheckP2.position, -Vector2.up, 0.2f);


        #region Player 1 Controls
        // jumping mechanic (just makes sure that you hitting the ground in order to jump
        if (hit.collider != null)
        {
            if (Input.GetKey(KeyCode.W))
            {
                player1.AddForce(new Vector2(0, jumpForce));
            }
        }

        // A is for going to the left
        if (Input.GetKey(KeyCode.A)) { player1.AddForce(new Vector2(-speed, 0)); }
        // D is for going to the right
        if (Input.GetKey(KeyCode.D)) { player1.AddForce(new Vector2(speed, 0)); }
        // And there is no need for need for the players to get a S key for going down
        #endregion


        #region Player 2 Controls
        // Up Arrow is jumping
        if (hit2.collider != null)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                player2.AddForce(new Vector2(0, jumpForce));
            }
        }

        // Left Arrow is going to the left
        if (Input.GetKey(KeyCode.LeftArrow)) { player2.AddForce(new Vector2(-speed, 0)); }
        // Right Arrow is going to the right (bruh)
        if (Input.GetKey(KeyCode.RightArrow)) { player2.AddForce(new Vector2(speed, 0)); }
        // And there is no need for need for the players to get a downArrow key for going down
        #endregion
    }
    // This is only used for the players Terminal Velocity.
    void FixedUpdate()
    {
        player1.velocity = Vector2.ClampMagnitude(player1.velocity, maximumVelocity);
        player2.velocity = Vector2.ClampMagnitude(player2.velocity, maximumVelocity);
    }

}
