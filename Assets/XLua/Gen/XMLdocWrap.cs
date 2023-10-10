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
    public class XMLdocWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(XMLdoc);
			Utils.BeginObjectRegister(type, L, translator, 0, 16, 1, 1);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "createXML", _m_createXML);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "insert", _m_insert);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "UpdateXML", _m_UpdateXML);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ReadXML", _m_ReadXML);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "DeleteXML", _m_DeleteXML);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "select_by_condition", _m_select_by_condition);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "delete", _m_delete);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "update", _m_update);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "createBaginfo", _m_createBaginfo);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "select_by_key", _m_select_by_key);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Update", _m_Update);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "account_select_role", _m_account_select_role);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "account_create_role", _m_account_create_role);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "account_get_role_list", _m_account_get_role_list);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "createXMLAccount", _m_createXMLAccount);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "createXMLbaseinfo", _m_createXMLbaseinfo);
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "filepath", _g_get_filepath);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "filepath", _s_set_filepath);
            
			
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
					
					XMLdoc gen_ret = new XMLdoc();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to XMLdoc constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_createXML(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                XMLdoc gen_to_be_invoked = (XMLdoc)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.createXML(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_insert(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                XMLdoc gen_to_be_invoked = (XMLdoc)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 2&& translator.Assignable<queryTabinterface>(L, 2)) 
                {
                    queryTabinterface _taskinf = (queryTabinterface)translator.GetObject(L, 2, typeof(queryTabinterface));
                    
                    gen_to_be_invoked.insert( _taskinf );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 3&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TTABLE)) 
                {
                    string _cond = LuaAPI.lua_tostring(L, 2);
                    XLua.LuaTable _good = (XLua.LuaTable)translator.GetObject(L, 3, typeof(XLua.LuaTable));
                    
                        bool gen_ret = gen_to_be_invoked.insert( _cond, _good );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to XMLdoc.insert!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UpdateXML(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                XMLdoc gen_to_be_invoked = (XMLdoc)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    long _id = LuaAPI.lua_toint64(L, 2);
                    queryTabinterface _taskinf = (queryTabinterface)translator.GetObject(L, 3, typeof(queryTabinterface));
                    
                    gen_to_be_invoked.UpdateXML( _id, _taskinf );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ReadXML(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                XMLdoc gen_to_be_invoked = (XMLdoc)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.ReadXML(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DeleteXML(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                XMLdoc gen_to_be_invoked = (XMLdoc)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.DeleteXML(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_select_by_condition(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                XMLdoc gen_to_be_invoked = (XMLdoc)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string _cond = LuaAPI.lua_tostring(L, 2);
                    XLua.LuaTable _tmp = (XLua.LuaTable)translator.GetObject(L, 3, typeof(XLua.LuaTable));
                    XLua.LuaTable _tablist = (XLua.LuaTable)translator.GetObject(L, 4, typeof(XLua.LuaTable));
                    
                        bool gen_ret = gen_to_be_invoked.select_by_condition( _cond, _tmp, _tablist );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_delete(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                XMLdoc gen_to_be_invoked = (XMLdoc)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string _cond = LuaAPI.lua_tostring(L, 2);
                    long _typeiid = LuaAPI.lua_toint64(L, 3);
                    
                        bool gen_ret = gen_to_be_invoked.delete( _cond, _typeiid );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_update(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                XMLdoc gen_to_be_invoked = (XMLdoc)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string _cond = LuaAPI.lua_tostring(L, 2);
                    XLua.LuaTable _good = (XLua.LuaTable)translator.GetObject(L, 3, typeof(XLua.LuaTable));
                    
                        bool gen_ret = gen_to_be_invoked.update( _cond, _good );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_createBaginfo(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                XMLdoc gen_to_be_invoked = (XMLdoc)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    long _rolid = LuaAPI.lua_toint64(L, 2);
                    
                    gen_to_be_invoked.createBaginfo( _rolid );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_select_by_key(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                XMLdoc gen_to_be_invoked = (XMLdoc)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    long _role_id = LuaAPI.lua_toint64(L, 2);
                    XLua.LuaTable _ttb = (XLua.LuaTable)translator.GetObject(L, 3, typeof(XLua.LuaTable));
                    
                        XLua.LuaTable gen_ret = gen_to_be_invoked.select_by_key( _role_id, _ttb );
                        translator.Push(L, gen_ret);
                    
                    
                    
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
            
            
                XMLdoc gen_to_be_invoked = (XMLdoc)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    long _id = LuaAPI.lua_toint64(L, 2);
                    queryTab _taskinf = (queryTab)translator.GetObject(L, 3, typeof(queryTab));
                    
                    gen_to_be_invoked.Update( _id, _taskinf );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_account_select_role(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                XMLdoc gen_to_be_invoked = (XMLdoc)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    long _roleid = LuaAPI.lua_toint64(L, 2);
                    XLua.LuaTable _res = (XLua.LuaTable)translator.GetObject(L, 3, typeof(XLua.LuaTable));
                    
                        bool gen_ret = gen_to_be_invoked.account_select_role( _roleid, _res );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_account_create_role(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                XMLdoc gen_to_be_invoked = (XMLdoc)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string _username = LuaAPI.lua_tostring(L, 2);
                    string _playname = LuaAPI.lua_tostring(L, 3);
                    long _career = LuaAPI.lua_toint64(L, 4);
                    XLua.LuaTable _res = (XLua.LuaTable)translator.GetObject(L, 5, typeof(XLua.LuaTable));
                    
                        bool gen_ret = gen_to_be_invoked.account_create_role( _username, _playname, _career, _res );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_account_get_role_list(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                XMLdoc gen_to_be_invoked = (XMLdoc)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string _playname = LuaAPI.lua_tostring(L, 2);
                    XLua.LuaTable _res = (XLua.LuaTable)translator.GetObject(L, 3, typeof(XLua.LuaTable));
                    
                        bool gen_ret = gen_to_be_invoked.account_get_role_list( _playname, _res );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_createXMLAccount(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                XMLdoc gen_to_be_invoked = (XMLdoc)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.createXMLAccount(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_createXMLbaseinfo(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                XMLdoc gen_to_be_invoked = (XMLdoc)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    long _roleid = LuaAPI.lua_toint64(L, 2);
                    long _career = LuaAPI.lua_toint64(L, 3);
                    string _playname = LuaAPI.lua_tostring(L, 4);
                    XLua.LuaTable _res = (XLua.LuaTable)translator.GetObject(L, 5, typeof(XLua.LuaTable));
                    
                    gen_to_be_invoked.createXMLbaseinfo( _roleid, _career, _playname, ref _res );
                    translator.Push(L, _res);
                        
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Instance(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    translator.Push(L, XMLdoc.Instance);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_filepath(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                XMLdoc gen_to_be_invoked = (XMLdoc)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, gen_to_be_invoked.filepath);
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
			    XMLdoc.Instance = (XMLdoc)translator.GetObject(L, 1, typeof(XMLdoc));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_filepath(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                XMLdoc gen_to_be_invoked = (XMLdoc)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.filepath = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
