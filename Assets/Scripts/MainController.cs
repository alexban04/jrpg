using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour
{
    public static MainController Instance;
    public List<PlayableCharacter> partyMembers = new List<PlayableCharacter>();
    public List<Character> enemies = new List<Character>();

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}