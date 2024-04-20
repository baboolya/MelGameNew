#include "pch-cpp.hpp"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif


#include <limits>



struct String_t;

IL2CPP_EXTERN_C RuntimeClass* Debug_t8394C7EEAECA3689C2C9B9DE9C7166D73596276F_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* String_t_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* YandexMetrica_t1B9C731B0CD60FEB34BEBB9F140942C5F683CAEB_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C String_t* _stringLiteral3DB81697956207AED45AC1CE8AF3E24F5E10EB3B;
IL2CPP_EXTERN_C String_t* _stringLiteral8B844225A3A15C0CDDD90E03F9AC65F970864EA8;
IL2CPP_EXTERN_C String_t* _stringLiteralDA39A3EE5E6B4B0D3255BFEF95601890AFD80709;


IL2CPP_EXTERN_C_BEGIN
IL2CPP_EXTERN_C_END

#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
struct U3CModuleU3E_tDC2D1A6197360726E4EA7D18D366ABA95EA61193 
{
};
struct String_t  : public RuntimeObject
{
	int32_t ____stringLength;
	Il2CppChar ____firstChar;
};
struct ValueType_t6D9B272BD21782F0A9A14F2E41F85A50E97A986F  : public RuntimeObject
{
};
struct ValueType_t6D9B272BD21782F0A9A14F2E41F85A50E97A986F_marshaled_pinvoke
{
};
struct ValueType_t6D9B272BD21782F0A9A14F2E41F85A50E97A986F_marshaled_com
{
};
struct YandexMetrica_t1B9C731B0CD60FEB34BEBB9F140942C5F683CAEB  : public RuntimeObject
{
};
struct Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22 
{
	bool ___m_value;
};
struct Void_t4861ACF8F4594C3437BB48B6E56783494B843915 
{
	union
	{
		struct
		{
		};
		uint8_t Void_t4861ACF8F4594C3437BB48B6E56783494B843915__padding[1];
	};
};
struct String_t_StaticFields
{
	String_t* ___Empty;
};
struct YandexMetrica_t1B9C731B0CD60FEB34BEBB9F140942C5F683CAEB_StaticFields
{
	bool ___CallbackLogging;
};
struct Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_StaticFields
{
	String_t* ___TrueString;
	String_t* ___FalseString;
};
#ifdef __clang__
#pragma clang diagnostic pop
#endif



IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool YandexMetrica_YandexMetricaSend_m2B1530765364CEFAB826F3ECBFD2A416A41AEA76 (String_t* ___0_eventName, String_t* ___1_eventData, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool String_IsNullOrEmpty_mEA9E3FB005AC28FE02E69FCF95A7B8456192B478 (String_t* ___0_value, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* String_Concat_m9E3155FB84015C823606188F53B47CB44C444991 (String_t* ___0_str0, String_t* ___1_str1, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* String_Concat_m8855A6DE10F84DA7F4EC113CADDB59873A25573B (String_t* ___0_str0, String_t* ___1_str1, String_t* ___2_str2, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Debug_Log_m87A9A3C761FF5C43ED8A53B16190A53D08F818BB (RuntimeObject* ___0_message, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void YandexMetrica_Send_mCF2FC4A4873E2C656BFCBE2933588100B0CC6B91 (String_t* ___0_eventName, String_t* ___1_eventDataJson, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C int32_t DEFAULT_CALL YandexMetricaSend(char*, char*);
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void YandexMetrica_Send_mCF2FC4A4873E2C656BFCBE2933588100B0CC6B91 (String_t* ___0_eventName, String_t* ___1_eventDataJson, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Debug_t8394C7EEAECA3689C2C9B9DE9C7166D73596276F_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&YandexMetrica_t1B9C731B0CD60FEB34BEBB9F140942C5F683CAEB_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral3DB81697956207AED45AC1CE8AF3E24F5E10EB3B);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral8B844225A3A15C0CDDD90E03F9AC65F970864EA8);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteralDA39A3EE5E6B4B0D3255BFEF95601890AFD80709);
		s_Il2CppMethodInitialized = true;
	}
	String_t* G_B3_0 = NULL;
	String_t* G_B3_1 = NULL;
	String_t* G_B2_0 = NULL;
	String_t* G_B2_1 = NULL;
	String_t* G_B4_0 = NULL;
	String_t* G_B4_1 = NULL;
	String_t* G_B4_2 = NULL;
	{
		String_t* L_0 = ___0_eventName;
		String_t* L_1 = ___1_eventDataJson;
		bool L_2;
		L_2 = YandexMetrica_YandexMetricaSend_m2B1530765364CEFAB826F3ECBFD2A416A41AEA76(L_0, L_1, NULL);
		bool L_3 = ((YandexMetrica_t1B9C731B0CD60FEB34BEBB9F140942C5F683CAEB_StaticFields*)il2cpp_codegen_static_fields_for(YandexMetrica_t1B9C731B0CD60FEB34BEBB9F140942C5F683CAEB_il2cpp_TypeInfo_var))->___CallbackLogging;
		if (!L_3)
		{
			goto IL_0039;
		}
	}
	{
		String_t* L_4 = ___0_eventName;
		String_t* L_5 = ___1_eventDataJson;
		bool L_6;
		L_6 = String_IsNullOrEmpty_mEA9E3FB005AC28FE02E69FCF95A7B8456192B478(L_5, NULL);
		if (L_6)
		{
			G_B3_0 = L_4;
			G_B3_1 = _stringLiteral3DB81697956207AED45AC1CE8AF3E24F5E10EB3B;
			goto IL_002a;
		}
		G_B2_0 = L_4;
		G_B2_1 = _stringLiteral3DB81697956207AED45AC1CE8AF3E24F5E10EB3B;
	}
	{
		String_t* L_7 = ___1_eventDataJson;
		String_t* L_8;
		L_8 = String_Concat_m9E3155FB84015C823606188F53B47CB44C444991(_stringLiteral8B844225A3A15C0CDDD90E03F9AC65F970864EA8, L_7, NULL);
		G_B4_0 = L_8;
		G_B4_1 = G_B2_0;
		G_B4_2 = G_B2_1;
		goto IL_002f;
	}

IL_002a:
	{
		G_B4_0 = _stringLiteralDA39A3EE5E6B4B0D3255BFEF95601890AFD80709;
		G_B4_1 = G_B3_0;
		G_B4_2 = G_B3_1;
	}

IL_002f:
	{
		String_t* L_9;
		L_9 = String_Concat_m8855A6DE10F84DA7F4EC113CADDB59873A25573B(G_B4_2, G_B4_1, G_B4_0, NULL);
		il2cpp_codegen_runtime_class_init_inline(Debug_t8394C7EEAECA3689C2C9B9DE9C7166D73596276F_il2cpp_TypeInfo_var);
		Debug_Log_m87A9A3C761FF5C43ED8A53B16190A53D08F818BB(L_9, NULL);
	}

IL_0039:
	{
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void YandexMetrica_Send_m7FEAC4E4E2086819D28DD9D23FED19D179C406D7 (String_t* ___0_eventName, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&String_t_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		String_t* L_0 = ___0_eventName;
		String_t* L_1 = ((String_t_StaticFields*)il2cpp_codegen_static_fields_for(String_t_il2cpp_TypeInfo_var))->___Empty;
		YandexMetrica_Send_mCF2FC4A4873E2C656BFCBE2933588100B0CC6B91(L_0, L_1, NULL);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool YandexMetrica_YandexMetricaSend_m2B1530765364CEFAB826F3ECBFD2A416A41AEA76 (String_t* ___0_eventName, String_t* ___1_eventData, const RuntimeMethod* method) 
{
	typedef int32_t (DEFAULT_CALL *PInvokeFunc) (char*, char*);

	char* ____0_eventName_marshaled = NULL;
	____0_eventName_marshaled = il2cpp_codegen_marshal_string(___0_eventName);

	char* ____1_eventData_marshaled = NULL;
	____1_eventData_marshaled = il2cpp_codegen_marshal_string(___1_eventData);

	int32_t returnValue = reinterpret_cast<PInvokeFunc>(YandexMetricaSend)(____0_eventName_marshaled, ____1_eventData_marshaled);

	il2cpp_codegen_marshal_free(____0_eventName_marshaled);
	____0_eventName_marshaled = NULL;

	il2cpp_codegen_marshal_free(____1_eventData_marshaled);
	____1_eventData_marshaled = NULL;

	return static_cast<bool>(returnValue);
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
