Shader "Custom/ColouredShadow" {
Properties {
		_Color ("Main Color", Color) = (1,1,1,1)
		_ShadowColor ("Shadow Color", Color) = (1,1,1,1)
		_MainTex ("Base (RGB)", 2D) = "white" {}
		_ShadowTex ("Shadow Texture", 2D) = "white" {}
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200


	
	CGPROGRAM
	#pragma surface surf CSLambert
	sampler2D _MainTex;
	sampler2D _ShadowTex;
	fixed4 _ShadowColor;

	struct Input {
		float2 uv_MainTex;
		float2 uv_ShadowTex;
	};
	

	half4 LightingCSLambert (SurfaceOutput s, half3 lightDir, half atten)	{

		fixed diff = max (0, dot (s.Normal, lightDir));

		fixed4 c;
		c.rgb = s.Albedo * _LightColor0.rgb * (diff * atten * 2);
	
		//shadow colorization
		//c.rgb += _ShadowColor.xyz * (1.0-atten);
	
		c.a = atten;
		
		//c.a = s.Alpha;
		return c;
}

	void surf (Input IN, inout SurfaceOutput o) {
		half4 c = tex2D (_MainTex, IN.uv_MainTex);
		half4 shadow = tex2D (_ShadowMapTexture, IN.uv_ShadowTex);
		
		//o.Albedo = c.rgb;
		o.Albedo = lerp (c.rgb, shadow.rgb, shadow.a);
		o.Alpha = c.a;
	}

	ENDCG
	}

	Fallback "VertexLit"
}
