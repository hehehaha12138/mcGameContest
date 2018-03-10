﻿// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/loadingShader" {
	Properties {
		//_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_Float1("Float1",Float) = 0.0
		//_Glossiness ("Smoothness", Range(0,1)) = 0.5
		//_Metallic ("Metallic", Range(0,1)) = 0.0
	}
	SubShader{
		Pass{
			CGPROGRAM

			#pragma vertex vert  
			#pragma fragment frag  

			uniform sampler2D _MainTex;
			uniform float _Float1;

			struct Input {
				float4 pos : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f {
				float4 pos : POSITION;
				float2 uv : TEXCOORD0;
			};

			v2f vert(Input i) {
				v2f o;
				o.pos = UnityObjectToClipPos(i.pos);
				o.uv = i.uv;
				return o;
			}

			float4 frag(v2f i) : COLOR{
				float4 outColor;
				outColor = tex2D(_MainTex, i.uv) + _Float1;
				return outColor;
			}
			ENDCG
		}
	}
	Fallback off
}
