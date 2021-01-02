using GLFW;

namespace Renderer3D
{
    public static class Input
    {
        public static bool GetKeyDown(Keys key) => Glfw.GetKey(DisplayManager.window, key) == InputState.Press;
        public static bool GetKeyUp(Keys key) => Glfw.GetKey(DisplayManager.window, key) == InputState.Release;
    }
}

/*
    public static class Input
    {
        private struct KeyState
        {
            public InputState lastState;
            public Keys key;

            public KeyState(Keys key)
            {
                this.key = key;
                this.lastState = InputState.Press;
            }

        }

        private static List<KeyState> keysBuffer = new List<KeyState>();

        public static bool GetKey(Keys key)
        {
            return Glfw.GetKey(DisplayManager.window, key) == InputState.Press;
        }

        public static bool GetKeyDown(Keys key)
        {
            int keyRef = -1;
            foreach(KeyState k in keysBuffer)
            {
                //Verifico se tenho a key 
                if (k.key == key)
                {
                    keyRef = keysBuffer.IndexOf(k);
                    break;
                }
            }
            if(keyRef == -1)
            {
                keysBuffer.Add(new KeyState(key));
                return true;
            }

            if (keysBuffer[keyRef].lastState == InputState.Press)
                return false;

            keysBuffer[keyRef].lastState = InputState.Press;

            return true;

            //return Glfw.GetKey(DisplayManager.window, key) == InputState.Press;
        }

        public static bool GetKeyUp(Keys key)
        { 
            return Glfw.GetKey(DisplayManager.window, key)
        }
*/