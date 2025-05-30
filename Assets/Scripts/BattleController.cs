using System;
using System.Collections.Generic;
using Unity.VisualScripting;
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

    //Consumable Items
    [SerializeField] List<GameObject> Consumables = new List<GameObject>();
    [SerializeField] List<GameObject> ConsumablesPageControllers = new List<GameObject>();
    List<Button> ConsumablePageButtons = new List<Button>();
    List<Button> ConsumableButtons = new List<Button>();
    //Initiative
    [SerializeField] List<GameObject> Initiative = new List<GameObject>();
    List<int> TurnOrder = new List<int>();
    //Other Fields
    [SerializeField] GameObject BackSprite;
    Button backButton;
    GameObject MainController;

    MainController mainController;

    List<WorkingEnemy> currentEnemies = new List<WorkingEnemy>();
    List<PlayableCharacter> currentParty = new List<PlayableCharacter>();
    int currentConsumablePage;

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
        buttonFriendlyTarget1.onClick.AddListener(OnFriendlyTarget1Pressed);
        buttonFriendlyTarget2 = friendlyTarget2.GetComponent<Button>();
        buttonFriendlyTarget2.onClick.AddListener(OnFriendlyTarget2Pressed);
        buttonFriendlyTarget3 = friendlyTarget3.GetComponent<Button>();
        buttonFriendlyTarget3.onClick.AddListener(OnFriendlyTarget3Pressed);
        buttonFriendlyTarget4 = friendlyTarget4.GetComponent<Button>();
        buttonFriendlyTarget4.onClick.AddListener(OnFriendlyTarget4Pressed);
        buttonEnemyTarget1 = enemyTarget1.GetComponent<Button>();
        buttonEnemyTarget1.onClick.AddListener(OnEnemyTarget1Pressed);
        buttonEnemyTarget2 = enemyTarget2.GetComponent<Button>();
        buttonEnemyTarget2.onClick.AddListener(OnEnemyTarget2Pressed);
        buttonEnemyTarget3 = enemyTarget3.GetComponent<Button>();
        buttonEnemyTarget3.onClick.AddListener(OnEnemyTarget3Pressed);
        buttonEnemyTarget4 = enemyTarget4.GetComponent<Button>();
        buttonEnemyTarget4.onClick.AddListener(OnEnemyTarget4Pressed);
        buttonEnemyTarget5 = enemyTarget5.GetComponent<Button>();
        buttonEnemyTarget5.onClick.AddListener(OnEnemyTarget5Pressed);
        buttonEnemyTarget6 = enemyTarget6.GetComponent<Button>();
        buttonEnemyTarget6.onClick.AddListener(OnEnemyTarget6Pressed);

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
            if (enemyId != -1) currentEnemies.Add(MainController.GetComponent<MainController>().enemies[enemyId]);
        }
        foreach (int partyMemeberId in mainController.CurrentPartyMembersId)
        {
            if (partyMemeberId != -1) currentParty.Add(MainController.GetComponent<MainController>().partyMembers[partyMemeberId]);
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

        foreach (GameObject obj in Consumables)
        {
            ConsumableButtons.Add(obj.GetComponent<Button>());
        }
        ConsumableButtons[0].onClick.AddListener(OnConsumable1);
        ConsumableButtons[1].onClick.AddListener(OnConsumable2);
        ConsumableButtons[2].onClick.AddListener(OnConsumable3);
        ConsumableButtons[3].onClick.AddListener(OnConsumable4);
        ConsumableButtons[4].onClick.AddListener(OnConsumable5);
        ConsumableButtons[5].onClick.AddListener(OnConsumable6);
        ConsumableButtons[6].onClick.AddListener(OnConsumable7);
        ConsumableButtons[7].onClick.AddListener(OnConsumable8);

        foreach (GameObject controller in ConsumablesPageControllers)
        {
            ConsumablePageButtons.Add(controller.GetComponent<Button>());
        }
        ConsumablePageButtons[0].onClick.AddListener(OnPreviousConsumablePage);
        ConsumablePageButtons[1].onClick.AddListener(OnNextConsumablePage);
        
        setInitiative();
    }

    void setInitiative()
    {
        List<String> list = new List<String>();
        List<int> speed = new List<int>();
        foreach (WorkingEnemy obj in currentEnemies)
        {
            list.Add(obj.characterName);
            speed.Add(obj.SPD);
        }
        foreach (PlayableCharacter obj in currentParty)
        {
            list.Add(obj.characterName);
            speed.Add(obj.SPD);
        }
        int tempint;
        String tempstring;
        for (int i = 0; i < list.Count; i++)
        {
            for (int j = i + 1; j < list.Count; j++)
            {
                if (speed[i] < speed[j])
                {
                    tempint = speed[i];
                    tempstring = list[i];
                    speed[i] = speed[j];
                    list[i] = list[j];
                    speed[j] = tempint;
                    list[j] = tempstring;
                }
            }
        }
        int count = 0;
        foreach (String name in list)
        {
            Initiative[count].GetComponent<Text>().text = name;
            count++;
            Debug.Log("added to initiative " + name);
        }
        while (count < 10)
        {
            Debug.Log("removed from initiative " + Initiative[count].GetComponent<Text>().text);
            Initiative[count].GetComponent<Text>().text = "";
            count++;
        }
    }

    PlayableCharacter PlayableFirstInitiative()
    {
        foreach (PlayableCharacter character in currentParty)
        {
            if (character.characterName.Equals(Initiative[0].GetComponent<Text>().text)) return character;
            Debug.Log(character.characterName + " != " + Initiative[0].GetComponent<Text>().name);
        }
        return null;
    }
        WorkingEnemy EnemyFirstInitiative()
    {
        foreach (WorkingEnemy enemy in currentEnemies)
        {
            if (enemy.characterName.Equals(Initiative[0].GetComponent<Text>().text)) return enemy;
        }
        return null;
    }

    void nextInitiative()
    {
        String text = Initiative[0].GetComponent<Text>().text;
        int size = Initiative.Count;
        for (int i = 0; i < size; i++)
        {
            Initiative[i].GetComponent<Text>().text = Initiative[i + 1].GetComponent<Text>().text;
        }
        Initiative[size].GetComponent<Text>().text = text;
    }
    void targetChosen(int target)
    {
        DisableAll();
        AttackPanel.SetActive(true);
        PlayableCharacter character = PlayableFirstInitiative();
        if (character == null) return;
        if(character.inventory[5])attackItemText6.GetComponent<Text>().text = character.inventory[5].name;
        if(character.inventory[4])attackItemText5.GetComponent<Text>().text = character.inventory[4].name;
        if(character.inventory[3])attackItemText4.GetComponent<Text>().text = character.inventory[3].name;
        if(character.inventory[2])attackItemText3.GetComponent<Text>().text = character.inventory[2].name;
        if(character.inventory[1])attackItemText2.GetComponent<Text>().text = character.inventory[1].name;
        if(character.inventory[0])attackItemText1.GetComponent<Text>().text = character.inventory[0].name;
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
    void OnConsumable1()
    {

    }
    void OnConsumable2()
    {
        
    }
    void OnConsumable3()
    {
        
    }
    void OnConsumable4()
    {
        
    }
    void OnConsumable5()
    {
        
    }
    void OnConsumable6()
    {
        
    }
    void OnConsumable7()
    {
        
    }
    void OnConsumable8()
    {
        
    }
    void OnPreviousConsumablePage()
    {
        currentConsumablePage -= 1;
        if (currentConsumablePage < 8) ConsumablesPageControllers[0].SetActive(false);
        if (PlayableFirstInitiative().consumables.Count > currentConsumablePage * 8 + 8) ConsumablesPageControllers[1].SetActive(true);
        ItemPanelRefresh();
    }
    void OnNextConsumablePage()
    {
        ConsumablesPageControllers[0].SetActive(true);
        currentConsumablePage += 1;
        if (PlayableFirstInitiative().consumables.Count < currentConsumablePage * 8 + 8) ConsumablesPageControllers[1].SetActive(false);
        ItemPanelRefresh();
    }
    void OnAttackButtonPressed()
    {
        DisableAll();
        TargetsPanel.SetActive(true);
    }
    void OnItemButtonPressed()
    {
        DisableAll();
        currentConsumablePage = 0;
        if (PlayableFirstInitiative().consumables.Count < currentConsumablePage * 8 + 8) ConsumablesPageControllers[1].SetActive(false);
        ConsumablesPageControllers[0].SetActive(false);
        ItemPanel.SetActive(true);
        ItemPanelRefresh();
    }
    void ItemPanelRefresh()
    {
        PlayableCharacter character = PlayableFirstInitiative();
        List<ConsumableItem> consumables = new List<ConsumableItem>();
        foreach (ConsumableItem item in character.consumables)
        {
            consumables.Add(item);
        }
        for (int i = 0; i < 8; i++)
        {
            Consumables[i].GetComponent<Text>().text = "";
        }
        for (int i = 0; i < 8; i++)
        {
            if (consumables.Count <= i + currentConsumablePage * 8) break;
            Consumables[i].GetComponent<Text>().text = consumables[currentConsumablePage * 8 + i].name;
        }
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
