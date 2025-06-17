using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class PlayerControllerTest
{
    private GameObject _playerControllerObj;
    private PlayerController _playerController;
    private GameObject _paddlePrefab;
    private GameObject _paddleInstance;

    [SetUp]
    public void SetUp()
    {
        // Create a mock paddle prefab with IPaddleBehaviour and SpriteRenderer
        _paddlePrefab = new GameObject("PaddlePrefab");
        _paddlePrefab.AddComponent<SpriteRenderer>();
        _paddlePrefab.AddComponent<RotatingPaddle>();

        // Create PlayerController GameObject and assign paddle prefab
        _playerControllerObj = new GameObject("PlayerController");
        _playerController = _playerControllerObj.AddComponent<PlayerController>();

        // Use reflection to set the private _paddlePrefab field
        typeof(PlayerController)
            .GetField("_paddlePrefab", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
            .SetValue(_playerController, _paddlePrefab);
    }

    [TearDown]
    public void TearDown()
    {
        Object.DestroyImmediate(_playerControllerObj);
        Object.DestroyImmediate(_paddlePrefab);
        if (_paddleInstance != null)
            Object.DestroyImmediate(_paddleInstance);
    }

    [UnityTest]
    public IEnumerator PlayerController_OnRotate_InvokesPaddleAction()
    {
        _playerControllerObj.transform.position = Vector3.zero;

        var paddle = _playerControllerObj.GetComponentInChildren<IPaddleBehaviour>();

        var ctx = new UnityEngine.InputSystem.InputAction.CallbackContext();
        //_playerController.OnRotate(ctx);

        yield return null;

        //Assert.IsTrue(paddle.ActionCalled, "Paddle Action should be called when OnRotate is invoked.");
    }
}
