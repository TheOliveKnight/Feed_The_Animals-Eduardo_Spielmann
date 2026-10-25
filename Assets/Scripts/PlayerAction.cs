using UnityEngine;
using UnityEngine.InputSystem;

/*

GameObject: Player

Component: PlayerAction

Description:

Handles selecting and throwing food items from the player's position, playing

associated audio feedback upon throw execution.

*/

public class PlayerAction : MonoBehaviour
{
[SerializeField] private GameObject[] foodItems;
[SerializeField] private Animator playerAnimator;
public AudioSource sfxThrowSource;

//This IsThrowing is for playermovement
public bool IsThrowing { get; private set; }
private void Start()
{
    sfxThrowSource = GetComponent<AudioSource>();
    playerAnimator = GetComponent<Animator>();
}

// Called by player input
public void OnFeedInput(InputAction.CallbackContext ctx)
{
    if (ctx.performed)
    {
        SelectFood(ctx.control.name);
    }
}

// This section handles the keyboard keys to food keys
private void SelectFood(string keyName)
{
    int index = 0;

    if (keyName == "h" || keyName.ToLower().Contains("h"))
    {
        index = 0;
    }
    else if (keyName == "u" || keyName.ToLower().Contains("u"))
    {
        index = 1;
    }
    else if (keyName == "i" || keyName.ToLower().Contains("i"))
    {
        index = 2;
    }
     else if (keyName == "l" || keyName.ToLower().Contains("l"))
    {
        index = 3;
    }

    ThrowFood(index);
}

// throws the food based on the index
private void ThrowFood(int index)
{
    if (foodItems == null || index < 0 || index >= foodItems.Length)
    {
        return;
    }

    if (IsThrowing)
    {
        return;
    }

    IsThrowing = true;

    if (foodItems[index] != null)
    {
        GameObject spawnedFood = Instantiate(foodItems[index], transform.position, Quaternion.identity);

        if (playerAnimator != null)
        {
            IsThrowing = true;
            //Debug.Log($"Throw has started");
            playerAnimator.SetTrigger("Throw");
        }
    
        Rigidbody rb = spawnedFood.GetComponent<Rigidbody>();
        if (rb != null)
        {
            // throws up b/c the player is rotated 90 for the sprite and its animations
            rb.AddForce(transform.up * 10f, ForceMode.Impulse);
        }

        if (sfxThrowSource != null && sfxThrowSource.clip != null)
        {
            // playoneshot so it can play multiple times without needing to wait for the first audio to finish, also its named sfxThrow so I can know the difference in the editor
            sfxThrowSource.PlayOneShot(sfxThrowSource.clip);
        }
    }
}
    public void FinishThrowAnimation()
    {
        IsThrowing = false;
        //Debug.Log("Throw finished - movement unlocked");
    }
}