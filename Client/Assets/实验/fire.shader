// Shader created with Shader Forge v1.38 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:0,bdst:1,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:False,igpj:False,qofs:0,qpre:3,rntp:3,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:9361,x:33398,y:32754,varname:node_9361,prsc:2|emission-2166-OUT,clip-9547-OUT;n:type:ShaderForge.SFN_Tex2d,id:9330,x:32222,y:32687,ptovrint:False,ptlb:Main,ptin:_Main,varname:node_9330,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Color,id:179,x:32222,y:32890,ptovrint:False,ptlb:color,ptin:_color,varname:node_179,prsc:2,glob:False,taghide:False,taghdr:True,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_VertexColor,id:3053,x:32222,y:33074,varname:node_3053,prsc:2;n:type:ShaderForge.SFN_Multiply,id:8531,x:32457,y:32822,varname:node_8531,prsc:2|A-9330-RGB,B-179-RGB,C-3053-RGB;n:type:ShaderForge.SFN_Multiply,id:2166,x:32812,y:32770,varname:node_2166,prsc:2|A-8531-OUT,B-5483-OUT;n:type:ShaderForge.SFN_ValueProperty,id:5483,x:32619,y:32991,ptovrint:False,ptlb:qd,ptin:_qd,varname:node_5483,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Multiply,id:9306,x:32556,y:33130,varname:node_9306,prsc:2|A-9330-A,B-179-A,C-3053-A;n:type:ShaderForge.SFN_Multiply,id:9547,x:32780,y:33166,varname:node_9547,prsc:2|A-9306-OUT,B-9007-OUT;n:type:ShaderForge.SFN_ValueProperty,id:9007,x:32623,y:33343,ptovrint:False,ptlb:opacity,ptin:_opacity,varname:node_9007,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Time,id:5167,x:30740,y:33137,varname:node_5167,prsc:2;n:type:ShaderForge.SFN_ValueProperty,id:5693,x:30907,y:32999,ptovrint:False,ptlb:Main_U,ptin:_Main_U,varname:node_5693,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_ValueProperty,id:763,x:30867,y:33390,ptovrint:False,ptlb:Main_V,ptin:_Main_V,varname:node_763,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_Multiply,id:3636,x:31068,y:33064,varname:node_3636,prsc:2|A-5693-OUT,B-5167-T;n:type:ShaderForge.SFN_Multiply,id:8385,x:31068,y:33313,varname:node_8385,prsc:2|A-5167-T,B-763-OUT;n:type:ShaderForge.SFN_Append,id:8351,x:31256,y:33204,varname:node_8351,prsc:2|A-3636-OUT,B-8385-OUT;n:type:ShaderForge.SFN_Add,id:5647,x:31498,y:33145,varname:node_5647,prsc:2|A-8783-UVOUT,B-8351-OUT;n:type:ShaderForge.SFN_Tex2d,id:8250,x:31591,y:32594,ptovrint:False,ptlb:Noise,ptin:_Noise,varname:node_8250,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-4345-OUT;n:type:ShaderForge.SFN_ValueProperty,id:1511,x:30902,y:32449,ptovrint:False,ptlb:Noise_U,ptin:_Noise_U,varname:node_1511,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_TexCoord,id:8783,x:31256,y:32941,varname:node_8783,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_ValueProperty,id:8759,x:30902,y:32677,ptovrint:False,ptlb:Noise_V,ptin:_Noise_V,varname:node_8759,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_Multiply,id:9172,x:31132,y:32518,varname:node_9172,prsc:2|A-5167-T,B-1511-OUT;n:type:ShaderForge.SFN_Multiply,id:3687,x:31132,y:32734,varname:node_3687,prsc:2|A-5167-T,B-8759-OUT;n:type:ShaderForge.SFN_Append,id:4345,x:31353,y:32594,varname:node_4345,prsc:2|A-9172-OUT,B-3687-OUT;n:type:ShaderForge.SFN_Lerp,id:9983,x:31957,y:32684,varname:node_9983,prsc:2|A-8250-RGB,B-5647-OUT,T-7418-OUT;n:type:ShaderForge.SFN_Slider,id:4980,x:31434,y:32809,ptovrint:False,ptlb:Noise_qd,ptin:_Noise_qd,varname:node_4980,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_TexCoord,id:7313,x:31525,y:32878,varname:node_7313,prsc:2,uv:1,uaff:True;n:type:ShaderForge.SFN_SwitchProperty,id:7418,x:31777,y:32823,ptovrint:False,ptlb:cust_w,ptin:_cust_w,varname:node_7418,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:False|A-4980-OUT,B-7313-W;n:type:ShaderForge.SFN_Tex2d,id:27,x:32275,y:32488,ptovrint:False,ptlb:node_27,ptin:_node_27,varname:node_27,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Add,id:1764,x:32050,y:32841,varname:node_1764,prsc:2|A-9983-OUT,B-6020-OUT;n:type:ShaderForge.SFN_Vector1,id:6020,x:31853,y:33012,varname:node_6020,prsc:2,v1:0;n:type:ShaderForge.SFN_Lerp,id:893,x:32029,y:32551,varname:node_893,prsc:2|A-8250-G,B-8250-B,T-4980-OUT;proporder:5483-9007-9330-179-5693-763-8250-1511-8759;pass:END;sub:END;*/

Shader "SFX_TYH/fire" {
    Properties {
        _qd ("qd", Float ) = 1
        _opacity ("opacity", Float ) = 1
        _Main ("Main", 2D) = "white" {}
        [HDR]_color ("color", Color) = (0.5,0.5,0.5,1)
        _Main_U ("Main_U", Float ) = 0
        _Main_V ("Main_V", Float ) = 0
        _Noise ("Noise", 2D) = "white" {}
        _Noise_U ("Noise_U", Float ) = 0
        _Noise_V ("Noise_V", Float ) = 0
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "Queue"="Transparent"
            "RenderType"="TransparentCutout"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Cull Off
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform sampler2D _Main; uniform float4 _Main_ST;
            uniform float4 _color;
            uniform float _qd;
            uniform float _opacity;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 vertexColor : COLOR;
                UNITY_FOG_COORDS(1)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.vertexColor = v.vertexColor;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                float4 _Main_var = tex2D(_Main,TRANSFORM_TEX(i.uv0, _Main));
                clip(((_Main_var.a*_color.a*i.vertexColor.a)*_opacity) - 0.5);
////// Lighting:
////// Emissive:
                float3 emissive = ((_Main_var.rgb*_color.rgb*i.vertexColor.rgb)*_qd);
                float3 finalColor = emissive;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "ShadowCaster"
            Tags {
                "LightMode"="ShadowCaster"
            }
            Offset 1, 1
            Cull Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_SHADOWCASTER
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform sampler2D _Main; uniform float4 _Main_ST;
            uniform float4 _color;
            uniform float _opacity;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
                float2 uv0 : TEXCOORD1;
                float4 vertexColor : COLOR;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.vertexColor = v.vertexColor;
                o.pos = UnityObjectToClipPos( v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                float4 _Main_var = tex2D(_Main,TRANSFORM_TEX(i.uv0, _Main));
                clip(((_Main_var.a*_color.a*i.vertexColor.a)*_opacity) - 0.5);
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
