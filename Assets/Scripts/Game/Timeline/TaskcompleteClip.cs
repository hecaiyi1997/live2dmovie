using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;
using UnityEngine.Playables;
using UnityMMO;
using UnityMMO.Component;

[System.Serializable]
public class TaskcompleteClip : PlayableAsset
{

    // Factory method that generates a playable based on this asset
    public override Playable CreatePlayable(PlayableGraph graph, GameObject go)
    {
        var playable = ScriptPlayable<TaskcompleteBehaviour>.Create(graph);
        var goe = go.GetComponent<GameObjectEntity>();
        if (goe!=null)
        {
            playable.GetBehaviour().Owner = goe.Entity;
            playable.GetBehaviour().EntityMgr = goe.EntityManager;
        }
        return playable;
    }
}
