using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegenIcon : StatusIcon
{
    public override bool updateState(Entity entity)
    {
        if (entity.regeneration != 0)
        {
            number.text = entity.regeneration.ToString();
            return (true);
        }
        else
        {
            number.text = entity.regeneration.ToString();
            return (false);
        }
    }
}
