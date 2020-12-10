#include <GL/glew.h>
#include <GLFW/glfw3.h>

#include <iostream>
#include <fstream>
#include <string>
#include <sstream>

#include "Renderer.h"

#include "VertexBuffer.h"
#include "VertexBufferLayout.h"
#include "IndexBuffer.h"
#include "VertexArray.h"
#include "Shader.h"
#include "Texture.h"

#include "glm/glm.hpp"
#include "glm/gtc/matrix_transform.hpp"

#include "imgui/imgui.h"
#include "imgui/imgui_impl_glfw_gl3.h"

int main(void)
{
    GLFWwindow* window;

    /* Initialize the library */
    if (!glfwInit())
        return -1;

    glfwWindowHint(GLFW_CONTEXT_VERSION_MAJOR, 3 );
    glfwWindowHint(GLFW_CONTEXT_VERSION_MINOR, 3 );
    glfwWindowHint(GLFW_OPENGL_PROFILE, GLFW_OPENGL_CORE_PROFILE);

    /* Create a windowed mode window and its OpenGL context */
    window = glfwCreateWindow(640, 480, "Hello World", NULL, NULL);
    if (!window)
    {
        glfwTerminate();
        return -1;
    }

    /* Make the window's context current */
    glfwMakeContextCurrent(window);

    if (glewInit() != GLEW_OK)
        std::cout << "GLEW IS NOT OK!" << std::endl;
    std::cout << glGetString(GL_VERSION) << std::endl;
    
    {
        float positions[] =
        {
            -0.5f, -0.5f,    0.0f, 0.0f, //0
             0.5f, -0.5f,    1.0f, 0.0f, //1
             0.5f,  0.5f,    1.0f, 1.0f, //2
            -0.5f,  0.5f,    0.0f, 1.0f  //3
    //   |================| |===============|
    //    Vertex Positions   Area/Coordenada
    //                       Para Leitura Das Texturas

        };

        unsigned int indices[] =
        {
            0, 1, 2,
            2, 3, 0
        };

        GLCall(glEnable(GL_BLEND)); //Set True para Blend na utilização de texturas
        GLCall(glBlendFunc(GL_SRC_ALPHA, GL_ONE_MINUS_SRC_ALPHA)); // Definindo como OpenGL irá lidar com Alpha Pixels

        VertexArray va;
        VertexBuffer vb(positions, 4 * 4 * sizeof(float));

        VertexBufferLayout layout;
        layout.Push<float>(2);
        layout.Push<float>(2);
        va.AddBuffer(vb, layout);
       
        IndexBuffer ib(indices, 6);

        glm::mat4 proj = glm::ortho(-4.0f, 4.0f, -2.0f, 2.0f, -1.0f, 1.0f);
        glm::mat4 view = glm::translate(glm::mat4(1.0f), glm::vec3(-100, 0, 0));

        Shader shader("res/Shaders/Basic.shader");
        shader.Bind();        
        shader.SetUniform4f("u_Color", 1.0f, 0.0f, 0.5f, 1.0f);

        Texture texture("res/Textures/luffy1.png");
        texture.Bind();
        shader.SetUniform1i("u_Texture", 0);

        va.Unbind();
        vb.Unbind();
        ib.Unbind();
        shader.Unbind();

        Renderer renderer;

        glm::vec3 translation(200, 200, 0);

        float r = 0.0f;
        float increment = 0.05f;
       
        /* Loop until the user closes the window */
        while (!glfwWindowShouldClose(window))
        {
            /* Render here */
            renderer.Clear();

            ImGui_ImplGlfwGL3_NewFrame();

			glm::mat4 model = glm::translate(glm::mat4(1.0f), translation);
			glm::mat4 mvp = proj * view * model;

            shader.Bind();
            shader.SetUniform4f("u_Color", r, 1.0f, 1.0f, 1.0f);
            shader.SetUniformMat4f("u_MVP", mvp);

            renderer.Draw(va, ib, shader);

			bool show_demo_window = true;
			bool show_another_window = false;
			ImVec4 clear_color = ImVec4(0.45f, 0.55f, 0.60f, 1.00f);
			
            if (r > 1.0f)
                increment = -0.05f;
            else if (r < 0.0f)
                increment = 0.05f;

            r += increment;

			{
				ImGui::SliderFloat3("Translation", &translation.x, 0.0f, 1.0f);
				ImGui::Text("Application average %.3f ms/frame (%.1f FPS)", 1000.0f / ImGui::GetIO().Framerate, ImGui::GetIO().Framerate);
			}

            ImGui::Render();
            ImGui_ImplGlfwGL3_RenderDrawData(ImGui::GetDrawData());

            /* Swap front and back buffers */
            glfwSwapBuffers(window);

            /* Poll for and process events */
            glfwPollEvents();
        }
    }

    ImGui_ImplGlfwGL3_Shutdown();
    ImGui::DestroyContext();
    glfwTerminate();
    return 0;
}