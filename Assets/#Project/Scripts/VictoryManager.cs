using UnityEngine;
using UnityEngine.SceneManagement;


public class VictoryManager : MonoBehaviour
{
    public void ShowVictoryScene()
    {
        Invoke("Victory", 2f);
    }
    public void Victory()
    {
        SceneManager.LoadScene("Victory");
        // Debug.Log("Victoire");
    }

}
