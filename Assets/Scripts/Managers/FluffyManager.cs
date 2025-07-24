using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Managers
{
    class FluffyManager : SingleTon<FluffyManager>
    {
        private GameObject blockPrefab;
        public Queue<GameObject> blockPool;
        public Action gameReset;
        public Text scoreText;
        public Text startTimer;
        public Text highScore;
        public GameObject gameOverPannel;

        public ScoreData highScoreData;
        public ScoreData currScoreData;

        public BlockData[] blockDatas = new BlockData[4]
        { new BlockData { pos = new Vector3(9.5f, -6.6f, 0f), ySize = 8f },
        new BlockData { pos = new Vector3(9.5f, -4.5f, 0f), ySize = 8f },
        new BlockData { pos = new Vector3(9.5f, -4f, 0f), ySize = 8f },
        new BlockData { pos = new Vector3(9.5f, 0.5f, 0f), ySize = 3f }};
        public bool isGameOver = true;

        protected override void Init()
        {
            ResourceManager.GetInstance.LoadAsync<GameObject>("FluffyBlock", (result) =>
            {
                blockPrefab = GameObject.Instantiate(result);

            }, true);
            blockPool = new Queue<GameObject>();
            ScoreData sData = ResourceManager.GetInstance.LoadData<ScoreData>("HighScore");
            currScoreData = new ScoreData() { score = 0f };
            highScoreData = sData;
            gameReset += () => { currScoreData.score = 0f; highScore.text = highScoreData.score.ToString("N2"); scoreText.text = "0.00"; };
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
        public void CompareScore()
        {
            if (highScoreData.score < currScoreData.score)
            {
                ResourceManager.GetInstance.SaveData<ScoreData>(currScoreData, "HighScore",true);
                highScoreData = new ScoreData() { score = currScoreData.score };
            }
        }
        public void UpdateTextBoard()
        {
            currScoreData.score += Time.deltaTime;
            scoreText.text = currScoreData.score.ToString("N2");
        }
    }
    public struct BlockData
    {
        public Vector3 pos;
        public float ySize;
    }
    [System.Serializable]
    public struct ScoreData
    {
        public float score;
    }
}
