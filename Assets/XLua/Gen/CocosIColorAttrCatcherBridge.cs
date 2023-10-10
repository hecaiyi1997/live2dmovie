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
using System;


namespace XLua.CSObjectWrap
{
    public class CocosIColorAttrCatcherBridge : LuaBase, Cocos.IColorAttrCatcher
    {
	    public static LuaBase __Create(int reference, LuaEnv luaenv)
		{
		    return new CocosIColorAttrCatcherBridge(reference, luaenv);
		}
		
		public CocosIColorAttrCatcherBridge(int reference, LuaEnv luaenv) : base(reference, luaenv)
        {
        }
		
        

        
        System.Func<UnityEngine.Transform, UnityEngine.Color> Cocos.IColorAttrCatcher.GetColor 
        {
            
            get 
            {
#if THREAD_SAFE || HOTFIX_ENABLE
                lock (luaEnv.luaEnvLock)
                {
#endif
					RealStatePtr L = luaEnv.L;
					int oldTop = LuaAPI.lua_gettop(L);
					ObjectTranslator translator = luaEnv.translator;
					LuaAPI.lua_getref(L, luaReference);
					LuaAPI.xlua_pushasciistring(L, "GetColor");
					if (0 != LuaAPI.xlua_pgettable(L, -2))
					{
						luaEnv.ThrowExceptionFromError(oldTop);
					}
					System.Func<UnityEngine.Transform, UnityEngine.Color> __gen_ret = translator.GetDelegate<System.Func<UnityEngine.Transform, UnityEngine.Color>>(L, -1);
					LuaAPI.lua_pop(L, 2);
					return __gen_ret;
#if THREAD_SAFE || HOTFIX_ENABLE
                }
#endif
            }
            
            
        }
        
        System.Action<UnityEngine.Transform, UnityEngine.Color> Cocos.IColorAttrCatcher.SetColor 
        {
            
            get 
            {
#if THREAD_SAFE || HOTFIX_ENABLE
                lock (luaEnv.luaEnvLock)
                {
#endif
					RealStatePtr L = luaEnv.L;
					int oldTop = LuaAPI.lua_gettop(L);
					ObjectTranslator translator = luaEnv.translator;
					LuaAPI.lua_getref(L, luaReference);
					LuaAPI.xlua_pushasciistring(L, "SetColor");
					if (0 != LuaAPI.xlua_pgettable(L, -2))
					{
						luaEnv.ThrowExceptionFromError(oldTop);
					}
					System.Action<UnityEngine.Transform, UnityEngine.Color> __gen_ret = translator.GetDelegate<System.Action<UnityEngine.Transform, UnityEngine.Color>>(L, -1);
					LuaAPI.lua_pop(L, 2);
					return __gen_ret;
#if THREAD_SAFE || HOTFIX_ENABLE
                }
#endif
            }
            
            
        }
        
        
        
		
		
	}
}
