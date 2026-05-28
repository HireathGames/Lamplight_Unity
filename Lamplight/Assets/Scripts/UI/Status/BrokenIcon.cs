using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenIcon : StatusIcon
{
    public override bool updateState(Entity entity)
    {
        if (entity.broken != 0)
        {
            number.text = entity.broken.ToString();
            return (true);
        }
        else
        {
            number.text = entity.broken.ToString();
            return (false);
        }
    }
}
