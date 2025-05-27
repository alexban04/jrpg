using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleController : MonoBehaviour
{
    //panels
    [SerializeField] GameObject BattlePanel;
    [SerializeField] GameObject TargetsPanel;

    [SerializeField] GameObject AttackPanel;

    [SerializeField] GameObject ItemPanel;

    [SerializeField] GameObject OtherPanel;
    //battlepanel buttons
    [SerializeField] GameObject AttackText;
    Button attackButton;
    [SerializeField] GameObject ItemText;
    Button itemButton;
    [SerializeField] GameObject DefendText;
    Button defendButton;
    [SerializeField] GameObject OtherText;
    Button otherButton;

    //targets buttons
    [SerializeField] GameObject friendlyTarget1;
    Button buttonFriendlyTarget1;
    [SerializeField] GameObject friendlyTarget2;
    Button buttonFriendlyTarget2;
    [SerializeField] GameObject friendlyTarget3;
    Button buttonFriendlyTarget3;
    [SerializeField] GameObject friendlyTarget4;
    Button buttonFriendlyTarget4;
    [SerializeField] GameObject enemyTarget1;
    Button buttonEnemyTarget1;
    [SerializeField] GameObject enemyTarget2;
    Button buttonEnemyTarget2;
    [SerializeField] GameObject enemyTarget3;
    Button buttonEnemyTarget3;
    [SerializeField] GameObject enemyTarget4;
    Button buttonEnemyTarget4;
    [SerializeField] GameObject enemyTarget5;
    Button buttonEnemyTarget5;
    [SerializeField] GameObject enemyTarget6;
    Button buttonEnemyTarget6;
    //attack buttons
    [SerializeField] GameObject attackItemText1;
    Button buttonAttackItem1;
    [SerializeField] GameObject attackItemText2;
    Button buttonAttackItem2;
    [SerializeField] GameObject attackItemText3;
    Button buttonAttackItem3;
    [SerializeField] GameObject attackItemText4;
    Button buttonAttackItem4;
    [SerializeField] GameObject attackItemText5;
    Button buttonAttackItem5;
    [SerializeField] GameObject attackItemText6;
    Button buttonAttackItem6;


    [SerializeField] GameObject BackSprite;
    Button backButton;
    GameObject MainController;

    MainController mainController;

    List<WorkingEnemy> currentEnemies = new List<WorkingEnemy>();
    List<PlayableCharacter> currentParty = new List<PlayableCharacter>();

    void Awake()
    {
        attackButton = AttackText.GetComponent<Button>();
        itemButton = ItemText.GetComponent<Button>();
        defendButton = DefendText.GetComponent<Button>();
        otherButton = OtherText.GetComponent<Button>();
        backButton = BackSprite.GetComponent<Button>();
        attackButton.onClick.AddListener(OnAttackButtonPressed);
        itemButton.onClick.AddListener(OnItemButtonPressed);
        defendButton.onClick.AddListener(OnDefendButtonPressed);
        otherButton.onClick.AddListener(OnOtherButtonPressed);
        backButton.onClick.AddListener(OnBackButtonPressed);

        MainController = GameObject.Find("MainController");

        buttonFriendlyTarget1 = friendlyTarget1.GetComponent<Button>();
        buttonFriendlyTarget1.onClick.AddListener(OnAttackButtonPressed);
        buttonFriendlyTarget2 = friendlyTarget2.GetComponent<Button>();
        buttonFriendlyTarget2.onClick.AddListener(OnAttackButtonPressed);
        buttonFriendlyTarget3 = friendlyTarget3.GetComponent<Button>();
        buttonFriendlyTarget3.onClick.AddListener(OnAttackButtonPressed);
        buttonFriendlyTarget4 = friendlyTarget4.GetComponent<Button>();
        buttonFriendlyTarget4.onClick.AddListener(OnAttackButtonPressed);
        buttonEnemyTarget1 = enemyTarget1.GetComponent<Button>();
        buttonEnemyTarget1.onClick.AddListener(OnAttackButtonPressed);
        buttonEnemyTarget2 = enemyTarget2.GetComponent<Button>();
        buttonEnemyTarget2.onClick.AddListener(OnAttackButtonPressed);
        buttonEnemyTarget3 = enemyTarget3.GetComponent<Button>();
        buttonEnemyTarget3.onClick.AddListener(OnAttackButtonPressed);
        buttonEnemyTarget4 = enemyTarget4.GetComponent<Button>();
        buttonEnemyTarget4.onClick.AddListener(OnAttackButtonPressed);
        buttonEnemyTarget5 = enemyTarget5.GetComponent<Button>();
        buttonEnemyTarget5.onClick.AddListener(OnAttackButtonPressed);
        buttonEnemyTarget6 = enemyTarget6.GetComponent<Button>();
        buttonEnemyTarget6.onClick.AddListener(OnAttackButtonPressed);

        buttonAttackItem1 = attackItemText1.GetComponent<Button>();
        buttonAttackItem1.onClick.AddListener(OnAttackButtonPressed);
        buttonAttackItem2 = attackItemText2.GetComponent<Button>();
        buttonAttackItem2.onClick.AddListener(OnAttackButtonPressed);
        buttonAttackItem3 = attackItemText3.GetComponent<Button>();
        buttonAttackItem3.onClick.AddListener(OnAttackButtonPressed);
        buttonAttackItem4 = attackItemText4.GetComponent<Button>();
        buttonAttackItem4.onClick.AddListener(OnAttackButtonPressed);
        buttonAttackItem5 = attackItemText5.GetComponent<Button>();
        buttonAttackItem5.onClick.AddListener(OnAttackButtonPressed);
        buttonAttackItem6 = attackItemText6.GetComponent<Button>();
        buttonAttackItem6.onClick.AddListener(OnAttackButtonPressed);

        mainController = MainController.GetComponent<MainController>();

        foreach (int enemyId in mainController.CurrentEnemiesId)
        {
            if(enemyId != -1) currentEnemies.Add(MainController.GetComponent<MainController>().enemies[enemyId]);
        }
        foreach (int partyMemeberId in mainController.CurrentPartyMembersId)
        {
            if(partyMemeberId != -1) currentParty.Add(MainController.GetComponent<MainController>().partyMembers[partyMemeberId]);
        }
        friendlyTarget1.GetComponent<Text>().text = currentParty[0].characterName;
        friendlyTarget2.GetComponent<Text>().text = currentParty[1].characterName;
        friendlyTarget3.GetComponent<Text>().text = currentParty[2].characterName;
        friendlyTarget4.GetComponent<Text>().text = currentParty[3].characterName;
        enemyTarget1.GetComponent<Text>().text = currentEnemies[0].characterName;
        enemyTarget2.GetComponent<Text>().text = currentEnemies[0].characterName;
        enemyTarget3.GetComponent<Text>().text = currentEnemies[0].characterName;
        enemyTarget4.GetComponent<Text>().text = currentEnemies[0].characterName;
        enemyTarget5.GetComponent<Text>().text = currentEnemies[0].characterName;
        enemyTarget6.GetComponent<Text>().text = currentEnemies[0].characterName;
    }
    void targetChosen(int target)
    {
        DisableAll();
        AttackPanel.SetActive(true);
    }
    void OnFriendlyTarget1Pressed()
    {
        targetChosen(1);
    }
    void OnFriendlyTarget2Pressed()
    {
        targetChosen(2);
    }
    void OnFriendlyTarget3Pressed()
    {
        targetChosen(3);
    }
    void OnFriendlyTarget4Pressed()
    {
        targetChosen(4);
    }
    void OnEnemyTarget1Pressed()
    {
        targetChosen(5);
    }
    void OnEnemyTarget2Pressed()
    {
        targetChosen(6);
    }
    void OnEnemyTarget3Pressed()
    {
        targetChosen(7);
    }
    void OnEnemyTarget4Pressed()
    {
        targetChosen(8);
    }
    void OnEnemyTarget5Pressed()
    {
        targetChosen(9);
    }
    void OnEnemyTarget6Pressed()
    {
        targetChosen(10);
    }
    void OnAttackButtonPressed()
    {
        DisableAll();
        TargetsPanel.SetActive(true);
    }
    void OnItemButtonPressed()
    {
        DisableAll();
        ItemPanel.SetActive(true);
    }
    void OnDefendButtonPressed()
    {
        Debug.Log("Defend!");
    }
    void OnOtherButtonPressed()
    {
        DisableAll();
        OtherPanel.SetActive(true);
    }
    void OnBackButtonPressed()
    {
        DisableAll();
        BattlePanel.SetActive(true);
        BackSprite.SetActive(false);
    }
    void DisableAll()
    {
        BattlePanel.SetActive(false);
        TargetsPanel.SetActive(false);
        AttackPanel.SetActive(false);
        ItemPanel.SetActive(false);
        OtherPanel.SetActive(false);
        BackSprite.SetActive(true);
    }
}
