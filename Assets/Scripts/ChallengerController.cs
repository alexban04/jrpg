using UnityEngine;
using UnityEngine.SceneManagement;

public class ChallengerController : MonoBehaviour, Interactable
{
    public void Interact()
    {
        Debug.Log("Battle Start");
        SceneManager.LoadScene(1);
    }
    
}
