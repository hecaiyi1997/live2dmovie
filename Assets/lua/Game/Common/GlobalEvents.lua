--lua端的全局事件号以10000起始，c#的是1~9999
local GlobalEvents = BaseClass(CS.UnityMMO.GlobalEvents)
GlobalEvents.GameStart = 10000
GlobalEvents.SetMainUIVisible = 10001
GlobalEvents.onKillMonster = 10002
GlobalEvents.onsceneloaded = 10009
GlobalEvents.BagChange = 11000

GlobalEvents.MoveStart=11001
GlobalEvents.finishplayaction=11002
GlobalEvents.talkDialogcompleted=11003

return GlobalEvents