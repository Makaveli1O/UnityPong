using System;
using System.Collections.Generic;
using Assets.Scripts.Blocks.Domain;

public class HardcodedResolver : IBlockBehaviourResolver
{
    public List<Type> Resolve(BlockColour color)
    {
        return color switch
        {
            BlockColour.Red => new() { typeof(ExplodeBehaviour) },
            BlockColour.Blue => new() { typeof(MoveBehaviour) },
            BlockColour.Purple => new() { typeof(ExplodeBehaviour), typeof(MoveBehaviour) },
            _ => new()
        };
    }
}
