using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainControl : MonoBehaviour
{
    public bool ticketSent;
    public List<string> currentOrder = new List<string>();
    public int score;
    public int potentialScore;
    public float gameTime = 300f;
    
    public ItemSlot slot1;
    public ItemSlot slot2;
    public ItemSlot slot3;
    public ItemSlot slot4;
    public ItemSlot slot5;
    public TicketGen generateTicket;
    
    


    // Start is called before the first frame update
    void Start()
    {
        currentOrder = generateTicket.GenerateOrder();
        ticketSent = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameTime <= 0f)
        {
            GameOver();
        }
        else
        {
            gameTime -= Time.deltaTime;
        }

        //If there is not already a ticket, generate one from a set of pre - generated orders(if ticketsent = false make a new ticket, then ticketSent = true)
        //The pre-generated order could also be a list of items for simplicity's sake
        if (ticketSent == false)
        {
            currentOrder = generateTicket.GenerateOrder();
            ticketSent = true;
        } 
    }

    public void OrderShipped()
    {
        Debug.Log("OrderShipped Initiated.");
        // Attach this method to a button near the plate
        //Go through all the slots of the Plate Station(PlateCanvas object) and put the items inside in a temporary list
        //Compare that list with the order for scoring(maybe in a different method called Scrore() ?)
        //Clear the slots of Plate Station and destroy the objects
        //Clear out the temporary list if needed

        
        List<ItemSlot> slots = new List<ItemSlot>();
        slots.Add(slot5);
        slots.Add(slot4);
        slots.Add(slot3);
        slots.Add(slot2);
        slots.Add(slot1);
        Debug.Log("Slots list created.");
        List<Item> currentItems = new List<Item>();
        for (int i = 0; i < 5; ++i)
        {
            if (slots[i].isFull == true)
            {
                currentItems.Add(slots[i].currentItem);
                Debug.Log(slots[i].currentItem.ItemName + "Added to currentItemList");
            }
        }
        
        
        Score(currentItems);
        Debug.Log("Score Generated.");
        for (int i = 0; i < 5; i++)
        {
            if (slots[i].isFull)
            {
                slots[i].currentItem.Destroy();
                slots[i].ClearSlot();
                Debug.Log(slots[i] + "cleared.");
            }
        }

        ticketSent = false;
    }

    public void Score(List<Item> currentItems)
    {
        //Compare the positions in the shipped order list to the pre - generated order
        //> If the there is a slot that doesn't match, apply a hefty penalty
        //> While you're doing that, check what score each item recieved (undercooked, perfect, etc) and apply scores based on that
        //> Update the public bool score variable

        int ScoreVal = 0;
        int currentItemCount = currentItems.Count;
        int orderItemCount = currentOrder.Count;
        Debug.Log("currentItemCount: " + currentItemCount);
        Debug.Log("orderItemCount: " + orderItemCount);

        if (currentItemCount == orderItemCount)
        {
            //If Both have the same length, check for how many items the player put.
            for (int i = 0; i < currentItemCount - 1; ++i)
            {

                if (currentItems[i].ItemName == currentOrder[i])
                {
                    ScoreVal += 1;
                }
                else
                {
                    ScoreVal -= 1;
                    bool itemExists = false;
                    for (int j = 0; j < orderItemCount - 1; ++j)
                    {
                        if (currentItems[i].ItemName == currentOrder[j])
                        {
                            itemExists = true;
                        }
                    }
                    if (itemExists == false)
                    {
                        ScoreVal -= 2;
                    }
                }
                string curNote = currentItems[i].note;
                if (curNote == "Not Cookable")
                {
                    ScoreVal += 0;
                }
                else if (curNote == "Perfectly Cooked!")
                {
                    ScoreVal += 5;
                }
                else if (curNote == "Slightly Overcooked!" || curNote == "Slightly Undercooked!")
                {
                    ScoreVal += 0;
                }
                else if (curNote == "Overcooked!")
                {
                    ScoreVal -= 2;
                }
                else if (curNote == "Undercooked!")
                {
                    ScoreVal -= 5;
                }
            }
            //For every item in the order, is there a corresponding item on the plate.
            for (int i = 0; i < orderItemCount; ++i)
            {
                bool itemExists = false;
                for (int j = 0; j < currentItemCount - 1; ++j)
                {
                    if (currentOrder[i] == currentItems[j].itemName)
                    {
                        itemExists = true;
                    }

                }
                if (itemExists == false)
                {
                    ScoreVal -= 2;
                }
                if (currentOrder[i] == "Top Bun" || currentOrder[i] == "Bottom Bun" || currentOrder[i] == "Cheese" || currentOrder[i] == "Lettuce")
                {
                    potentialScore += 1;
                }
                else
                {
                    potentialScore += 6;
                }
            }
            score += ScoreVal;

        }
        else if (currentItemCount > orderItemCount || orderItemCount > currentItemCount)
        {
            List<string> bigList = new List<string>();
            List<string> smallList = new List<string>();
            if (currentItemCount > orderItemCount)
            {
                for (int k = 0; k < currentItemCount; k++)
                {
                    bigList.Add(currentItems[k].itemName);
                }
                smallList = currentOrder;
            }
            else
            {
                bigList = currentOrder;
                for (int k = 0; k < currentItemCount; k++)
                {
                    smallList.Add(currentItems[k].itemName);
                }
            }
            for (int i = 0; i < smallList.Count - 1; ++i)
                if (smallList[i] == bigList[i])
                {
                    ScoreVal += 1;
                }
                else
                {
                    ScoreVal -= 1;
                    bool itemExists = false;
                    for (int j = 0; j < bigList.Count - 1; ++j)
                    {
                        if (smallList[i] == bigList[j])
                        {
                            itemExists = true;
                        }
                    }
                    if (itemExists == false)
                    {
                        ScoreVal -= 2;
                    }
                }
            for (int i = 0; i < currentItemCount - 1; ++i)
            {
                string curNote = currentItems[i].note;
                if (curNote == "Not Cookable")
                {
                    ScoreVal += 0;
                }
                else if (curNote == "Perfectly Cooked!")
                {
                    ScoreVal += 5;
                }
                else if (curNote == "Slightly Overcooked!" || curNote == "Slightly Undercooked!")
                {
                    ScoreVal += 0;
                }
                else if (curNote == "Overcooked!")
                {
                    ScoreVal -= 2;
                }
                else if (curNote == "Undercooked!")
                {
                    ScoreVal -= 5;
                }
            }
            for (int i = 0; i < bigList.Count - 1; ++i)
            {
                bool itemExists = false;
                for (int j = 0; j < smallList.Count - 1; ++j)
                {
                    if (bigList[i] == smallList[j])
                    {
                        itemExists = true;
                    }

                }
                if (itemExists == false)
                {
                    ScoreVal -= 2;
                }
            }
            for (int i = 0; i < orderItemCount; ++i)
            {
                if (currentOrder[i] == "Top Bun" || currentOrder[i] == "Bottom Bun" || currentOrder[i] == "Cheese" || currentOrder[i] == "Lettuce")
                {
                    potentialScore += 1;
                }
                else
                {
                    potentialScore += 6;
                }
            }
            score += ScoreVal;
        }
    }
    public void GameOver()
    {
        int finalDecimal = score / potentialScore;
        string finalScore = score + "/" + potentialScore;
        string grade;
        string resultNote;
        if (finalDecimal == 1)
        {
            grade = "A+";
            resultNote = "Pawpaw's Finest Chef!";
        } else if (finalDecimal >= 0.86)
        {
            grade = "A";
            resultNote = "A Fine Sous Chef!";
        } else if (finalDecimal >= 0.72) {
            grade = "B";
            resultNote = "Not Bad, Cook.";
        } else if (finalDecimal >= 0.6){
            grade = "C";
            resultNote = "Could use some work, Rookie.";
        }
        else if (finalDecimal >= 0.5)
        {
            grade = "D";
            resultNote = "First day on line, dishee?";
        } else if (finalDecimal <= 0.49)
        {
            grade = "F";
            resultNote = "GET BACK TO THE DISH PIT!!";
        }

    }

}
