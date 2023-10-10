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
    public class UnityMMOWorldManagerWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(UnityMMO.WorldManager);
			Utils.BeginObjectRegister(type, L, translator, 0, 9, 9, 9);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "calcAtChunk", _m_calcAtChunk);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "waituntilallpersistentloaded", _m_waituntilallpersistentloaded);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "RecordpersistentChunks", _m_RecordpersistentChunks);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "loadpersistentChunks", _m_loadpersistentChunks);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "loadCurrentViewChunks", _m_loadCurrentViewChunks);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Loadallchunk", _m_Loadallchunk);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "addLoadChunk", _m_addLoadChunk);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "getChunkName", _m_getChunkName);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Update", _m_Update);
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "chunkSplit", _g_get_chunkSplit);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "chunkSize", _g_get_chunkSize);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "hasTerrainObjs", _g_get_hasTerrainObjs);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "terrainObjs", _g_get_terrainObjs);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "persistentterrainObjs", _g_get_persistentterrainObjs);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "persistentObjs", _g_get_persistentObjs);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "haspreload", _g_get_haspreload);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "scene", _g_get_scene);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "beganloadpersistent", _g_get_beganloadpersistent);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "chunkSplit", _s_set_chunkSplit);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "chunkSize", _s_set_chunkSize);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "hasTerrainObjs", _s_set_hasTerrainObjs);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "terrainObjs", _s_set_terrainObjs);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "persistentterrainObjs", _s_set_persistentterrainObjs);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "persistentObjs", _s_set_persistentObjs);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "haspreload", _s_set_haspreload);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "scene", _s_set_scene);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "beganloadpersistent", _s_set_beganloadpersistent);
            
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 1, 1, 1);
			
			
            
			Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "currinst", _g_get_currinst);
            
			Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "currinst", _s_set_currinst);
            
			
			Utils.EndClassRegister(type, L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					UnityMMO.WorldManager gen_ret = new UnityMMO.WorldManager();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to UnityMMO.WorldManager constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_calcAtChunk(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityMMO.WorldManager gen_to_be_invoked = (UnityMMO.WorldManager)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    float _x = (float)LuaAPI.lua_tonumber(L, 2);
                    float _z = (float)LuaAPI.lua_tonumber(L, 3);
                    
                        UnityMMO.WorldManager.ChunkPos gen_ret = gen_to_be_invoked.calcAtChunk( _x, _z );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_waituntilallpersistentloaded(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityMMO.WorldManager gen_to_be_invoked = (UnityMMO.WorldManager)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        bool gen_ret = gen_to_be_invoked.waituntilallpersistentloaded(  );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RecordpersistentChunks(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityMMO.WorldManager gen_to_be_invoked = (UnityMMO.WorldManager)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    UnityEngine.Vector3 _pos;translator.Get(L, 2, out _pos);
                    
                    gen_to_be_invoked.RecordpersistentChunks( _pos );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_loadpersistentChunks(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityMMO.WorldManager gen_to_be_invoked = (UnityMMO.WorldManager)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    UnityEngine.Vector3 _pos;translator.Get(L, 2, out _pos);
                    
                        System.Collections.IEnumerator gen_ret = gen_to_be_invoked.loadpersistentChunks( _pos );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_loadCurrentViewChunks(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityMMO.WorldManager gen_to_be_invoked = (UnityMMO.WorldManager)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    UnityEngine.Vector3 _pos;translator.Get(L, 2, out _pos);
                    
                    gen_to_be_invoked.loadCurrentViewChunks( _pos );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Loadallchunk(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityMMO.WorldManager gen_to_be_invoked = (UnityMMO.WorldManager)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.Loadallchunk(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_addLoadChunk(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityMMO.WorldManager gen_to_be_invoked = (UnityMMO.WorldManager)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    UnityMMO.WorldManager.ChunkPos _chunkIdx;translator.Get(L, 2, out _chunkIdx);
                    
                    gen_to_be_invoked.addLoadChunk( _chunkIdx );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_getChunkName(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityMMO.WorldManager gen_to_be_invoked = (UnityMMO.WorldManager)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    UnityMMO.WorldManager.ChunkPos _chunkIdx;translator.Get(L, 2, out _chunkIdx);
                    
                        string gen_ret = gen_to_be_invoked.getChunkName( _chunkIdx );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
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
            
            
                UnityMMO.WorldManager gen_to_be_invoked = (UnityMMO.WorldManager)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    UnityEngine.Vector3 _Playerpos;translator.Get(L, 2, out _Playerpos);
                    
                    gen_to_be_invoked.Update( _Playerpos );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_currinst(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    translator.Push(L, UnityMMO.WorldManager.currinst);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_chunkSplit(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityMMO.WorldManager gen_to_be_invoked = (UnityMMO.WorldManager)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.chunkSplit);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_chunkSize(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityMMO.WorldManager gen_to_be_invoked = (UnityMMO.WorldManager)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.chunkSize);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_hasTerrainObjs(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityMMO.WorldManager gen_to_be_invoked = (UnityMMO.WorldManager)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.hasTerrainObjs);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_terrainObjs(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityMMO.WorldManager gen_to_be_invoked = (UnityMMO.WorldManager)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.terrainObjs);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_persistentterrainObjs(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityMMO.WorldManager gen_to_be_invoked = (UnityMMO.WorldManager)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.persistentterrainObjs);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_persistentObjs(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityMMO.WorldManager gen_to_be_invoked = (UnityMMO.WorldManager)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.persistentObjs);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_haspreload(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityMMO.WorldManager gen_to_be_invoked = (UnityMMO.WorldManager)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.haspreload);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_scene(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityMMO.WorldManager gen_to_be_invoked = (UnityMMO.WorldManager)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.scene);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_beganloadpersistent(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityMMO.WorldManager gen_to_be_invoked = (UnityMMO.WorldManager)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.beganloadpersistent);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_currinst(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    UnityMMO.WorldManager.currinst = (UnityMMO.WorldManager)translator.GetObject(L, 1, typeof(UnityMMO.WorldManager));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_chunkSplit(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityMMO.WorldManager gen_to_be_invoked = (UnityMMO.WorldManager)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.chunkSplit = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_chunkSize(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityMMO.WorldManager gen_to_be_invoked = (UnityMMO.WorldManager)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.chunkSize = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_hasTerrainObjs(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityMMO.WorldManager gen_to_be_invoked = (UnityMMO.WorldManager)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.hasTerrainObjs = (bool[,,])translator.GetObject(L, 2, typeof(bool[,,]));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_terrainObjs(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityMMO.WorldManager gen_to_be_invoked = (UnityMMO.WorldManager)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.terrainObjs = (UnityEngine.GameObject[,,])translator.GetObject(L, 2, typeof(UnityEngine.GameObject[,,]));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_persistentterrainObjs(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityMMO.WorldManager gen_to_be_invoked = (UnityMMO.WorldManager)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.persistentterrainObjs = (bool[,,])translator.GetObject(L, 2, typeof(bool[,,]));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_persistentObjs(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityMMO.WorldManager gen_to_be_invoked = (UnityMMO.WorldManager)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.persistentObjs = (bool[,,])translator.GetObject(L, 2, typeof(bool[,,]));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_haspreload(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityMMO.WorldManager gen_to_be_invoked = (UnityMMO.WorldManager)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.haspreload = (bool[,,])translator.GetObject(L, 2, typeof(bool[,,]));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_scene(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityMMO.WorldManager gen_to_be_invoked = (UnityMMO.WorldManager)translator.FastGetCSObj(L, 1);
                UnityEngine.SceneManagement.Scene gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.scene = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_beganloadpersistent(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityMMO.WorldManager gen_to_be_invoked = (UnityMMO.WorldManager)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.beganloadpersistent = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
