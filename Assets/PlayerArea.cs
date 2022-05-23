using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArea : MonoBehaviour
{

    [SerializeField] CardDisplay _discardPile;
    [SerializeField] CardDisplay _inventoryPile;
    [SerializeField] CardDisplay _handDisplay;
    [SerializeField] CardDisplay _playDisplay;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetLocalInteractivity(bool interactable)
    {
        _discardPile.SetInteractable(interactable);
        _inventoryPile.SetInteractable(interactable);
        _handDisplay.SetInteractable(interactable);
        _playDisplay.SetInteractable(interactable);
    }
}
