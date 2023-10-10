local TaskDialogView = BaseClass(UINode)

function TaskDialogView:Constructor(  )
	self.viewCfg = {
		prefabPath = "Assets/AssetBundleRes/ui/task/TaskDialogView.prefab",
		canvasName = "Normal",
	}
	self.id=0;
	self.notfirst_oneflag=1; --第一次进入之后改为2，当为2进入后回复1
	self.Taskcompleted=false;
	self.model = TaskModel:GetInstance()
	self:Load()
end

function TaskDialogView:OnLoad(  )
	local names = {
		"bottom/chat:txt",
	}
	UI.GetChildren(self, self.transform, names)
	self.transform.sizeDelta = Vector2.zero

	self:AddEvents()
end

function TaskDialogView:HandleBtnClick(  )
	print('Cat:TaskDialogView.lua[26] self.curShowData.clickCallBack', self.curShowData.clickCallBack)
	if self.curShowData.clickCallBack then
		self.curShowData.clickCallBack()
	else
		self:Unload()
	end
end

function TaskDialogView:AddEvents(  )
	local on_click = function ( click_obj )
		if self.btn_obj == click_obj then
			self:HandleBtnClick()
		elseif self.skip_btn_obj == click_obj then
			self:Unload()
		elseif self.click_bg_obj == click_obj then
			self:Unload()
		end
	end
	--UI.BindClickEvent(self.btn_obj, on_click)
	--UI.BindClickEvent(self.skip_btn_obj, on_click)
	--UI.BindClickEvent(self.click_bg_obj, on_click)
	
end

function TaskDialogView:ShowNextTalk(  )
    self.curShowTalkNum = self.curShowTalkNum + 1
	self:OnUpdate()
end

function TaskDialogView:ReqTakeTask(  ) --flag==2的时候应该去找下一个对话
	
	local goe = RoleMgr.GetInstance():GetMainRole().Entity;
--    --local typeID = ECS:GetComponentData(goe, CS.UnityMMO.Component.TypeID)
	local UID = ECS:GetComponentData(goe, CS.UnityMMO.UID)
--	local ackTakeTask = function ( ackData )
--		if ackData.result == NoError then
--        	self:Unload()
--        else
--       	Message:Show(ConfigMgr:GetErrorDesc(ackData.result))
--        end
--    end
--    --NetDispatcher:SendMessage("Task_TakeTask", {taskID=self.curShowData.taskID}, ackTakeTask)

	local ackData=Task_TakeTask({cur_role_id=UID.Value},{taskID=self.curShowData.taskID})
--	print("Cat:TaskDialogView.lua[26] self.curShowData.clickCallBack ReqTakeTask",UID.Value,self.curShowData.taskID)
--	if ackData.result == NoError then
--		self:Unload()
--		--print("ReqTakeTask",ackData.result)
--		TaskController:ReqTaskList()
--	else
--		Message:Show(ConfigMgr:GetErrorDesc(ackData.result))
--	end
	self:Unload();
	
end

function TaskDialogView:ReqDoTask(  )--flag==3的时候应该去找任务对话
	
	local goe = RoleMgr.GetInstance():GetMainRole().Entity;
--    --local typeID = ECS:GetComponentData(goe, CS.UnityMMO.Component.TypeID)
	local UID = ECS:GetComponentData(goe, CS.UnityMMO.UID)
--	local ackDoTask = function ( ackData )
--		if ackData.result == NoError then
--        	self:Unload()
--       else
--       	Message:Show(ConfigMgr:GetErrorDesc(ackData.result))
--        end
 --   end
    --NetDispatcher:SendMessage("Task_DoTask", {taskID=self.curShowData.taskID}, ackDoTask)
	local ackData=Task_DoTask({cur_role_id=UID.Value},{taskID=self.curShowData.taskID})
--	if ackData.result == NoError then
--		self:Unload()
--		TaskController:ReqTaskList()
--	else
--		Message:Show(ConfigMgr:GetErrorDesc(ackData.result))
--	end
	self:Unload();
end

function TaskDialogView:ClickOk(  )
	--self:Unload()
end

