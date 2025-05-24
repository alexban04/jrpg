using UnityEngine;
using UnityEngine.UI;

public class BattleController : MonoBehaviour
{
    [SerializeField] GameObject BattlePanel;
    [SerializeField] GameObject TargetsPanel;

    [SerializeField] GameObject AttackPanel;

    [SerializeField] GameObject ItemPanel;

    [SerializeField] GameObject OtherPanel;
    [SerializeField] GameObject AttackText;
    Button attackButton;
    [SerializeField] GameObject ItemText;
    Button itemButton;
    [SerializeField] GameObject DefendText;
    Button defendButton;
    [SerializeField] GameObject OtherText;
    Button otherButton;
    [SerializeField] GameObject BackSprite;
    Button backButton;

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
