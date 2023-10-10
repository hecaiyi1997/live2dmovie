using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;
using Unity.Entities;
using Unity.Mathematics;
using UnityMMO;
using Cinemachine;
using System;
using UnityEngine.Playables;
using UnityEngine.Timeline;

using Crosstales.RTVoice;

using Crosstales.RTVoice.Model.Event;

public struct PlayInfo
{
    //long uid, int talknum, int subidx, int taskid, long to,int actionID=1
    public long Uid;
    public int Talknum;
    public int Subidx;
    public int Taskid;
    public long To;
    public int ActionID;
}
[Hotfix]
[LuaCallCSharp]
public class MovePlayManager : MonoBehaviour
{
    public static MovePlayManager Instance = null;

    public long currentUID = 0;
    public Entity owner = Entity.Null;
    public EntityManager entityManager;
    GameWorld m_GameWorld;

    float attackInterval = 0.01f;
    float lastAttackTime;
    public Queue<PlayInfo> queue = new Queue<PlayInfo>();
    public EntityManager EntityManager { get => m_GameWorld.GetEntityManager(); }

    Cocos.ActionRunner runner;

    protected void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        runner = GameObject.Find("CM vcam1").AddComponent<Cocos.ActionRunner>();
    }

    public void Init(GameWorld world)
    {
        m_GameWorld = world;
        lastAttackTime = 0;
        Speaker.OnSpeakAudioGenerationComplete += speakAudioGenerationCompleteMethod;
        Speaker.OnSpeakStart += SpeakStart;


    }
public void ReqTakeTask(long uid, int taskid)
{

}
public void setRatio(float r)
 {
        CinemachineVirtualCamera cam = runner.GetComponent<CinemachineVirtualCamera>();
        float currentRatio = cam.m_Lens.OrthographicSize;
        float delt = r - currentRatio;
        var moveAction = Cocos.RatioBy.CreateLocal(2.5f, delt);
        runner.PlayAction(moveAction);

 }

