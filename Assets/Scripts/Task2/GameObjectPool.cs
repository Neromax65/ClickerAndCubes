using System.Collections.Generic;
using UnityEngine;

namespace Task2
{
    public class GameObjectPool : MonoBehaviour
    {
        [SerializeField] private GameObject gameObjectPrefab;
        [SerializeField] private Transform parent;
        [SerializeField] private int preSpawnCount = 15;

        private readonly List<GameObject> _pooledGameObjects = new List<GameObject>();

        private void Start()
        {
            PreSpawn();
        }

        private void PreSpawn()
        {
            for (int i = 0; i < preSpawnCount; i++)
            {
                GameObject pooledGameObject = Instantiate(gameObjectPrefab, parent);
                pooledGameObject.SetActive(false);
                _pooledGameObjects.Add(pooledGameObject);
            }
        }

        public GameObject GetFromPool()
        {
            foreach (var pooledGameObject in _pooledGameObjects)
            {
                if (!pooledGameObject.activeInHierarchy)
                {
                    pooledGameObject.SetActive(true);
                    return pooledGameObject;
                }
            }

            GameObject newGameObject = Instantiate(gameObjectPrefab, parent);
            _pooledGameObjects.Add(newGameObject);
            return newGameObject;
        }

        public void HideInPool(GameObject pooledGameObject)
        {
            if (_pooledGameObjects.Contains(pooledGameObject))
                pooledGameObject.SetActive(false);
        }
    }
}