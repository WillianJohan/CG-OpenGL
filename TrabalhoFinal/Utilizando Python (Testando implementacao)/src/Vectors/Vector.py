import math
from abc import ABC, abstractmethod

class IVector(ABC):

    # Getters Methods : ===========
    
    @abstractmethod
    def Zero(self): pass
    
    @abstractmethod
    def Right(self): pass
    
    @abstractmethod
    def Up(self): pass
    
    @abstractmethod
    def Forward(self): pass
    
    @abstractmethod
    def One(self): pass
    
    #==============================




    # Other Methods ===============
    
    @abstractmethod
    def Reset(self): pass

    @abstractmethod
    def Magnetude(self): pass

    @abstractmethod
    def Normalized(self): pass
    
    #===============




    # "Static" Methods : ====================

    @abstractmethod
    def Dot(self, vectorA, vectorB): pass
    
    @abstractmethod
    def Distance(self, VectorA, VectorB): pass

    #========================================




    # Operators =============================

    @abstractmethod
    def __add__(self, other): pass
    @abstractmethod
    def __sub__(self, other): pass
    @abstractmethod
    def __matmul__(self, other): pass
    @abstractmethod
    def __neg__(self):pass

    #========================================



class Vector2(IVector):
    def __init__(self, x: float, y: float):
        self.x = x
        self.y = y

    # Getters Methods : ===========
    
    def Zero(self):
        return Vector2(0,0)
    
    def Right(self):
        return Vector2(1,0)
    
    def Up(self):
        return Vector2(0,1)
    
    def Forward(self):
        return Vector2(0,0)
    
    def One(self):
        return Vector2(1,1)
    
    #==============================



    # Other Methods ===============
    
    def Reset(self):
        self.x = 0
        self.y = 0

    def Magnetude(self):
        magnitude = 0

        magnitude += math.pow(self.x, 2)
        magnitude += math.pow(self.y, 2)
        magnitude =  math.sqrt(magnitude)

        return magnitude

    def Normalized(self):
        magnitude = self.Magnetude()
        
        if(magnitude <= 1.0):
            normalizedVector = Vector2(self.x, self.y) 
        else: 
            normalizedVector = Vector2(self.x / magnitude, self.y / magnitude)

        return normalizedVector
    
    #===============



    # "Static" Methods : ====================

    def Dot(self, vectorA, vectorB):
        a = math.pow(vectorA.x - vectorB.x, 2)
        b = math.pow(vectorA.y - vectorB.y, 2)
        return math.sqrt(a + b)
    
    def Distance(self, VectorA, VectorB):
        return ((VectorA.x * VectorB.x) + (VectorA.y * VectorB.y))

    #========================================
    

    # Operators =============================

    def __add__(self, other):
        if type(other) == Vector2:
            vec = self.Zero()
            
            vec.x = self.x + other.x
            vec.y = self.y + other.y

            return vec
        return NotImplemented

    def __sub__(self, other):
        if type(other) == Vector2:
            vec = self.Zero()      
            vec.x = self.x - other.x
            vec.y = self.y - other.y

            return vec
        return NotImplemented

    def __matmul__(self, other):
        if type(other) == type(self):
            vec = self.Zero()
            
            vec.x = self.x * other.x
            vec.y = self.y * other.y

            return vec
        elif type(other) == float or type(other) == int:
            vec = self.Zero()
            
            vec.x = self.x * other
            vec.y = self.y * other

            return vec
        return NotImplemented
        

    def __neg__(self):
        return Vector2(-self.x, -self.y)

    #========================================



