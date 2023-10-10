TaskConst = require("Game/Task/TaskConst")
TaskModel = require("Game/Task/TaskModel")
require("Game/Task/Taskserver")
TaskController = {}
local cfg = require "Config.ConfigTask"

function TaskController:Init(  )
    self.auto=false;
	self.model = TaskModel:GetInstance()
    self:AddEvents()
end

function TaskController:GetInstance()
	return TaskController
end

function TaskController:AddEvents(  )

    local onGameStart = function (  )
        
        print("onGameStart dddddffggghhhhh")
        self.model:Reset()
        self:ReqTaskList()
        --self:ListenTaskProgressChange()
    end
    local onMoveStart=function()
        self:HandleAutoDoTask()
        self.auto=true;
    end
    GlobalEventSystem:Bind(GlobalEvents.GameStart, onGameStart)
    GlobalEventSystem:Bind(GlobalEvents.MoveStart, onMoveStart)
	self.model:Bind(TaskConst.Events.ReqTaskList, function()
		self:ReqTaskList()
	end)
    --GlobalEventSystem:Bind(NetDispatcher.Event.onApplyTalkExp, TaskController.onApplyTalkExp, self)

    --GlobalEventSystem:Bind(GlobalEvents.onKillMonster,TaskController.onKillMonster, self)
end

function TaskController:onKillMonster(roleid,monsterid,num)
    print("TaskController:onKillMonster",roleid,monsterid,num)
    KillMonster(roleid,monsterid,num)
end

function TaskController:onApplyTalkExp(typeID,uid)
    print("onApplyTalkExp taskcontroller")
    local view = require("Game/Task/TalkDialogView").New()
    view:SetData({type_id=typeID,u_id=uid})
end

function TaskController:ListenTaskProgressChange(  )
    local on_progress_changed = function ( ack_data )
        print("Cat:TaskController [start:38] on_progress_changed ack_data:", ack_data)
        PrintTable(ack_data)
        print("Cat:TaskController [end]")
        self.model:UpdateTaskInfo(ack_data.taskInfo)
        print('Cat:TaskController.lua[35] ack_data.status, ', ack_data.status, TaskConst.Status.Finished)
        if ack_data.taskInfo and ack_data.taskInfo.status == TaskConst.Status.Finished then
            self:ReqTaskList()
        else
            self.model:Fire(TaskConst.Events.AckTaskList)
            self:HandleAutoDoTask()
        end
    end
    --NetDispatcher:Listen("Task_ProgressChanged", nil, on_progress_changed)
end


function TaskController:ReqTaskList(  )
	local on_ack = function ( ackData )
        print("Cat:TaskController [start:47] ackData: ", ackData)
        PrintTable(ackData)
        print("Cat:TaskController [end]")
		self.model:SetTaskInfos(ackData)
		self.model:Fire(TaskConst.Events.AckTaskList)
        --self:HandleAutoDoTask()
	end
    local goe = RoleMgr.GetInstance():GetMainRole().Entity;
    local roleid = ECS:GetComponentData(goe, CS.UnityMMO.UID)

    print("dddddffggghhhhh",roleid.Value)
    local ackData=Task_GetInfoList({cur_role_id=roleid.Value}, on_ack)
    for i,v in pairs(ackData.taskList) do

        for k,jv in pairs(v) do
            print(i,k,"ReqTakeTask2",jv)
        end
    end
    
    
    self.model:SetTaskInfos(ackData)
    self.model:Fire(TaskConst.Events.AckTaskList)
    self.curDoingTaskInfo=self.model:GetTaskInfos().taskList[1];

    if(self.auto) then
        
        self:HandleAutoDoTask()
    end
    --NetDispatcher:SendMessage("Task_GetInfoList", nil, on_ack)


end

