using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreScript : MonoBehaviour //handles the store, all the purchases and skin selection
{
    public GameObject page1; //objects for each different page of the store
    public GameObject page2;
    public GameObject page3;

    public GameObject warningPage; //the warning pop up 
    public Text warningText; //text on the warning

    public GameObject milkPage; //the page for the player to buy credit
    public Text amountMilk; //their current amount of credit

    public Text egyptText; //text which is under each different skin
    public Text robotText;
    public Text unicornText;
    public Text blueText;

    private void Update()
    {
        amountMilk.text = SharedData.MilkAmount.ToString(); //set the milk amount on screen
        //if the skin is unlocked then the text under that skin is changed to say use
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

    public void PageButton() //this is used for the arrow button and cycles through the pages, setting the current to active while making the rest inactive
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

    public void GetMilk() //displasy the milk page while setting the other pages to inactive
    {
        milkPage.SetActive(true);

        page1.SetActive(false);
        page2.SetActive(false);
        page3.SetActive(false);
    }

    public void BackStore() //returns back to the normal store away from the milk store, by making page 1 active again and milk inactive
    {
        page1.SetActive(true);

        milkPage.SetActive(false);
    }

    public void DEVAddMilk() //this is a dev button to add credit this would not be in the released game
    {
        SharedData.MilkAmount += 10;
    }

    public void EgyptianCat() //button for buying the egypt cat
    {
        if (SharedData.UnlockSkin[2] == 0) //if not already bought
        {
            BuyCat(2); //run buy function with the current skin number
        }
        else //if have bought
        {
            SharedData.CatSkin = 2; //set the current skin to this skin
        }
    }

    public void RobotCat()//button for buying the robot cat
    {
        if (SharedData.UnlockSkin[3] == 0)//if not already bought
        {
            BuyCat(3);//run buy function with the current skin number
        }
        else//if have bought
        {
            SharedData.CatSkin = 3;//set the current skin to this skin
        }
    }

    public void UnicornCat()//button for buying the unicorn cat
    {
        if (SharedData.UnlockSkin[4] == 0)//if not already bought
        {
            BuyCat(4);//run buy function with the current skin number
        }
        else//if have bought
        {
            SharedData.CatSkin = 4;//set the current skin to this skin
        }
    }

    public void BlueCat()//button for unlocking the blue cat
    {
        if (SharedData.UnlockSkin[1] == 0)//if not already unlocked
        {
            UnlockCat(1);//run unlock function with the current skin number
        }
        else//if have unlocked
        {
            SharedData.CatSkin = 1;//set the current skin to this skin
        }
    }
    public void PinkCat()//functionfor pink cat, its already unlocked at start so cant be unlocked or bought
    {
        SharedData.CatSkin = 0;//set the current skin to this skin
    }

    private void BuyCat(int skinNum) //takes in the skin number
    {
        if (SharedData.MilkAmount >= 10) //checks if there is enough credit
        {
            SharedData.MilkAmount -= 10; //subtracts the credit
            SharedData.CatSkin = skinNum; //sets current skin to that skin number
            SharedData.UnlockSkin[skinNum] = 1; //set that skin numbers position in array to unlocked
            SharedData.SaveData(); //save the game
        }
        else //if not enough credit
        {
            StartCoroutine(WarningBox("Not Enough Milk!")); //show the warning page saying not enough credit
        }
    }

    private void UnlockCat(int skinNum)//takes in the skin number
    {
        if (PlayerPrefs.GetFloat("score") >= 400) //checks if there is enough score
        {
            SharedData.CatSkin = skinNum;//sets current skin to that skin number
            SharedData.UnlockSkin[skinNum] = 1;//set that skin numbers position in array to unlocked
        }
        else//if not enough score
        {
            StartCoroutine(WarningBox("Unlock with a score of 400!"));//show the warning page saying not enough score
        }
    }

    private IEnumerator WarningBox(string warning)//simply shows the wanring page with the given text for a few seconds before setting back to inactive
    {
        warningPage.SetActive(true);
        warningText.text = warning;
        yield return new WaitForSeconds(3.0f);
        warningText.text = null;
        warningPage.SetActive(false);
    }

    public void ResetPurch() //used on the reset purchases button
    {
        SharedData.ResetData(); //resets all saved data
        //resets all the text boxes under each cat back to default
        egyptText.text = "Buy"; 
        robotText.text = "Buy";
        unicornText.text = "Buy";
        blueText.text = "Unlock";
    }
}