function TaskDialogView:ProcessBtnNameAndCallBack( flag )
	if not self.flagMap then
		self.flagMap = {--//configTask 中flag定义为1
			[TaskConst.DialogBtnFlag.Continue] = {name="继续", func=TaskDialogView.ShowNextTalk},
			[TaskConst.DialogBtnFlag.TakeTask] = {name="接取", func=TaskDialogView.ReqTakeTask},
			[TaskConst.DialogBtnFlag.DoTask]   = {name="完成", func=TaskDialogView.ReqDoTask}, 
			[TaskConst.DialogBtnFlag.Ok] 	   = {name="确定", func=TaskDialogView.ClickOk},
		}
		-- 3 DoTask表示该子任务系列已经做完了；2 TakeTask表示继续开始做下一子任务吗
	end
	local flagInfo = self.flagMap[flag]
	if not flagInfo then return end
	
	self.curShowData.btnName = flagInfo.name
    self.curShowData.clickCallBack = function()
    	flagInfo.func(self)
	end
	self.countdown = self.countdown or self:AddUIComponent(UI.Countdown)
  	self.countdown:CountdownByLeftTime(20, function(leftTime)
  		if leftTime > 0  then
  			--self.left_time_txt.text = string.format("%s秒后自动", math.floor(leftTime/1))
			if self.Taskcompleted then
				self:HandleBtnClick()
				self.Taskcompleted=false;
			end
  		else 
			self:HandleBtnClick()
			self.Taskcompleted=false;
		end
	end, 0.2)

	--这里有问题，不是我预期aaa bbb aaa bbb...而是aa aa bb 
	--local id=0
	--local talkDialogcompleted= function()
		
	--	print("bbb bindid=",id)
	--	GlobalEventSystem:UnBind(id)
		--self:ProcessBtnNameAndCallBack(talkCfg.flag)
	--	self:HandleBtnClick()
		
	--end
	--id=GlobalEventSystem:Bind(GlobalEvents.talkDialogcompleted, talkDialogcompleted)
	
	--print("aaa bindid=",id,flag)
end
function TaskDialogView:VtalkDialogcompleted( )
	print("lua TaskDialogView:talkDialogcompleted be called")
	GlobalEventSystem:UnBind(self.id)
	if self.curShowData.flag==1 then
		print("bbb bindid=",self.id)
		GlobalEventSystem:UnBind(self.id)
		self:ProcessBtnNameAndCallBack(self.curShowData.flag)
		print("lua TaskDialogView:talkDialogcompleted",self.curShowData.flag,self.curShowData.content)
		self:HandleBtnClick() --其内又里面更新显示播放，而且非常快又来到了VtalkDialogcompleted函数，又更新播放显示，把上一个未来得及的显示覆盖了？解决办法:显示2秒后播放？
	elseif self.curShowData.flag==2 or self.curShowData.flag==3 then
		if self.notfirst_oneflag==1 then --第二次进来了
			--GlobalEventSystem:UnBind(self.id) --监听要保留
			--self:ProcessBtnNameAndCallBack(self.curShowData.flag)
			print("lua TaskDialogView:talkDialogcompleted---",self.curShowData.content)
			self.notfirst_oneflag=2
			self:UpdateContent()			
			--self:HandleBtnClick()
		elseif self.notfirst_oneflag==2 then
			print("lua TaskDialogView:talkDialogcompletedxxxx",self.curShowData.content)
			print("bbb bindid=",self.id)
			GlobalEventSystem:UnBind(self.id)
			self:ProcessBtnNameAndCallBack(self.curShowData.flag)
			self:HandleBtnClick()
			self.notfirst_oneflag=1;
		end
	end
end
function TaskDialogView:VtalkDialogcompleted1( )
	print("TaskDialogView:VtalkDialogcompleted1")
	--self:HandleBtnClick()
	self.Taskcompleted=true

end
function TaskDialogView:talkDialogcompleted( )
	print("lua TaskDialogView:talkDialogcompleted",self.curShowData.flag,self.curShowData.content)
	self.id=GlobalEventSystem:Bind(GlobalEvents.talkDialogcompleted, self.VtalkDialogcompleted,self)
	print("aaa bindid=",self.id,self.curShowData.flag)
end

