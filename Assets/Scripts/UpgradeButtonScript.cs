using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeButtonScript : MonoBehaviour
{
    BuffClass buffClass;

    [SerializeField]
    TMPro.TextMeshProUGUI buffDescriptionText;

    [SerializeField]
    Button upgradeButton;

    [Header("References To Check if they are here")]
    [SerializeField]
    UpgradeManager upgradeManager;
    [SerializeField]
    UpgradeController upgradeController;

    string buffDescriptionTextString = "";

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
        buffDescriptionTextString = "This upgrades gives you a";
        if (buffClass.Multiply)
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
        if (upgradeController.UpgradePoints >= buffClass.UpgradeCost)
        {
            upgradeController.UpgradePoints -= buffClass.UpgradeCost;
            upgradeManager.applyBuff(buffClass);
        }
    }
}
