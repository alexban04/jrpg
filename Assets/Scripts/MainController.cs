using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour
{
    public static MainController Instance;
    public Dictionary<int, PlayableCharacter> partyMembers = new Dictionary<int, PlayableCharacter>();
    public List<Character> enemies = new List<Character>();

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}