using System.Collections;
using UnityEngine;

namespace Task2
{
    public class CubeSpawner : MonoBehaviour
    {
        [SerializeField] private InputValidator spawnFrequencyInput;
        [SerializeField] private InputValidator speedToFlyInput;
        [SerializeField] private InputValidator distanceToFlyInput;
        [SerializeField] private GameObjectPool gameObjectPool;

        private float SpawnFrequency => spawnFrequencyInput.InputValue;
        private float SpeedToFly => speedToFlyInput.InputValue;
        private float DistanceToFly => distanceToFlyInput.InputValue;

        private void Start()
        {
            StartCoroutine(CubeSpawnCoroutine());
        }

        private IEnumerator CubeSpawnCoroutine()
        {
            float time = 0;
            float timeToSpawn = SpawnFrequency;
            while (true)
            {
                time += Time.deltaTime;
                if (time > timeToSpawn)
                {
                    time = 0;
                    timeToSpawn = SpawnFrequency;
                    var spawnedCube = gameObjectPool.GetFromPool();
                    spawnedCube.transform.localPosition = Vector3.zero;
                    StartCoroutine(CubeMoveCoroutine(spawnedCube, SpeedToFly, DistanceToFly));
                }

                yield return null;
            }
        }

        private IEnumerator CubeMoveCoroutine(GameObject cube, float speed, float distance)
        {
            Vector3 startPoint = cube.transform.position;
            while (Vector3.Distance(cube.transform.position, startPoint) < distance)
            {
                cube.transform.Translate(cube.transform.forward * (Time.deltaTime * speed));
                yield return null;
            }
            gameObjectPool.HideInPool(cube);
            yield return null;
        }
    }
}