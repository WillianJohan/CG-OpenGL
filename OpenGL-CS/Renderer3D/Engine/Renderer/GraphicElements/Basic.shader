// VERTEX SHADER CODE ==================================================================================================
#shader vertex
#version 330

layout(location = 0) in vec3 vertex_position;
layout(location = 1) in vec3 vertex_normal;

out vec3 vertex_position_cam;
out vec3 vertex_normal_cam;

uniform mat4 matriz;
uniform mat4 view;
uniform mat4 proj;

void main() {
    vertex_position_cam = vec3(view * matriz * vec4(vertex_position, 1.0)); // Position of the object in relation to the CAMERA
    vertex_normal_cam = vec3(view * matriz * vec4(vertex_normal, 0.0));     // Normal values ​​of the object in relation to CAMERA
    gl_Position = proj * view * matriz * vec4(vertex_position, 1.0);
};
// =====================================================================================================================
// =====================================================================================================================
// FRAGMENT SHADER CODE ================================================================================================
#shader fragment
#version 330 core

in vec3 vertex_position_cam;
in vec3 vertex_normal_cam;



// Spotlight properties
uniform vec3 light_position;
uniform vec3 Ls;// Specular Light
uniform vec3 Ld;// Diffuse Light
uniform vec3 La;// Ambient Light



// Surface reflection properties
uniform vec3 Ks; // Specular Reflection
uniform vec3 Kd; // Diffuse Reflection
uniform vec3 Ka; // Ambient Reflection
uniform float especular_exp; // Specular exponent

uniform mat4 view;
out vec4 frag_colour;

// CRIAR AQUI METODOS PARA RETORNAR OS CALCULOS DAS LUZES E ETC...

vec3 AmbientLightIntensity() {
    /* Calculation of Ambient Light Intensity (Ia)
        The calculation of ambient light intensity is the simplest:
            just multiply the color of the ambient light by the reflectance of ambient light from the surface
    */

    return La * Ka;
}


vec3 DiffuseLightIntensity() {
    /* Calculation of Diffused Light Intensity (Id)
    To calculate the intensity of diffused light, we first need to
    calculate the position of the light in relation to the camera (light_position_cam)*/
    vec3 light_position_cam = vec3(view * vec4(light_position, 1.0)); // Position of the light in relation to the camera

    /*The light position (light_position_cam) calculated above represents a vector that comes from the origin (0,0,0) and
    points to the light. For diffuse light, we need to calculate a vector that comes out of each vertex of the object
    (vertex_posicao_cam) and point to that light. To do this, we simply calculate the difference between light_position_cam
    and vertex_position_cam*/
    vec3 light_vector_cam = light_position_cam - vertex_position_cam; // Vector pointing to the light in relation to the vertex position
    
    /*Finally, we normalize the light vector in relation to the vertex of the object and calculate the cosine of the angle
    between the same and the normal surface using the scalar product*/
    vec3 light_vector_cam_normalized = normalize(light_vector_cam);
    vec3 vertex_normal_cam_normalized = normalize(vertex_normal_cam);
    float cosine_diffuse = dot(vertex_normal_cam_normalized, light_vector_cam_normalized); // Cosine of the angle between the light vector and the surface normal

    return Ld * Kd * cosine_diffuse;
}


vec3 SpecularLightIntensity()
{
    /*Specular Light Intensity Calculation (Is)
        To calculate the specular light intensity, we first need to calculate the vector that represents the reflected light in relation to the normal of the surface */
    vec3 light_position_cam = vec3(view * vec4(light_position, 1.0));

    /*The light position (light_position_cam) calculated above represents a vector that comes from the origin (0,0,0) and
    points to the light. For diffuse light, we need to calculate a vector that comes out of each vertex of the object
    (vertex_position_cam) and point to that light. To do this, just calculate the difference between light_position_cam
    and vertex_posicao_cam.*/
    vec3 light_vector_cam = light_position_cam - vertex_position_cam;// Vector pointing to the light in relation to the vertex position

    
    /*Normalize the light vector in relation to the vertex of the object and calculate the cosine of the angle
    between the same and the normal surface using the scalar product*/
    vec3 light_vetor_cam_normalized = normalize(light_vector_cam);//vetor da luz normalizada
    vec3 vertex_normal_cam_normalized = normalize(vertex_normal_cam);

    vec3 reflection_light_vetor_cam = reflect(-light_vetor_cam_normalized, vertex_normal_cam_normalized);

    /*As the intensity of the specular light depends on the position of the camera, we define a vector that comes out of the surface
    of the object and points to the camera, and then we normalize, because we will use it in the calculation of the scalar product*/
    vec3 surface_cam_vetor = normalize(-vertex_position_cam);

    /*And then we calculate the angle between the light reflection vector and the vector in relation to the observer's position*/
    float specular_cosine = dot(reflection_light_vetor_cam, surface_cam_vetor);
    specular_cosine = max(specular_cosine, 0.0);//se o cosseno der negativo, atribui 0 para ele

    /*At specular intensity, we need to raise the cosine calculated above to the specular exponent*/
    float specular_factor = pow(specular_cosine, especular_exp);

    /*And finally, we calculate the intensity of reflected specular light (Is)*/
    return Ls * Ks * specular_factor;
}


void main() {

    vec3 Ia = AmbientLightIntensity();
    vec3 Id = DiffuseLightIntensity();
    vec3 Is = SpecularLightIntensity();

    /*A cor final do fragmento é a soma das 3 componentes de iluminação*/
    frag_colour = vec4(Ia + Id + Is, 1.0);
};
