#if USE_UNI_LUA
using LuaAPI = UniLua.Lua;
using RealStatePtr = UniLua.ILuaState;
using LuaCSFunction = UniLua.CSharpFunctionDelegate;
#else
using LuaAPI = XLua.LuaDLL.Lua;
using RealStatePtr = System.IntPtr;
using LuaCSFunction = XLua.LuaDLL.lua_CSFunction;
#endif

using XLua;
using System.Collections.Generic;


namespace XLua.CSObjectWrap
{
    using Utils = XLua.Utils;
    public class MovePlayManagerWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(MovePlayManager);
			Utils.BeginObjectRegister(type, L, translator, 0, 13, 5, 4);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Init", _m_Init);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ReqTakeTask", _m_ReqTakeTask);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "setRatio", _m_setRatio);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "setLookat", _m_setLookat);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SpeakStart", _m_SpeakStart);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "speakAudioGenerationCompleteMethod", _m_speakAudioGenerationCompleteMethod);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "playsound", _m_playsound);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "playaction", _m_playaction);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "play", _m_play);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetSceneObjTypeBySkillID", _m_GetSceneObjTypeBySkillID);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetSkillResPath", _m_GetSkillResPath);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "lookat", _m_lookat);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "CastSkill", _m_CastSkill);
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "EntityManager", _g_get_EntityManager);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "currentUID", _g_get_currentUID);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "owner", _g_get_owner);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "entityManager", _g_get_entityManager);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "queue", _g_get_queue);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "currentUID", _s_set_currentUID);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "owner", _s_set_owner);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "entityManager", _s_set_entityManager);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "queue", _s_set_queue);
            
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 1, 1, 1);
			
			
            
			Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "Instance", _g_get_Instance);
            
			Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "Instance", _s_set_Instance);
            
			
			Utils.EndClassRegister(type, L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					MovePlayManager gen_ret = new MovePlayManager();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to MovePlayManager constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Init(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                MovePlayManager gen_to_be_invoked = (MovePlayManager)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    GameWorld _world = (GameWorld)translator.GetObject(L, 2, typeof(GameWorld));
                    
                    gen_to_be_invoked.Init( _world );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ReqTakeTask(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                MovePlayManager gen_to_be_invoked = (MovePlayManager)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    long _uid = LuaAPI.lua_toint64(L, 2);
                    int _taskid = LuaAPI.xlua_tointeger(L, 3);
                    
                    gen_to_be_invoked.ReqTakeTask( _uid, _taskid );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_setRatio(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                MovePlayManager gen_to_be_invoked = (MovePlayManager)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    float _r = (float)LuaAPI.lua_tonumber(L, 2);
                    
                    gen_to_be_invoked.setRatio( _r );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_setLookat(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                MovePlayManager gen_to_be_invoked = (MovePlayManager)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    long _uid = LuaAPI.lua_toint64(L, 2);
                    
                    gen_to_be_invoked.setLookat( _uid );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SpeakStart(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                MovePlayManager gen_to_be_invoked = (MovePlayManager)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    Crosstales.RTVoice.Model.Event.SpeakEventArgs _wrapper = (Crosstales.RTVoice.Model.Event.SpeakEventArgs)translator.GetObject(L, 2, typeof(Crosstales.RTVoice.Model.Event.SpeakEventArgs));
                    
                    gen_to_be_invoked.SpeakStart( _wrapper );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_speakAudioGenerationCompleteMethod(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                MovePlayManager gen_to_be_invoked = (MovePlayManager)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    Crosstales.RTVoice.Model.Event.SpeakEventArgs _wrapper = (Crosstales.RTVoice.Model.Event.SpeakEventArgs)translator.GetObject(L, 2, typeof(Crosstales.RTVoice.Model.Event.SpeakEventArgs));
                    
                    gen_to_be_invoked.speakAudioGenerationCompleteMethod( _wrapper );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_playsound(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                MovePlayManager gen_to_be_invoked = (MovePlayManager)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string _txt = LuaAPI.lua_tostring(L, 2);
                    long _uid = LuaAPI.lua_toint64(L, 3);
                    
                    gen_to_be_invoked.playsound( _txt, _uid );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_playaction(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                MovePlayManager gen_to_be_invoked = (MovePlayManager)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    long _uid = LuaAPI.lua_toint64(L, 2);
                    int _actionid = LuaAPI.xlua_tointeger(L, 3);
                    int _npcID = LuaAPI.xlua_tointeger(L, 4);
                    
                    gen_to_be_invoked.playaction( _uid, _actionid, _npcID );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_play(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                MovePlayManager gen_to_be_invoked = (MovePlayManager)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 7&& (LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2) || LuaAPI.lua_isint64(L, 2))&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 5)&& (LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 6) || LuaAPI.lua_isint64(L, 6))&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 7)) 
                {
                    long _uid = LuaAPI.lua_toint64(L, 2);
                    int _talknum = LuaAPI.xlua_tointeger(L, 3);
                    int _subidx = LuaAPI.xlua_tointeger(L, 4);
                    int _taskid = LuaAPI.xlua_tointeger(L, 5);
                    long _to = LuaAPI.lua_toint64(L, 6);
                    int _actionID = LuaAPI.xlua_tointeger(L, 7);
                    
                    gen_to_be_invoked.play( _uid, _talknum, _subidx, _taskid, _to, _actionID );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 6&& (LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2) || LuaAPI.lua_isint64(L, 2))&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 5)&& (LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 6) || LuaAPI.lua_isint64(L, 6))) 
                {
                    long _uid = LuaAPI.lua_toint64(L, 2);
                    int _talknum = LuaAPI.xlua_tointeger(L, 3);
                    int _subidx = LuaAPI.xlua_tointeger(L, 4);
                    int _taskid = LuaAPI.xlua_tointeger(L, 5);
                    long _to = LuaAPI.lua_toint64(L, 6);
                    
                    gen_to_be_invoked.play( _uid, _talknum, _subidx, _taskid, _to );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to MovePlayManager.play!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetSceneObjTypeBySkillID(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                MovePlayManager gen_to_be_invoked = (MovePlayManager)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    int _skillID = LuaAPI.xlua_tointeger(L, 2);
                    
                        int gen_ret = gen_to_be_invoked.GetSceneObjTypeBySkillID( _skillID );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetSkillResPath(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                MovePlayManager gen_to_be_invoked = (MovePlayManager)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    int _skillID = LuaAPI.xlua_tointeger(L, 2);
                    
                        string gen_ret = gen_to_be_invoked.GetSkillResPath( _skillID );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_lookat(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                MovePlayManager gen_to_be_invoked = (MovePlayManager)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    UnityEngine.Transform _flow = (UnityEngine.Transform)translator.GetObject(L, 2, typeof(UnityEngine.Transform));
                    UnityEngine.Transform _look = (UnityEngine.Transform)translator.GetObject(L, 3, typeof(UnityEngine.Transform));
                    
                    gen_to_be_invoked.lookat( _flow, _look );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CastSkill(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                MovePlayManager gen_to_be_invoked = (MovePlayManager)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    int _skillID = LuaAPI.xlua_tointeger(L, 2);
                    long _uid = LuaAPI.lua_toint64(L, 3);
                    
                    gen_to_be_invoked.CastSkill( _skillID, _uid );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_EntityManager(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                MovePlayManager gen_to_be_invoked = (MovePlayManager)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.EntityManager);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Instance(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    translator.Push(L, MovePlayManager.Instance);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_currentUID(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                MovePlayManager gen_to_be_invoked = (MovePlayManager)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushint64(L, gen_to_be_invoked.currentUID);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_owner(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                MovePlayManager gen_to_be_invoked = (MovePlayManager)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.owner);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_entityManager(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                MovePlayManager gen_to_be_invoked = (MovePlayManager)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.entityManager);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_queue(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                MovePlayManager gen_to_be_invoked = (MovePlayManager)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.queue);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Instance(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    MovePlayManager.Instance = (MovePlayManager)translator.GetObject(L, 1, typeof(MovePlayManager));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_currentUID(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                MovePlayManager gen_to_be_invoked = (MovePlayManager)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.currentUID = LuaAPI.lua_toint64(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_owner(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                MovePlayManager gen_to_be_invoked = (MovePlayManager)translator.FastGetCSObj(L, 1);
                Unity.Entities.Entity gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.owner = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_entityManager(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                MovePlayManager gen_to_be_invoked = (MovePlayManager)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.entityManager = (Unity.Entities.EntityManager)translator.GetObject(L, 2, typeof(Unity.Entities.EntityManager));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_queue(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                MovePlayManager gen_to_be_invoked = (MovePlayManager)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.queue = (System.Collections.Generic.Queue<PlayInfo>)translator.GetObject(L, 2, typeof(System.Collections.Generic.Queue<PlayInfo>));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
