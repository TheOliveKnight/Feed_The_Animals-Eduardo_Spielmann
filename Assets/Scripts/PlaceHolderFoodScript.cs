using UnityEngine;

public class PlaceHolderFoodScript : MonoBehaviour
{

[SerializeField] private float lifeDuration = 5f;

private void Start()
{
    Destroy(gameObject, lifeDuration);
}


}