public void setLookat(long uid)//后面参数是嘴
 {
        Entity ent = SceneMgr.Instance.GetSceneObject(uid);
        Transform trans = EntityManager.GetComponentObject<Transform>(ent);
        lookat(trans, trans);
        /*
        var spawnAction = Cocos.MoveTo.Create(0.3f, flow.position);
        var action = Cocos.Sequence.Create(spawnAction, Cocos.CallFunc.Create(() => {
            lookat(flow, look);
        }));
        runner.PlayAction(action);
        */

    }
    public void SpeakStart(SpeakEventArgs wrapper)
{
        //var moveAction = Cocos.RatioBy.CreateLocal(1f, -0.5f);
        //runner.PlayAction(moveAction);
        //MovePlayManager.Instance.setRatio(0.6f);

    }
 public void speakAudioGenerationCompleteMethod(SpeakEventArgs wrapper)
{

        //currentWrapper = wrapper;

        //Invoke(nameof(speakAudio), 0.1f); //needs a small delay
        XLuaManager.Instance.talkDialogcompleted.Invoke();//要结束对话框显示

        //var moveAction = Cocos.RatioBy.CreateLocal(1f,0.5f);
        //runner.PlayAction(moveAction);
        //SkillManager.GetInstance().setRatio(1.1f);
        //MovePlayManager.Instance.setRatio(1.0f);
        MovePlayManager.Instance.setRatio(1.0f);
    }
    public void playsound(string txt,long uid)
    {
        
        Entity ent = SceneMgr.Instance.GetSceneObject(uid);
        Transform trans = EntityManager.GetComponentObject<Transform>(ent);
        AudioSource souce =trans.GetChild(0).GetComponent<AudioSource>();
        Speaker.Speak(txt, souce, Speaker.Voices[0]);
    }
    public void playaction(long uid,int actionid,int npcID)
    {
        //对应一个timeline1*100000+1*1000+actionID*100
        //如果是monster timeline下标=2*100000+actionID*100

        int combindex = npcID % 10;//对应不同种类的怪物
        int type1 = (int)(uid / 10000000000);
        int skillID = 0;
        if (type1 == 2)
        {
            //int combindex = (int)(uid / 20000000000);
            skillID = 2 * 100000 + (combindex-1)*10000+ actionid-1;//从0开始，所有20000x对应第一个类型怪物，210000对应第二个怪物的第一个；220001对应第三怪物第二；
                                                                   // 类型对应：monster_2000;               monster_2001;                 monster_2002
        }
        else if (type1 == 1)
        {
            //int combindex = (int)(uid / 10000000000);
            skillID = 1 * 100000 + 1 * 10000 + actionid-1;//此刻actionid=2，所以对应110001
        }
        Entity ent = SceneMgr.Instance.GetSceneObject(uid);
        Transform trans = EntityManager.GetComponentObject<Transform>(ent);
        //SkillManager.GetInstance().setRatio(1.0f);
        //SkillManager.GetInstance().setRatio(1f);
        //MovePlayManager.Instance.setRatio(1.0f);

        Live2D.Cubism.Framework.MouthMovement.AudiosourceBinding bind = trans.GetChild(0).GetComponent<Live2D.Cubism.Framework.MouthMovement.AudiosourceBinding>();
        Transform mouth = bind.mouth;
        lookat(trans, mouth);
        //setLookat(trans, mouth);

        Debug.Log("playaction MovePlayManager.play called" + type1 + ":" + skillID);
        CastSkill(skillID, uid);

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - lastAttackTime < attackInterval)
            return;
        
        if (queue.Count < 1) return;
        lastAttackTime = Time.time;
        PlayInfo info = queue.Dequeue();
        long uid = info.Uid;
        int talknum = info.Talknum;
        int subidx = info.Subidx;
        int taskid = info.Taskid;
        long to = info.To;
        int actionID = info.ActionID;

        Debug.Log("MovePlayManager.play called" + uid + ":" + talknum + ":" + subidx + ":" + taskid + ":" + to);
        int type1 = (int)(uid / 10000000000);

        int skillID = 0;
        if (type1 == 2)
        {
            int combindex = (int)(uid / 20000000000);  //从这里我知道你是第几个怪物，就知道你的类型是200x
            skillID = 2 * 100000 + (combindex - 1) * 10000 + actionID - 1;//200000;210000/220000,下标从0开始,actionID默认1
        }
        else if (type1 == 1)
        {
            int combindex = (int)(uid / 10000000000);
            skillID = 1 * 100000 + 1 * 10000 + actionID - 1;
        }
        Entity ent = SceneMgr.Instance.GetSceneObject(uid);
        Transform trans = EntityManager.GetComponentObject<Transform>(ent);
        //SkillManager.GetInstance().setRatio(0.6f);
        //SkillManager.GetInstance().setRatio(1f);
        //MovePlayManager.Instance.setRatio(0.6f);

        Entity toEnt = SceneMgr.Instance.GetSceneObject(to);
        Transform toTrans = EntityManager.GetComponentObject<Transform>(toEnt);

        trans.GetChild(0).GetComponent<Live2D.Cubism.Framework.MouthMovement.CubismLookTarget>().target = toTrans;//看向他的眼镜

        Live2D.Cubism.Framework.MouthMovement.AudiosourceBinding bind = trans.GetChild(0).GetComponent<Live2D.Cubism.Framework.MouthMovement.AudiosourceBinding>();
        Transform mouth = bind.mouth;

        lookat(trans, mouth);//要改成从之前cam位置移动到trans位置后调用该方法
        //setLookat(trans, mouth);
        Debug.Log("MovePlayManager.play called" + type1 + ":" + skillID);
        CastSkill(skillID, uid);

    }

    // Start is called before the first frame update
    public void play(long uid, int talknum, int subidx, int taskid, long to, int actionID = 1)
    {
        /*
        Entity ent = SceneMgr.Instance.GetSceneObject(uid);
        Transform trans = EntityManager.GetComponentObject<Transform>(ent);
        PlayableDirector playerDirector = trans.GetComponent<PlayableDirector>();
        playerDirector.Stop();
        */
        //装入，在update里面执行

        var playInfo = new PlayInfo
        {
            Uid = uid,
            Talknum = talknum,
            Subidx = subidx,
            Taskid = taskid,
            To = to,
            ActionID = actionID,
        };

        queue.Enqueue(playInfo);
    }
    public int GetSceneObjTypeBySkillID(int skillID)
    {
        return (int)math.floor((skillID / 100000));
    }
    public string GetSkillResPath(int skillID)
    {
        string assetPath;
        int scene_obj_type = GetSceneObjTypeBySkillID(skillID);
        if (scene_obj_type == (int)SceneObjectType.Role)
            assetPath = ResPath.GetRoleSkillResPath(skillID);
        else if (scene_obj_type == (int)SceneObjectType.Monster)
            assetPath = ResPath.GetMonsterSkillResPath(skillID);
        else
            assetPath = "";
        return assetPath;
    }
    public void lookat(Transform flow, Transform look)
    {
        GameObject vcam = GameObject.Find("CM vcam1");
        CinemachineVirtualCamera cam = vcam.GetComponent<CinemachineVirtualCamera>();
        cam.Follow = flow;
        cam.LookAt = look;
    }

    public void CastSkill(int skillID,long uid)
    {
        Debug.Log("CastSkillCastSkillCastSkill");

        string assetPath = GetSkillResPath(skillID);
        Debug.Log("CastSkill assetPath=" + assetPath);
        //bool isNormalAttack = IsNormalAttack(skillID);//普通攻击
        //Debug.Log("OnBehaviourPlayMMMMMMMM PATH : " + assetPath);
        //if (!isNormalAttack)
        //ResetCombo();//使用非普攻技能时就重置连击索引
        Entity ent= SceneMgr.Instance.GetSceneObject(uid);
        //var uid = UnityMMO.SceneMgr.Instance.EntityManager.GetComponentData<UnityMMO.UID>(ent);
        //Debug.Log("CastSkill assetPath UID=" + uid.Value);

        Action<TimelineInfo.Event> afterAdd = null;

        var timelineInfo = new TimelineInfo { ResPath = assetPath, Owner = ent, StateChange = afterAdd };
        TimelineManager.GetInstance().AddTimeline(uid, timelineInfo, SceneMgr.Instance.EntityManager);
    }
}
