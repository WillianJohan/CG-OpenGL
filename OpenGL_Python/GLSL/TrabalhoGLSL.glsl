// Código feito para rodar em: http://glslsandbox.com/

precision mediump float;

#define BLACK   vec3(0.0, 0.0, 0.0)
#define WHITE   vec3(1.0, 1.0, 1.0)
#define RED     vec3(1.0, 0.0, 0.0)
#define YELLOW  vec3(1.0, 1.0, 0.0)

uniform vec2 resolution;

vec4 A() {
	
    vec2 position = ( gl_FragCoord.xy - resolution.xy*0.5 ) / resolution.y;
    float radius = 0.3;

    vec4 Color;
	
    if (step(length(position), radius) == 1.0){
	    Color = vec4(BLACK,1.0);
    }
    else{
	Color = vec4(RED, 1.0);
    }

    return Color;
}

vec4 B() {
	
    vec2 position = ( gl_FragCoord.xy - resolution.xy*0.5 ) / resolution.y;
    float radius_Circle1 = 0.3;
    float radius_Circle2 = 0.33;

    vec4 Color;
	
    if(step(length(position), radius_Circle1) == 1.0){
	Color = vec4(RED, 1.0);
    }
    else if (step(length(position), radius_Circle2) == 1.0){
	Color = vec4(BLACK,1.0);
    }    
    else{
	Color = vec4(RED, 1.0);
    }
    
    return Color;
}

vec4 C() {
	
    vec2 position = ( gl_FragCoord.xy - resolution.xy*0.5 ) / resolution.y;
    float radius_Circle1 = 0.3;
    float radius_Circle2 = 0.33;

    vec4 Color;
	
    if(step(length(position), radius_Circle1) == 1.0){
	Color = vec4(YELLOW, 1.0);
    }
    else if (step(length(position), radius_Circle2) == 1.0){
	Color = vec4(BLACK,1.0);
    }    
    else{
	Color = vec4(RED, 1.0);
    }
    
    return Color;
}


vec4 D()
{
    	vec2 positionCircle_01 = ( gl_FragCoord.xy - resolution.xy) / resolution.y + vec2(1.2,0.7);
	vec2 positionCircle_02 = ( gl_FragCoord.xy - resolution.xy) / resolution.y + vec2(1.2,0.3);
	vec2 positionCircle_03 = ( gl_FragCoord.xy - resolution.xy) / resolution.y + vec2(0.8,0.3);
	vec2 positionCircle_04 = ( gl_FragCoord.xy - resolution.xy) / resolution.y + vec2(0.8,0.7);
    
    	float radius = 0.15;

    	vec4 Color = vec4(RED,1.0);
	
	if(step(length(positionCircle_01), radius) == 1.0){
	Color = vec4(BLACK,1.0);
	}
	else if(step(length(positionCircle_02), radius) == 1.0){
	Color = vec4(BLACK,1.0);
	}
	else if(step(length(positionCircle_03), radius) == 1.0){
	Color = vec4(BLACK,1.0);
	}
	else if(step(length(positionCircle_04), radius) == 1.0){
	Color = vec4(BLACK,1.0);
	}

    
    return Color;
}


vec4 E(){

    vec4 color = vec4(RED,1.0);
	
    if(gl_FragCoord.x/resolution.x < gl_FragCoord.y/resolution.y){
	color = vec4(BLACK,1.0);
    }
	
    return color;
}

vec4 F(){
	
    vec2 uv = floor(gl_FragCoord.xy / 30.0);
    vec4 color;
    bool isEven = mod(uv.x + uv.y, 2.0) == 0.0;
    if(isEven) {
        color = vec4(BLACK, 1.0);
    }
    else {
        color = vec4(WHITE, 1.0);
    }
    return color;
}


void main() 
{
    // Atribua ao FragColor a função que desejar.
    gl_FragColor = D();
}