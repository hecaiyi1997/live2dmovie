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
    public class UnityMMOBuffMgrWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(UnityMMO.BuffMgr);
			Utils.BeginObjectRegister(type, L, translator, 0, 4, 0, 0);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Init", _m_Init);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "HandleBuff", _m_HandleBuff);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "HandleSuckHP", _m_HandleSuckHP);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "HandleDizzy", _m_HandleDizzy);
			
			
			
			
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 2, 0, 0);
			Utils.RegisterFunc(L, Utils.CLS_IDX, "GetInstance", _m_GetInstance_xlua_st_);
            
			
            
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            return LuaAPI.luaL_error(L, "UnityMMO.BuffMgr does not have a constructor!");
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetInstance_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    
                        UnityMMO.BuffMgr gen_ret = UnityMMO.BuffMgr.GetInstance(  );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Init(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityMMO.BuffMgr gen_to_be_invoked = (UnityMMO.BuffMgr)translator.FastGetCSObj(L, 1);
            
            
                
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
        static int _m_HandleBuff(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityMMO.BuffMgr gen_to_be_invoked = (UnityMMO.BuffMgr)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    Unity.Entities.Entity _entity;translator.Get(L, 2, out _entity);
                    string _buffStr = LuaAPI.lua_tostring(L, 3);
                    
                    gen_to_be_invoked.HandleBuff( _entity, _buffStr );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_HandleSuckHP(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityMMO.BuffMgr gen_to_be_invoked = (UnityMMO.BuffMgr)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    Unity.Entities.Entity _entity;translator.Get(L, 2, out _entity);
                    string[] _buffStrs = (string[])translator.GetObject(L, 3, typeof(string[]));
                    
                    gen_to_be_invoked.HandleSuckHP( _entity, _buffStrs );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_HandleDizzy(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityMMO.BuffMgr gen_to_be_invoked = (UnityMMO.BuffMgr)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    Unity.Entities.Entity _entity;translator.Get(L, 2, out _entity);
                    string[] _buffStrs = (string[])translator.GetObject(L, 3, typeof(string[]));
                    
                    gen_to_be_invoked.HandleDizzy( _entity, _buffStrs );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        
        
		
		
		
		
    }
}
