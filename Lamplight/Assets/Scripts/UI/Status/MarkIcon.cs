using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkIcon : StatusIcon
{
    public override bool updateState(Entity entity)
    {
        if (entity.mark != 0)
        {
            number.text = entity.mark.ToString();
            return (true);
        }
        else
        {
            number.text = entity.mark.ToString();
            return (false);
        }
    }
}
