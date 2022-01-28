// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "MasterTransluscentSurfaceShader"
{
	Properties
	{
		_NormalDisabled("NormalDisabled", Color) = (0,0,1,0)
		[Toggle(_USENORMALTEXTURE_ON)] _UseNormalTexture("Use Normal Texture", Float) = 0
		_NormalTexture("Normal Texture", 2D) = "white" {}
		_AlbedoColor("Albedo Color", Color) = (0.509434,0.509434,0.509434,0)
		[Toggle(_USEALBEDOTEXTURE_ON)] _UseAlbedoTexture("Use Albedo Texture", Float) = 0
		_AlbedoTexture("Albedo Texture", 2D) = "gray" {}
		_MetallicValue("Metallic Value", Range( 0 , 1)) = 0
		[Toggle(_USEMETALLICTEXTURE_ON)] _UseMetallicTexture("Use Metallic Texture", Float) = 0
		_MetallicTexture("Metallic Texture", 2D) = "gray" {}
		_GlossValue("Gloss Value", Range( 0 , 1)) = 0
		[Toggle(_USEGLOSSTEXTURE_ON)] _UseGlossTexture("Use Gloss Texture", Float) = 0
		[Toggle(_USEOPACITYTEXTURE_ON)] _UseOpacityTexture("Use Opacity Texture", Float) = 0
		_GlossTexture("Gloss Texture", 2D) = "gray" {}
		_EmissiveTexture("Emissive Texture", 2D) = "white" {}
		_EmissiveIntensity("Emissive Intensity", Float) = 1
		_OpacityTexture("Opacity Texture", 2D) = "white" {}
		_Opacityvalue("Opacity value", Range( 0 , 1)) = 0
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "Transparent"  "Queue" = "Transparent+0" "IgnoreProjector" = "True" "IsEmissive" = "true"  }
		Cull Back
		CGINCLUDE
		#include "UnityPBSLighting.cginc"
		#include "Lighting.cginc"
		#pragma target 3.0
		#pragma shader_feature_local _USENORMALTEXTURE_ON
		#pragma shader_feature_local _USEALBEDOTEXTURE_ON
		#pragma shader_feature_local _USEMETALLICTEXTURE_ON
		#pragma shader_feature_local _USEGLOSSTEXTURE_ON
		#pragma shader_feature_local _USEOPACITYTEXTURE_ON
		struct Input
		{
			float2 uv_texcoord;
		};

		uniform float4 _NormalDisabled;
		uniform sampler2D _NormalTexture;
		uniform float4 _NormalTexture_ST;
		uniform float4 _AlbedoColor;
		uniform sampler2D _AlbedoTexture;
		uniform float4 _AlbedoTexture_ST;
		uniform sampler2D _EmissiveTexture;
		uniform float4 _EmissiveTexture_ST;
		uniform float _EmissiveIntensity;
		uniform float _MetallicValue;
		uniform sampler2D _MetallicTexture;
		uniform float4 _MetallicTexture_ST;
		uniform float _GlossValue;
		uniform sampler2D _GlossTexture;
		uniform float4 _GlossTexture_ST;
		uniform sampler2D _OpacityTexture;
		uniform float4 _OpacityTexture_ST;
		uniform float _Opacityvalue;

		void surf( Input i , inout SurfaceOutputStandard o )
		{
			float2 uv_NormalTexture = i.uv_texcoord * _NormalTexture_ST.xy + _NormalTexture_ST.zw;
			#ifdef _USENORMALTEXTURE_ON
				float4 staticSwitch17 = float4( UnpackNormal( tex2D( _NormalTexture, uv_NormalTexture ) ) , 0.0 );
			#else
				float4 staticSwitch17 = _NormalDisabled;
			#endif
			o.Normal = staticSwitch17.rgb;
			float2 uv_AlbedoTexture = i.uv_texcoord * _AlbedoTexture_ST.xy + _AlbedoTexture_ST.zw;
			#ifdef _USEALBEDOTEXTURE_ON
				float4 staticSwitch6 = tex2D( _AlbedoTexture, uv_AlbedoTexture );
			#else
				float4 staticSwitch6 = _AlbedoColor;
			#endif
			o.Albedo = staticSwitch6.rgb;
			float2 uv_EmissiveTexture = i.uv_texcoord * _EmissiveTexture_ST.xy + _EmissiveTexture_ST.zw;
			o.Emission = ( tex2D( _EmissiveTexture, uv_EmissiveTexture ) * _EmissiveIntensity ).rgb;
			float4 temp_cast_4 = (_MetallicValue).xxxx;
			float2 uv_MetallicTexture = i.uv_texcoord * _MetallicTexture_ST.xy + _MetallicTexture_ST.zw;
			#ifdef _USEMETALLICTEXTURE_ON
				float4 staticSwitch11 = tex2D( _MetallicTexture, uv_MetallicTexture );
			#else
				float4 staticSwitch11 = temp_cast_4;
			#endif
			o.Metallic = staticSwitch11.r;
			float4 temp_cast_6 = (_GlossValue).xxxx;
			float2 uv_GlossTexture = i.uv_texcoord * _GlossTexture_ST.xy + _GlossTexture_ST.zw;
			#ifdef _USEGLOSSTEXTURE_ON
				float4 staticSwitch12 = tex2D( _GlossTexture, uv_GlossTexture );
			#else
				float4 staticSwitch12 = temp_cast_6;
			#endif
			o.Smoothness = staticSwitch12.r;
			float2 uv_OpacityTexture = i.uv_texcoord * _OpacityTexture_ST.xy + _OpacityTexture_ST.zw;
			float4 temp_cast_8 = (_Opacityvalue).xxxx;
			#ifdef _USEOPACITYTEXTURE_ON
				float4 staticSwitch25 = temp_cast_8;
			#else
				float4 staticSwitch25 = tex2D( _OpacityTexture, uv_OpacityTexture );
			#endif
			o.Alpha = staticSwitch25.r;
		}

		ENDCG
		CGPROGRAM
		#pragma surface surf Standard alpha:fade keepalpha fullforwardshadows exclude_path:deferred 

		ENDCG
		Pass
		{
			Name "ShadowCaster"
			Tags{ "LightMode" = "ShadowCaster" }
			ZWrite On
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma target 3.0
			#pragma multi_compile_shadowcaster
			#pragma multi_compile UNITY_PASS_SHADOWCASTER
			#pragma skip_variants FOG_LINEAR FOG_EXP FOG_EXP2
			#include "HLSLSupport.cginc"
			#if ( SHADER_API_D3D11 || SHADER_API_GLCORE || SHADER_API_GLES || SHADER_API_GLES3 || SHADER_API_METAL || SHADER_API_VULKAN )
				#define CAN_SKIP_VPOS
			#endif
			#include "UnityCG.cginc"
			#include "Lighting.cginc"
			#include "UnityPBSLighting.cginc"
			sampler3D _DitherMaskLOD;
			struct v2f
			{
				V2F_SHADOW_CASTER;
				float2 customPack1 : TEXCOORD1;
				float3 worldPos : TEXCOORD2;
				float4 tSpace0 : TEXCOORD3;
				float4 tSpace1 : TEXCOORD4;
				float4 tSpace2 : TEXCOORD5;
				UNITY_VERTEX_INPUT_INSTANCE_ID
				UNITY_VERTEX_OUTPUT_STEREO
			};
			v2f vert( appdata_full v )
			{
				v2f o;
				UNITY_SETUP_INSTANCE_ID( v );
				UNITY_INITIALIZE_OUTPUT( v2f, o );
				UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO( o );
				UNITY_TRANSFER_INSTANCE_ID( v, o );
				Input customInputData;
				float3 worldPos = mul( unity_ObjectToWorld, v.vertex ).xyz;
				half3 worldNormal = UnityObjectToWorldNormal( v.normal );
				half3 worldTangent = UnityObjectToWorldDir( v.tangent.xyz );
				half tangentSign = v.tangent.w * unity_WorldTransformParams.w;
				half3 worldBinormal = cross( worldNormal, worldTangent ) * tangentSign;
				o.tSpace0 = float4( worldTangent.x, worldBinormal.x, worldNormal.x, worldPos.x );
				o.tSpace1 = float4( worldTangent.y, worldBinormal.y, worldNormal.y, worldPos.y );
				o.tSpace2 = float4( worldTangent.z, worldBinormal.z, worldNormal.z, worldPos.z );
				o.customPack1.xy = customInputData.uv_texcoord;
				o.customPack1.xy = v.texcoord;
				o.worldPos = worldPos;
				TRANSFER_SHADOW_CASTER_NORMALOFFSET( o )
				return o;
			}
			half4 frag( v2f IN
			#if !defined( CAN_SKIP_VPOS )
			, UNITY_VPOS_TYPE vpos : VPOS
			#endif
			) : SV_Target
			{
				UNITY_SETUP_INSTANCE_ID( IN );
				Input surfIN;
				UNITY_INITIALIZE_OUTPUT( Input, surfIN );
				surfIN.uv_texcoord = IN.customPack1.xy;
				float3 worldPos = IN.worldPos;
				half3 worldViewDir = normalize( UnityWorldSpaceViewDir( worldPos ) );
				SurfaceOutputStandard o;
				UNITY_INITIALIZE_OUTPUT( SurfaceOutputStandard, o )
				surf( surfIN, o );
				#if defined( CAN_SKIP_VPOS )
				float2 vpos = IN.pos;
				#endif
				half alphaRef = tex3D( _DitherMaskLOD, float3( vpos.xy * 0.25, o.Alpha * 0.9375 ) ).a;
				clip( alphaRef - 0.01 );
				SHADOW_CASTER_FRAGMENT( IN )
			}
			ENDCG
		}
	}
	Fallback "Diffuse"
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=18800
0;0;1920;1019;1336.532;-87.66028;1.404689;True;False
Node;AmplifyShaderEditor.RangedFloatNode;4;-637.5367,251.3419;Inherit;False;Property;_MetallicValue;Metallic Value;13;0;Create;True;0;0;0;False;0;False;0;1;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.SamplerNode;23;-663.7905,1071.952;Inherit;True;Property;_OpacityTexture;Opacity Texture;21;0;Create;True;0;0;0;False;0;False;-1;None;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SamplerNode;5;-664.4297,-298.1441;Inherit;True;Property;_AlbedoTexture;Albedo Texture;12;0;Create;True;0;0;0;False;0;False;-1;None;None;True;0;False;gray;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SamplerNode;8;-666.8821,602.604;Inherit;True;Property;_GlossTexture;Gloss Texture;18;0;Create;True;0;0;0;False;0;False;-1;None;None;True;0;False;gray;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ColorNode;16;-577.7714,-108.4455;Inherit;False;Property;_NormalDisabled;NormalDisabled;7;0;Create;True;0;0;0;False;0;False;0,0,1,0;0,0,1,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;3;-648.054,523.6855;Inherit;False;Property;_GlossValue;Gloss Value;16;0;Create;True;0;0;0;False;0;False;0;1;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.SamplerNode;13;-662.2712,65.75454;Inherit;True;Property;_NormalTexture;Normal Texture;9;0;Create;True;0;0;0;False;0;False;-1;None;None;True;0;False;white;Auto;True;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SamplerNode;7;-662.9296,329.9558;Inherit;True;Property;_MetallicTexture;Metallic Texture;15;0;Create;True;0;0;0;False;0;False;-1;None;None;True;0;False;gray;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ColorNode;2;-582.0369,-467.758;Inherit;False;Property;_AlbedoColor;Albedo Color;10;0;Create;True;0;0;0;False;0;False;0.509434,0.509434,0.509434,0;0,0,0,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;24;-645.9977,1263.359;Inherit;False;Property;_Opacityvalue;Opacity value;22;0;Create;True;0;0;0;False;0;False;0;0;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.SamplerNode;20;-662.9565,794.5145;Inherit;True;Property;_EmissiveTexture;Emissive Texture;19;0;Create;True;0;0;0;False;0;False;-1;None;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;18;-573.5707,998.0671;Inherit;False;Property;_EmissiveIntensity;Emissive Intensity;20;0;Create;True;0;0;0;False;0;False;1;1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.StaticSwitch;25;-125.9689,1071.747;Inherit;False;Property;_UseOpacityTexture;Use Opacity Texture;17;0;Create;True;0;0;0;False;0;False;0;0;0;True;;Toggle;2;Key0;Key1;Create;True;True;9;1;COLOR;0,0,0,0;False;0;COLOR;0,0,0,0;False;2;COLOR;0,0,0,0;False;3;COLOR;0,0,0,0;False;4;COLOR;0,0,0,0;False;5;COLOR;0,0,0,0;False;6;COLOR;0,0,0,0;False;7;COLOR;0,0,0,0;False;8;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;22;-153.2736,797.0247;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.StaticSwitch;17;-224.1717,63.15451;Inherit;False;Property;_UseNormalTexture;Use Normal Texture;8;0;Create;True;0;0;0;False;0;False;0;0;0;True;;Toggle;2;Key0;Key1;Create;True;True;9;1;COLOR;0,0,0,0;False;0;COLOR;0,0,0,0;False;2;COLOR;0,0,0,0;False;3;COLOR;0,0,0,0;False;4;COLOR;0,0,0,0;False;5;COLOR;0,0,0,0;False;6;COLOR;0,0,0,0;False;7;COLOR;0,0,0,0;False;8;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.StaticSwitch;12;-258.1401,451.1479;Inherit;False;Property;_UseGlossTexture;Use Gloss Texture;17;0;Create;True;0;0;0;False;0;False;0;0;0;True;;Toggle;2;Key0;Key1;Create;True;True;9;1;COLOR;0,0,0,0;False;0;COLOR;0,0,0,0;False;2;COLOR;0,0,0,0;False;3;COLOR;0,0,0,0;False;4;COLOR;0,0,0,0;False;5;COLOR;0,0,0,0;False;6;COLOR;0,0,0,0;False;7;COLOR;0,0,0,0;False;8;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.StaticSwitch;6;-310.4297,-386.144;Inherit;False;Property;_UseAlbedoTexture;Use Albedo Texture;11;0;Create;True;0;0;0;False;0;False;0;0;0;True;;Toggle;2;Key0;Key1;Create;True;True;9;1;COLOR;0,0,0,0;False;0;COLOR;0,0,0,0;False;2;COLOR;0,0,0,0;False;3;COLOR;0,0,0,0;False;4;COLOR;0,0,0,0;False;5;COLOR;0,0,0,0;False;6;COLOR;0,0,0,0;False;7;COLOR;0,0,0,0;False;8;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.StaticSwitch;11;-261.5402,243.1479;Inherit;False;Property;_UseMetallicTexture;Use Metallic Texture;14;0;Create;True;0;0;0;False;0;False;0;0;0;True;;Toggle;2;Key0;Key1;Create;True;True;9;1;COLOR;0,0,0,0;False;0;COLOR;0,0,0,0;False;2;COLOR;0,0,0,0;False;3;COLOR;0,0,0,0;False;4;COLOR;0,0,0,0;False;5;COLOR;0,0,0,0;False;6;COLOR;0,0,0,0;False;7;COLOR;0,0,0,0;False;8;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;704,272;Float;False;True;-1;2;ASEMaterialInspector;0;0;Standard;MasterSurfaceShader;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;False;False;False;False;False;False;Back;0;False;-1;0;False;-1;False;0;False;-1;0;False;-1;False;0;Transparent;0.5;True;True;0;False;Transparent;;Transparent;ForwardOnly;14;all;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;0.5;True;2;5;False;-1;10;False;-1;0;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;14;0;-1;-1;0;False;0;0;False;-1;-1;0;False;-1;0;0;0;False;0.1;False;-1;0;False;-1;False;16;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;25;1;23;0
WireConnection;25;0;24;0
WireConnection;22;0;20;0
WireConnection;22;1;18;0
WireConnection;17;1;16;0
WireConnection;17;0;13;0
WireConnection;12;1;3;0
WireConnection;12;0;8;0
WireConnection;6;1;2;0
WireConnection;6;0;5;0
WireConnection;11;1;4;0
WireConnection;11;0;7;0
WireConnection;0;0;6;0
WireConnection;0;1;17;0
WireConnection;0;2;22;0
WireConnection;0;3;11;0
WireConnection;0;4;12;0
WireConnection;0;9;25;0
ASEEND*/
//CHKSM=19E2AF3CA251E4DFDA36D7A832D0DD74A540112D