function TaskController:HandleAutoDoTask(  )
    print("call HandleAutoDoTask");
    if not self.curDoingTaskInfo then return end
    print("HandleAutoDoTask",self.curDoingTaskInfo.taskID)
    local lastDoingType = self.model:GetTaskType(self.curDoingTaskInfo.taskID)
    print("HandleAutoDoTask lastDoingType",lastDoingType)
    local taskInfo = self.curDoingTaskInfo;
    print("HandleAutoDoTask taskInfo",taskInfo.subTaskIndex,taskInfo.status)
    if taskInfo and (taskInfo.subTaskIndex == self.curDoingTaskInfo.subTaskIndex) and (taskInfo.status == TaskConst.Status.CanTake or taskInfo.status == TaskConst.Status.Doing or taskInfo.status == TaskConst.Status.Finished) then
        print("HandleAutoDoTask call DoTask");
        self:DoTask(taskInfo)

        --local id=0;
        --local taskCfg = ConfigMgr:GetTaskCfg(taskInfo.taskID)--明白taskInfo就是当前任务表,从xml文件可以看到的
        --if taskInfo.subType==3 then
        --    id=taskInfo.UID
        --elseif taskInfo.subType==1 then
        --    local subTaskCfg = taskCfg.subTasks[taskInfo.subTaskIndex]
        --    local talkCfg = subTaskCfg.content[1]
        --    id=talkCfg.speeker
        --end
        --if id~=0 then
        --    print("HandleAutoDoTask@@@@@",id)
            --CS.MovePlayManager.Instance:setLookat(id);--谁做动作谁就是摄像机跟随对象
        -- end
    end
end

function TaskController:DoTask( taskInfo )--如果是subType1则执行人是speeker；如果是subType3则执行人是UID
    print("Cat:TaskController [start:DoTask] taskInfo:", taskInfo.subType)
    PrintTable(taskInfo)
    print("Cat:TaskController [end]")
	if not taskInfo or not taskInfo.subType then return end
    RoleMgr.GetInstance():StopMainRoleRunning()
    if not self.handleTaskFuncs then
        self.handleTaskFuncs = {
            [TaskConst.SubType.Talk] = TaskController.DoTalk,
            [TaskConst.SubType.KillMonster] = TaskController.DoKillMonster,
            [TaskConst.SubType.Collect] = TaskController.DoCollect,
        }
    end
    local func = self.handleTaskFuncs[taskInfo.subType]
    if func then
        print("if func true")
        self.curDoingTaskInfo = taskInfo
        func(self,taskInfo)
    else
        error("had not find handle func for subtype : "..taskInfo.subType)
    end
end

function TaskController:DoTalk( taskInfo )
    print("TaskController:DoTalk",taskInfo.taskID)
    local cfgs = cfg[taskInfo.taskID]
    local subTaskCfg = cfgs.subTasks[taskInfo.subTaskIndex]

    local npcID = subTaskCfg.contentID
    local uuid=subTaskCfg.UID;
    print("TaskController:DoTalk",npcID,uuid)
    taskInfo.sceneID=subTaskCfg.sceneID
    local goe = RoleMgr.GetInstance():GetMainRole().Entity;--这里我需要得到开始说话的人的uuid=下面几句
    local UID = ECS:GetComponentData(goe, CS.UnityMMO.UID)
    --[[
	local onApproachingNpc = function (  )
        local onGetTaskListInNPC = function ( ackData )
            local view = require("Game/Task/TaskDialogView").New()
            view:SetData(ackData)
        end
        NetDispatcher:SendMessage("Task_GetInfoListInNPC", {npcID=npcID}, onGetTaskListInNPC)
    end
    --]]
    local onApproachingNpc = function (  )
        print("onApproachingNpc call")
        local onGetTaskListInNPC = function ()
            print("onGetTaskListInNPC call")
            local ackData=Task_GetInfoListInNPC({cur_role_id=UID.Value}, {npcID=npcID})--只能取当前一个
            for i,v in pairs(ackData.taskIDList) do
                    print(i,"dddssgggonGetTaskListInNPC",v)
            end
            print("onApproachingNpc",UID.Value,ackData.taskID)
            local view = require("Game/Task/TaskDialogView").New()
            view:SetData(ackData)
        end
        onGetTaskListInNPC();
    end

    local goe = RoleMgr.GetInstance():GetMainRole()
    local moveQuery = goe:GetComponent(typeof(CS.UnityMMO.MoveQuery))
    --local npcPos = ConfigMgr:GetNPCPosInScene(taskInfo.sceneID, npcID)

    local npcPos =SceneHelper.GetSceneObjectPos(uuid)
    local mainroletrans = goe:GetComponent(typeof(CS.UnityEngine.Transform))
    print("npcpos====",npcID,npcPos.x,npcPos.y,npcPos.z)
    print("mainrolepos====",mainroletrans.position.x,mainroletrans.position.y,mainroletrans.position.z)
    local findInfo = {
        destination = npcPos,
        stoppingDistance = 0.8,
        onStop = onApproachingNpc,
        sceneID = taskInfo.sceneID,
    }
    --Cat_Todo : handle destination are in different scene
    moveQuery:StartFindWay(findInfo)
