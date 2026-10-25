using UnityEngine;

public class AnimalMove : MonoBehaviour
{
    [SerializeField] protected float animalSpeed;
    [SerializeField] private float outOfScene;

    private void Update()
    {
        MoveForward();
        DeleteOutOfScene();
    }

    private void MoveForward()
    {
        transform.Translate(Vector3.forward * animalSpeed * Time.deltaTime);
    }

    private void DeleteOutOfScene()
    {
        // Check if the animal has crossed the out-of-scene boundary
        if (transform.position.z > outOfScene)
        {
            // Call UIManager to lower the remaining animals count
            if (UIManager.Instance != null)
            {
                UIManager.Instance.AnimalsRemainingUpdate();
            }

            // Delete / Destroy the animal object
            Destroy(gameObject);
        }
    }
}