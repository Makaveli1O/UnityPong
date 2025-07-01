using Assets.Scripts.Blocks;
using Assets.Scripts.SharedKernel;
using Assets.Scripts.SharedKernel;
using Unity.Mathematics;
using UnityEngine;

namespace Assets.Scripts.Level
{
    public class LevelDesigner : MonoBehaviour, ILevelDesigner
    {
        private BlockSpawner _spawner;
        private ISoundPlayer _soundPlayer;
        public AudioClip GetSceneMusicTheme => Resources.Load<AudioClip>("Sound/UI/Themes/game_loop");

        void Awake()
        {
            _spawner = GetComponent<BlockSpawner>();
            _soundPlayer = SimpleServiceLocator.Resolve<ISoundPlayer>();
            
        }

        void Start()
        {
            LoadLevel(GetLevel0());
            _soundPlayer.PlayMusic(GetSceneMusicTheme);
        }

        public LevelData GetLevel0()
        {
            var behavioursBlueBasic = new BehaviourBuilder()
                .Add<MoveBehaviour, MoveConfig>(
                    new MoveConfig(
                        1.0f,
                        new Vector3(-3f, -3f, 0f),
                        new Vector3(1f, -3f, 0f)
                    )
                )
                .Build();

            var behavioursRedBasic = new BehaviourBuilder()
                .AddNonConfigurable<ExplodeBehaviour>()
                .Build();
                
            var combinedBasicBehaviours = new BehaviourBuilder()
                .Add<MoveBehaviour, MoveConfig>(
                    new MoveConfig(
                        10.0f,
                        new Vector3(3f, 3f, 0f),
                        new Vector3(1f, 3f, 0f)
                    )
                )
                .AddNonConfigurable<ExplodeBehaviour>()
                .Build();

            return new LevelBuilder()
                .WithBlock(
                    new int2(3, 4),
                    behavioursBlueBasic
                )
                .WithBlock(
                    new int2(-3, -4),
                    behavioursRedBasic
                )
                .WithBlock(
                    new int2(-1,-1),
                    combinedBasicBehaviours
                )
                .Build();
        }

        public void LoadLevel(LevelData levelData)
        {
            foreach (BlockData data in levelData.Blocks)
                _spawner.SpawnBlock(data);
        }
    }
}