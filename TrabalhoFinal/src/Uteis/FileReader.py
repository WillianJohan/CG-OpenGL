import os
import glob


sandboxDir = os.path.dirname(os.path.realpath(
    __file__)).replace('\\', '/') + "/Sandbox/"


print(sandboxDir)


os.chdir(sandboxDir)
for file in glob.glob("*.txt"):
    print(file)
