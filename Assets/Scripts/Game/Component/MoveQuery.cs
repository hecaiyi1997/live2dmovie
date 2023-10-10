﻿using System;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Profiling;
using UnityMMO;
using UnityMMO.Component;

namespace UnityMMO
{
public struct FindWayInfo
{
    public Vector3 destination;
    //到达目的地前的一段距离就停下来
    public float stoppingDistance;
    public Action onStop;
    public int sceneID;
}
public class MoveQuery : MonoBehaviour
{
    public float slopeLimit;
    public float stepOffset;
    public float skinWidth;
    public float minMoveDistance;
    public float3 center;
    public float radius;
    public float height;
    private bool isAutoFinding;
    private FindWayInfo findWayAfterLoadScene;

    [NonSerialized] public int collisionLayer;
    [NonSerialized] public float3 moveQueryStart;
    [NonSerialized] public float3 moveQueryEnd;
    [NonSerialized] public float3 moveQueryResult;
    [NonSerialized] public bool isGrounded;
    [NonSerialized] public GameObject queryObj;
    [NonSerialized] public GameObjectEntity ownerGOE;

    [NonSerialized] public CharacterController charController;
    [NonSerialized] public NavMeshAgent navAgent;
    [NonSerialized] public Action onStop;

    public bool IsAutoFinding { get => isAutoFinding; set => isAutoFinding = value; }

    public void Initialize(bool isNeedNavAgent=true)
    {
        ownerGOE = GetComponent<GameObjectEntity>();
        GameObject go = null;
        if (isNeedNavAgent)
            go = new GameObject("MoveColl_" + name, typeof(CharacterController), typeof(UIDProxy), typeof(NavMeshAgent));
        else
            go = new GameObject("MoveColl_" + name, typeof(CharacterController), typeof(UIDProxy), typeof(NavMeshAgent));
        queryObj = go;
        navAgent=go.GetComponent<NavMeshAgent>();
            queryObj.transform.SetParent(UnityMMO.SceneMgr.Instance.MoveQueryContainer);
        
        charController = go.GetComponent<CharacterController>();
        queryObj.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);//我需要他与movequery节点也就是mainrole或者monster预制体节点一样

        moveQueryStart = transform.position;
        moveQueryEnd = transform.position;
        //charController.transform.SetParent(UnityMMO.SceneMgr.Instance.MoveQueryContainer);
        charController.slopeLimit = this.slopeLimit;
        charController.stepOffset = this.stepOffset;
        charController.skinWidth = this.skinWidth;
        charController.minMoveDistance = this.minMoveDistance;
        charController.center = this.center; 
        charController.radius = this.radius; 
        charController.height = this.height;
        
        go.layer = gameObject.layer;

        var uid = go.GetComponent<UIDProxy>();
        uid.Value = ownerGOE.EntityManager.GetComponentData<UID>(ownerGOE.Entity);
        isAutoFinding = true;
        if (isNeedNavAgent)
        {
            navAgent = go.GetComponent<NavMeshAgent>();
            navAgent.radius = this.radius;
            navAgent.height = this.height;
        }
    }

    public void ChangeUID(long uid)
    {
        var uidProxy = queryObj.GetComponent<UIDProxy>();
        uidProxy.Value = new UID{Value=uid};
    }

    public void UpdateNavAgent()
    {
        //var uidProxy = queryObj.GetComponent<UIDProxy>();
        //Debug.Log("UpdateNavAgent"+ uidProxy.Value);
        NavMeshHit closestHit;
        // Debug.Log("transform.position : "+transform.position.x+" "+transform.position.y+" "+transform.position.z);
        if (NavMesh.SamplePosition(transform.position, out closestHit, 100f, NavMesh.AllAreas)) 
        {
            Debug.Log("main role pos update nav agent in sample pos transform.position" + transform.position.x + ":" + transform.position.y + ":" + transform.position.z);
            Debug.Log("main role pos update nav agent in sample pos"+ closestHit.position.x+ ":"+closestHit.position.y+":"+ closestHit.position.z);
            transform.position = closestHit.position;//这个transform是MainRole预制体
            Debug.Log("main role pos update nav agent in sample pos transform.position" + transform.position.x+ ":"+ transform.position.y+":"+ transform.position.z);
                //navAgent.destination = new UnityEngine.Vector3(closestHit.position.x + 5, closestHit.position.y+0.01f, 0);
                //transform.position = new Vector3(closestHit.position.x, closestHit.position.y, closestHit.position.z);
                //transform.localPosition = new Vector3(closestHit.position.x, closestHit.position.y, closestHit.position.z);
                queryObj.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);//我需要他与movequery节点也就是mainrole或者monster预制体节点一样
                if (navAgent == null)
            {
                navAgent = this.gameObject.AddComponent<NavMeshAgent>();
            }
            else
            {
                navAgent.enabled = false;
                navAgent.enabled = true;
            }
            navAgent.radius = this.radius;
            navAgent.height = this.height;
        }
        else
        {
            Debug.Log("has not in navmesh");
        }
        // if (navAgent != null)
        //     GameObject.DestroyImmediate(navAgent);
        // navAgent = charController.gameObject.AddComponent<NavMeshAgent>();
        // navAgent.radius = this.radius;
        // navAgent.height = this.height;
        // Debug.Log("findWayAfterLoadScene.sceneID : "+findWayAfterLoadScene.sceneID);
        if (findWayAfterLoadScene.sceneID != 0)
        {
            StartFindWay(findWayAfterLoadScene);
            findWayAfterLoadScene.sceneID = 0;
        }
            
    }

    public void StartFindWay(FindWayInfo info)
    {
        if (info.sceneID != 0 && info.sceneID != SceneMgr.Instance.CurSceneID)
        {
            findWayAfterLoadScene = info;
            SceneMgr.Instance.ReqEnterScene(info.sceneID);
            return;
        }
        if (!navAgent)
        {
            Debug.LogError("has no NavMeshAgent Component!call my method Initialize(true)");
            return;
        }
        else if (!navAgent.isOnNavMesh)
        {
            Debug.Log("nav agent is not on navmesh!"+ navAgent.isOnNavMesh);
            UpdateNavAgent();
            return;
        }
        navAgent.isStopped = false;
        navAgent.acceleration = 100;
        navAgent.angularSpeed = 100;
            navAgent.stoppingDistance = info.stoppingDistance;
        UpdateSpeed();
        navAgent.destination = info.destination;
        onStop = info.onStop;
        isAutoFinding = true; 
        float len=(info.destination-transform.position).magnitude;
        float len2=(info.destination-transform.localPosition).magnitude;         
        Debug.Log("start find way by move query"+len+":"+len2+ navAgent.remainingDistance);
    }

    public void UpdateSpeed()
    {
        var moveSpeed = ownerGOE.EntityManager.GetComponentObject<SpeedData>(ownerGOE.Entity);
        navAgent.speed = moveSpeed.CurSpeed*0.1f;
    }

    public void StopFindWay()
    {
        Debug.Log("Stop FindWay by move query");
        navAgent.isStopped = true;
        var newPos = navAgent.transform.localPosition;
        this.isAutoFinding = false;
        this.moveQueryStart = newPos;
        this.moveQueryEnd = newPos;
        this.moveQueryResult = newPos;
        if (onStop != null)
        {
            onStop();
            onStop = null;
        }
    }

    public void Shutdown()
    {
        GameObject.Destroy(navAgent.gameObject);
    }
}

}