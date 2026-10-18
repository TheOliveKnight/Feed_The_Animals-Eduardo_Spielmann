using UnityEngine;

/*GameObject: the food prefabs or smth like that, it could be used on any object that needs to be destroyed after a certain time

Componet: PlaceHolderScriptFood

Description: wrote it on the "GameObject"
*/
public class PlaceHolderFoodScript : MonoBehaviour
{

[SerializeField] private float lifeDuration = 5f;

private void Start()
{
    Destroy(gameObject, lifeDuration);
}

}