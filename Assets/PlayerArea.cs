using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArea : MonoBehaviour
{

    [SerializeField] CardDisplay _discardPile;
    [SerializeField] CardDisplay _inventoryPile;
    [SerializeField] CardDisplay _handDisplay;
    [SerializeField] CardDisplay _playDisplay;

    [SerializeField] int totalGold = 0;
    [SerializeField] int totalAmmo = 0;
    [SerializeField] int playerDecorations = 0;
    [SerializeField] int playerHealths = 0;
    [SerializeField] int playerLevel = 1;

    /// <summary>
    /// Draw total is how many card the player will recieve when clicking the inventory stack, default 4, affected by actions
    /// </summary>
    private int _drawTotal = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            _handDisplay.DetatchAllCards(_discardPile);
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            InventorySelect();

        }
    }

    public void SetLocalInteractivity(bool interactable)
    {
        _discardPile.SetInteractable(interactable);
        _inventoryPile.SetInteractable(interactable);
        _handDisplay.SetInteractable(interactable);
        _playDisplay.SetInteractable(interactable);
    }


    public void InventorySelect()
    {
        InventoryTotalCheck(_drawTotal);
        _inventoryPile.DetatchCards(_handDisplay, _drawTotal);
        _drawTotal = 0;

        /*
        switch (_handDisplay.gameObject.transform.childCount)
        {
            // draw 5 cards
            case 0:
                InventoryTotalCheck(5);
                _inventoryPile.DetatchCards(_handDisplay, 5);
                
                break;



                // draw extra cards allowed by played actions
            case 5:
                _inventoryPile.DetatchCards(_handDisplay, _drawTotal);
                break;



        }
        */

    }


    bool InventoryTotalCheck(int requiredCards)
    {

        if(_inventoryPile.gameObject.transform.childCount < requiredCards)
        {
            // not enough cards to complete a draw
            RestockInventory();

            return false;
        }

        else
        {
            return true;
        }

    }

    public void RestockInventory()
    {
        _discardPile.DetatchAllCards(_inventoryPile);

    }



}
