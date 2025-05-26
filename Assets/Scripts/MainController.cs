using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour
{
    public static MainController Instance;
    public List<PlayableCharacter> partyMembers = new List<PlayableCharacter>();
    public List<WorkingEnemy> enemies = new List<WorkingEnemy>();
    public List<int> CurrentPartyMembersId = new List<int>();
    public List<int> CurrentEnemiesId = new List<int>();

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}