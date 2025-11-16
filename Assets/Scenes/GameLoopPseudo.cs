using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoopPseudo : MonoBehaviour
{

    public List<Item> foodsList { get; set; }
    public List<Item> cookedItems;
    public List<Item> ToBeCooked;
    public List<string> BillList;

    // Start is called before the first frame update
    void Start()
    {
        //Create a list of foods to cook
        //use bill creator text to display the foods to cook by adding a textmeshpro object to the screens
        // and attaching the billcreator text script to the tmp and then feeding the tmp as an argument to the script (you can ignore this and do it later)
        //create a priority queue for each screen (grills and friers) i.e. sort the queue or stack based on how close each item is to being cooked and have two queues, one for each screen
        //alt, you can make two lists and sort them based on cook time remaining every update call
        

    }

    // Update is called once per frame
    void Update()
    {
        //if desired score is reached or time has passed end the game
        //if clear bill button is clicked, clear the list of foods to cook and generate a new one 
        // and remove all cooked food that match the bill from the cooked food list aka the line, 
        // also remove them from the display, don't forget to check whether they actually cooked all the items on the bill
        // by comparing cooked food list to list of foods to cook then clear both and then generate a new bill
        //might have to add a clear bill button, you can leave the bills for sunday and focus on making the rest of the game work
        //UI GOAL (you can ignore this and do it later): Blink the buttons using the priority queue
        //if an item is removed from it's cooker then remove it from it's queue and add it to a cooked list
        //this should be all for now lets get this working and then we can finetune the bills and the ui features.
        

        
    }
}
