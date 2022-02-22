// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "FX/alpha_j"
{
	Properties
	{
		_Main_tex("Main_tex", 2D) = "white" {}
		[HDR]_Color0("Color 0", Color) = (1,1,1,1)
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		[HideInInspector] _tex4coord2( "", 2D ) = "white" {}
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "Custom"  "Queue" = "Transparent+0" "IsEmissive" = "true"  }
		Cull Off
		ZWrite Off
		Blend SrcAlpha OneMinusSrcAlpha
		BlendOp Add
		CGPROGRAM
		#pragma target 3.0
		#pragma surface surf Lambert keepalpha noshadow noambient novertexlights nolightmap  nodynlightmap nodirlightmap nofog nometa noforwardadd 
		#undef TRANSFORM_TEX
		#define TRANSFORM_TEX(tex,name) float4(tex.xy * name##_ST.xy + name##_ST.zw, tex.z, tex.w)
		struct Input
		{
			float4 vertexColor : COLOR;
			float2 uv_texcoord;
			float4 uv2_tex4coord2;
		};

		uniform float4 _Color0;
		uniform sampler2D _Main_tex;
		uniform float4 _Main_tex_ST;

		void surf( Input i , inout SurfaceOutput o )
		{
			float2 uv0_Main_tex = i.uv_texcoord * _Main_tex_ST.xy + _Main_tex_ST.zw;
			float4 uv1_Main_tex = i.uv2_tex4coord2;
			uv1_Main_tex.xy = i.uv2_tex4coord2.xy * _Main_tex_ST.xy + _Main_tex_ST.zw;
			float2 appendResult4 = (float2(uv1_Main_tex.x , uv1_Main_tex.y));
			float4 tex2DNode1 = tex2D( _Main_tex, ( uv0_Main_tex + appendResult4 ) );
			o.Emission = ( (i.vertexColor).rgb * (_Color0).rgb * (tex2DNode1).rgb );
			o.Alpha = ( i.vertexColor.b * _Color0.a * tex2DNode1.a );
		}

		ENDCG
	}
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=18000
115;420;1906;886;2767.635;696.4689;2.058238;True;True
Node;AmplifyShaderEditor.TextureCoordinatesNode;2;-2291.789,56.3972;Inherit;False;1;1;4;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.TextureCoordinatesNode;5;-2077.896,-263.4163;Inherit;False;0;1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.DynamicAppendNode;4;-2015.37,106.0779;Inherit;False;FLOAT2;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SimpleAddOpNode;6;-1836.872,64.36421;Inherit;False;2;2;0;FLOAT2;0,0;False;1;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.VertexColorNode;10;-1579.417,-654.7889;Inherit;False;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ColorNode;8;-1600.352,-372.1819;Float;False;Property;_Color0;Color 0;2;1;[HDR];Create;True;0;0;False;0;1,1,1,1;23.58574,18.25993,36.32964,1;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SamplerNode;1;-1636.96,-78.17033;Inherit;True;Property;_Main_tex;Main_tex;1;0;Create;True;0;0;False;0;-1;None;0208a06c0bb3fa9459d2739cf4cdb395;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ComponentMaskNode;14;-1245.985,-323.7505;Inherit;False;True;True;True;False;1;0;COLOR;0,0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.ComponentMaskNode;13;-1276.985,-66.75052;Inherit;False;True;True;True;False;1;0;COLOR;0,0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.ComponentMaskNode;15;-1221.296,-587.7808;Inherit;False;True;True;True;False;1;0;COLOR;0,0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;11;-464.958,136.9535;Inherit;False;3;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;9;-422.676,-216.9227;Inherit;False;3;3;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;2.176509,-40.7534;Float;False;True;-1;2;ASEMaterialInspector;0;0;Lambert;FX/alpha_j;False;False;False;False;True;True;True;True;True;True;True;True;False;False;False;False;False;False;False;False;False;Off;2;False;-1;0;False;-1;False;0;False;-1;0;False;-1;False;0;Custom;0.5;True;False;0;True;Custom;;Transparent;All;14;all;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;0.5;False;2;5;False;-1;10;False;-1;0;5;False;-1;10;False;-1;1;False;-1;0;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;0;-1;-1;-1;0;False;0;0;False;-1;-1;0;False;-1;0;0;0;False;0.1;False;-1;0;False;-1;15;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;4;0;2;1
WireConnection;4;1;2;2
WireConnection;6;0;5;0
WireConnection;6;1;4;0
WireConnection;1;1;6;0
WireConnection;14;0;8;0
WireConnection;13;0;1;0
WireConnection;15;0;10;0
WireConnection;11;0;10;3
WireConnection;11;1;8;4
WireConnection;11;2;1;4
WireConnection;9;0;15;0
WireConnection;9;1;14;0
WireConnection;9;2;13;0
WireConnection;0;2;9;0
WireConnection;0;9;11;0
ASEEND*/
//CHKSM=D0224B05E85FCDD844D3C58248F216EF510B0217