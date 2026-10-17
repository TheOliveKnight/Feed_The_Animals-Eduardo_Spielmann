using UnityEngine;
using UnityEngine.InputSystem;

/*

GameObject: Player

Component: PlayerMovement

Description:

Handles player horizontal movement within designated boundary limits and updates, 

the character animator parameters based on movement state.

the character plays a audio as a walking sound based on a interval clock and based on movement state
*/

public class PlayerMovement : MonoBehaviour
{
[SerializeField] private float playerSpeed;
private float centerToEdge_ = 15.0f;
private Vector2 movementDirection;
private Animator animator;
public AudioSource audioSource;
private bool isMoving;
[SerializeField] private float stepInterval = 0.4f; // Time in seconds between each sound
private float stepTimer;
private void Start()
{
    animator = GetComponent<Animator>();
}

private void Update()
{
    Move();
}

// Called by: Player Input
public void OnMovementInput(InputAction.CallbackContext ctx)
{
    movementDirection = ctx.ReadValue<Vector2>(); 
    // Debug.Log($"inputvalue{movementDirection}");
}

private void Move()
{
    Vector3 currentPosition = transform.position;
    Vector3 movement = new Vector3(movementDirection.x, 0f, 0f) * playerSpeed * Time.deltaTime;
    Vector3 newPosition = currentPosition + movement;

    newPosition.x = Mathf.Clamp(newPosition.x, -centerToEdge_, centerToEdge_);
    transform.position = newPosition;
    isMoving = Mathf.Abs(movementDirection.x) > 0.001f;
    if (animator != null)
    {
        animator.SetBool("IsRunning", isMoving);
    }

    //Next section handles the internal clock

   // Debug.Log($"{isMoving}");
    // Handle repeating movement audio
    if (isMoving)
        {
            //Debug.Log($"{isMoving}");
            stepTimer += Time.deltaTime;
            //Debug.Log($"It is infact dectecting isMoving and also steptimer = {stepTimer}");
            if (stepTimer >= stepInterval)
            {
                //Debug.Log($" stepTimer > interval also {stepTimer}");
                if (audioSource != null && audioSource.clip != null)
                {
                    audioSource.PlayOneShot(audioSource.clip);
                }
                stepTimer = 0f; // Reset the timer after playing
            }
        }
    else
    {
            // Reset timer immediately when stopping so the next movement starts instantly
            stepTimer = 0f; 
    }
}
}
