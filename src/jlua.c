#define LUA_LIB

#include "lua.h"
#include "jlua.h"

#include <string.h>
#include <stdint.h>

//ֻ�ж�����LUA_LIB����LUA_CODE����ʹ��LUA_API�����
LUA_API int jlua_where(lua_State *L, int level) {
	
	lua_Debug ar;

	if (lua_getstack(L, level, &ar)) {

		lua_getinfo(L, "Sl", &ar);

		if (ar.currentline > 0) {
			lua_pushstring(L, ar.source);
			return ar.currentline;
		}
	}

	lua_pushliteral(L, "");
	return -1;
}

LUA_API int jlua_get_registry_index() {
	return LUA_REGISTRYINDEX;
}