end

function TaskController:DoKillMonster( taskInfo )--模拟立刻完成杀怪任务
    print('Cat:TaskController.lua[112] taskInfo.sceneID, taskInfo.monsterID', taskInfo.sceneID, taskInfo.monsterID)
    local monsterPos = ConfigMgr:GetMonsterPosInScene(taskInfo.sceneID, taskInfo.monsterID)
    if not monsterPos then return end

    local onApproachingMonster = function (  )
        local goe = RoleMgr.GetInstance():GetMainRole()
        if goe then
            local autoFight = goe:GetComponent(typeof(CS.UnityMMO.AutoFight))
            print('Cat:TaskController.lua[119] autoFight', autoFight)
            autoFight.enabled = true
        end
    end
    print("Cat:TaskController [start:123] monsterPos:", taskInfo.monsterID,monsterPos.x,monsterPos.y,monsterPos.z,taskInfo.monsterID)
    PrintTable(monsterPos)
    print("Cat:TaskController [end]")
    local findInfo = {
        destination = monsterPos,
        stoppingDistance = 0.8,
        onStop = onApproachingMonster,
        sceneID = taskInfo.sceneID,
    }
    --Cat_Todo : handle destination are in different scene
    local goe = RoleMgr.GetInstance():GetMainRole()
    local moveQuery = goe:GetComponent(typeof(CS.UnityMMO.MoveQuery))
    moveQuery:StartFindWay(findInfo)
end

function TaskController:DoCollect( taskInfo )--对应subtype=3

    local cfgs = cfg[taskInfo.taskID]
    local subTaskCfg = cfgs.subTasks[taskInfo.subTaskIndex]

    local npcID = subTaskCfg.contentID
    local uuid=subTaskCfg.UID;--做动作的人的id
    local actionid=subTaskCfg.actionID;--做动作的人的actionID

    if(subTaskCfg.UID) then
		--print("lua MovePlayManager.play called",self.curShowData.speeker,self.curShowTalkNum,self.curShowData.taskID)
		CS.MovePlayManager.Instance:playaction(uuid,actionid,npcID);
	end

    --if(subTaskCfg.flag==2) then self:ReqTakeTask(taskInfo.taskID) end 
    local finishplayaction=function()
        print("finishplayaction",taskInfo.taskID,subTaskCfg.flag)
        if(subTaskCfg.flag==2) then self:ReqTakeTask(taskInfo.taskID) end 
    end
    GlobalEventSystem:Bind(GlobalEvents.finishplayaction, finishplayaction)
    
end

function TaskController:ReqTakeTask( taskid ) --flag==2的时候应该去找下一个对话
	
	local goe = RoleMgr.GetInstance():GetMainRole().Entity;
	local UID = ECS:GetComponentData(goe, CS.UnityMMO.UID)

	local ackData=Task_TakeTask({cur_role_id=UID.Value},{taskID=taskid})--所有的任务都是我的任务，别人做的任务也是属于我的

	
end

return TaskController
