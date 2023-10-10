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
    public class CocosSpawnWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(Cocos.Spawn);
			Utils.BeginObjectRegister(type, L, translator, 0, 7, 0, 0);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Init", _m_Init);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "InitWithTwoActions", _m_InitWithTwoActions);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Clone", _m_Clone);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "StartWithTarget", _m_StartWithTarget);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Stop", _m_Stop);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Update", _m_Update);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Reverse", _m_Reverse);
			
			
			
			
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 4, 0, 0);
			Utils.RegisterFunc(L, Utils.CLS_IDX, "Create", _m_Create_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "CreateWithTwoActions", _m_CreateWithTwoActions_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "CreateWithList", _m_CreateWithList_xlua_st_);
            
			
            
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            return LuaAPI.luaL_error(L, "Cocos.Spawn does not have a constructor!");
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Create_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    Cocos.FiniteTimeAction _action1 = (Cocos.FiniteTimeAction)translator.GetObject(L, 1, typeof(Cocos.FiniteTimeAction));
                    Cocos.FiniteTimeAction[] _args = translator.GetParams<Cocos.FiniteTimeAction>(L, 2);
                    
                        Cocos.Spawn gen_ret = Cocos.Spawn.Create( _action1, _args );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CreateWithTwoActions_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    Cocos.FiniteTimeAction _actionOne = (Cocos.FiniteTimeAction)translator.GetObject(L, 1, typeof(Cocos.FiniteTimeAction));
                    Cocos.FiniteTimeAction _actionTwo = (Cocos.FiniteTimeAction)translator.GetObject(L, 2, typeof(Cocos.FiniteTimeAction));
                    
                        Cocos.Spawn gen_ret = Cocos.Spawn.CreateWithTwoActions( _actionOne, _actionTwo );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CreateWithList_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    System.Collections.Generic.List<Cocos.FiniteTimeAction> _arrayOfActions = (System.Collections.Generic.List<Cocos.FiniteTimeAction>)translator.GetObject(L, 1, typeof(System.Collections.Generic.List<Cocos.FiniteTimeAction>));
                    
                        Cocos.Spawn gen_ret = Cocos.Spawn.CreateWithList( _arrayOfActions );
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
            
            
                Cocos.Spawn gen_to_be_invoked = (Cocos.Spawn)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    System.Collections.Generic.List<Cocos.FiniteTimeAction> _arrayOfActions = (System.Collections.Generic.List<Cocos.FiniteTimeAction>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<Cocos.FiniteTimeAction>));
                    
                        bool gen_ret = gen_to_be_invoked.Init( _arrayOfActions );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_InitWithTwoActions(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Cocos.Spawn gen_to_be_invoked = (Cocos.Spawn)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    Cocos.FiniteTimeAction _action1 = (Cocos.FiniteTimeAction)translator.GetObject(L, 2, typeof(Cocos.FiniteTimeAction));
                    Cocos.FiniteTimeAction _action2 = (Cocos.FiniteTimeAction)translator.GetObject(L, 3, typeof(Cocos.FiniteTimeAction));
                    
                        bool gen_ret = gen_to_be_invoked.InitWithTwoActions( _action1, _action2 );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Clone(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Cocos.Spawn gen_to_be_invoked = (Cocos.Spawn)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        Cocos.Action gen_ret = gen_to_be_invoked.Clone(  );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_StartWithTarget(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Cocos.Spawn gen_to_be_invoked = (Cocos.Spawn)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    UnityEngine.Transform _target = (UnityEngine.Transform)translator.GetObject(L, 2, typeof(UnityEngine.Transform));
                    
                    gen_to_be_invoked.StartWithTarget( _target );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Stop(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Cocos.Spawn gen_to_be_invoked = (Cocos.Spawn)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.Stop(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Update(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Cocos.Spawn gen_to_be_invoked = (Cocos.Spawn)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    float _time = (float)LuaAPI.lua_tonumber(L, 2);
                    
                    gen_to_be_invoked.Update( _time );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Reverse(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Cocos.Spawn gen_to_be_invoked = (Cocos.Spawn)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        Cocos.Action gen_ret = gen_to_be_invoked.Reverse(  );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        
        
		
		
		
		
    }
}
