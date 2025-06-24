using System;
using System.Collections.Generic;
using Assets.Scripts.Blocks.Domain;

public interface IBlockBehaviourResolver
{
    List<Type> Resolve(BlockColour color);
}
