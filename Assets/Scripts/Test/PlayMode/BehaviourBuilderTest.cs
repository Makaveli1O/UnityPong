using NUnit.Framework;
using System;
using Assets.Scripts.Blocks;
using UnityEngine;

public class BehaviourBuilderTest
{
    [Test]
    public void Add_ConfigurableBehaviour_Succeeds()
    {
        var builder = new BehaviourBuilder();

        builder.Add<MoveBehaviour, MoveConfig>(new MoveConfig(2.5f, Vector3.zero, Vector3.zero));
        var configs = builder.Build();

        Assert.AreEqual(1, configs.Count);
        Assert.AreEqual(typeof(MoveBehaviour), configs[0].BehaviourType);
        Assert.IsInstanceOf<MoveConfig>(configs[0].Config);
    }

    [Test]
    public void AddNonConfigurable_WithNonConfigurableBehaviour_Succeeds()
    {
        var builder = new BehaviourBuilder();

        builder.AddNonConfigurable<ExplodeBehaviour>();
        var configs = builder.Build();

        Assert.AreEqual(1, configs.Count);
        Assert.AreEqual(typeof(ExplodeBehaviour), configs[0].BehaviourType);
        Assert.AreSame(NoConfig.Instance, configs[0].Config);
    }

    [Test]
    public void AddNonConfigurable_WithConfigurableBehaviour_Throws()
    {
        var builder = new BehaviourBuilder();

        Assert.Throws<Exception>(() =>
        {
            builder.AddNonConfigurable<MoveBehaviour>();
        });
    }

    [Test]
    public void Add_MultipleBehaviours_AccumulatesCorrectly()
    {
        var builder = new BehaviourBuilder();

        builder
            .Add<MoveBehaviour, MoveConfig>(new MoveConfig(1.5f, Vector3.zero, Vector3.zero))
            .AddNonConfigurable<ExplodeBehaviour>();

        var configs = builder.Build();

        Assert.AreEqual(2, configs.Count);
        Assert.AreEqual(typeof(MoveBehaviour), configs[0].BehaviourType);
        Assert.AreEqual(typeof(ExplodeBehaviour), configs[1].BehaviourType);
    }
}
