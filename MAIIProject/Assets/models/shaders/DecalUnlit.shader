Shader "Custom/DecalUnlit" {

Properties {
	_DecalColor ("Decal Color", Color) = (0,0,0,1)
	_MainTex ("Base (RGB)", 2D) = "white" {}
	_DecalTex ("Decal (RGBA)", 2D) = "black" {}
}

SubShader {
	Tags { "RenderType"="Opaque" }
	LOD 100
		
	Pass {
	
		Name "BASE"
		  
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
		sampler2D _DecalTex;
		float4 _DecalColor;
		float4 _MainTex_ST;
			
		v2f vert (appdata_t v) {			
			v2f o;
			o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
			o.texcoord = TRANSFORM_TEX(v.texcoord, _MainTex);
			return o;
		}
			
		fixed4 frag (v2f i) : SV_Target	{			
			fixed4 col = tex2D(_MainTex, i.texcoord);
			half4 decal = tex2D(_DecalTex, i.texcoord);
			decal.rgb = decal.rgb * _DecalColor;
			col.rgb = lerp (col.rgb, decal.rgb, decal.a);
			return col;
		}
		ENDCG
		}
	}
}
