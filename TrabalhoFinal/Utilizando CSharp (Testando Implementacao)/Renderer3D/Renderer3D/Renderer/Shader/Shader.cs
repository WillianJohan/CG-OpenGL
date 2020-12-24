using System.Diagnostics;
using static Renderer3D.OpenGL.GL;

namespace Renderer3D.Renderer.Shader
{
    class Shader
    {
        string vertexCode;
        string fragmentCode;

        public uint ProgramID { get; set; }

        public Shader(string vertexCode, string fragmentCode)
        {
            this.vertexCode = vertexCode;
            this.fragmentCode = fragmentCode;
        }

        public void Load()
        {
            //Criando as variáveis
            uint vs; //VertexShader
            uint fs; //FragmentShader
            int[] status; //Serve para verificar o status da compilação dos Shaders


            //Vertex Shader
            vs = glCreateShader(GL_VERTEX_SHADER);
            glShaderSource(vs, vertexCode);
            glCompileShader(vs);

            status = glGetShaderiv(vs, GL_COMPILE_STATUS, 1);
            if (status[0] == 0)
            {
                string error = glGetShaderInfoLog(vs);
                Debug.WriteLine("ERRO AO COMPILAR VERTEX SHADER: " + error);
            }


            //Fragment Shader
            fs = glCreateShader(GL_FRAGMENT_SHADER);
            glShaderSource(fs, fragmentCode);
            glCompileShader(fs);

            status = glGetShaderiv(fs, GL_COMPILE_STATUS, 1);
            if (status[0] == 0)
            {
                string error = glGetShaderInfoLog(fs);
                Debug.WriteLine("ERRO AO COMPILAR FRAGMENT SHADER: " + error);
            }


            //Linkando os shaders ao Program
            ProgramID = glCreateProgram();
            glAttachShader(ProgramID, vs);
            glAttachShader(ProgramID, fs);

            glLinkProgram(ProgramID);


            //Delete Shader pq não precisa mais depois que carrega
            glDetachShader(ProgramID, vs);
            glDetachShader(ProgramID, fs);
            glDeleteShader(vs);
            glDeleteShader(fs);

        }

        public void Use() => glUseProgram(ProgramID);

    }
}
