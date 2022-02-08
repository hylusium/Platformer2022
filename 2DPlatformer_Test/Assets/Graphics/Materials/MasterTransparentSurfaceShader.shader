// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "MasterTransluscentSurfaceShader"
{
	Properties
	{
		_Cutoff( "Mask Clip Value", Float ) = 0.5
		_NormalDisabled("NormalDisabled", Color) = (0,0,0,0)
		[Toggle(_USENORMALTEXTURE_ON)] _UseNormalTexture("Use Normal Texture", Float) = 0
		_NormalTexture("Normal Texture", 2D) = "white" {}
		_AlbedoColor("Albedo Color", Color) = (0,0,0,0)
		[Toggle(_USEALBEDOTEXTURE_ON)] _UseAlbedoTexture("Use Albedo Texture", Float) = 0
		_AlbedoTexture("Albedo Texture", 2D) = "white" {}
		_MetallicValue("Metallic Value", Float) = 0
		[Toggle(_USEMETALLICTEXTURE_ON)] _UseMetallicTexture("Use Metallic Texture", Float) = 0
		_MetallicTexture("Metallic Texture", 2D) = "white" {}
		_GlossValue("Gloss Value", Float) = 0
		[Toggle(_USEOPACITYTEXTURE_ON)] _UseOpacityTexture("Use Opacity Texture", Float) = 0
		[Toggle(_USEGLOSSTEXTURE_ON)] _UseGlossTexture("Use Gloss Texture", Float) = 0
		_GlossTexture("Gloss Texture", 2D) = "white" {}
		_EmissiveTexture("Emissive Texture", 2D) = "white" {}
		_EmissiveIntensity("Emissive Intensity", Float) = 0
		_Opacityvalue("Opacity value", Float) = 0
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "TransparentCutout"  "Queue" = "AlphaTest+0" "IgnoreProjector" = "True" "IsEmissive" = "true"  }
		Cull Back
		CGPROGRAM
		#pragma target 3.0
		#pragma shader_feature _USENORMALTEXTURE_ON
		#pragma shader_feature _USEALBEDOTEXTURE_ON
		#pragma shader_feature _USEMETALLICTEXTURE_ON
		#pragma shader_feature _USEGLOSSTEXTURE_ON
		#pragma shader_feature _USEOPACITYTEXTURE_ON
		#pragma surface surf Standard keepalpha addshadow fullforwardshadows exclude_path:deferred 
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
		uniform float _Opacityvalue;
		uniform float _Cutoff = 0.5;

		void surf( Input i , inout SurfaceOutputStandard o )
		{
			float2 uv_NormalTexture = i.uv_texcoord * _NormalTexture_ST.xy + _NormalTexture_ST.zw;
			#ifdef _USENORMALTEXTURE_ON
				float4 staticSwitch17 = tex2D( _NormalTexture, uv_NormalTexture );
			#else
				float4 staticSwitch17 = _NormalDisabled;
			#endif
			o.Normal = staticSwitch17.rgb;
			float2 uv_AlbedoTexture = i.uv_texcoord * _AlbedoTexture_ST.xy + _AlbedoTexture_ST.zw;
			float4 tex2DNode5 = tex2D( _AlbedoTexture, uv_AlbedoTexture );
			#ifdef _USEALBEDOTEXTURE_ON
				float4 staticSwitch6 = tex2DNode5;
			#else
				float4 staticSwitch6 = _AlbedoColor;
			#endif
			o.Albedo = staticSwitch6.rgb;
			float2 uv_EmissiveTexture = i.uv_texcoord * _EmissiveTexture_ST.xy + _EmissiveTexture_ST.zw;
			o.Emission = ( tex2D( _EmissiveTexture, uv_EmissiveTexture ) * _EmissiveIntensity ).rgb;
			float4 temp_cast_3 = (_MetallicValue).xxxx;
			float2 uv_MetallicTexture = i.uv_texcoord * _MetallicTexture_ST.xy + _MetallicTexture_ST.zw;
			#ifdef _USEMETALLICTEXTURE_ON
				float4 staticSwitch11 = tex2D( _MetallicTexture, uv_MetallicTexture );
			#else
				float4 staticSwitch11 = temp_cast_3;
			#endif
			o.Metallic = staticSwitch11.r;
			float4 temp_cast_5 = (_GlossValue).xxxx;
			float2 uv_GlossTexture = i.uv_texcoord * _GlossTexture_ST.xy + _GlossTexture_ST.zw;
			#ifdef _USEGLOSSTEXTURE_ON
				float4 staticSwitch12 = tex2D( _GlossTexture, uv_GlossTexture );
			#else
				float4 staticSwitch12 = temp_cast_5;
			#endif
			o.Smoothness = staticSwitch12.r;
			o.Alpha = 1;
			#ifdef _USEOPACITYTEXTURE_ON
				float staticSwitch25 = _Opacityvalue;
			#else
				float staticSwitch25 = tex2DNode5.a;
			#endif
			clip( staticSwitch25 - _Cutoff );
		}

		ENDCG
	}
	Fallback "Diffuse"
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=17400
321;448;1129;566;1157.704;-150.7272;1.869172;True;False
Node;AmplifyShaderEditor.RangedFloatNode;4;-637.5367,251.3419;Inherit;False;Property;_MetallicValue;Metallic Value;13;0;Create;True;0;0;False;0;0;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;24;-645.9977,1263.359;Inherit;False;Property;_Opacityvalue;Opacity value;23;0;Create;True;0;0;False;0;0;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;18;-573.5707,998.0671;Inherit;False;Property;_EmissiveIntensity;Emissive Intensity;21;0;Create;True;0;0;False;0;0;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SamplerNode;20;-662.9565,794.5145;Inherit;True;Property;_EmissiveTexture;Emissive Texture;20;0;Create;True;0;0;False;0;-1;None;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ColorNode;2;-582.0369,-467.758;Inherit;False;Property;_AlbedoColor;Albedo Color;10;0;Create;True;0;0;False;0;0,0,0,0;0.509434,0.509434,0.509434,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SamplerNode;7;-662.9296,329.9558;Inherit;True;Property;_MetallicTexture;Metallic Texture;15;0;Create;True;0;0;False;0;-1;None;e96bf5e78b8a2194db3fa241852f5445;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SamplerNode;13;-662.2712,65.75454;Inherit;True;Property;_NormalTexture;Normal Texture;9;0;Create;True;0;0;False;0;-1;None;f1e716a6e37db6d4fb6b937678c4c082;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ColorNode;16;-577.7714,-108.4455;Inherit;False;Property;_NormalDisabled;NormalDisabled;7;0;Create;True;0;0;False;0;0,0,0,0;0,0,1,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SamplerNode;8;-666.8821,602.604;Inherit;True;Property;_GlossTexture;Gloss Texture;19;0;Create;True;0;0;False;0;-1;None;9cb4a8dec23ff964eab91c92675c9c4f;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;3;-648.054,523.6855;Inherit;False;Property;_GlossValue;Gloss Value;16;0;Create;True;0;0;False;0;0;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SamplerNode;5;-664.4297,-298.1441;Inherit;True;Property;_AlbedoTexture;Albedo Texture;12;0;Create;True;0;0;False;0;-1;None;e52e612763903bf4a8d196c0aa1a4dc8;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.StaticSwitch;25;-125.9689,1071.747;Inherit;False;Property;_UseOpacityTexture;Use Opacity Texture;17;0;Create;True;0;0;False;0;0;0;0;True;;Toggle;2;Key0;Key1;Create;False;9;1;FLOAT;0;False;0;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT;0;False;7;FLOAT;0;False;8;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;22;-153.2736,797.0247;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.StaticSwitch;6;-310.4297,-386.144;Inherit;False;Property;_UseAlbedoTexture;Use Albedo Texture;11;0;Create;True;0;0;False;0;0;0;1;True;;Toggle;2;Key0;Key1;Create;False;9;1;COLOR;0,0,0,0;False;0;COLOR;0,0,0,0;False;2;COLOR;0,0,0,0;False;3;COLOR;0,0,0,0;False;4;COLOR;0,0,0,0;False;5;COLOR;0,0,0,0;False;6;COLOR;0,0,0,0;False;7;COLOR;0,0,0,0;False;8;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.StaticSwitch;11;-100.152,246.0822;Inherit;False;Property;_UseMetallicTexture;Use Metallic Texture;14;0;Create;True;0;0;False;0;0;0;1;True;;Toggle;2;Key0;Key1;Create;False;9;1;COLOR;0,0,0,0;False;0;COLOR;0,0,0,0;False;2;COLOR;0,0,0,0;False;3;COLOR;0,0,0,0;False;4;COLOR;0,0,0,0;False;5;COLOR;0,0,0,0;False;6;COLOR;0,0,0,0;False;7;COLOR;0,0,0,0;False;8;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.StaticSwitch;12;-90.88323,445.2792;Inherit;False;Property;_UseGlossTexture;Use Gloss Texture;18;0;Create;True;0;0;False;0;0;0;1;True;;Toggle;2;Key0;Key1;Create;False;9;1;COLOR;0,0,0,0;False;0;COLOR;0,0,0,0;False;2;COLOR;0,0,0,0;False;3;COLOR;0,0,0,0;False;4;COLOR;0,0,0,0;False;5;COLOR;0,0,0,0;False;6;COLOR;0,0,0,0;False;7;COLOR;0,0,0,0;False;8;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.StaticSwitch;17;-95.06114,66.08884;Inherit;False;Property;_UseNormalTexture;Use Normal Texture;8;0;Create;True;0;0;False;0;0;0;1;True;;Toggle;2;Key0;Key1;Create;False;9;1;COLOR;0,0,0,0;False;0;COLOR;0,0,0,0;False;2;COLOR;0,0,0,0;False;3;COLOR;0,0,0,0;False;4;COLOR;0,0,0,0;False;5;COLOR;0,0,0,0;False;6;COLOR;0,0,0,0;False;7;COLOR;0,0,0,0;False;8;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SamplerNode;23;-663.7905,1071.952;Inherit;True;Property;_OpacityTexture;Opacity Texture;22;0;Create;True;0;0;False;0;-1;None;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;704,272;Float;False;True;-1;2;ASEMaterialInspector;0;0;Standard;MasterTransluscentSurfaceShader;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;False;False;False;False;False;False;Back;0;False;-1;0;False;-1;False;0;False;-1;0;False;-1;False;0;Masked;0.5;True;True;0;False;TransparentCutout;;AlphaTest;ForwardOnly;14;all;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;0.5;True;0;5;False;-1;10;False;-1;0;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;0;0;-1;-1;0;False;0;0;False;-1;-1;0;False;-1;0;0;0;False;0.1;False;-1;0;False;-1;16;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;25;1;5;4
WireConnection;25;0;24;0
WireConnection;22;0;20;0
WireConnection;22;1;18;0
WireConnection;6;1;2;0
WireConnection;6;0;5;0
WireConnection;11;1;4;0
WireConnection;11;0;7;0
WireConnection;12;1;3;0
WireConnection;12;0;8;0
WireConnection;17;1;16;0
WireConnection;17;0;13;0
WireConnection;0;0;6;0
WireConnection;0;1;17;0
WireConnection;0;2;22;0
WireConnection;0;3;11;0
WireConnection;0;4;12;0
WireConnection;0;9;25;0
WireConnection;0;10;25;0
ASEEND*/
//CHKSM=B2CCFD32BB8C2CFB9960E24C6D7D81202C9BD8FE