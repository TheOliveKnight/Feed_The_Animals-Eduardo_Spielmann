using UnityEngine;

public class EatFood : MonoBehaviour
{
    [SerializeField] protected string foodItEats;
    private bool isHungry = true;

    // Optional: Set how many points this food/animal gives (you can adjust this in the inspector)
    [SerializeField] private int pointsToAdd = 1;

    private void OnCollisionEnter(Collision other)
    {
        if (isHungry)
        {
            // Check if the collided object matches the food tag or name
            if (other.gameObject.CompareTag(foodItEats) || other.gameObject.name.Contains(foodItEats))
            {
                // Action: Eat the food (destroy the food object)
                Destroy(other.gameObject);

                // Update UI: Add score and lower remaining animals count
                if (UIManager.Instance != null)
                {
                    UIManager.Instance.ScoreUpdate(pointsToAdd);
                }

                // Transition: Move to 'Not Hungry' state
                isHungry = false;
            }
        }
        else
        {
            // FSM State: Not Hungry - Ignores food collisions
            //Debug.Log($"{gameObject.name} is not hungry and ignored the food.");
        }
    }
}