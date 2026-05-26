using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrengthIcon : StatusIcon
{
    public override bool updateState(Entity entity)
    {
        if (entity.strength != 0)
        {
            number.text = entity.strength.ToString();
            return (true);
        }
        else
        {
            number.text = entity.strength.ToString();
            return (false);
        }
    }
}
