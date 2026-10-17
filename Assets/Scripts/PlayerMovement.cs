using UnityEngine;
using UnityEngine.InputSystem;

/*

GameObject: Player

Component: PlayerMovement

Description:

Handles player horizontal movement within designated boundary limits and updates

the character animator parameters based on movement state.
*/

public class PlayerMovement : MonoBehaviour
{
[SerializeField] private float playerSpeed;
private float centerToEdge_ = 15.0f;
private Vector2 movementDirection;
private Animator animator;

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
    Debug.Log($"inputvalue{movementDirection}");
}

private void Move()
{
    Vector3 currentPosition = transform.position;
    Vector3 movement = new Vector3(movementDirection.x, 0f, 0f) * playerSpeed * Time.deltaTime;
    Vector3 newPosition = currentPosition + movement;

    newPosition.x = Mathf.Clamp(newPosition.x, -centerToEdge_, centerToEdge_);
    transform.position = newPosition;

    if (animator != null)
    {
        bool isMoving = Mathf.Abs(movementDirection.x) > 0.005f;
        animator.SetBool("IsRunning", isMoving);
    }
}
}
