// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'
// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Shader created with Shader Forge v1.17 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.17;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:1,spmd:1,trmd:1,grmd:0,uamb:True,mssp:False,bkdf:False,hqlp:False,rprd:True,enco:False,rmgx:True,rpth:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,culm:2,bsrc:0,bdst:7,dpts:2,wrdp:False,dith:2,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,ofsf:0,ofsu:0,f2p0:False;n:type:ShaderForge.SFN_Final,id:7900,x:32719,y:32712,varname:node_7900,prsc:2|diff-8105-RGB,spec-1113-RGB,gloss-5911-OUT,amdfl-5586-OUT,alpha-5775-OUT,refract-5876-OUT;n:type:ShaderForge.SFN_Slider,id:3709,x:32082,y:33159,ptovrint:False,ptlb:Refraction Strength,ptin:_RefractionStrength,varname:node_3709,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.2,max:1;n:type:ShaderForge.SFN_Tex2d,id:3553,x:32160,y:33302,ptovrint:False,ptlb:Refraction,ptin:_Refraction,varname:node_3553,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:3,isnm:True;n:type:ShaderForge.SFN_ComponentMask,id:9648,x:32383,y:33283,varname:node_9648,prsc:2,cc1:0,cc2:1,cc3:-1,cc4:-1|IN-3553-RGB;n:type:ShaderForge.SFN_Multiply,id:5876,x:32473,y:33103,varname:node_5876,prsc:2|A-9648-OUT,B-3709-OUT;n:type:ShaderForge.SFN_Cubemap,id:8671,x:32140,y:32485,ptovrint:False,ptlb:Environment,ptin:_Environment,varname:node_5001,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,cube:decaa526c37cba94493535eb8e16d475,pvfc:0;n:type:ShaderForge.SFN_Color,id:1113,x:32365,y:32790,ptovrint:False,ptlb:Specular Color,ptin:_SpecularColor,varname:node_5047,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Slider,id:4461,x:31704,y:33104,ptovrint:False,ptlb:Transparency Strength,ptin:_TransparencyStrength,varname:node_3512,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:1,cur:0.1700291,max:0;n:type:ShaderForge.SFN_Fresnel,id:86,x:31946,y:32887,varname:node_86,prsc:2|EXP-6884-OUT;n:type:ShaderForge.SFN_Slider,id:6884,x:31489,y:32927,ptovrint:False,ptlb:Fresnel Transparency Strength,ptin:_FresnelTransparencyStrength,varname:node_151,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:3.835927,max:5;n:type:ShaderForge.SFN_Slider,id:7834,x:32038,y:32684,ptovrint:False,ptlb:Environment Strength,ptin:_EnvironmentStrength,varname:node_7834,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.948718,max:1;n:type:ShaderForge.SFN_Color,id:8105,x:32470,y:32373,ptovrint:False,ptlb:Diffuse Color,ptin:_DiffuseColor,varname:node_8105,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Multiply,id:5586,x:32436,y:32646,varname:node_5586,prsc:2|A-8671-RGB,B-7834-OUT;n:type:ShaderForge.SFN_Slider,id:5911,x:32050,y:32810,ptovrint:False,ptlb:Gloss Strength,ptin:_GlossStrength,varname:node_5911,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.2621359,max:1;n:type:ShaderForge.SFN_Add,id:5775,x:32358,y:32992,varname:node_5775,prsc:2|A-86-OUT,B-4461-OUT;proporder:8105-1113-5911-6884-4461-3553-3709-8671-7834;pass:END;sub:END;*/

