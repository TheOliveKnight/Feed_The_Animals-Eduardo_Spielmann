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
public AudioSource sfxThrowSource;
private void Start()
{
    sfxThrowSource = GetComponent<AudioSource>();
}

// Called by: Player Input
public void OnFeedInput(InputAction.CallbackContext ctx)
{
    if (ctx.performed)
    {
        SelectFood(ctx.control.name);
    }
}

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

private void ThrowFood(int index)
{
    if (foodItems == null || index < 0 || index >= foodItems.Length)
    {
        return;
    }

    if (foodItems[index] != null)
    {
        GameObject spawnedFood = Instantiate(foodItems[index], transform.position, Quaternion.identity);

        Rigidbody rb = spawnedFood.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(transform.up * 10f, ForceMode.Impulse);
        }

        if (sfxThrowSource != null && sfxThrowSource.clip != null)
        {
            sfxThrowSource.PlayOneShot(sfxThrowSource.clip);
        }
    }
}
}