using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManiaIcon : StatusIcon
{
    public override bool updateState(Entity entity)
    {
        if (entity.mania != 0)
        {
            number.text = entity.mania.ToString();
            return (true);
        }
        else
        {
            number.text = entity.mania.ToString();
            return (false);
        }
    }
}
