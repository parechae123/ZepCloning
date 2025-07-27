using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts.Managers
{
    class FlaffyManager : SingleTon<FlaffyManager>
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

        public readonly float blockSpawnPoint = 11f;
        public bool isGameOver = true;

        protected override void Init()
        {
            ResourceManager.GetInstance.LoadAsync<GameObject>("FlaffyBlock", (result) =>
            {
                blockPrefab = result;

            }, true);
            blockPool = new Queue<GameObject>();
            ScoreData sData = ResourceManager.GetInstance.LoadData<ScoreData>("HighScore");
            currScoreData = new ScoreData() { score = 0f };
            highScoreData = sData;
        }
        public void Reset()
        {
            blockPool = new Queue<GameObject>();
            gameReset = null;
            gameReset += () => { currScoreData.score = 0f; highScore.text = highScoreData.score.ToString("N2"); scoreText.text = "0.00"; };

        }
        public void Enqueue(GameObject obj)
        {
            obj.SetActive(false);
            blockPool.Enqueue(obj);
        }

        public void BlockDequeue()
        {
            //2.86~-4.52
            float index = UnityEngine.Random.Range(-4.52f, 2.86f);
            GameObject obj = Dequeue();
            obj.transform.position = new Vector3(blockSpawnPoint,index,0);
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
