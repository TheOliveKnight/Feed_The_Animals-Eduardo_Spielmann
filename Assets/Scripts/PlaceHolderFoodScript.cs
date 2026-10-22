using UnityEngine;

/*GameObject: the food prefabs  

Componet: PlaceHolderScriptFood

Description: any object that needs to be destroyed after a certain time
*/
public class PlaceHolderFoodScript : MonoBehaviour
{

[SerializeField] private Animator animator;
[SerializeField] private float lifeDuration = 5f;

private void Start()
{
    Destroy(gameObject, lifeDuration);
}

}