Shader "PGS/Shd_Glass" {
    Properties {
        _DiffuseColor ("Diffuse Color", Color) = (0.5,0.5,0.5,1)
        _SpecularColor ("Specular Color", Color) = (1,1,1,1)
        _GlossStrength ("Gloss Strength", Range(0, 1)) = 0.2621359
        _FresnelTransparencyStrength ("Fresnel Transparency Strength", Range(0, 5)) = 3.835927
        _TransparencyStrength ("Transparency Strength", Range(1, 0)) = 0.1700291
        _Refraction ("Refraction", 2D) = "bump" {}
        _RefractionStrength ("Refraction Strength", Range(0, 1)) = 0.2
        _Environment ("Environment", Cube) = "_Skybox" {}
        _EnvironmentStrength ("Environment Strength", Range(0, 1)) = 0.948718
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        GrabPass{ }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend One OneMinusSrcAlpha
            Cull Off
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdbase
            #pragma multi_compile_fog
            #pragma exclude_renderers xbox360 ps3 
            #pragma target 3.0
            uniform sampler2D _GrabTexture;
            uniform float _RefractionStrength;
            uniform sampler2D _Refraction; uniform float4 _Refraction_ST;
            uniform samplerCUBE _Environment;
            uniform float4 _SpecularColor;
            uniform float _TransparencyStrength;
            uniform float _FresnelTransparencyStrength;
            uniform float _EnvironmentStrength;
            uniform float4 _DiffuseColor;
            uniform float _GlossStrength;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float4 screenPos : TEXCOORD3;
                UNITY_FOG_COORDS(4)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos(v.vertex);
                UNITY_TRANSFER_FOG(o,o.pos);
                o.screenPos = o.pos;
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                #if UNITY_UV_STARTS_AT_TOP
                    float grabSign = -_ProjectionParams.x;
                #else
                    float grabSign = _ProjectionParams.x;
                #endif
                i.normalDir = normalize(i.normalDir);
                i.screenPos = float4( i.screenPos.xy / i.screenPos.w, 0, 0 );
                i.screenPos.y *= _ProjectionParams.x;
                float3 _Refraction_var = UnpackNormal(tex2D(_Refraction,TRANSFORM_TEX(i.uv0, _Refraction)));
                float2 sceneUVs = float2(1,grabSign)*i.screenPos.xy*0.5+0.5 + (_Refraction_var.rgb.rg*_RefractionStrength);
                float4 sceneColor = tex2D(_GrabTexture, sceneUVs);
/////// Vectors:
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                
                float nSign = sign( dot( viewDirection, i.normalDir ) ); // Reverse normal if this is a backface
                i.normalDir *= nSign;
                normalDirection *= nSign;
                
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = 1;
                float3 attenColor = attenuation * _LightColor0.xyz;
///////// Gloss:
                float gloss = _GlossStrength;
                float specPow = exp2( gloss * 10.0+1.0);
/////// GI Data:
                UnityLight light;
                #ifdef LIGHTMAP_OFF
                    light.color = lightColor;
                    light.dir = lightDirection;
                    light.ndotl = LambertTerm (normalDirection, light.dir);
                #else
                    light.color = half3(0.f, 0.f, 0.f);
                    light.ndotl = 0.0f;
                    light.dir = half3(0.f, 0.f, 0.f);
                #endif
                UnityGIInput d;
                d.light = light;
                d.worldPos = i.posWorld.xyz;
                d.worldViewDir = viewDirection;
                d.atten = attenuation;
                d.boxMax[0] = unity_SpecCube0_BoxMax;
                d.boxMin[0] = unity_SpecCube0_BoxMin;
                d.probePosition[0] = unity_SpecCube0_ProbePosition;
                d.probeHDR[0] = unity_SpecCube0_HDR;
                d.boxMax[1] = unity_SpecCube1_BoxMax;
                d.boxMin[1] = unity_SpecCube1_BoxMin;
                d.probePosition[1] = unity_SpecCube1_ProbePosition;
                d.probeHDR[1] = unity_SpecCube1_HDR;
                UnityGI gi = UnityGlobalIllumination (d, 1, gloss, normalDirection);
                lightDirection = gi.light.dir;
                lightColor = gi.light.color;
////// Specular:
                float NdotL = max(0, dot( normalDirection, lightDirection ));
                float3 specularColor = _SpecularColor.rgb;
                float3 directSpecular = attenColor * pow(max(0,dot(halfDirection,normalDirection)),specPow)*specularColor;
                float3 indirectSpecular = (gi.indirect.specular)*specularColor;
                float3 specular = (directSpecular + indirectSpecular);
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += UNITY_LIGHTMODEL_AMBIENT.rgb; // Ambient Light
                indirectDiffuse += (texCUBE(_Environment,viewReflectDirection).rgb*_EnvironmentStrength); // Diffuse Ambient Light
                float3 diffuseColor = _DiffuseColor.rgb;
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse * (pow(1.0-max(0,dot(normalDirection, viewDirection)),_FresnelTransparencyStrength)+_TransparencyStrength) + specular;
                fixed4 finalRGBA = fixed4(lerp(sceneColor.rgb, finalColor,(pow(1.0-max(0,dot(normalDirection, viewDirection)),_FresnelTransparencyStrength)+_TransparencyStrength)),1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "FORWARD_DELTA"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            Cull Off
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdadd
            #pragma multi_compile_fog
            #pragma exclude_renderers xbox360 ps3 
            #pragma target 3.0
            uniform sampler2D _GrabTexture;
            uniform float _RefractionStrength;
            uniform sampler2D _Refraction; uniform float4 _Refraction_ST;
            uniform float4 _SpecularColor;
            uniform float _TransparencyStrength;
            uniform float _FresnelTransparencyStrength;
            uniform float4 _DiffuseColor;
            uniform float _GlossStrength;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float4 screenPos : TEXCOORD3;
                LIGHTING_COORDS(4,5)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.screenPos = o.pos;
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                #if UNITY_UV_STARTS_AT_TOP
                    float grabSign = -_ProjectionParams.x;
                #else
                    float grabSign = _ProjectionParams.x;
                #endif
                i.normalDir = normalize(i.normalDir);
                i.screenPos = float4( i.screenPos.xy / i.screenPos.w, 0, 0 );
                i.screenPos.y *= _ProjectionParams.x;
                float3 _Refraction_var = UnpackNormal(tex2D(_Refraction,TRANSFORM_TEX(i.uv0, _Refraction)));
                float2 sceneUVs = float2(1,grabSign)*i.screenPos.xy*0.5+0.5 + (_Refraction_var.rgb.rg*_RefractionStrength);
                float4 sceneColor = tex2D(_GrabTexture, sceneUVs);
/////// Vectors:
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                
                float nSign = sign( dot( viewDirection, i.normalDir ) ); // Reverse normal if this is a backface
                i.normalDir *= nSign;
                normalDirection *= nSign;
                
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
///////// Gloss:
                float gloss = _GlossStrength;
                float specPow = exp2( gloss * 10.0+1.0);
////// Specular:
                float NdotL = max(0, dot( normalDirection, lightDirection ));
                float3 specularColor = _SpecularColor.rgb;
                float3 directSpecular = attenColor * pow(max(0,dot(halfDirection,normalDirection)),specPow)*specularColor;
                float3 specular = directSpecular;
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float3 diffuseColor = _DiffuseColor.rgb;
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse * (pow(1.0-max(0,dot(normalDirection, viewDirection)),_FresnelTransparencyStrength)+_TransparencyStrength) + specular;
                return fixed4(finalColor,0);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
