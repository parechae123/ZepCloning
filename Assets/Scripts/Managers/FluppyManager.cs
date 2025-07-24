using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Managers
{
    class FluppyManager : SingleTon<FluppyManager>
    {
        private GameObject blockPrefab;
        public Queue<GameObject> blockPool;
        public Action gameReset;
        public Text scoreText;
        public Text startTimer;
        public GameObject gameOverPannel;

        public BlockData[] blockDatas = new BlockData[4] 
        { new BlockData { pos = new Vector3(9.5f, -6.6f, 0f), ySize = 8f },
        new BlockData { pos = new Vector3(9.5f, -4.5f, 0f), ySize = 8f },
        new BlockData { pos = new Vector3(9.5f, -4f, 0f), ySize = 8f },
        new BlockData { pos = new Vector3(9.5f, 0.5f, 0f), ySize = 3f }};
        public bool isGameOver = true;
        
        protected override void Init()
        {
            ResourceManager.GetInstance.LoadAsync<GameObject>("FluppyBlock", (result) =>
            {
                blockPrefab = GameObject.Instantiate(result);
                
            }, true);
            blockPool = new Queue<GameObject>();
        }
        public void Reset()
        {
            blockPool = new Queue<GameObject>();
        }
        public void Enqueue(GameObject obj)
        {
            obj.SetActive(false);
            blockPool.Enqueue(obj);
        }

        public void BlockDequeue()
        {
            int index = new System.Random().Next(0, blockDatas.Length);
            GameObject obj = Dequeue();
            obj.transform.position = blockDatas[index].pos;
            obj.transform.localScale = new Vector3(1f, blockDatas[index].ySize, 1f);
            obj.SetActive(true);
        }

        private GameObject Dequeue()
        {
            if (blockPool.Count <= 0)
            {
                return GameObject.Instantiate(blockPrefab);
            }
            return blockPool.Dequeue();
        }
    }
    public struct BlockData
    {
        public Vector3 pos;
        public float ySize;
    }
}
