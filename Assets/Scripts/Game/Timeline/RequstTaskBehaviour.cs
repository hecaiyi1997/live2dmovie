using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;
using UnityEngine.Playables;
using UnityMMO;
using UnityMMO.Component;

// A behaviour that is attached to a playable
public class RequstTaskBehaviour : PlayableBehaviour
{
    public Entity Owner;
    public EntityManager EntityMgr;

    public int taskid;
    public long roleid;
    
    // Called when the owning graph starts playing
    public override void OnGraphStart(Playable playable)
    {

    }

    // Called when the owning graph stops playing
    public override void OnGraphStop(Playable playable)
    {
    }
    public override void PrepareFrame(Playable playable, FrameData info)
    {
       

    }
    // Called when the state of the playable is set to Play
    public override void OnBehaviourPlay(Playable playable, FrameData info)
    {
        //SkillManager.GetInstance().setRatio(0.6f);
        //SkillManager.GetInstance().setRatio(1f);
        MovePlayManager.Instance.setRatio(0.6f);

    }

    // Called when the state of the playable is set to Paused
    public override void OnBehaviourPause(Playable playable, FrameData info)
    {
       
    }

}
