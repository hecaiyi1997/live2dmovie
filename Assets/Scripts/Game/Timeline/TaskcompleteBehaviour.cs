using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;
using UnityEngine.Playables;
using UnityMMO;
using UnityMMO.Component;

// A behaviour that is attached to a playable
public class TaskcompleteBehaviour : PlayableBehaviour
{
    public Entity Owner;
    public EntityManager EntityMgr;

    public int taskid;
    public long roleid;
    public bool called = false;
    
    // Called when the owning graph starts playing
    public override void OnGraphStart(Playable playable)
    {


    }

    // Called when the owning graph stops playing
    public override void OnGraphStop(Playable playable)
    {

    }

    // Called when the state of the playable is set to Play
    public override void OnBehaviourPlay(Playable playable, FrameData info)
    {
        Debug.Log("c#TaskDialogView:talkDialogcompleted*******" + Time.time);

        //SkillManager.GetInstance().setRatio(1.1f);
        //MovePlayManager.Instance.setRatio(1.1f);

        //XLuaManager.Instance.talkDialogcompleted.Invoke();//要结束对话框显示




    }

    // Called when the state of the playable is set to Paused
    public override void OnBehaviourPause(Playable playable, FrameData info)
    {

    }

    // Called each frame while the state is set to Play
    public override void PrepareFrame(Playable playable, FrameData info)
    {


    }
    public override void OnPlayableDestroy(Playable playable)
    {
        base.OnPlayableDestroy(playable);



    }
}
