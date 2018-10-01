Shader "Unlit/OrbShader"
{
	Properties
	{
        [HDR]_TintColor ("Tint Color", Color) = (0.5,0.5,0.5,0.5)
		_MainTex ("Texture", 2D) = "white" {}
        _BumpTex ("Normalmap (RG) & Alpha (A)", 2D) = "black" {}
	}
	SubShader
	{
		Tags { "Queue"="Overlay"  "IgnoreProjector"="True"  "RenderType"="Transparent" "LightMode" = "Always"  }
        Blend SrcAlpha OneMinusSrcAlpha
		Cull Off
		Lighting Off
		ZWrite Off
		ZTest Always

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_particles
			
			#include "UnityCG.cginc"

			struct appdata_t
			{
				float4 vertex : POSITION;
                float2 texcoord: TEXCOORD0;
				float2 uv : TEXCOORD0;
                half4 color: COLOR;

			};

			struct v2f
			{
            float4 uvgrab : TEXCOORD1;
				float2 uvmain : TEXCOORD0;
                float2 uvbump : TEXCOORD2;
				float4 vertex : SV_POSITION;
                half4 color : COLOR;
			};

            sampler2D _MainTex;
            sampler2D _BumpTex;
            float4 _MainTex_ST;
            float4 _BumpTex_ST;
            float4 _TintColor;
            sampler2D _GrabTexture;
            float4 _GrabTexture_TexelSize;
			
			v2f vert (appdata_t v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uvmain.rg = TRANSFORM_TEX(v.texcoord, _MainTex);
                o.uvbump = TRANSFORM_TEX(v.texcoord, _BumpTex);
                o.color = v.color;
                o.uvgrab.xy = (float2(o.vertex.x, o.vertex.y) + o.vertex.w) * 0.5;
                o.uvgrab.zw = o.vertex.w;
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
                half4 tex = tex2D( _MainTex, i.uvmain.rg);
				half3 bump = UnpackNormal(tex2D( _BumpTex, i.uvbump));
                half alphaBump = abs(bump.r + bump.g) * 25;


                float4 col = tex2Dproj( _GrabTexture, i.uvgrab) *  _TintColor * tex * 50;

                //col.rgb = UnpackNormal(tex2D(_MainTex,i.uvmain));
                col.a =  saturate(i.color.a * alphaBump) *0.05;
                return col;
			}
			ENDCG
		}
	}
}
