using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaknessIcon : StatusIcon
{
    public override bool updateState(Entity entity)
    {
        if (entity.weakness != 0)
        {
            number.text = entity.weakness.ToString();
            return (true);
        }
        else
        {
            number.text = entity.weakness.ToString();
            return (false);
        }
    }
}
