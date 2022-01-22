using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreScript : MonoBehaviour
{
    public GameObject page1;
    public GameObject page2;
    public GameObject page3;

    public GameObject warningPage;
    public Text warningText;

    public GameObject milkPage;
    public Text amountMilk;

    public Text egyptText;
    public Text robotText;
    public Text unicornText;
    public Text blueText;

    private void Update()
    {
        amountMilk.text = SharedData.MilkAmount.ToString();

        if (SharedData.UnlockSkin[2] == 1)
        {
            egyptText.text = "Use";
        }

        if (SharedData.UnlockSkin[3] == 1)
        {
            robotText.text = "Use";
        }

        if (SharedData.UnlockSkin[4] == 1)
        {
            unicornText.text = "Use";
        }

        if (SharedData.UnlockSkin[1] == 1)
        {
            blueText.text = "Use";
        }
    }

    public void PageButton()
    {
        if (page1.activeSelf == true)
        {
            page2.SetActive(true);
            page1.SetActive(false);
        }
        else if (page2.activeSelf == true)
        {
            page3.SetActive(true);
            page2.SetActive(false);
        }
        else if (page3.activeSelf == true)
        {
            page1.SetActive(true);
            page3.SetActive(false);
        }
    }

    public void GetMilk()
    {
        milkPage.SetActive(true);

        page1.SetActive(false);
        page2.SetActive(false);
        page3.SetActive(false);
    }

    public void BackStore()
    {
        page1.SetActive(true);

        milkPage.SetActive(false);
    }

    public void DEVAddMilk()
    {
        SharedData.MilkAmount += 10;
    }

    public void EgyptianCat()
    {
        if (SharedData.UnlockSkin[2] == 0)
        {
            BuyCat(2);
        }
        else
        {
            SharedData.CatSkin = 2;
        }
    }

    public void RobotCat()
    {
        if (SharedData.UnlockSkin[3] == 0)
        {
            BuyCat(3);
        }
        else
        {
            SharedData.CatSkin = 3;
        }
    }

    public void UnicornCat()
    {
        if (SharedData.UnlockSkin[4] == 0)
        {
            BuyCat(4);
        }
        else
        {
            SharedData.CatSkin = 4;
        }
    }

    public void BlueCat()
    {
        if (SharedData.UnlockSkin[1] == 0)
        {
            UnlockCat(1);
        }
        else
        {
            SharedData.CatSkin = 1;
        }
    }
    public void PinkCat()
    {
        SharedData.CatSkin = 0;
    }

    private void BuyCat(int skinNum)
    {
        if (SharedData.MilkAmount >= 10)
        {
            SharedData.MilkAmount -= 10;
            SharedData.CatSkin = skinNum;
            SharedData.UnlockSkin[skinNum] = 1;
            SharedData.SaveData();
        }
        else
        {
            StartCoroutine(WarningBox("Not Enough Milk!"));
        }
    }

    private void UnlockCat(int skinNum)
    {
        if (PlayerPrefs.GetFloat("score") >= 400) 
        {
            SharedData.CatSkin = skinNum;
            SharedData.UnlockSkin[skinNum] = 1;
        }
        else
        {
            StartCoroutine(WarningBox("Unlock with a score of 10!"));
        }
    }

    private IEnumerator WarningBox(string warning)
    {
        warningPage.SetActive(true);
        warningText.text = warning;
        yield return new WaitForSeconds(3.0f);
        warningText.text = null;
        warningPage.SetActive(false);
    }

    public void ResetPurch()
    {
        SharedData.ResetData();
        egyptText.text = "Buy";
        robotText.text = "Buy";
        unicornText.text = "Buy";
        blueText.text = "Unlock";
    }
}
