using System.Collections.Generic;
using UnityEngine;

namespace ZD5Project2D.Enemy
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField]
        private List<EnemyInstance> enemies;

        public void InitEnemies()
        {
            foreach (var enemy in enemies)
            {
                enemy.Init();
            }
        }

        public void UpdateEnemiesPos()
        {
            foreach (var enemy in enemies)
            {
                enemy.UpdatePosition();
            }
        }

    } 
}