class Vector3(IVector):
    def __init__(self, x: float, y: float, z: float):
        self.x = x
        self.y = y
        self.z = z

    # Getters Methods : ===========
    
    def Zero(self):
        return Vector3(0,0,0)
    
    def Right(self):
        return Vector3(1,0,0)
    
    def Up(self):
        return Vector3(0,1,0)
    
    def Forward(self):
        return Vector3(0,0,1)
    
    def One(self):
        return Vector3(1,1,1)
    
    #==============================



    # Other Methods ===============
    
    def Reset(self):
        self.x = 0
        self.y = 0
        self.z = 0

    def Magnetude(self):
        magnitude = 0

        magnitude += math.pow(self.x, 2)
        magnitude += math.pow(self.y, 2)
        magnitude += math.pow(self.z, 2)
        magnitude =  math.sqrt(magnitude)

        return magnitude

    def Normalized(self):
        magnitude = self.Magnetude()
        
        if(magnitude <= 1.0):
            normalizedVector = Vector3(self.x, self.y, self.z) 
        else: 
            normalizedVector = Vector3(self.x / magnitude, self.y / magnitude, self.z / magnitude)

        return normalizedVector
    
    #===============



    # "Static" Methods : ====================

    def Dot(self, vectorA, vectorB):
        a = math.pow(vectorA.x - vectorB.x, 2)
        b = math.pow(vectorA.y - vectorB.y, 2)
        c = math.pow(vectorA.z - vectorB.z, 2)
        return math.sqrt(a + b + c)
    
    def Distance(self, vectorA, vectorB):
        return ((VectorA.x * VectorB.x) + (VectorA.y * VectorB.y) + (VectorA.z * VectorB.z))

    #========================================
    

    # Operators =============================

    def __add__(self, other):
        if type(other) == Vector3:
            vec = self.Zero()
            
            vec.x = self.x + other.x
            vec.y = self.y + other.y
            vec.z = self.z + other.z

            return vec
        return NotImplemented

    def __sub__(self, other):
        if type(other) == Vector3:
            vec = self.Zero()      
            vec.x = self.x - other.x
            vec.y = self.y - other.y
            vec.z = self.z - other.z

            return vec
        return NotImplemented

    def __matmul__(self, other):
        if type(other) == type(self):
            vec = self.Zero()
            
            vec.x = self.x * other.x
            vec.y = self.y * other.y
            vec.z = self.z * other.z

            return vec
        elif type(other) == float or type(other) == int:
            vec = self.Zero()
            
            vec.x = self.x * other
            vec.y = self.y * other
            vec.z = self.z * other

            return vec
        return NotImplemented
        

    def __neg__(self):
        return Vector3(-self.x, -self.y, -self.z)

    #========================================



class Vector4(IVector):
    def __init__(self, x: float, y: float, z: float, w : float):
        self.x = x
        self.y = y
        self.z = z
        self.w = w

    # Getters Methods : ===========
    
    def Zero(self):
        return Vector4(0,0,0,0)
    
    def Right(self):
        return Vector4(1,0,0,0)
    
    def Up(self):
        return Vector4(0,1,0,0)
    
    def Forward(self):
        return Vector4(0,0,1,0)
    
    def One(self):
        return Vector4(1,1,1,1)
    
    #==============================



    # Other Methods ===============
    
    def Reset(self):
        self.x = 0
        self.y = 0
        self.z = 0
        self.w = 0

    def Magnetude(self):
        magnitude = 0

        magnitude += math.pow(self.x, 2)
        magnitude += math.pow(self.y, 2)
        magnitude += math.pow(self.z, 2)
        magnitude += math.pow(self.w, 2)
        magnitude =  math.sqrt(magnitude)

        return magnitude

    def Normalized(self):
        magnitude = self.Magnetude()
        
        if(magnitude <= 1.0):
            normalizedVector = Vector4(self.x, self.y, self.z, self.w) 
        else: 
            normalizedVector = Vector4(self.x / magnitude, self.y / magnitude, self.z / magnitude, self.w / magnitude)

        return normalizedVector
    
    #===============



    # "Static" Methods : ====================

    def Dot(self, vectorA, vectorB):
        a = math.pow(vectorA.x - vectorB.x, 2)
        b = math.pow(vectorA.y - vectorB.y, 2)
        c = math.pow(vectorA.z - vectorB.z, 2)
        d = math.pow(vectorA.w - vectorB.w, 2)
        return math.sqrt(a + b + c + d)
    
    def Distance(self, vectorA, vectorB):
        return ((VectorA.x * VectorB.x) + (VectorA.y * VectorB.y) + (VectorA.z * VectorB.z) + (VectorA.w * VectorB.w))

    #========================================
    

    # Operators =============================

    def __add__(self, other):
        if type(other) == type(self):
            vec = self.Zero()
            
            vec.x = self.x + other.x
            vec.y = self.y + other.y
            vec.z = self.z + other.z
            vec.w = self.w + other.w

            return vec
        return NotImplemented

    def __sub__(self, other):
        if type(other) == Vector4:
            vec = self.Zero()      
            vec.x = self.x - other.x
            vec.y = self.y - other.y
            vec.z = self.z - other.z
            vec.w = self.w - other.w

            return vec
        return NotImplemented

    def __matmul__(self, other):
        if type(other) == type(self):
            vec = self.Zero()
            
            vec.x = self.x * other.x
            vec.y = self.y * other.y
            vec.z = self.z * other.z
            vec.w = self.w * other.w

            return vec
        elif type(other) == float or type(other) == int:
            vec = self.Zero()
            
            vec.x = self.x * other
            vec.y = self.y * other
            vec.z = self.z * other
            vec.w = self.w * other

            return vec
        return NotImplemented
        

    def __neg__(self):
        return Vector4(-self.x, -self.y, -self.z, -self.w)

    #========================================