function TaskDialogView:ProcessTaskInfo(  )
	
	if not self.data then return end
	local taskNum = self.data.taskIDList and #self.data.taskIDList or 0
	print("taskNum=",taskNum)
	if taskNum == 1 then
		local taskInfo = self.model:GetTaskInfo(self.data.taskIDList[1])
        self.curShowData = table.deep_copy(taskInfo)
        local taskCfg = ConfigMgr:GetTaskCfg(self.curShowData.taskID)
        local subTaskCfg = taskCfg.subTasks[self.curShowData.subTaskIndex]
        if not taskCfg or not subTaskCfg or not subTaskCfg.content or self.curShowData.subType ~= TaskConst.SubType.Talk then
        	self.curShowData = nil
        end
        self.curShowTalkNum = self.curShowTalkNum or 1
        local talkCfg = subTaskCfg.content[self.curShowTalkNum]
        if talkCfg then
	        self.curShowData.content = talkCfg.chat
	        self.curShowData.who = talkCfg.who
			self.curShowData.speeker=talkCfg.speeker
			self.curShowData.to=talkCfg.to
			self.curShowData.flag=talkCfg.flag
			--CS.SpeechVoice.Instance:StopVoice();
			--if CS.UnityEngine.RuntimePlatform.WindowsEditor==CS.UnityEngine.Application.platform then
				--CS.SpeechVoice.Instance:Speech_Voice(self.curShowData.content)
			--end
			print("talkCfg.flag="..talkCfg.flag..self.curShowData.subTaskIndex);
	        self:ProcessBtnNameAndCallBack(talkCfg.flag)
			--self:talkDialogcompleted()
	    end
    elseif taskNum > 1 then
		--Cat_Todo : multi task in npc
    else
        --show default conversation
        self.curShowData = {}
        self.curShowData.content = "哈哈,你猜我是谁?"
        self.curShowData.who = self.data.npcID
		self.curShowData.flag=TaskConst.DialogBtnFlag.Ok
		--CS.SpeechVoice.Instance:StopVoice();
		if CS.UnityEngine.RuntimePlatform.WindowsEditor==CS.UnityEngine.Application.platform then
			--CS.SpeechVoice.Instance:Speech_Voice(self.curShowData.content)
		end
    	self:ProcessBtnNameAndCallBack(TaskConst.DialogBtnFlag.Ok)
		--self:talkDialogcompleted()
    end
end

function TaskDialogView:OnUpdate(  )
	print("TaskDialogView:OnUpdate ")
	self:ProcessTaskInfo()--根据序号从配置文件取后一通赋值,
	if not self.curShowData then return end
	--print("TaskDialogView:OnUpdate after")
	self:UpdateContent()--执行当前显示，执行动画，等待监听回调,回调发现flag==1，转ShowNextTalk显示下一句
	                    --回调发现flag==2，此刻的那条内容还没显示出来，不能去执行2对应的函数，应该执行1监听还要保留2.显示播放内容，3不修改flg,但是要怎么触发2对应函数呢？
	self:UpdateLooks()
end
--问题是倒数第二句播放完，监听到结束，然后播放最后一句，但是最后一句flag=2/3，执行了ReqTakeTask告知server完成
--解决办法：
function TaskDialogView:UpdateContent(  )
	--self.npc_name_txt.text = ConfigMgr:GetNPCName(self.curShowData.npcID)
	self.chat_txt.text = self.curShowData.content
	--self.btn_label_txt.text = self.curShowData.btnName
	if(self.curShowData.speeker) then
		print("luaTaskDialogView:talkDialogcomplet MovePlayManager.play called",self.curShowData.speeker,self.curShowTalkNum,self.curShowData.taskID)
		CS.MovePlayManager.Instance:play(self.curShowData.speeker,self.curShowTalkNum,self.curShowData.subTaskIndex,self.curShowData.taskID,self.curShowData.to);
		CS.MovePlayManager.Instance:playsound(self.chat_txt.text,self.curShowData.speeker)
		--------------------------------------------------------------------------------
		self.id=GlobalEventSystem:Bind(GlobalEvents.talkDialogcompleted, self.VtalkDialogcompleted1,self)
	end
	
end

function TaskDialogView:UpdateLooks( )
	
end

return TaskDialogView