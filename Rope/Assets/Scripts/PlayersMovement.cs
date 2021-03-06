
using UnityEngine;


public class PlayersMovement : MonoBehaviour
{
    public Rigidbody2D player1;
    public Transform groundCheckP1;

    public Rigidbody2D player2;
    public Transform groundCheckP2;

    const float speed = 15.0f;
    const float jumpForce = 1000.0f;
    const float maximumVelocity = 10.0f;

    const float jumpCooldown = 0.5f;
    float t1 = 0;
    float t2 = 0;

    // Update is called once per frame
    void Update()
    {
        //get singular layer that raycast looks at
        int layer_mask = LayerMask.GetMask("Environment");

        // This makes a raycast in order to know if he's touching the ground in order to jump, (because it doesn't make sense if he's in the
        // air and jumping mid air, bruh).
        // Ground Checks for Player 1 position
        RaycastHit2D hit = Physics2D.Raycast(groundCheckP1.position, -Vector2.up, 0.35f,layer_mask);

        // Ground checks for player 2 position
        RaycastHit2D hit2 = Physics2D.Raycast(groundCheckP2.position, -Vector2.up, 0.35f,layer_mask);
       

        #region Player 1 Controls
        // jumping mechanic (just makes sure that you hitting the ground in order to jump
        if (hit.collider != null)
        {
            print(hit.transform.name);
            if (Input.GetKeyDown(KeyCode.W)&&t1>jumpCooldown)
            {
                player1.AddForce(new Vector2(0, jumpForce));
                t1 = 0;
            }
        }
        t1 += Time.deltaTime;

        // A is for going to the left
        if (Input.GetKey(KeyCode.A)) { player1.AddForce(new Vector2(-speed, 0)); }
        // D is for going to the right
        if (Input.GetKey(KeyCode.D)) { player1.AddForce(new Vector2(speed, 0)); }
        // And there is no need for need for the players to get a S key for going down

        // Holy shit it finally works, it only took 3 tries to finding a code that actually works, I copied this one from the 2010
        // unity forum's question, the code was given by "3itg" from a 2014 response comment. (Many Thanks to that guy)
        if (Mathf.Abs(player1.velocity.x) > maximumVelocity)
         {
            // clamp velocity:
            Vector3 newVelocity = player1.velocity.normalized;
            newVelocity *= maximumVelocity;
            player1.velocity = newVelocity;
        }
        #endregion


        #region Player 2 Controls
        // Up Arrow is jumping
        if (hit2.collider != null)
        {
            
            if (Input.GetKeyDown(KeyCode.UpArrow)&&t2>jumpCooldown)
            {
                player2.AddForce(new Vector2(0, jumpForce));
                t2 = 0;
            }
        }
        t2 += Time.deltaTime;

        // Left Arrow is going to the left
        if (Input.GetKey(KeyCode.LeftArrow)) { player2.AddForce(new Vector2(-speed, 0)); }
        // Right Arrow is going to the right (bruh)
        if (Input.GetKey(KeyCode.RightArrow)) { player2.AddForce(new Vector2(speed, 0)); }
        // And there is no need for need for the players to get a downArrow key for going down

        if (Mathf.Abs(player2.velocity.x) > maximumVelocity)
        {
            // clamp velocity:
            Vector3 newVelocity = player2.velocity.normalized;
            newVelocity *= maximumVelocity;
            player2.velocity = newVelocity;
        }
        #endregion
    }
}
