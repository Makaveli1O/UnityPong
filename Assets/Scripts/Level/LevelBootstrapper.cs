namespace Assets.Scripts.Level
{
    using UnityEngine;
    using Assets.Scripts.SharedKernel;
    using Assets.Scripts.SharedKernel;

    public class LevelBootstrapper : MonoBehaviour
    {
        [SerializeField] private GameObject _levelDesignerPrefab;

        void Awake()
        {
            Instantiate(_levelDesignerPrefab);
            var designer = _levelDesignerPrefab.GetComponent<LevelDesigner>();
            SimpleServiceLocator.Register<ILevelDesigner>(designer);
        }
    }
}