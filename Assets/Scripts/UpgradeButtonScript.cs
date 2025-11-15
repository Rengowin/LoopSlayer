using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeButtonScript : MonoBehaviour
{
    // all infos what buff it gives and so on
    BuffClass buffClass;

    [SerializeField]
    TMPro.TextMeshProUGUI buffDescriptionText;

    [SerializeField]
    Button upgradeButton;

    UpgradeManager upgradeManager;
    UpgradeController upgradeController;

    string buffDescriptionTextString = "";
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Init(BuffClass buffInfo, UpgradeManager manager, UpgradeController controller)
    {
        buffClass = buffInfo;
        upgradeManager = manager;
        upgradeController = controller;

        buffDescriptionText.text = createBuffDescription();
        upgradeButton.onClick.AddListener(OnUpgradeButtonPressed);
    }


    private string createBuffDescription()
    {
        buffDescriptionTextString = "This upgrades gives the you a";
        if( buffClass.Multiply)
        {
            buffDescriptionTextString += " multiplicative ";
        }
        else if (buffClass.BuffAddtive)
        {
            buffDescriptionTextString += "n addtive ";
        }
        buffDescriptionTextString +=
            $"{buffClass.BuffName} buff of {buffClass.BuffAmount}.\n" +
            $"Upgrade Cost: {buffClass.UpgradeCost}";
        return buffDescriptionTextString;
    }

    public void OnUpgradeButtonPressed()
    {
        Debug.Log("Upgrade Button Pressed, es wird probiert ein upgrade gekauft");
        if (upgradeController.UpgradePoints >= buffClass.UpgradeCost)
        {
            upgradeController.UpgradePoints -= buffClass.UpgradeCost;
            upgradeManager.applyBuff(buffClass);
        }
        else
        {
            Debug.Log("Not enough upgrade points!");
        }
    }
}
