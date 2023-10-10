using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using UnityEngine.AI;
using UnityMMO.Component;
using System.Security.Cryptography;
using System;
using UnityMMO;
//using System;

public class monsterapi : MonoBehaviour
{
    public long uid;
    public long typeID;
    public float radius;

    public GameObject target=null;

    public Entity ent= Entity.Null;

    public float elasped = 0;
    public Vector3 origpos;

    float attackInterval = 0.8f;
    float lastAttackTime=0;

    public UnityMMO.MoveQuery movequery;

    public bool canskill = true;




    public enum state
    {
        idle,
        patrol,
        fight,//应该改成talk
    }
    public state curstate=state.idle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(ent != Entity.Null)
        {
            var locoState = SceneMgr.Instance.EntityManager.GetComponentData<LocomotionState>(ent);
            //if (locoState.LocoState != LocomotionState.State.Dead) this.think();
        }

    }
    public void think()
    {
        //Debug.Log("monster main role pos update nav agent in sample pos beginthink ");

       elasped += Time.deltaTime;
       // Debug.Log("curstate+elasped" + curstate+":"+elasped+";"+ Time.deltaTime);
        if (curstate== state.idle)
        {
            if (elasped > 3.0f)
            {
                Debug.Log("monster main role pos update nav agent in sample pos begpatrolpath ");
                patrolpath();//巡逻并且查找target
                Debug.Log("monster main role pos update nav agent in sample pos finish patrolpath ");
                curstate = state.patrol;
                elasped = 0;
            }
        }
        if (curstate == state.patrol)
        {
            if (elasped > 5.0f)
            {
                Debug.Log("monster main role pos update nav agent in sample pos beg idle ");
                idlepath();//休息
                Debug.Log("monster main role pos update nav agent in sample pos after idle ");
                curstate = state.idle;
                elasped = 0;
            }

        }

        if (curstate == state.fight)
        {
            if (target == null)
            {
                Debug.Log("monster main role pos update nav agent in sample pos begin idle2 ");
                idlepath();//休闲，
                Debug.Log("monster main role pos update nav agent in sample pos after idle2 ");
                curstate = state.idle;
                elasped = 0;
            }
            else
            {
                if (target != null)
                {
                    Debug.Log("monster main role pos update nav agent in sample pos begfight ");
                    fight();//攻击，
                    Debug.Log("monster main role pos update nav agent in sample pos after fight ");
                    //curstate = state.fight;
                    //elasped = 0;
                }
            }
        }
        //Debug.Log("monster main role pos update nav agent in sample pos beg find target ");
        Findtarget();
        //Debug.Log("monster main role pos update nav agent in sample pos after fiind target ");
    }

    void idlepath()//休息
    {
        var newTargetPos = new TargetPosition();
        newTargetPos.Value = gameObject.transform.position;
        Debug.Log("idlepath newTargetPos.Value=" + newTargetPos.Value.x + ":" + newTargetPos.Value.z + ":" + newTargetPos.Value.z);
        //UnityMMO.SceneMgr.Instance.EntityManager.SetComponentData<TargetPosition>(ent, newTargetPos);
        var findInfo = new UnityMMO.FindWayInfo
        {
            destination = gameObject.transform.position,
            stoppingDistance = 0.8f,
            onStop = null,
        };
        Debug.Log("monster fight StartFindWay destination=" + findInfo.destination.x + ":" + findInfo.destination.y + ":" + findInfo.destination.z);
        gameObject.GetComponent<UnityMMO.MoveQuery>().StartFindWay(findInfo);
    }

    void fight()//攻击，
    {
        //Debug.Log("enter fight function");
        //if (movequery.IsAutoFinding || movequery.navAgent.pathPending || !movequery.navAgent.isStopped)
            //return;
        if (Time.time - lastAttackTime < attackInterval)
            return;
        if (target == null) return;
        var isExist = UnityMMO.SceneMgr.Instance.EntityManager.Exists(target.GetComponent<GameObjectEntity>().Entity);
        if (!isExist)
        {
            target = null;
            return;
        }
        var goe = target.GetComponent<GameObjectEntity>();
        var State = SceneMgr.Instance.EntityManager.GetComponentData<LocomotionState>(goe.Entity);
        if (State.LocoState == LocomotionState.State.Dead) return;//敌人已亡
        var monsTrans = target.transform;
        var dis = Vector3.Distance(gameObject.transform.position, monsTrans.position);
        //Debug.Log("fight dis=" + dis);
        if (dis <= 0.8)//1.2
        {
//            var UIDData=UnityMMO.SceneMgr.Instance.EntityManager.GetComponentData<UnityMMO.UID>(ent);
            //Debug.Log("fight cast skill" + UIDData.Value);
            lastAttackTime = Time.time;
            //UnityMMO.SkillManager.GetInstance().CastSkillByIndex();
            //CastSkillByIndex();
            if (canskill)
            {
                SkillManager.GetInstance().lookat(gameObject.transform, gameObject.transform);
                CastTalkByIndex();
                canskill = false;//在timeline中播放完再志为true
            }
            //var isNormalAttack = UnityMMO.SkillManager.GetInstance().IsNormalAttack(skillID);
            //attackInterval = isNormalAttack ? 0.8f : 1.5f;
        }
        else
        {
            var findInfo = new UnityMMO.FindWayInfo
            {
                destination = monsTrans.position,
                stoppingDistance = 0.8f,
                onStop = null,
            };
            Debug.Log("monster fight StartFindWay destination="+ findInfo.destination.x+":"+ findInfo.destination.y+":"+ findInfo.destination.z);
            gameObject.GetComponent<UnityMMO.MoveQuery>().StartFindWay(findInfo);
        }
    }
    public Vector3 getrandompos()
    {
        Debug.Log("enter monster random getrandompos ");
        Vector3 curpos = origpos;

        byte[] randomBytes = new byte[4];
        RNGCryptoServiceProvider rngServiceProvider = new RNGCryptoServiceProvider();
        rngServiceProvider.GetBytes(randomBytes);
        Int32 result = BitConverter.ToInt32(randomBytes, 0);
        //int idx = Mathf.Abs(result) % 10;//我需要正负数都可以
        int idx =(result) % 10;//我需要正负数都可以
        float randx = idx * 0.1f;

        byte[] randomBytes2 = new byte[4];
        rngServiceProvider.GetBytes(randomBytes2);
        result = BitConverter.ToInt32(randomBytes2, 0);
        //idx = Mathf.Abs(result) % 10;
        idx = (result) % 10;//我需要正负数都可以
        float randy = idx * 0.1f;

        byte[] randomBytes3 = new byte[4];
        rngServiceProvider.GetBytes(randomBytes3);
        result = BitConverter.ToInt32(randomBytes3, 0);
        //idx = Mathf.Abs(result) % 10;//假设想要0-10范围的随机数
        idx = (result) % 10;//我需要正负数都可以
        float randz = idx*0.1f;

        //Debug.Log("monster random pos="+randx + ":" + randy + ":" + randz);

        //Vector3 target = new Vector3(curpos.x + randx, curpos.y + randy, curpos.z + randz);
        Vector3 target = new Vector3(curpos.x + randx, curpos.y, curpos.z);
        NavMeshHit closestHit;
        // Debug.Log("transform.position : "+transform.position.x+" "+transform.position.y+" "+transform.position.z);
        if (NavMesh.SamplePosition(target, out closestHit, 1000f, NavMesh.AllAreas))
        {
            Debug.Log("monster main role pos update nav agent in sample pos" + closestHit.position.x + ":" + closestHit.position.y + ":" + closestHit.position.z);
            //transform.position = closestHit.position;

            return new Vector3(closestHit.position.x, closestHit.position.y, closestHit.position.z);
        }
        Debug.Log("monster random getrandompos "+ target.x+":"+ target.y+":"+ target.z);
        return target;
    }
    public void Findtarget()//巡逻并且查找target
    {
        GameObjectEntity goe = UnityMMO.RoleMgr.GetInstance().GetMainRole();
        if (!goe) return;
        Vector3 pos = UnityMMO.RoleMgr.GetInstance().GetMainRole().transform.position;
        Vector3 curpos = gameObject.transform.position;
        var dis = Vector3.Distance(pos, curpos);
        Debug.Log("fight Findtarget distance"+dis);
        if (dis < 0.8f)
        {
            //Debug.Log("fight Findtarget UID DIS" + uid + ":" + dis);
            target = UnityMMO.RoleMgr.GetInstance().GetMainRole().gameObject;
            curstate = state.fight;
            elasped = 0;
        }
        /*
        else
        {
            target = null;
            curstate = state.idle;
            elasped = 0;
        }
        */
    }
    public void patrolpath()//巡逻并且查找target
    {
        Vector3 targetpos = getrandompos();
        var newTargetPos = new TargetPosition();
        newTargetPos.Value = targetpos;
        //newTargetPos.Value = origpos;
        //EntityManager.SetComponentData<TargetPosition>(ent, newTargetPos);
        Debug.Log("monster main role pos update nav agent in sample pos origpos " + newTargetPos.Value.x + ":" + newTargetPos.Value.y + ":" + newTargetPos.Value.z);
        //UnityMMO.SceneMgr.Instance.EntityManager.SetComponentData<TargetPosition>(ent, newTargetPos);
        var findInfo = new UnityMMO.FindWayInfo
        {
            destination = targetpos,
            stoppingDistance = 0.01f,
            onStop = null,
        };
        Debug.Log("monster fight StartFindWay destination=" + findInfo.destination.x + ":" + findInfo.destination.y + ":" + findInfo.destination.z);
        gameObject.GetComponent<UnityMMO.MoveQuery>().StartFindWay(findInfo);

    }
    public void init(long uuid, long typeid, float radiuss, Entity monster,Vector3 pos)
    {
        uid = uuid;
        typeID = typeid;
        radius = radiuss;
        ent = monster;
        movequery = gameObject.GetComponent<UnityMMO.MoveQuery>();
        //movequery.UpdateNavAgent();
        
    }
    
    public int CastTalkByIndex(int skillIndex = -1)
    {
        var skillID = GetSkillIDByIndex(skillIndex);
        CastSkill(skillID);
        return skillID;
    }
    public int CastSkillByIndex(int skillIndex = -1)
    {
        var skillID = GetSkillIDByIndex(skillIndex);
        CastSkill(skillID);
        return skillID;
    }
    public int GetSkillIDByIndex(int skillIndex)
    {
        if (skillIndex == -1)
            return GetCurAttackID();
        else
            return (int)(typeID * 100)+ skillIndex;
    }
    public int GetCurAttackID()
    {
        return GetAttackID(2,1);
    }
    private int GetAttackID(int career, int comboIndex)
    {
        //等于typeID00=typeID*100,typeID=2000所有对应的timeline资源命名为skill_200000,再往后添加timeline就增加个位数
        //技能id：十万位是类型1角色，2怪物，3NPC，万位为职业，个十百位随便用
        return (int)(typeID * 100);
    }
    public void CastSkill(int skillID)
    {
        // var skillID = GetSkillIDByIndex(skillIndex);

        
        string assetPath = UnityMMO.ResPath.GetMonsterSkillResPath(skillID);
        Debug.Log("CastSkill assetPath=" + assetPath);
        //bool isNormalAttack = IsNormalAttack(skillID);//普通攻击
        //Debug.Log("OnBehaviourPlayMMMMMMMM PATH : " + assetPath);
        //if (!isNormalAttack)
        //ResetCombo();//使用非普攻技能时就重置连击索引
        var uid = UnityMMO.SceneMgr.Instance.EntityManager.GetComponentData<UnityMMO.UID>(ent);
        Debug.Log("CastSkill assetPath UID=" + uid.Value);
        Action<TimelineInfo.Event> afterAdd = null;

        var timelineInfo = new TimelineInfo { ResPath = assetPath, Owner = ent, StateChange = afterAdd };
        TimelineManager.GetInstance().AddTimeline(uid.Value, timelineInfo, SceneMgr.Instance.EntityManager);
    }
}
