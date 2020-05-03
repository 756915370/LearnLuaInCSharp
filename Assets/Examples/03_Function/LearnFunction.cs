using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using LuaInterface;
using UnityEngine;

public class LearnFunction : MonoBehaviour
{
    //xlua/tolua的dll是c写的
    // Start is called before the first frame update
    void Start()
    {
        var L = LuaDLL.luaL_newstate();

        //这三个方法不能同时运行，必须注释掉2个跑另一个
        //CallLuaFunction(L);
        //LuaHelloWorld(L);
        HandleError(L);
        
        LuaDLL.lua_close(L);
    }

    private void HandleError(IntPtr L)
    {
        var functionIntptr = Marshal.GetFunctionPointerForDelegate(new MyCSFunction(ErrorHandle));
        LuaDLL.lua_pushcclosure(L, functionIntptr, 0);

        var errorFuncIndex = LuaDLL.lua_gettop(L);//获得栈顶位置
        var path = Application.dataPath + "/Examples/03_Function/03.lua";

        LuaDLL.luaL_loadfile(L, path);
        LuaDLL.lua_pcall(L, 0, 0, 0);

        LuaDLL.lua_getglobal(L, "addandsub");

        LuaDLL.lua_pushnumber(L, 10);
        LuaDLL.lua_pushstring(L, "error");

        LuaDLL.lua_pcall(L, 2, 2, errorFuncIndex);

        Debug.Log(LuaDLL.lua_tonumber(L, -1));
        Debug.Log(LuaDLL.lua_tonumber(L, -2));
    }
    
    private void LuaHelloWorld(IntPtr L)
    {
        var functionIntptr = Marshal.GetFunctionPointerForDelegate(new MyCSFunction(HelloWorld));
        LuaDLL.lua_pushcclosure(L, functionIntptr, 0);
        LuaDLL.lua_pcall(L, 0, 0, 0);
    }
    
    private void CallLuaFunction(IntPtr L)
    {
        var path = Application.dataPath + "/Examples/03_Function/03.lua";

        LuaDLL.luaL_loadfile(L, path);
        LuaDLL.lua_pcall(L, 0, 0, 0);

        LuaDLL.lua_getglobal(L, "addandsub");

        LuaDLL.lua_pushnumber(L, 10);
        LuaDLL.lua_pushnumber(L, 20);

        if (LuaDLL.lua_pcall(L, 2, 2, 0) != 0)
        {
            Debug.LogError(LuaDLL.lua_tostring(L, -1));
        }

        Debug.Log(LuaDLL.lua_tonumber(L, -1));
        Debug.Log(LuaDLL.lua_tonumber(L, -2));
    }

    [MonoPInvokeCallbackAttribute(typeof(MyCSFunction))]
    private static void HelloWorld(IntPtr L)
    {
        Debug.Log("helloworld");
    }

    [MonoPInvokeCallbackAttribute(typeof(MyCSFunction))]
    private static void ErrorHandle(IntPtr L)
    {
        if (LuaDLL.lua_isstring(L, -1) == 1)
        {
            Debug.LogError(LuaDLL.lua_tostring(L, -1));
        }
        else
        {
            Debug.Log("Not find error string");
        }
    }
}

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public delegate void MyCSFunction(IntPtr L);