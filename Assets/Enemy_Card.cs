using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Card : Base_Card
{
    


    public void SetCard(Card_Enemy card)
    {

        var materials = _renderer.sharedMaterials;
        materials[0] = card.material;
        _renderer.materials = materials;

        _iconText[0].text = "" + card.health;
        _iconText[1].text = "" + card.damage;
        _iconText[2].text = "" + card.decorations;
    }

}
