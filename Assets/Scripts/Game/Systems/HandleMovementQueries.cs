
using Unity.Entities;
using Unity.Mathematics;
using UnityMMO.Component;

namespace UnityMMO
{    
[DisableAutoCreation]
class HandleMovementQueries : BaseComponentSystem
{
    EntityQuery Group;
	
    public HandleMovementQueries(GameWorld world) : base(world) {}
	
    protected override void OnCreate()
    {
        base.OnCreate();
        Group = GetEntityQuery(typeof(MoveQuery));
    }

    protected override void OnUpdate()
    {
        // Profiler.BeginSample("HandleMovementQueries");
        var queryArray = Group.ToComponentArray<MoveQuery>();
        // Debug.Log("queryArray.Length : "+queryArray.Length);
        for (var i = 0; i < queryArray.Length; i++)
        {
            var query = queryArray[i];
            if (!query.IsAutoFinding)
            {
                /*
                var charController = query.charController;
                float3 currentControllerPos = charController.transform.position;
                if (math.distance(currentControllerPos, query.moveQueryStart) > 0.01f)
                {
                    currentControllerPos = query.moveQueryStart;
                    charController.transform.position = currentControllerPos;
                }

                var deltaPos = query.moveQueryEnd - currentControllerPos;
                UnityEngine.Debug.Log("---deltaPos : "+ deltaPos.x+" :"+ deltaPos.y+" :"+ deltaPos.z+ ":"+query.isGrounded);
                    //deltaPos.y = 1;
                charController.Move(deltaPos);


                query.moveQueryResult = charController.transform.position;
                query.isGrounded = charController.isGrounded;
                UnityEngine.Debug.Log("query.moveQueryResult : " + query.moveQueryResult.x+" "+query.moveQueryResult.y+" "+query.moveQueryResult.z);
                query.transform.localPosition = query.moveQueryResult;
                */
            }
            else
            {   
                
                query.UpdateSpeed();
                var isReachTarget = !query.navAgent.pathPending;
                //var isReachTarget = !query.navAgent.pathPending && query.navAgent.remainingDistance<=query.navAgent.stoppingDistance;
                var newPos = query.navAgent.transform.localPosition;//预付终端
                //query.navAgent.destination = new UnityEngine.Vector3(newPos.x, newPos.y, 0);

                //UnityEngine.Debug.Log("newPos--- :"+ query.navAgent.isOnNavMesh+newPos.x+" "+newPos.y+" "+newPos.z+" reach:"+isReachTarget+" remainDis:"+query.navAgent.remainingDistance+" stopDis:"+query.navAgent.stoppingDistance);
                //query.isGrounded = query.charController.isGrounded;
                query.transform.localPosition = newPos;//都来跟我比较
                if (isReachTarget&&query.navAgent.remainingDistance<=query.navAgent.stoppingDistance)
                {
                    //UnityEngine.Debug.Log("Stop FindWay by move query,isReachTarget");
                    query.StopFindWay();
                }
                else
                {
                    var nextTargetPos = query.navAgent.nextPosition;
                    var dir = nextTargetPos - query.navAgent.transform.position;
                    //UnityEngine.Debug.Log("nextTargetPos : "+nextTargetPos.x+" "+nextTargetPos.y+" "+nextTargetPos.z+" dir:"+dir.x+" "+dir.y+" "+dir.z);
                    nextTargetPos = nextTargetPos + dir*10;//for rotation in MovementUpdateSystem only
                    // lastTargetPos.Value = nextTargetPos;
                    //下面这句话我注销了，因为他的用途只是为了方位而已
                    //query.ownerGOE.EntityManager.SetComponentData<TargetPosition>(query.ownerGOE.Entity, new TargetPosition{Value=nextTargetPos});
                }
                
            }
        }
        // Profiler.EndSample();
    }
}
}