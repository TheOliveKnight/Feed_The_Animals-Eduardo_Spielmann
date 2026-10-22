using UnityEngine;
public class Test_GameManager : MonoBehaviour
{
        // Start is called once and then after 2 seconds calls RunTest every 1.5 seconds
     void Start()
     {
        InvokeRepeating("RunTest", 2, 1.5f);
     }
        // This will remove an animal and add 10 points every 1.5 seconds 
     void RunTest()
    {
         UIManager.Instance.AnimalsRemainingUpdate();
         UIManager.Instance.ScoreUpdate(10);
    }
}
