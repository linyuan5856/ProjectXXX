// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "shichadilie"
{
	Properties
	{
		_shendutu("shendutu", 2D) = "white" {}
		_shendukongzhi("shendukongzhi", Range( 0 , 0.5)) = 0
		_Normal("Normal", 2D) = "white" {}
		_toumingTEX("toumingTEX", 2D) = "white" {}
		_Opacity("Opacity", Range( 0 , 1)) = 1
		_DIss("DIss", 2D) = "white" {}
		_Diss_qd("Diss_qd", Range( 0 , 1)) = 0
		_DIss_RY("DIss_R/Y", Range( 0 , 1)) = 1
		_TextureSample0("Emission", 2D) = "white" {}
		[HDR]_Emission_color("Emission_color", Color) = (1,0,0,0)
		_liudongwenli("liudongwenli", 2D) = "white" {}
		[HDR]_shendu_color("shendu_color", Color) = (1,0.6628425,0,0)
		_shichaUV_APEED("shichaUV_APEED", Vector) = (1,1,0.2,0.2)
		_11111("11111", Float) = 0
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "Transparent"  "Queue" = "Transparent+0" "IgnoreProjector" = "True" "IsEmissive" = "true"  }
		Cull Back
		CGPROGRAM
		#include "UnityShaderVariables.cginc"
		#pragma target 3.5
		#pragma surface surf Standard alpha:fade keepalpha noshadow 
		struct Input
		{
			float2 uv_texcoord;
			float3 viewDir;
			INTERNAL_DATA
			float3 worldNormal;
			float3 worldPos;
		};

		uniform sampler2D _Normal;
		uniform sampler2D _shendutu;
		uniform float _shendukongzhi;
		uniform float4 _shendutu_ST;
		uniform sampler2D _TextureSample0;
		uniform float4 _Emission_color;
		uniform sampler2D _liudongwenli;
		uniform float _11111;
		uniform float4 _shichaUV_APEED;
		uniform float4 _shendu_color;
		uniform sampler2D _toumingTEX;
		uniform float _Opacity;
		uniform float _DIss_RY;
		uniform sampler2D _DIss;
		uniform float4 _DIss_ST;
		uniform float _Diss_qd;


		inline float2 POM( sampler2D heightMap, float2 uvs, float2 dx, float2 dy, float3 normalWorld, float3 viewWorld, float3 viewDirTan, int minSamples, int maxSamples, float parallax, float refPlane, float2 tilling, float2 curv, int index )
		{
			float3 result = 0;
			int stepIndex = 0;
			int numSteps = ( int )lerp( (float)maxSamples, (float)minSamples, saturate( dot( normalWorld, viewWorld ) ) );
			float layerHeight = 1.0 / numSteps;
			float2 plane = parallax * ( viewDirTan.xy / viewDirTan.z );
			uvs += refPlane * plane;
			float2 deltaTex = -plane * layerHeight;
			float2 prevTexOffset = 0;
			float prevRayZ = 1.0f;
			float prevHeight = 0.0f;
			float2 currTexOffset = deltaTex;
			float currRayZ = 1.0f - layerHeight;
			float currHeight = 0.0f;
			float intersection = 0;
			float2 finalTexOffset = 0;
			while ( stepIndex < numSteps + 1 )
			{
				currHeight = tex2Dgrad( heightMap, uvs + currTexOffset, dx, dy ).r;
				if ( currHeight > currRayZ )
				{
					stepIndex = numSteps + 1;
				}
				else
				{
					stepIndex++;
					prevTexOffset = currTexOffset;
					prevRayZ = currRayZ;
					prevHeight = currHeight;
					currTexOffset += deltaTex;
					currRayZ -= layerHeight;
				}
			}
			int sectionSteps = 10;
			int sectionIndex = 0;
			float newZ = 0;
			float newHeight = 0;
			while ( sectionIndex < sectionSteps )
			{
				intersection = ( prevHeight - prevRayZ ) / ( prevHeight - currHeight + currRayZ - prevRayZ );
				finalTexOffset = prevTexOffset + intersection * deltaTex;
				newZ = prevRayZ - intersection * layerHeight;
				newHeight = tex2Dgrad( heightMap, uvs + finalTexOffset, dx, dy ).r;
				if ( newHeight > newZ )
				{
					currTexOffset = finalTexOffset;
					currHeight = newHeight;
					currRayZ = newZ;
					deltaTex = intersection * deltaTex;
					layerHeight = intersection * layerHeight;
				}
				else
				{
					prevTexOffset = finalTexOffset;
					prevHeight = newHeight;
					prevRayZ = newZ;
					deltaTex = ( 1 - intersection ) * deltaTex;
					layerHeight = ( 1 - intersection ) * layerHeight;
				}
				sectionIndex++;
			}
			result.xy = uvs + finalTexOffset;
			#ifdef UNITY_PASS_SHADOWCASTER
			if ( unity_LightShadowBias.z == 0.0 )
			{
			#endif
				if ( result.x < 0 )
					clip( -1 );
				if ( result.x > tilling.x )
					clip( -1 );
				if ( result.y < 0 )
					clip( -1 );
				if ( result.y > tilling.y )
					clip( -1 );
			#ifdef UNITY_PASS_SHADOWCASTER
			}
			#endif
			return result.xy;
		}


		void surf( Input i , inout SurfaceOutputStandard o )
		{
			float3 ase_worldNormal = WorldNormalVector( i, float3( 0, 0, 1 ) );
			float3 ase_worldPos = i.worldPos;
			float3 ase_worldViewDir = normalize( UnityWorldSpaceViewDir( ase_worldPos ) );
			float2 OffsetPOM4 = POM( _shendutu, i.uv_texcoord, ddx(i.uv_texcoord), ddy(i.uv_texcoord), ase_worldNormal, ase_worldViewDir, i.viewDir, 128, 128, _shendukongzhi, 0.5, _shendutu_ST.xy, float2(0,0), 0 );
			float2 DepthUV12 = OffsetPOM4;
			float4 Normal24 = tex2D( _Normal, DepthUV12 );
			o.Normal = Normal24.rgb;
			float4 tex2DNode105 = tex2D( _TextureSample0, DepthUV12 );
			float2 temp_output_62_0 = (DepthUV12*1.0 + 0.0);
			float2 break100 = temp_output_62_0;
			float2 appendResult89 = (float2(pow( length( temp_output_62_0 ) , _11111 ) , ( atan2( break100.y , break100.x ) / UNITY_PI )));
			float2 appendResult93 = (float2(_shichaUV_APEED.x , _shichaUV_APEED.y));
			float2 appendResult94 = (float2(_shichaUV_APEED.z , _shichaUV_APEED.w));
			float4 lerpResult108 = lerp( ( tex2DNode105.r * _Emission_color ) , ( tex2D( _liudongwenli, (appendResult89*appendResult93 + ( appendResult94 * _Time.y )) ) * _shendu_color ) , tex2DNode105.r);
			float4 Emission109 = lerpResult108;
			o.Emission = Emission109.rgb;
			float2 uv_DIss = i.uv_texcoord * _DIss_ST.xy + _DIss_ST.zw;
			float smoothstepResult55 = smoothstep( ( 1.0 - _DIss_RY ) , _DIss_RY , ( tex2D( _DIss, uv_DIss ).r + 1.0 + ( _Diss_qd * -2.0 ) ));
			float Alpha58 = ( tex2D( _toumingTEX, DepthUV12 ).r * _Opacity * smoothstepResult55 );
			o.Alpha = Alpha58;
		}

		ENDCG
	}
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=18000
510;537;2508;1342;-2350.835;506.259;1;True;True
Node;AmplifyShaderEditor.CommentaryNode;19;-1177.54,-143.0925;Inherit;False;1050;895;视差;6;2;8;11;10;4;12;;1,1,1,1;0;0
Node;AmplifyShaderEditor.TexturePropertyNode;8;-1157.541,93.9077;Inherit;True;Property;_shendutu;shendutu;2;0;Create;True;0;0;False;0;None;cbe1989aaf2279541b1c6bfe9bd692c2;False;white;Auto;Texture2D;-1;0;1;SAMPLER2D;0
Node;AmplifyShaderEditor.ViewDirInputsCoordNode;11;-1127.541,535.9082;Inherit;False;Tangent;False;0;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.RangedFloatNode;10;-1139.541,338.908;Inherit;False;Property;_shendukongzhi;shendukongzhi;3;0;Create;True;0;0;False;0;0;0.025;0;0.5;0;1;FLOAT;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;2;-1118.541,-93.09255;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ParallaxOcclusionMappingNode;4;-681.5419,-69.09255;Inherit;False;0;128;False;-1;128;False;-1;10;0.02;0.5;True;1,1;False;0,0;Texture2D;7;0;FLOAT2;0,0;False;1;SAMPLER2D;;False;2;FLOAT;0.02;False;3;FLOAT3;0,0,0;False;4;FLOAT;0;False;5;FLOAT2;0,0;False;6;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.CommentaryNode;110;-1414.83,2156.247;Inherit;False;5100.398;966.7834;Emission;25;89;91;93;94;90;97;87;98;100;95;86;62;66;64;101;68;104;106;108;109;105;107;103;113;114;;1,1,1,1;0;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;12;-335.5411,-65.09255;Inherit;False;DepthUV;-1;True;1;0;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.GetLocalVarNode;64;-1364.83,2329.03;Inherit;False;12;DepthUV;1;0;OBJECT;;False;1;FLOAT2;0
Node;AmplifyShaderEditor.ScaleAndOffsetNode;62;-1077.1,2327.525;Inherit;False;3;0;FLOAT2;0,0;False;1;FLOAT;1;False;2;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.BreakToComponentsNode;100;-731.8297,2465.031;Inherit;False;FLOAT2;1;0;FLOAT2;0,0;False;16;FLOAT;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4;FLOAT;5;FLOAT;6;FLOAT;7;FLOAT;8;FLOAT;9;FLOAT;10;FLOAT;11;FLOAT;12;FLOAT;13;FLOAT;14;FLOAT;15
Node;AmplifyShaderEditor.Vector4Node;91;279.17,2697.03;Inherit;False;Property;_shichaUV_APEED;shichaUV_APEED;19;0;Create;True;0;0;False;0;1,1,0.2,0.2;3,3,0.01,0.05;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.LengthOpNode;66;-707.8297,2331.03;Inherit;False;1;0;FLOAT2;0,0;False;1;FLOAT;0
Node;AmplifyShaderEditor.PiNode;87;-215.8299,2600.03;Inherit;False;1;0;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.ATan2OpNode;68;-260.8299,2465.031;Inherit;False;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;114;-533.2719,2708.375;Inherit;False;Property;_11111;11111;20;0;Create;True;0;0;False;0;0;0.36;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.PowerNode;113;-272.2719,2241.375;Inherit;False;False;2;0;FLOAT;0;False;1;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.DynamicAppendNode;94;660.1699,2818.03;Inherit;False;FLOAT2;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.CommentaryNode;59;1515.504,486.0347;Inherit;False;1751;1201.517;Alpha;14;43;44;45;47;48;49;50;51;52;53;55;56;46;58;;1,1,1,1;0;0
Node;AmplifyShaderEditor.SimpleDivideOpNode;86;8.169983,2441.031;Inherit;False;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleTimeNode;97;729.1699,3012.03;Inherit;False;1;0;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;50;1565.504,1327.552;Inherit;False;Property;_Diss_qd;Diss_qd;13;0;Create;True;0;0;False;0;0;0;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;95;1017.17,2805.03;Inherit;False;2;2;0;FLOAT2;0,0;False;1;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.DynamicAppendNode;93;653.1699,2675.03;Inherit;False;FLOAT2;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.DynamicAppendNode;89;190.17,2352.03;Inherit;False;FLOAT2;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.RangedFloatNode;51;1680.504,1490.552;Inherit;False;Constant;_Float1;Float 1;14;0;Create;True;0;0;False;0;-2;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SamplerNode;47;1607.504,920.5519;Inherit;True;Property;_DIss;DIss;12;0;Create;True;0;0;False;0;-1;None;25771e60124c9884ebc25a54e362aad4;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;49;1797.504,1147.552;Inherit;False;Constant;_Float0;Float 0;13;0;Create;True;0;0;False;0;1;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.ScaleAndOffsetNode;90;1101.17,2401.03;Inherit;False;3;0;FLOAT2;0,0;False;1;FLOAT2;1,0;False;2;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.RangedFloatNode;53;1954.504,1571.552;Inherit;False;Property;_DIss_RY;DIss_R/Y;14;0;Create;True;0;0;False;0;1;0.838;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;52;1955.504,1329.552;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;104;1884.569,2212.247;Inherit;False;12;DepthUV;1;0;OBJECT;;False;1;FLOAT2;0
Node;AmplifyShaderEditor.OneMinusNode;56;2308.504,1275.552;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;43;1618.816,589.7216;Inherit;False;12;DepthUV;1;0;OBJECT;;False;1;FLOAT2;0
Node;AmplifyShaderEditor.ColorNode;103;1540.17,2673.03;Inherit;False;Property;_shendu_color;shendu_color;18;1;[HDR];Create;True;0;0;False;0;1,0.6628425,0,0;1.405038,2.69299,5.59088,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleAddOpNode;48;2157.504,970.5519;Inherit;False;3;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode;107;2493.569,2367.247;Inherit;False;Property;_Emission_color;Emission_color;16;1;[HDR];Create;True;0;0;False;0;1,0,0,0;0,3.043321,9.082411,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.CommentaryNode;25;-1236.02,978.313;Inherit;False;1022;280;Normal;3;21;23;24;;1,1,1,1;0;0
Node;AmplifyShaderEditor.SamplerNode;105;2079.569,2197.247;Inherit;True;Property;_TextureSample0;Emission;15;0;Create;False;0;0;False;0;-1;None;42fb1d9267d5ed340857f601ab6e87ed;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SamplerNode;98;1373.17,2362.03;Inherit;True;Property;_liudongwenli;liudongwenli;17;0;Create;True;0;0;False;0;-1;None;e1f8b1c2217b8b84fbdd2dbb15263703;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SmoothstepOpNode;55;2560.504,1131.552;Inherit;False;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;106;2961.569,2232.247;Inherit;False;2;2;0;FLOAT;0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.GetLocalVarNode;21;-1186.02,1047.313;Inherit;False;12;DepthUV;1;0;OBJECT;;False;1;FLOAT2;0
Node;AmplifyShaderEditor.RangedFloatNode;45;2275.504,773.5519;Inherit;False;Property;_Opacity;Opacity;11;0;Create;True;0;0;False;0;1;1;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;101;1912.17,2446.031;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SamplerNode;44;1940.938,536.0347;Inherit;True;Property;_toumingTEX;toumingTEX;10;0;Create;True;0;0;False;0;-1;None;42fb1d9267d5ed340857f601ab6e87ed;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;46;2811.504,645.5519;Inherit;False;3;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SamplerNode;23;-840.0203,1028.313;Inherit;True;Property;_Normal;Normal;4;0;Create;True;0;0;False;0;-1;None;d0718963b0e93b74d92c1bc7ffb9d25e;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.LerpOp;108;3128.569,2459.247;Inherit;False;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;58;3042.504,641.5519;Inherit;False;Alpha;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;109;3448.569,2483.247;Inherit;False;Emission;-1;True;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.CommentaryNode;34;10.42645,1007.42;Inherit;False;1416.001;365;smooth;6;27;28;30;29;31;32;;1,1,1,1;0;0
Node;AmplifyShaderEditor.CommentaryNode;20;149,-149.8171;Inherit;False;1265.487;626;漫反射;5;13;14;15;16;17;;1,1,1,1;0;0
Node;AmplifyShaderEditor.CommentaryNode;40;16.38611,555.8087;Inherit;False;1251;407;AO;5;37;38;39;35;36;;1,1,1,1;0;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;24;-438.0203,1031.313;Inherit;False;Normal;-1;True;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.GetLocalVarNode;33;3355.71,62.09018;Inherit;False;32;smooth;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;27;60.42645,1112.42;Inherit;False;12;DepthUV;1;0;OBJECT;;False;1;FLOAT2;0
Node;AmplifyShaderEditor.OneMinusNode;29;772.427,1091.42;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;17;1190.487,12.49031;Inherit;False;Albedo;-1;True;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.RangedFloatNode;30;771.427,1256.42;Inherit;False;Property;_smooth_qd;smooth_qd;6;0;Create;True;0;0;False;0;0;1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;31;1007.427,1135.42;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;32;1202.427,1126.42;Inherit;False;smooth;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;41;3360.376,143.5741;Inherit;False;39;AO;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.SamplerNode;36;305.3861,605.8087;Inherit;True;Property;_TextureSample1;AO;7;0;Create;False;0;0;False;0;-1;None;42fb1d9267d5ed340857f601ab6e87ed;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.GetLocalVarNode;13;199,-74;Inherit;False;12;DepthUV;1;0;OBJECT;;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SamplerNode;28;344.4264,1057.42;Inherit;True;Property;_smooth;smooth;5;0;Create;True;0;0;False;0;-1;None;42fb1d9267d5ed340857f601ab6e87ed;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;37;624.3861,846.8087;Inherit;False;Property;_AO;AO;8;0;Create;True;0;0;False;0;0;1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;16;964.1879,24.18292;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.GetLocalVarNode;60;3366.588,288.5478;Inherit;False;58;Alpha;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;38;850.3861,644.8087;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;26;3361.97,-164.9216;Inherit;False;24;Normal;1;0;OBJECT;;False;1;COLOR;0
Node;AmplifyShaderEditor.GetLocalVarNode;18;3362.178,-248.0517;Inherit;False;17;Albedo;1;0;OBJECT;;False;1;COLOR;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;39;1043.386,639.8087;Inherit;False;AO;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;42;3369.376,-15.42592;Inherit;False;Property;_Metallic;Metallic;9;0;Create;True;0;0;False;0;0;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;35;66.38611,635.8087;Inherit;False;12;DepthUV;1;0;OBJECT;;False;1;FLOAT2;0
Node;AmplifyShaderEditor.GetLocalVarNode;111;3465.786,437.3801;Inherit;False;109;Emission;1;0;OBJECT;;False;1;COLOR;0
Node;AmplifyShaderEditor.SamplerNode;14;499.1879,-99.81708;Inherit;True;Property;_manfanshe;manfanshe;0;0;Create;True;0;0;False;0;-1;None;42fb1d9267d5ed340857f601ab6e87ed;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;15;599.1879,112.1829;Inherit;False;Property;_manfansheqd;manfansheqd;1;0;Create;True;0;0;False;0;0;3;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;4303.496,-50.02551;Float;False;True;-1;3;ASEMaterialInspector;0;0;Standard;shichadilie;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;False;False;False;False;False;False;Back;0;False;-1;0;False;-1;False;0;False;-1;0;False;-1;False;0;Transparent;0.5;True;False;0;False;Transparent;;Transparent;All;14;all;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;0.5;False;2;5;False;-1;10;False;-1;0;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;-1;-1;-1;-1;0;False;0;0;False;-1;-1;0;False;-1;0;0;0;False;0.1;False;-1;0;False;-1;16;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;4;0;2;0
WireConnection;4;1;8;0
WireConnection;4;2;10;0
WireConnection;4;3;11;0
WireConnection;12;0;4;0
WireConnection;62;0;64;0
WireConnection;100;0;62;0
WireConnection;66;0;62;0
WireConnection;68;0;100;1
WireConnection;68;1;100;0
WireConnection;113;0;66;0
WireConnection;113;1;114;0
WireConnection;94;0;91;3
WireConnection;94;1;91;4
WireConnection;86;0;68;0
WireConnection;86;1;87;0
WireConnection;95;0;94;0
WireConnection;95;1;97;0
WireConnection;93;0;91;1
WireConnection;93;1;91;2
WireConnection;89;0;113;0
WireConnection;89;1;86;0
WireConnection;90;0;89;0
WireConnection;90;1;93;0
WireConnection;90;2;95;0
WireConnection;52;0;50;0
WireConnection;52;1;51;0
WireConnection;56;0;53;0
WireConnection;48;0;47;1
WireConnection;48;1;49;0
WireConnection;48;2;52;0
WireConnection;105;1;104;0
WireConnection;98;1;90;0
WireConnection;55;0;48;0
WireConnection;55;1;56;0
WireConnection;55;2;53;0
WireConnection;106;0;105;1
WireConnection;106;1;107;0
WireConnection;101;0;98;0
WireConnection;101;1;103;0
WireConnection;44;1;43;0
WireConnection;46;0;44;1
WireConnection;46;1;45;0
WireConnection;46;2;55;0
WireConnection;23;1;21;0
WireConnection;108;0;106;0
WireConnection;108;1;101;0
WireConnection;108;2;105;1
WireConnection;58;0;46;0
WireConnection;109;0;108;0
WireConnection;24;0;23;0
WireConnection;29;0;28;1
WireConnection;17;0;16;0
WireConnection;31;0;29;0
WireConnection;31;1;30;0
WireConnection;32;0;31;0
WireConnection;36;1;35;0
WireConnection;28;1;27;0
WireConnection;16;0;14;0
WireConnection;16;1;15;0
WireConnection;38;0;36;1
WireConnection;38;1;37;0
WireConnection;39;0;38;0
WireConnection;14;1;13;0
WireConnection;0;1;26;0
WireConnection;0;2;111;0
WireConnection;0;9;60;0
ASEEND*/
//CHKSM=EBDD14F3C78504531F9B1F5D161878B54A67A27F