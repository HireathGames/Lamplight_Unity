using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BleedIcon : StatusIcon
{
    public override bool updateState(Entity entity)
    {
        if (entity.bleed != 0)
        {
            number.text = entity.bleed.ToString();
            return (true);
        }
        else
        {
            number.text = entity.bleed.ToString();
            return (false);
        }
    }
}
