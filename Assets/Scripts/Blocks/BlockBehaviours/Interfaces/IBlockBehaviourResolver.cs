using System;
using System.Collections.Generic;
using Assets.Scripts.Blocks;

namespace Assets.Scripts.Blocks
{
    public interface IBlockBehaviourResolver
    {
        List<Type> Resolve(BlockColour color);
    }
}