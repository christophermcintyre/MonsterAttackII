﻿Shader "Custom/UnlitDoubleSided" {
Properties {
	_MainTex ("Base (RGB)", 2D) = "white" {}
	_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
	
}

SubShader {
	Tags { "RenderType"="Opaque" }
	LOD 100
	
	Lighting Off
	Cull Off
	
	Pass {
		  
		CGPROGRAM
		#pragma vertex vert
		#pragma fragment frag
			
		#include "UnityCG.cginc"

		struct appdata_t {
			float4 vertex : POSITION;
			float2 texcoord : TEXCOORD0;
		};

		struct v2f {
			float4 vertex : SV_POSITION;
			half2 texcoord : TEXCOORD0;
		};

		sampler2D _MainTex;
		float4 _MainTex_ST;
		fixed _Cutoff;
			
		v2f vert (appdata_t v) {			
			v2f o;
			o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
			o.texcoord = TRANSFORM_TEX(v.texcoord, _MainTex);
			return o;
		}
			
		fixed4 frag (v2f i) : SV_Target	{			
			fixed4 col = tex2D(_MainTex, i.texcoord);
			clip(col.a - _Cutoff);
			return col;
		}
		ENDCG
		}
	}
}
