using UnityEngine;
using UnityEngine.SceneManagement;


public class VictoryManager : MonoBehaviour
{
    [SerializeField] private float delayToVictoryScene = 2f;
    public void ShowVictoryScene()
    {
        Invoke("Victory", delayToVictoryScene);
    }
    public void Victory()
    {
        SceneManager.LoadScene("Victory");
        // Debug.Log("Victoire");
    }

}
