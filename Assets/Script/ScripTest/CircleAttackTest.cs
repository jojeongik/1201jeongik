using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CircleAttackTest : MonoBehaviour
{
    public GameManger gameManger;
    float EnemyDamage;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
//    void OnTrigerEnter2D(Collision2D collision)
//    {
//        if (collision.gameObject.tag == "Enemy")
//        {
//            Debug.Log("hit");
//            OnAttack(collision.transform);
//        }
//        if (collision.gameObject.tag == "EnemyFly")
//        {
//            Debug.Log("hit");
//            OnAttackFly(collision.transform);
//        }
//        if (collision.gameObject.tag == "EnemyBoss")
//        {
//            Debug.Log("hit");
//            OnAttackBoss(collision.transform);
//        }
//        if (collision.gameObject.tag == "EnemyBossTest")
//        {
//            Debug.Log("hit");
//            OnAttackBossTest(collision.transform);
//        }
//        if (collision.gameObject.tag == "EnemyRangedAttack")
//        {
//            Debug.Log("hit");
//            OnAttackEnemyRangedAttack(collision.transform);
//        }
//        if (collision.gameObject.tag == "EnemyBomb")
//        {
//            Debug.Log("hit");
//            OnAttackEnemyBomb(collision.transform);
//        }
//    }

//    public void OnAttack(Transform Enemy)

//    {
//        EnemyMove enemymove = Enemy.GetComponent<EnemyMove>();
//        enemymove.EnemyDamaged(PlayerMoving.TotalPlayerDamage);

//    }
//    //���߸� ����
//    public void OnAttackFly(Transform Enemy)

//    {
//        EnemyFlyMove enemyFlyMove = Enemy.GetComponent<EnemyFlyMove>();
//        enemyFlyMove.EnemyDamaged(PlayerMoving.TotalPlayerDamage);
//    }
//    //������ ����
//    public void OnAttackBoss(Transform Enemy)

//    {
//        EnemyBossMove enemyBossMove = Enemy.GetComponent<EnemyBossMove>();
//        enemyBossMove.EnemyDamaged(PlayerMoving.TotalPlayerDamage);
//    }
//    public void OnAttackBossTest(Transform Enemy)

//    {
//        EnemyBossMoveTest enemyBossMove = Enemy.GetComponent<EnemyBossMoveTest>();
//        enemyBossMove.EnemyDamaged(PlayerMoving.TotalPlayerDamage);
//    }
//    public void OnAttackEnemyRangedAttack(Transform Enemy)

//    {
//        EnemyRangedAttack enemyRangedAttack = Enemy.GetComponent<EnemyRangedAttack>();
//        enemyRangedAttack.EnemyDamaged(PlayerMoving.TotalPlayerDamage);
//    }
//    public void OnAttackEnemyBomb(Transform Enemy)

//    {
//        EnemyBomb enemyBomb = Enemy.GetComponent<EnemyBomb>();
//        enemyBomb.EnemyDamaged(PlayerMoving.TotalPlayerDamage);
//    }
//}
