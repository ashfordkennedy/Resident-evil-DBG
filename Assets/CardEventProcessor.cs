using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EventProcessorMode {none, Hand, play, Discard, Inventory, mansion, ShopItem}
public class CardEventProcessor : MonoBehaviour
{
    [SerializeField] EventProcessorMode eventMode = EventProcessorMode.none;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    


    public void SelectCard(GameObject card)
    {
        string identifier = card.name;


        switch (eventMode)
        {
            case EventProcessorMode.Inventory:

                break;



        }





    }
}
