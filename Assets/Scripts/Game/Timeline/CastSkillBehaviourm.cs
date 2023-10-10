using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using UnityMMO;
using UnityMMO.Component;
// A behaviour that is attached to a playable
public class CastSkillBehaviourm : PlayableBehaviour
{
    public Entity Owner;//发出杀招人
    public EntityManager EntityMgr;
    private int SkillID;


    public override void PrepareFrame(Playable playable, FrameData info)
    {
        

    }
    public override void OnPlayableDestroy(Playable playable)
    {
        //XLuaManager.Instance.talkDialogcompleted.Invoke();//要结束对话框显示
        //SkillManager.GetInstance().setRatio(1.1f);
    }
    public void Init(Entity owner, EntityManager entityMgr, int skillID)
    {
        Owner = owner;   //他是Monster prefab生成的那个，他上面挂了MoveQuery
        EntityMgr = entityMgr;
        this.SkillID = skillID;
    }
    
    // Called when the owning graph starts playing
    public override void OnGraphStart(Playable playable)
    {
    }

    // Called when the owning graph stops playing
    public override void OnGraphStop(Playable playable)
    {
        /*
        if (Owner != Entity.Null&& EntityMgr!=null)
        {
            Transform trans = EntityMgr.GetComponentObject<Transform>(Owner);
            if (trans.GetComponent<monsterapi>())
            {
                trans.GetComponent<monsterapi>().canskill = true;
            }
            
            
        }
        */
        
    }

    // Called when the state of the playable is set to Play
    public override void OnBehaviourPlay(Playable playable, FrameData info)
    {

        //SkillManager.GetInstance().setRatio(0.6f);
        MovePlayManager.Instance.setRatio(0.6f);

    }

    void FindFlyWord(Playable playable, object obj, int level=0)
    {
        // var inputCount = playable.GetInputCount();
        // for (int i = 0; i < inputCount; i++)
        // {
        //     Type playableType = playable.GetInput(i).GetPlayableType();
        //     var isFlyWord = playableType == typeof(ApplyDamageBehaviour);
        //     if (isFlyWord)
        //     {
        //         var flyWordPlayable = (ScriptPlayable<ApplyDamageBehaviour>)(playable.GetInput(i));
        //         var behaviour = flyWordPlayable.GetBehaviour();
        //         if (behaviour != null)
        //             behaviour.Defenders = obj as List<SprotoType.scene_fight_defender_info>;
        //         // Debug.Log("isFlyWord : "+isFlyWord.ToString()+" flyWordPlayable:"+flyWordPlayable.ToString()+" behaviour:"+(behaviour!=null).ToString()+" level:"+level+" i:"+i+" inputCount:"+inputCount+" playableType:"+playableType.FullName);
        //     }
        //     FindFlyWord(playable.GetInput(i), obj, level+1);
        // }
    }

    // Called when the state of the playable is set to Paused
    public override void OnBehaviourPause(Playable playable, FrameData info)
    {
    }

    // Called each frame while the state is set to Play
}
